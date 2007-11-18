using System;
using System.Drawing;
using System.Collections;
using System.Windows.Forms;
using SharpMTClasses;
using System.Xml;
using System.Net;
using System.IO;
using System.Threading;
using Microsoft.Win32;
using Pocket_SharpMT._Objects.code;

namespace Phone_SharpMT {
  public partial class Dialog_Main : Form {
    private void setCursors(bool bWait) {
      Cursor cr = (bWait ? Cursors.WaitCursor : Cursors.Default);
      Cursor.Current = cr;

      for (int i = 0; i < Controls.Count; i++) {
        Controls[i].Enabled = !bWait;
      }
    }

    public void UploadFileThreadProc() {
      this.Refresh();
      UploadFileData(m_strLocalFile, m_strRemoteFile);

      // clean up
      m_strLocalFile = "";
      m_strRemoteFile = "";

      // done!
      prepProgress(false);
      Cursor.Current = Cursors.WaitCursor;
      Cursor.Current = Cursors.Default;
    }

    private void UpdatePostThreadProc() {
      // Get the most recent data
      CPostItem objPI = grabUiData();

      // Post the Entry
      bool bRet = postTheEntry(objPI);

      if (bRet) {
        // set the flag
        ckbServerPosted.Checked = true;
        saveClicked();
      }

      // done!
      prepProgress(false);
      Cursor.Current = Cursors.WaitCursor;
      Cursor.Current = Cursors.Default;
    }

    private bool postTheEntry(CPostItem objPI) {
      string strTitle = lblFileTitle.Text;//this.Text;
      this.Refresh();
      string strXml = GetPostData(objPI);

      if (strXml.Length == 0) {
        MessageBox.Show("Error connecting to Blog server!", Dialog_Main.m_strAppName, MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1);
        prepProgress(false);
        //this.Text = strTitle;
        lblFileTitle.Text = strTitle;
        Cursor.Current = Cursors.Default;
        return false;
      }

      XmlDocument xmlDoc = new XmlDocument();
      try {
        xmlDoc.LoadXml(strXml);
      }
      catch {
        MessageBox.Show("Error connecting to host!", m_strAppName, MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1);
        lblFileTitle.Text = strTitle;
        //this.Text = strTitle;
        prepProgress(false);
        Cursor.Current = Cursors.Default;
        return false;
      }

      XmlNode xmlNode = xmlDoc.FirstChild;

      if (xmlNode == null) {
        prepProgress(false);
        lblFileTitle.Text = strTitle;
        //this.Text = strTitle;
        Cursor.Current = Cursors.Default;
        return false;
      }

      if (xmlNode.HasChildNodes == false)
        xmlNode = xmlNode.NextSibling;

      XmlNodeReader xmlReader = new XmlNodeReader(xmlNode);
      string strNewPostId = "";
      while (xmlReader.Read()) {
        if (xmlReader.Name == "string") {
          string strElement = xmlReader.ReadString();
          strNewPostId = strElement;
          break;
        }
      }

      // now set the Category - also allows for NO category
      if (objPI.a_strCategory.Count > 0) {
        this.Refresh();
        string strRet = SetCategoryData(strNewPostId, objPI.a_strCategory);
        if (strRet.Length > 0) {
          //form the rebuild
          this.Refresh();
          SetRebuildMT(strNewPostId);
        }
      }

      lblFileTitle.Text = strTitle;
      return true;
    }

    private string GetPostData(CPostItem objPI) {
      objPI.EncodeHTML();

      // Go get the list of thingies
      string strXml = "";
      string[] a_str = objPI.strPings.Split('\n');

      string strTime = string.Format(m_strDraftsHome + "temp{0}.xml", DateTime.Now.Ticks);
      XmlTextWriter xmlWriter = new XmlTextWriter(strTime, System.Text.Encoding.ASCII);
      xmlWriter.Formatting = Formatting.None;
      xmlWriter.Namespaces = false;
      xmlWriter.WriteStartDocument();
      xmlWriter.WriteStartElement("methodCall");
      xmlWriter.WriteElementString("methodName", "metaWeblog.newPost");
      xmlWriter.WriteStartElement("params");
      writeMTParam(ref xmlWriter, "string", m_strBlogId);
      writeMTParam(ref xmlWriter, "string", m_strUsername);
      writeMTParam(ref xmlWriter, "string", m_strPassword);
      xmlWriter.WriteStartElement("param");
      xmlWriter.WriteStartElement("value");
      xmlWriter.WriteStartElement("struct");
      writeMTMember(ref xmlWriter, "title", "string", objPI.strTitle);
      writeMTMember(ref xmlWriter, "description", "string", objPI.strEntry);
      writeMTMember(ref xmlWriter, "mt_allow_comments", "string", objPI.strAllowComments);
      writeMTMember(ref xmlWriter, "mt_allow_pings", "string", objPI.strAllowPings);
      writeMTMember(ref xmlWriter, "mt_convert_breaks", "string", objPI.strTextFormatting);
      writeMTMember(ref xmlWriter, "mt_text_more", "string", objPI.strExtended);
      writeMTMember(ref xmlWriter, "mt_excerpt", "string", objPI.strExcerpt);
      writeMTMember(ref xmlWriter, "mt_keywords", "string", objPI.strKeyword);
      if (objPI.strDateTime.Length > 0) {
        String str = objPI.strDateTime;
        str = str.Replace("-", "");
        writeMTMember(ref xmlWriter, "dateCreated", "string", str);
      }

      if (a_str.Length > 0) {
        for (int i = 0; i < a_str.Length; i++) {
          if (a_str[i].Length > 0) {
            xmlWriter.WriteStartElement("member");
            xmlWriter.WriteElementString("name", "mt_tb_ping_urls");
            xmlWriter.WriteStartElement("value");
            xmlWriter.WriteStartElement("array");
            xmlWriter.WriteStartElement("data");
            xmlWriter.WriteStartElement("value");
            xmlWriter.WriteElementString("string", a_str[i]);
            xmlWriter.WriteEndElement(); //"value"
            xmlWriter.WriteEndElement(); //"data"
            xmlWriter.WriteEndElement();//"array"
            xmlWriter.WriteEndElement();//"value"
            xmlWriter.WriteEndElement(); //"member"
          }
        }
      }
      xmlWriter.WriteEndElement(); //"struct"
      xmlWriter.WriteEndElement(); //"value"
      xmlWriter.WriteEndElement(); //"param"
      writeMTParam(ref xmlWriter, "boolean", objPI.strPostStatus);
      xmlWriter.WriteEndElement(); //"params"
      xmlWriter.WriteEndElement(); //"methodCall"
      xmlWriter.WriteEndDocument();
      xmlWriter.Close();

      strXml = "";
      using (FileStream fs = new FileStream(strTime, FileMode.Open, FileAccess.Read, FileShare.Read)) {
        byte[] bf = new byte[1024];
        int n = fs.Read(bf, 0, bf.Length);
        System.Text.ASCIIEncoding utf = new System.Text.ASCIIEncoding();
        while (n > 0) {
          strXml += utf.GetString(bf, 0, n);
          n = fs.Read(bf, 0, bf.Length);
        }
        fs.Close();
      }

      File.Delete(strTime);
      return GetWebData(strXml);
    }

    private string SetCategoryData(string strId, ArrayList a_strCat) {
      // Go get the list of thingies
      string strXml;
      string strCats = "";
      for (int i = 0; i < a_strCat.Count; i++) {
        strCats += string.Format("<value><struct><member><name>categoryId</name><value><string>{0}</string></value></member></struct></value>", a_strCat[i]);
      }
      strXml = string.Format("<?xml version=\"1.0\"?><methodCall><methodName>mt.setPostCategories</methodName><params>" +
        "<param><value><string>{0}</string></value></param>" +
        "<param><value><string>{1}</string></value></param>" +
        "<param><value><string>{2}</string></value></param>" +
        "<param><value><array><data>" +
        "{3}" +
        "</data></array></value></param>" +
        "</params></methodCall>", strId, m_strUsername, m_strPassword, strCats);

      return GetWebData(strXml);
    }

    private string SetRebuildMT(string strId) {
      // Go get the list of thingies
      string strXml;
      strXml = string.Format("<?xml version=\"1.0\"?><methodCall><methodName>mt.publishPost</methodName><params>" +
        "<param><value><string>{0}</string></value></param>" +
        "<param><value><string>{1}</string></value></param>" +
        "<param><value><string>{2}</string></value></param>" +
        "</params></methodCall>", strId, m_strUsername, m_strPassword);

      return GetWebData(strXml);
    }

    private void UpdateTextFilters() {
      setCursors(true);
      prepProgress(true);

      UpdateTextFiltersThreadProc();
    }

    private void UpdateTextFiltersThreadProc() {
      string strXml = GetTextFilterData("mt.supportedTextFilters");

      if (strXml.Length == 0) {
        MessageBox.Show("Error connecting to Blog server!", Dialog_Main.m_strAppName, MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1);
        prepProgress(false);
        return;
      }
      XmlDocument xmlDoc = new XmlDocument();
      try {
        xmlDoc.LoadXml(strXml);
      }
      catch {
        MessageBox.Show("Error connecting to host!", m_strAppName, MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1);
        prepProgress(false);
        return;
      }

      XmlNode xmlNode = xmlDoc.FirstChild;

      if (xmlNode == null) {
        prepProgress(false);
        return;
      }

      if (xmlNode.HasChildNodes == false)
        xmlNode = xmlNode.NextSibling;

      XmlNodeReader xmlReader = new XmlNodeReader(xmlNode);
      ma_objTextFilters.Clear();
      CCatItem objTI = new CCatItem();
      string strValueName = "";
      bool bStartTag = true;
      string strEndTag = "struct";
      while (xmlReader.Read()) {
        if (xmlReader.Name == "name") {
          string strElement = xmlReader.ReadString();
          switch (strElement) {
            case "key": // key
            case "label": // label
              strValueName = strElement;
              break;
            default:
              strValueName = "";
              break;
          }
        }
        else if (xmlReader.Name == "string") {
          string strElement = xmlReader.ReadString();
          switch (strValueName) {
            case "key": // key
              objTI.strId = strElement;
              break;
            case "label": // label
              objTI.strName = strElement;
              break;
          }
        }
        else if (xmlReader.Name == strEndTag) {
          if (bStartTag) {
            objTI = new CCatItem();
            bStartTag = false;
          }
          else {
            ma_objTextFilters.Add(objTI);
            bStartTag = true;
          }
        }
      }

      // Pop through the Array and update the list
      int nPos = cbFormatting.SelectedIndex;
      cbFormatting.Items.Clear();
      cbFormatting.Items.Add("None");
      for (int nField = 0; nField < ma_objTextFilters.Count; nField++) {
        objTI = (CCatItem)ma_objTextFilters[nField];
        cbFormatting.Items.Add(objTI.strName);
      }
      if (nPos >= ma_objTextFilters.Count) {
        nPos = 0;
      }
      cbFormatting.SelectedIndex = nPos;

      //SaveDataFiles();

      prepProgress(false);
    }

    private void UpdateCategories() {
      setCursors(true);
      prepProgress(true);

      UpdateCategoriesThreadProc();
    }

    private void UpdateCategoriesThreadProc() {
      string strXml = GetOtherData("mt.getCategoryList");

      if (strXml.Length == 0) {
        MessageBox.Show("Error connecting to Blog server!", Dialog_Main.m_strAppName, MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1);
        prepProgress(false);
        return;
      }
      XmlDocument xmlDoc = new XmlDocument();
      try {
        xmlDoc.LoadXml(strXml);
      }
      catch {
        MessageBox.Show("Error connecting to host!", m_strAppName, MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1);
        prepProgress(false);
        return;
      }

      XmlNode xmlNode = xmlDoc.FirstChild;

      if (xmlNode == null) {
        prepProgress(false);
        return;
      }

      if (xmlNode.HasChildNodes == false)
        xmlNode = xmlNode.NextSibling;

      XmlNodeReader xmlReader = new XmlNodeReader(xmlNode);
      ma_objCategories.Clear();
      CCatItem objCI = new CCatItem();
      string strValueName = "";
      bool bStartTag = true;
      string strEndTag = "struct";
      while (xmlReader.Read()) {
        if (xmlReader.Name == "name") {
          string strElement = xmlReader.ReadString();
          switch (strElement) {
            case "categoryId": // categoryId
            case "categoryName": // categoryName
              strValueName = strElement;
              break;
            default:
              strValueName = "";
              break;
          }
        }
        else if (xmlReader.Name == "string") {
          string strElement = xmlReader.ReadString();
          switch (strValueName) {
            case "categoryId": // categoryId
              objCI.strId = strElement;
              break;
            case "categoryName": // categoryName
              objCI.strName = strElement;
              break;
          }
        }
        else if (xmlReader.Name == strEndTag) {
          if (bStartTag) {
            objCI = new CCatItem();
            bStartTag = false;
          }
          else {
            ma_objCategories.Add(objCI);
            bStartTag = true;
          }
        }
      }

      // Sort the array
      IComparer sortList = new sortObjects();
      ma_objCategories.Sort(sortList);

      // Pop through the Array and update the list
      int nPos = cbCategories.SelectedIndex;
      cbCategories.Items.Clear();
      cbCategories.Items.Add("(none)");
      for (int nField = 0; nField < ma_objCategories.Count; nField++) {
        objCI = (CCatItem)ma_objCategories[nField];
        cbCategories.Items.Add(objCI.strName);
      }
      if (nPos >= ma_objCategories.Count) {
        nPos = 0;
      }

      cbCategories.SelectedIndex = nPos;

      // Set the CatButton
      if (cbCategories.Items.Count > 2)
        btnCategories.Enabled = true;
      else
        btnCategories.Enabled = false;

      //SaveDataFiles();

      prepProgress(false);

    }

    private string GetSinglePostData() {
      // only get the latest post to check to see whats there
      string strXml;
      strXml = string.Format("<?xml version=\"1.0\"?><methodCall><methodName>mt.getRecentPostTitles</methodName><params>" +
        "<param><value><string>{0}</string></value></param>" +
        "<param><value><string>{1}</string></value></param>" +
        "<param><value><string>{2}</string></value></param>" +
        "<param><value><string>{3}</string></value></param>" +
        "</params></methodCall>", m_strBlogId, m_strUsername, m_strPassword, "1");
      return GetWebData(strXml);
    }

    private string GetTextFilterData(string strCommand) {
      // any other command
      string strXml;
      strXml = string.Format("<?xml version=\"1.0\"?><methodCall><methodName>{0}</methodName>" +
        "</methodCall>", strCommand);
      return GetWebData(strXml);
    }

    private string GetOtherData(string strCommand) {
      // any other command
      string strXml;
      strXml = string.Format("<?xml version=\"1.0\"?><methodCall><methodName>{0}</methodName><params>" +
        "<param><value><string>{1}</string></value></param>" +
        "<param><value><string>{2}</string></value></param>" +
        "<param><value><string>{3}</string></value></param>" +
        "</params></methodCall>", strCommand, m_strBlogId, m_strUsername, m_strPassword);
      return GetWebData(strXml);
    }

    private string GetWebData(string strCommand) {
      string str = string.Format("http://{0}{1}", m_strHostname, m_strCgiPath);
      string strXml = strCommand;
      byte[] bytes = null;
      bytes = System.Text.Encoding.UTF8.GetBytes(strXml);

      HttpWebRequest wbRequest = (HttpWebRequest)WebRequest.Create(str);
      //if (m_netProxy == null)
      //  wbRequest.Proxy = GlobalProxySelection.GetEmptyWebProxy();
      //else
      //  wbRequest.Proxy = m_netProxy;

      if (m_netProxy != null)
        wbRequest.Proxy = m_netProxy;
      wbRequest.UserAgent = Dialog_Main.m_strUserAgent;
      wbRequest.Method = "POST";
      wbRequest.ContentType = "text/xml";
      wbRequest.ContentLength = bytes.Length;
      try {
        Stream stmOut = wbRequest.GetRequestStream();
        stmOut.Write(bytes, 0, bytes.Length);
        stmOut.Close();
      }
      catch {
        MessageBox.Show("Error connecting to host!", m_strAppName, MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1);
        prepProgress(false);
        Cursor.Current = Cursors.Default;
        return "";
      }

      WebResponse wbResponse = null;
      try {
        wbResponse = wbRequest.GetResponse();
      }
      catch (WebException we) {
        MessageBox.Show(we.Message, Dialog_Main.m_strAppName, MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1);
        prepProgress(false);
        Cursor.Current = Cursors.Default;
        return "";
      }

      // Get the response stream.
      Stream stmRead = wbResponse.GetResponseStream();
      StreamReader stmReader = new StreamReader(stmRead, System.Text.Encoding.ASCII);
      strXml = stmReader.ReadToEnd();
      stmRead.Close();
      wbResponse.Close();
      return strXml;
    }

    private string UploadFileData(string strAbsoluteFile, string strFileName) {
      // Go get the list of thingies
      string strXml = "";

      string strTime = string.Format(m_strDraftsHome + "temp{0}.xml", DateTime.Now.Ticks);
      XmlTextWriter xmlWriter = new XmlTextWriter(strTime, System.Text.Encoding.ASCII);
      xmlWriter.Formatting = Formatting.None;
      xmlWriter.Namespaces = false;
      xmlWriter.WriteStartDocument();
      xmlWriter.WriteStartElement("methodCall");
      xmlWriter.WriteElementString("methodName", "metaWeblog.newMediaObject");
      xmlWriter.WriteStartElement("params");
      writeMTParam(ref xmlWriter, "string", m_strBlogId);
      writeMTParam(ref xmlWriter, "string", m_strUsername);
      writeMTParam(ref xmlWriter, "string", m_strPassword);
      xmlWriter.WriteStartElement("param");
      xmlWriter.WriteStartElement("value");
      xmlWriter.WriteStartElement("struct");
      writeMTMember(ref xmlWriter, "bits", "base64", "");

      xmlWriter.WriteStartElement("member");
      xmlWriter.WriteElementString("name", "bits");
      xmlWriter.WriteStartElement("value");
      xmlWriter.WriteStartElement("base64");

      FileStream fsImage = null;
      try {
        fsImage = new FileStream(strAbsoluteFile, FileMode.Open, FileAccess.Read, FileShare.Read);
      }
      catch {
        MessageBox.Show("The selected image could not be found!", m_strAppName, MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1);
        return "";
      }
      BinaryReader br = new BinaryReader(fsImage);
      byte[] bfImage = new byte[1024];
      int nRead = 0;
      try {
        do {
          nRead = br.Read(bfImage, 0, bfImage.Length);
          xmlWriter.WriteBase64(bfImage, 0, nRead);
        } while (bfImage.Length <= nRead);
      }
      catch (Exception ex) {
        EndOfStreamException ex1 = new EndOfStreamException();

        if (ex1.Equals(ex)) {
          Console.WriteLine("We are at end of file");
        }
        else {
          Console.WriteLine(ex);
        }
      }

      xmlWriter.WriteEndElement(); //"base64"
      xmlWriter.WriteEndElement(); //"value"
      xmlWriter.WriteEndElement(); //"member"

      writeMTMember(ref xmlWriter, "name", "string", strFileName);
      xmlWriter.WriteEndElement(); //"struct"
      xmlWriter.WriteEndElement(); //"value"
      xmlWriter.WriteEndElement(); //"param"
      xmlWriter.WriteEndElement(); //"params"
      xmlWriter.WriteEndElement(); //"methodCall"
      xmlWriter.WriteEndDocument();
      xmlWriter.Close();

      strXml = "";
      using (FileStream fs = new FileStream(strTime, FileMode.Open, FileAccess.Read, FileShare.Read)) {
        byte[] bf = new byte[1024];
        int n = fs.Read(bf, 0, bf.Length);
        System.Text.ASCIIEncoding utf = new System.Text.ASCIIEncoding();
        while (n > 0) {
          strXml += utf.GetString(bf, 0, n);
          n = fs.Read(bf, 0, bf.Length);
        }
        fs.Close();
      }

      File.Delete(strTime);
      return GetWebData(strXml);
    }

    private void writeMTMember(ref XmlTextWriter xmlWriter, string strField, string strType, string strName) {
      xmlWriter.WriteStartElement("member");
      xmlWriter.WriteElementString("name", strField);
      xmlWriter.WriteStartElement("value");
      xmlWriter.WriteElementString(strType, strName);
      xmlWriter.WriteEndElement(); //"value"
      xmlWriter.WriteEndElement(); //"member"
    }

    private void writeMTParam(ref XmlTextWriter xmlWriter, string strType, string strName) {
      xmlWriter.WriteStartElement("param");
      xmlWriter.WriteStartElement("value");
      xmlWriter.WriteElementString(strType, strName);
      xmlWriter.WriteEndElement(); //"value"
      xmlWriter.WriteEndElement(); //"param"
    }

    private void prepProgress(bool bState) {
      if (bState) {
      }
      else {
        setCursors(false);
      }
    }

    private void LoadRegistrySettings() {
      RegistryKey regKey = Registry.CurrentUser.OpenSubKey(m_strRegKey);
      int nCat = 0, nStatus = 0, nFormatting = 0, nComment = 0;

      if (regKey != null) {
        // Load DropDown settings
        nCat = 0;
        nStatus = Int32.Parse((string)regKey.GetValue("CurStatus", "0"));
        nFormatting = Int32.Parse((string)regKey.GetValue("CurFormatting", "0"));
        nComment = Int32.Parse((string)regKey.GetValue("CurComment", "0"));
        int n = 0;
        n = Int32.Parse((string)regKey.GetValue("CurPing", "0"));
        if (n == 1)
          ckbAllowPings.Checked = true;

        n = 1;
        n = Int32.Parse((string)regKey.GetValue("CurTime", "1"));
        if (n == 0)
          ckbServer.Checked = false;

        n = Int32.Parse((string)regKey.GetValue("ShowSIP", "1"));
        if (n == 0)
          m_bShowSIP = false;

        n = Int32.Parse((string)regKey.GetValue("ShowExit", "1"));
        if (n == 0)
          m_bShowExit = false;

        n = 0;
        n = Int32.Parse((string)regKey.GetValue("UseProxy", "0"));
        if (n == 1)
          m_bUseProxy = true;

        n = 0;
        n = Int32.Parse((string)regKey.GetValue("UseProxyAuthentication", "0"));
        if (n == 1)
          m_bProxyAuthentication = true;

        // Proxy stuff
        m_strProxyUrl = (string)regKey.GetValue("ProxyUrl", "");
        m_strProxyUserName = (string)regKey.GetValue("ProxyUserName", "");
        m_strProxyPassword = (string)regKey.GetValue("ProxyPassport", "");
        m_nProxyPort = Int32.Parse((string)regKey.GetValue("ProxyPort", "80"));

        // Tags
        m_strBold = (string)regKey.GetValue("BoldTag", "b");
        m_strItalics = (string)regKey.GetValue("ItalicTag", "i");
        m_strUnderline = (string)regKey.GetValue("UnderlineTag", "u");
        m_strImage = (string)regKey.GetValue("ImageTag", "<img src=\"[IMAGELINK]\">");

        // Site info
        m_strBlogId = (string)regKey.GetValue("BlogId", "-1");
        m_strUsername = (string)regKey.GetValue("UserName", "");
        m_strPassword = (string)regKey.GetValue("Password", "");
        m_strHostname = (string)regKey.GetValue("HostName", "www.hostname.com");
        if (m_strHostname.IndexOf("typepad.com") > -1)
          m_nBlogMode = BlogEngine.TypePad;
        else
          m_nBlogMode = BlogEngine.MovableType;
        m_strCgiPath = (string)regKey.GetValue("CgiPath", "/cgipath/mt-xmlrpc.cgi");
        m_nSelBlog = Int32.Parse((string)regKey.GetValue("SelBlog", "0"));

        m_strCustomOne = (string)regKey.GetValue("CustomOne", "strike");
        m_strCustomTwo = (string)regKey.GetValue("CustomTwo", "p");

        n = Int32.Parse((string)regKey.GetValue("CloseCustomOne", "1"));
        if (n == 1)
          m_bCloseCustomOne = true;
        n = Int32.Parse((string)regKey.GetValue("CloseCustomTwo", "0"));
        if (n == 1)
          m_bCloseCustomTwo = true;

        // insert url after upload
        n = Int32.Parse((string)regKey.GetValue("InsertImageUrl", "1"));
        if (n == 0)
          m_bInsertImageUrl = false;

        m_strUrlPrefix = (string)regKey.GetValue("UrlPrefix", "http://");

        m_strUploadPath = (string)regKey.GetValue("UploadPath", "");
        m_strDefaultTarget = (string)regKey.GetValue("DefaultTarget", "");

#if Smartphone
        m_strDraftsHome = (string)regKey.GetValue("DraftHome", Environment.GetFolderPath(Environment.SpecialFolder.Personal) + @"\My Drafts");
#endif

        // read in the Blog Lists
        RegistryKey regSubKey = Registry.CurrentUser.OpenSubKey(m_strRegKey + "\\BlogList");
        if (regSubKey != null) {
          int nCount = regSubKey.ValueCount / 2;
          for (int i = 0; i < nCount; i++) {
            string strId = (string)regSubKey.GetValue(String.Format("Id{0}", i));
            string strName = (string)regSubKey.GetValue(String.Format("Name{0}", i));
            string strUrl = (string)regSubKey.GetValue(String.Format("Url{0}", i), "");
            if ((strId != null) && (strName != null)) {
              CBlogItem objBI = new CBlogItem();
              objBI.strId = strId;
              objBI.strName = strName;
              objBI.strUrl = strUrl;
              ma_objBlogs.Add(objBI);
            }
          }
          regSubKey.Close();
        }

        regSubKey = Registry.CurrentUser.OpenSubKey(m_strRegKey + "\\CategoryList");
        if (regSubKey != null) {
          int nCount = regSubKey.ValueCount / 2;
          for (int i = 0; i < nCount; i++) {
            string strId = (string)regSubKey.GetValue(String.Format("Id{0}", i));
            string strName = (string)regSubKey.GetValue(String.Format("Name{0}", i));
            if ((strId != null) && (strName != null)) {
              CCatItem objCI = new CCatItem();
              objCI.strId = strId;
              objCI.strName = strName;
              ma_objCategories.Add(objCI);
              cbCategories.Items.Add(strName);
            }
          }
          regSubKey.Close();
        }

        regSubKey = Registry.CurrentUser.OpenSubKey(m_strRegKey + "\\TextFilterList");
        if (regSubKey != null) {
          int nCount = regSubKey.ValueCount / 2;
          for (int i = 0; i < nCount; i++) {
            string strId = (string)regSubKey.GetValue(String.Format("Id{0}", i));
            string strName = (string)regSubKey.GetValue(String.Format("Name{0}", i));
            if ((strId != null) && (strName != null)) {
              CCatItem objTI = new CCatItem();
              objTI.strId = strId;
              objTI.strName = strName;
              ma_objTextFilters.Add(objTI);
              cbFormatting.Items.Add(strName);
            }
          }
          regSubKey.Close();
        }
        regKey.Close();
      }

      // Set the DropDown controls
      cbCategories.SelectedIndex = nCat;
      cbStatus.SelectedIndex = nStatus;
      if (nFormatting >= cbFormatting.Items.Count)
        nFormatting = 0;
      cbFormatting.SelectedIndex = nFormatting;
      cbComment.SelectedIndex = nComment;

      // Update object
      m_advDefaults.nStatus = nStatus;
      m_advDefaults.nFormat = nFormatting;
      m_advDefaults.nComments = nComment;
      m_advDefaults.bAllowPings = ckbAllowPings.Checked;
      m_advDefaults.bUseServerTime = ckbServer.Checked;

      // Set the CatButton
      if (cbCategories.Items.Count > 2)
        btnCategories.Enabled = true;
      else
        btnCategories.Enabled = false;
    }

    private void SaveRegistrySettings() {
      RegistryKey regKey = Registry.CurrentUser.CreateSubKey(m_strRegKey);

      regKey.SetValue("CurStatus", string.Format("{0}", m_advDefaults.nStatus));
      regKey.SetValue("CurFormatting", string.Format("{0}", m_advDefaults.nFormat));
      regKey.SetValue("CurComment", string.Format("{0}", m_advDefaults.nComments));
      int n = 0;
      if (m_advDefaults.bAllowPings)
        n = 1;
      regKey.SetValue("CurPing", string.Format("{0}", n));

      n = 0;
      if (m_advDefaults.bUseServerTime)
        n = 1;
      regKey.SetValue("CurTime", string.Format("{0}", n));

      n = 0;
      if (m_bShowSIP)
        n = 1;
      regKey.SetValue("ShowSIP", string.Format("{0}", n));

      n = 0;
      if (m_bShowExit)
        n = 1;
      regKey.SetValue("ShowExit", string.Format("{0}", n));

      // Save Proxy flag
      n = 0;
      if (m_bUseProxy == true)
        n = 1;
      regKey.SetValue("UseProxy", string.Format("{0}", n));

      n = 0;
      if (m_bProxyAuthentication == true)
        n = 1;
      regKey.SetValue("UseProxyAuthentication", string.Format("{0}", n));

      // Proxy stuff
      regKey.SetValue("ProxyUrl", m_strProxyUrl);
      regKey.SetValue("ProxyUserName", m_strProxyUserName);
      regKey.SetValue("ProxyPassport", m_strProxyPassword);
      regKey.SetValue("ProxyPort", string.Format("{0}", m_nProxyPort));

      // Tags
      regKey.SetValue("BoldTag", m_strBold);
      regKey.SetValue("ItalicTag", m_strItalics);
      regKey.SetValue("UnderlineTag", m_strUnderline);
      regKey.SetValue("ImageTag", m_strImage);
      regKey.SetValue("CustomOne", m_strCustomOne);
      regKey.SetValue("CustomTwo", m_strCustomTwo);
      n = 0;
      if (m_bCloseCustomOne)
        n = 1;
      regKey.SetValue("CloseCustomOne", string.Format("{0}", n));
      n = 0;
      if (m_bCloseCustomTwo)
        n = 1;
      regKey.SetValue("CloseCustomTwo", string.Format("{0}", n));

      regKey.SetValue("BlogId", m_strBlogId);
      regKey.SetValue("UserName", m_strUsername);
      regKey.SetValue("Password", m_strPassword);
      regKey.SetValue("HostName", m_strHostname);
      regKey.SetValue("CgiPath", m_strCgiPath);
      regKey.SetValue("SelBlog", string.Format("{0}", m_nSelBlog));

      regKey.SetValue("UrlPrefix", m_strUrlPrefix);
      regKey.SetValue("UploadPath", m_strUploadPath);
      regKey.SetValue("DefaultTarget", m_strDefaultTarget);

#if Smartphone
      regKey.SetValue("DraftHome", m_strDraftsHome);
#endif

      // Save insert image flag
      n = 0;
      if (m_bInsertImageUrl == true)
        n = 1;
      regKey.SetValue("InsertImageUrl", string.Format("{0}", n));

      // set the BlogLists
      RegistryKey regSubKey = Registry.CurrentUser.OpenSubKey(m_strRegKey + "\\BlogList", true);
      // remove if it existed
      if (regSubKey != null) {
        regSubKey.Close();
        regKey.DeleteSubKey("BlogList");
      }
      // create new
      regSubKey = Registry.CurrentUser.CreateSubKey(m_strRegKey + "\\BlogList");
      for (int i = 0; i < ma_objBlogs.Count; i++) {
        CBlogItem objBI = (CBlogItem)ma_objBlogs[i];
        regSubKey.SetValue(String.Format("Id{0}", i), objBI.strId);
        regSubKey.SetValue(String.Format("Name{0}", i), objBI.strName);
        regSubKey.SetValue(String.Format("Url{0}", i), objBI.strUrl);
      }
      regSubKey.Close();

      // set the CategoriesLists
      regSubKey = Registry.CurrentUser.OpenSubKey(m_strRegKey + "\\CategoryList", true);
      // remove if it existed
      if (regSubKey != null) {
        regSubKey.Close();
        regKey.DeleteSubKey("CategoryList");
      }
      // create new
      regSubKey = Registry.CurrentUser.CreateSubKey(m_strRegKey + "\\CategoryList");
      for (int i = 0; i < ma_objCategories.Count; i++) {
        CCatItem objCI = (CCatItem)ma_objCategories[i];
        regSubKey.SetValue(String.Format("Id{0}", i), objCI.strId);
        regSubKey.SetValue(String.Format("Name{0}", i), objCI.strName);
      }
      regSubKey.Close();

      // set the TextFilterLists
      regSubKey = Registry.CurrentUser.OpenSubKey(m_strRegKey + "\\TextFilterList", true);
      // remove if it existed
      if (regSubKey != null) {
        regSubKey.Close();
        regKey.DeleteSubKey("TextFilterList");
      }
      // create new
      regSubKey = Registry.CurrentUser.CreateSubKey(m_strRegKey + "\\TextFilterList");
      for (int i = 0; i < ma_objTextFilters.Count; i++) {
        CCatItem objTI = (CCatItem)ma_objTextFilters[i];
        regSubKey.SetValue(String.Format("Id{0}", i), objTI.strId);
        regSubKey.SetValue(String.Format("Name{0}", i), objTI.strName);
      }
      regSubKey.Close();

      regKey.Close();
    }

    private void saveFile(string strFileName) {
      CPostItem objPI = new CPostItem();
      grabUiData(objPI);

      // save the DraftsList
      XmlTextWriter xmlWriter = new XmlTextWriter(strFileName, System.Text.Encoding.UTF8);
      xmlWriter.Formatting = Formatting.Indented;
      xmlWriter.Namespaces = false;
      xmlWriter.WriteStartDocument();
      xmlWriter.WriteStartElement("blogDrafts");

      xmlWriter.WriteStartElement("draftItem");
      // extra tag is required by a bug in the XML parse of .NET 1.1!
      xmlWriter.WriteElementString("name", objPI.strAllowComments);
      xmlWriter.WriteElementString("comments", objPI.strAllowComments);
      xmlWriter.WriteElementString("ping", objPI.strAllowPings);
      for (int n = 0; n < objPI.a_strCategory.Count; n++)
        xmlWriter.WriteElementString("category", (string)objPI.a_strCategory[n]);
      xmlWriter.WriteElementString("entry", objPI.strEntry);
      xmlWriter.WriteElementString("excerpt", objPI.strExcerpt);
      xmlWriter.WriteElementString("extended", objPI.strExtended);
      xmlWriter.WriteElementString("post", objPI.strPostStatus);
      xmlWriter.WriteElementString("formatting", objPI.strTextFormatting);
      xmlWriter.WriteElementString("keywords", objPI.strKeyword);
      xmlWriter.WriteElementString("pings", objPI.strPings);
      if (objPI.bPosted)
        xmlWriter.WriteElementString("status", "1");
      else
        xmlWriter.WriteElementString("status", "0");
      xmlWriter.WriteElementString("datetime", objPI.strDateTime);
      xmlWriter.WriteElementString("title", objPI.strTitle);
      xmlWriter.WriteEndElement();

      xmlWriter.WriteEndElement();
      xmlWriter.WriteEndDocument();
      xmlWriter.Close();
    }

    private string makeFileNameSave(string strFileName) {
      string strRet = strFileName.Replace("\\", "_");
      strRet = strRet.Replace("/", "_");
      strRet = strRet.Replace(":", "_");
      strRet = strRet.Replace("*", "_");
      strRet = strRet.Replace("?", "_");
      strRet = strRet.Replace("\"", "_");
      strRet = strRet.Replace("<", "_");
      strRet = strRet.Replace(">", "_");
      strRet = strRet.Replace("|", "_");
      return strRet;
    }

    private CPostItem grabUiData() {
      CPostItem objPI = new CPostItem();
      return (grabUiData(objPI));
    }
    private CPostItem grabUiData(CPostItem objPI) {
      // get the Draft data from the UI
      objPI.strAllowComments = Convert.ToString(cbComment.SelectedIndex, 10); // 0 = None, 1 = Open, 2 = Closed
      objPI.strAllowPings = (ckbAllowPings.Checked ? "1" : "0"); // 0 = unchecked, 1 = checked
      objPI.a_strCategory.Clear();

      if (cbCategories.SelectedIndex > 0) {
        // get the primary
        objPI.a_strCategory.Add(((CCatItem)ma_objCategories[cbCategories.SelectedIndex - 1]).strId); // get the Category ID

        // get the rest of the ID's
        for (int i = 0; i < ma_strSelectCat.Count; i++) {
          objPI.a_strCategory.Add(ma_strSelectCat[i]);
        }
      }
      objPI.strPostStatus = Convert.ToString(cbStatus.SelectedIndex); // 0(1) = Draft, 1(2) = Publish
      objPI.strTextFormatting = Convert.ToString(cbFormatting.SelectedIndex); // 0 = None, 1 = __default__
      if (cbFormatting.SelectedIndex != 0)
        objPI.strTextFormatting = ((CCatItem)this.ma_objTextFilters[cbFormatting.SelectedIndex - 1]).strId;//"__default__";
      objPI.strEntry = ebEntry.Text;
      objPI.strExcerpt = ebExcerpt.Text;
      objPI.strExtended = ebExtended.Text;
      objPI.strKeyword = ebKeywords.Text;
      objPI.strPings = ebPings.Text;
      if (ckbServer.Checked == true) {
        objPI.strDateTime = "";
      }
      else {
        String stringMonth, stringDay, stringHour, stringMinute, stringSecond;
        stringMonth = PadZero(dtDate.Value.Month);
        stringDay = PadZero(dtDate.Value.Day);
        stringHour = PadZero(dtTime.Value.Hour);
        stringMinute = PadZero(dtTime.Value.Minute);
        stringSecond = PadZero(dtTime.Value.Second);
        objPI.strDateTime = string.Format("{0}-{1}-{2}T{3}:{4}:{5}", dtDate.Value.Year, stringMonth, stringDay, stringHour, stringMinute, stringSecond);
      }
      objPI.bPosted = ckbServerPosted.Checked;
      objPI.strTitle = ebTitle.Text;

      return objPI;
    }

    private String PadZero(int value) {
      string str = string.Format("{0}", value);
      if (str.Length < 2)
        str = "0" + str;
      return str;
    }

    private void pushUiData(CPostItem objPI) {
      // pust the Draft data into the UI
      if (objPI.strAllowComments.Length == 0) {
        cbComment.SelectedIndex = m_advDefaults.nComments;
      }
      else {
        cbComment.SelectedIndex = Convert.ToInt32(objPI.strAllowComments, 10); // 0 = None, 1 = Open, 2 = Closed
      }
      ckbAllowPings.Checked = ((objPI.strAllowPings == "1") ? true : false);// 0 = unchecked, 1 = checked
      string strPrimary = "";
      if (objPI.a_strCategory.Count == 0) {
        ma_strSelectCat.Clear();
      }
      else {
        for (int i = 0; i < objPI.a_strCategory.Count; i++) {
          // gets the list of assigned categories
          for (int n = 0; n < ma_objCategories.Count; n++) {// set the Category ID
            if (((CCatItem)ma_objCategories[n]).strId == (string)objPI.a_strCategory[i]) {
              ma_strSelectCat.Add(((CCatItem)ma_objCategories[n]).strId);
              if (i == 0) strPrimary = ((CCatItem)ma_objCategories[n]).strName;
              break;
            }
          }
        }
      }

      if (ma_strSelectCat.Count <= 0) {
        cbCategories.SelectedIndex = 0;
      }
      else {
        // always set the primary
        int n = cbCategories.Items.IndexOf(strPrimary);
        if (n > -1)
          cbCategories.SelectedIndex = n;
        else
          cbCategories.SelectedIndex = 0;
      }

      // remove it from the array to prevent overlapping
      if (ma_strSelectCat.Count >= 1) {
        ma_strSelectCat.RemoveAt(0);
      }

      cbStatus.SelectedIndex = Convert.ToInt32(objPI.strPostStatus); // 0 (1) = Draft, 1(2) = Publish
      if (objPI.strTextFormatting == "0") // 0 = None, 1 = __default__
        cbFormatting.SelectedIndex = 0;
      else {
        for (int i = 0; i < ma_objTextFilters.Count; i++) {
          CCatItem objTI = ((CCatItem)ma_objTextFilters[i]);
          if (objPI.strTextFormatting == objTI.strId) {
            cbFormatting.SelectedIndex = i + 1;
            break;
          }
        }
      }

      ebEntry.Text = objPI.strEntry;
      ebExcerpt.Text = objPI.strExcerpt;
      ebExtended.Text = objPI.strExtended;
      ebKeywords.Text = objPI.strKeyword;
      ebPings.Text = objPI.strPings;

      if (objPI.strDateTime == "") {
        ckbServer.Checked = true;
      }
      else {
        ckbServer.Checked = false;
        DateTime dt = DateTime.Parse(objPI.strDateTime);
        dtDate.Value = dt;
        dtTime.Value = dt;
      }
      ckbServerPosted.Checked = objPI.bPosted;
      ebTitle.Text = objPI.strTitle;
    }

    private void makeDirty() {
      if (m_bLoading) {
        return;
      }

      mniSave.Enabled = true;
      tbbSave.Enabled = true;

      string strTitle = lblFileTitle.Text;//this.Text;
      if (strTitle.IndexOf("*") == -1)
        lblFileTitle.Text += "*";

      if (m_strBlogId == "-1") {
        mniPost.Enabled = false;
      }
      else {
        mniPost.Enabled = true;
      }

      updateTextBoxMenuToolbar(false, false);
    }

    private void openFile(string strFileName) {
      XmlTextReader xmlReader = null;
      CPostItem objPI = null; ;
      try {
        xmlReader = new XmlTextReader(strFileName);
        xmlReader.WhitespaceHandling = WhitespaceHandling.None;
        objPI = new CPostItem();
        bool bRun = true;
        while ((xmlReader.Read()) && (bRun)) {
          string strElement = xmlReader.ReadString();
          switch (xmlReader.Name) {
            case "comments": //linkID
              if (strElement.Length == 0)
                strElement = string.Format("{0}", this.m_advDefaults.nComments);
              objPI.strAllowComments = strElement;
              break;
            case "ping": // ping
              objPI.strAllowPings = strElement;
              break;
            case "category": //category
              objPI.a_strCategory.Add(strElement);
              break;
            case "entry": //Entry
              objPI.strEntry = strElement;
              break;
            case "excerpt": //Excerpt
              objPI.strExcerpt = strElement;
              break;
            case "extended": //Extended
              objPI.strExtended = strElement;
              break;
            case "post": // Post
              objPI.strPostStatus = strElement;
              break;
            case "formatting": // textFormatting
              objPI.strTextFormatting = strElement;
              break;
            case "keywords": // Keywords
              objPI.strKeyword = strElement;
              break;
            case "pings": // Pings
              objPI.strPings = strElement;
              break;
            case "status":
              if (strElement == "1")
                objPI.bPosted = true;
              else
                objPI.bPosted = false;
              break;
            case "datetime":
              objPI.strDateTime = strElement;
              break;
            case "title": //Title
              objPI.strTitle = strElement;
              bRun = false;
              break;
          }
        }
      }
      catch {
      }
      finally {
        if (xmlReader != null)
          xmlReader.Close();
      }

      if (objPI == null) {
        MessageBox.Show("Error loading draft!", m_strAppName, MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1);
      }
      else {
        pushUiData(objPI);
      }

      lblLocalName.Text = strFileName;
      strFileName = strFileName.Substring(strFileName.LastIndexOf("\\") + 1);
      //Removed to make certification happy!
      lblFileTitle.Text = strFileName;

      // turn off save because nothing has changed yet
      mniSave.Enabled = false;
      tbbSave.Enabled = false;
    }

    private void newClicked() {
      if (dirtyCheck() == false)
        return;

      m_bLoading = true;

      // on get here to start new
      ebTitle.Text = "";
      ebEntry.Text = "";
      ebExtended.Text = "";
      ebExcerpt.Text = "";
      ebKeywords.Text = "";
      ebPings.Text = "";
      ckbServer.Checked = true;

      cbStatus.SelectedIndex = m_advDefaults.nStatus;
      cbComment.SelectedIndex = m_advDefaults.nComments;
      cbFormatting.SelectedIndex = m_advDefaults.nFormat;
      ckbAllowPings.Checked = m_advDefaults.bAllowPings;
      ckbServer.Checked = m_advDefaults.bUseServerTime;

      ckbServerPosted.Checked = false;
      lblLocalName.Text = "";

      // reset post b/c it's a new form
      mniPost.Enabled = false;
      cbCategories.SelectedIndex = 0;
      ma_strSelectCat.Clear();

      // now that everything else is clear, do this last one to rest the toolbar/menu
      mniSave.Enabled = false;
      tbbSave.Enabled = false;

      //removed to make certification happy
      lblFileTitle.Text = "(untitled)";
      m_bLoading = false;
      ebTitle.Focus();
    }

    private void optionsClicked() {
      Cursor.Current = Cursors.WaitCursor;
      Dialog_Preferences dlg = new Dialog_Preferences();
      dlg.Visible = false;
      if (m_strBlogId == "-1") {
        dlg.cbBlogs.SelectedIndex = 0;
      }
      dlg.ebHost.Text = m_strHostname;
      dlg.ebCgi.Text = m_strCgiPath;
      dlg.ebUsername.Text = m_strUsername;
      dlg.ebPassword.Text = m_strPassword;
      // set the lists
      dlg.ma_objBlogs = ma_objBlogs;
      dlg.ma_objTextFilters = ma_objTextFilters;
      dlg.m_nSelBlog = m_nSelBlog;

      dlg.ckbShowExit.Checked = m_bShowExit;
      dlg.ebUpload.Text = m_strUploadPath;

      dlg.cbStatus.SelectedIndex = m_advDefaults.nStatus;
      dlg.cbComment.SelectedIndex = m_advDefaults.nComments;
      for (int i = 0; i < ma_objTextFilters.Count; i++) {
        dlg.cbFormatting.Items.Add(((CCatItem)ma_objTextFilters[i]).strName);
      }
      dlg.cbFormatting.SelectedIndex = m_advDefaults.nFormat;
      dlg.ckbAllowPings.Checked = m_advDefaults.bAllowPings;
      dlg.ckbServerTime.Checked = m_advDefaults.bUseServerTime;

#if PocketPC
      dlg.ckbBox.Checked = m_bShowSIP;
      dlg.ebBold.Text = m_strBold;
      dlg.ebItalics.Text = m_strItalics;
      dlg.ebUnderline.Text = m_strUnderline;
      dlg.ebImage.Text = m_strImage;

      dlg.ckb1.Checked = m_bCloseCustomOne;
      dlg.ckb2.Checked = m_bCloseCustomTwo;

      dlg.eb1.Text = m_strCustomOne;
      dlg.eb2.Text = m_strCustomTwo;
#endif
      dlg.ebTarget.Text = m_strDefaultTarget;

      dlg.ckbUseProxy.Checked = m_bUseProxy;
      dlg.ckbProxyAuthentication.Checked = m_bProxyAuthentication;
      dlg.ebProxyUrl.Text = m_strProxyUrl;
      dlg.ebProxyUserName.Text = m_strProxyUserName;
      dlg.ebProxyPassword.Text = m_strProxyPassword;
      dlg.ebProxyPort.Text = string.Format("{0}", m_nProxyPort);

      if (dlg.ShowDialog() == DialogResult.OK) {
        Cursor.Current = Cursors.Default;

        // do proxy stuff first
        m_bUseProxy = dlg.ckbUseProxy.Checked;
        m_bProxyAuthentication = dlg.ckbProxyAuthentication.Checked;
        m_strProxyUrl = dlg.ebProxyUrl.Text;
        m_strProxyUserName = dlg.ebProxyUserName.Text;
        m_strProxyPassword = dlg.ebProxyPassword.Text;
        m_nProxyPort = Convert.ToInt32(dlg.ebProxyPort.Text);
        SetupProxyInformation();

        m_strHostname = dlg.ebHost.Text;
        if (m_strHostname.IndexOf("typepad.com") > -1)
          m_nBlogMode = BlogEngine.TypePad;
        else
          m_nBlogMode = BlogEngine.MovableType;
        m_strCgiPath = dlg.ebCgi.Text;
        m_strUsername = dlg.ebUsername.Text;
        m_strPassword = dlg.ebPassword.Text;
        m_nSelBlog = dlg.cbBlogs.SelectedIndex;
#if PocketPC
        m_bShowSIP = dlg.ckbBox.Checked;
        m_strBold = dlg.ebBold.Text;
        m_strItalics = dlg.ebItalics.Text;
        m_strUnderline = dlg.ebUnderline.Text;
        m_strImage = dlg.ebImage.Text;

        m_bCloseCustomOne = dlg.ckb1.Checked;
        m_bCloseCustomTwo = dlg.ckb2.Checked;

        m_strCustomOne = dlg.eb1.Text;
        m_strCustomTwo = dlg.eb2.Text;
#endif
        m_strDefaultTarget = dlg.ebTarget.Text;

        // grab the lists
        ma_objBlogs = dlg.ma_objBlogs;
        //set the blog number
        if ((m_nSelBlog != -1) && (m_nSelBlog < ma_objBlogs.Count)) {
          CBlogItem objBI = (CBlogItem)ma_objBlogs[m_nSelBlog];
          m_strBlogId = objBI.strId;
          if (dlg.m_bMadeDirty) {
            DialogResult dlgRes = MessageBox.Show("The current Blog settings have changed and the categories and text filter lists should be updated.\r\n\r\nDo you want to do this now?", m_strAppName, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            switch (dlgRes) {
              case DialogResult.No:
                break;
              case DialogResult.Yes:
                setCursors(true);
                prepProgress(true);
                UpdateCategoriesThreadProc();
                setCursors(true);
                prepProgress(true);
                UpdateTextFiltersThreadProc();
                break;
            }
          }
        }
        else {
          m_strBlogId = "-1";
        }

        // change the draft for the defaults
        m_advDefaults.nStatus = dlg.cbStatus.SelectedIndex;
        m_advDefaults.nComments = dlg.cbComment.SelectedIndex;
        m_advDefaults.nFormat = dlg.cbFormatting.SelectedIndex;
        m_advDefaults.bAllowPings = dlg.ckbAllowPings.Checked;
        m_advDefaults.bUseServerTime = dlg.ckbServerTime.Checked;

        cbStatus.SelectedIndex = m_advDefaults.nStatus;
        cbComment.SelectedIndex = m_advDefaults.nComments;
        cbFormatting.SelectedIndex = m_advDefaults.nFormat;
        ckbAllowPings.Checked = m_advDefaults.bAllowPings;
        ckbServer.Checked = m_advDefaults.bUseServerTime;

        m_bShowExit = dlg.ckbShowExit.Checked;
        // make it an immediate update
        if (m_bShowExit) {
          if (this.mniExit == null) {
            this.mniExit = new System.Windows.Forms.MenuItem();
            this.mniExit.Text = "Exit";
            this.mniExit.Click += new System.EventHandler(this.mniExit_Click);
#if PocketPC
            this.mnuMain.MenuItems.Add(this.mniExit);
            this.ControlBox = false;
#endif
#if Smartphone
            this.mnuTools.MenuItems.Add(this.mniExit);
#endif
          }
        }
        else {
          if (this.mniExit != null) {
#if PocketPC
            this.mnuMain.MenuItems.Remove(this.mniExit);
            this.ControlBox = true;
#endif
#if Smartphone
            this.mnuTools.MenuItems.Remove(this.mniExit);
#endif
            this.mniExit = null;
          }
        }
        m_strUploadPath = dlg.ebUpload.Text;

        updateConnectionMenuToolbar();

        ebTitle.Focus();
        mniSave.Enabled = false;
        tbbSave.Enabled = false;
        mniPost.Enabled = false;
      }
      dlg.Dispose();
    }

    private void SetupProxyInformation() {
      // Create a proxy, if I'm supposed to
      if (m_bUseProxy) {
        try {
          m_netProxy = new WebProxy();

          // Create a new Uri object.
          Uri uriProxy = new Uri(string.Format("http://{0}:{1}", m_strProxyUrl, m_nProxyPort));

          // Associate the newUri object to 'myProxy' object so that new myProxy settings can be set.
          m_netProxy.Address = uriProxy;

          // Create a NetworkCredential object and associate it with the Proxy property of request object.
          if (m_bProxyAuthentication) {
            NetworkCredential netCredential = new NetworkCredential(m_strProxyUserName, m_strProxyPassword);
            CredentialCache credentialCache = new CredentialCache();
            credentialCache.Add(uriProxy, "Basic", netCredential);
            credentialCache.Add(uriProxy, "Digest", netCredential);
            credentialCache.Add(uriProxy, "NTLM", netCredential);
            credentialCache.Add(uriProxy, "Kerberos", netCredential);
            m_netProxy.Credentials = credentialCache;
          }
        }
        catch {
          MessageBox.Show("Error configuring for your proxy server!\n\nPlease verify your proxy information on the Options dialog.", m_strAppName, MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1);
          m_netProxy = null;
        }
      }
      else
        m_netProxy = null;
    }

    private void updateConnectionMenuToolbar() {
      if (m_strBlogId == "-1") {
        mniCategories.Enabled = false;
        mniTextFilters.Enabled = false;
        mniUpload.Enabled = false;
        mniOptions.Text = "Options... << Setup First!";
        mniOpen.Enabled = false;
      }
      else {
        mniCategories.Enabled = true;
        mniTextFilters.Enabled = true;
        mniUpload.Enabled = true;
        mniOptions.Text = "Options...";
        mniOpen.Enabled = true;
      }
    }

    private void updateTextBoxMenuToolbar(bool bTextSelected, bool bInEditBox) {
      updateTextBoxMenuToolbar(bTextSelected, bInEditBox, null);
    }

    private void updateTextBoxMenuToolbar(bool bTextSelected, bool bInEditBox, Control ctrl) {
      if (bInEditBox) {
        m_ctrlCurrent = ctrl;
      }
      else {
        m_ctrlCurrent = null;
      }

#if PocketPC
      if (m_bShowSIP == true) {
        if (inputPanel != null) {
          if (bInEditBox) {
            inputPanel.Enabled = true;
          }
          else {
            inputPanel.Enabled = false;
          }
        }
      }

      mniBold.Enabled = bInEditBox;
      mniItalics.Enabled = bInEditBox;
      mniUnderline.Enabled = bInEditBox;
      mniUrl.Enabled = bInEditBox;
      if (m_strCustomOne.Length > 0)
        mniCustomOne.Enabled = bInEditBox;
      else
        mniCustomOne.Enabled = false;
      if (m_strCustomTwo.Length > 0)
        mniCustomTwo.Enabled = bInEditBox;
      else
        mniCustomTwo.Enabled = false;
#endif
      mniContact.Enabled = bInEditBox;
    }
  }
}
