using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Net;
using System.IO;
using System.Xml;
using SharpMTClasses;
using Pocket_SharpMT._Objects.code;

namespace Phone_SharpMT {
  public partial class Dialog_Preferences : Form {
    public int m_nSelBlog;
    public ArrayList ma_objBlogs;
    public ArrayList ma_objTextFilters;
    public bool m_bMadeDirty;
    private Control m_ctrlCurrent;
    private int m_currentFrame = 0;
    
    public Dialog_Preferences() {
      InitializeComponent();

      m_ctrlCurrent = null;

      DialogResult = DialogResult.OK;

      ma_objBlogs = new ArrayList();
      ma_objTextFilters = null;
      m_nSelBlog = 0;
      m_bMadeDirty = false;
    }

    private void btnOK_Click(object sender, EventArgs e) {
      this.DialogResult = DialogResult.OK;
    }

    private void btnCancel_Click(object sender, EventArgs e) {
      this.DialogResult = DialogResult.Cancel;
      //this.Close();
    }

    private bool ValidateHost() {
      bool b = true;
      string str = ebHost.Text;
      if (str.Length <= 0) {
        MessageBox.Show("Please enter your Web Server Name!", Dialog_Main.m_strAppName, MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1);
        ebHost.Focus();
        b = false;
      }
      str = str.ToLower();
      str.Replace("http://", "");
      ebHost.Text = str;
      return b;
    }

    private bool ValidateCgi() {
      bool b = true;
      string str = ebCgi.Text;
      if (str.Length <= 0) {
        MessageBox.Show("Please enter your CGI-BIN Path!", Dialog_Main.m_strAppName, MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1);
        ebCgi.Focus();
        b = false;
      }
      if (str[0] != '/')
        str = "/" + str;
      ebCgi.Text = str;
      return b;
    }

    private void Dialog_Preferences_Load(object sender, EventArgs e) {
      if (ma_objBlogs.Count > 0) {
        // Pop through the Array and update the list
        cbBlogs.Items.Clear();
        for (int i = 0; i < ma_objBlogs.Count; i++) {
          CBlogItem objBI = (CBlogItem)ma_objBlogs[i];
          cbBlogs.Items.Add(string.Format("{0} ({1})", objBI.strName, objBI.strId));
        }
        cbBlogs.SelectedIndex = m_nSelBlog;
      }
      if (ebHost.Text == "") {
        ebHost.Text = "www.hostname.com";
      }
      if (ebCgi.Text == "") {
        ebCgi.Text = "/cgipath/mt-xmlrpc.cgi";
      }
      m_bMadeDirty = false;
      Cursor.Current = Cursors.Default;
    }

    protected override void OnClosing(CancelEventArgs e) {
      base.OnClosing(e);
      if (DialogResult == DialogResult.OK) {
        if (ValidateHost() == false) {
          e.Cancel = true;
          return;
        }
        if (ValidateCgi() == false) {
          e.Cancel = true;
          return;
        }
        if (cbBlogs.Text == "Click Refresh to update") {
          if (MessageBox.Show("You haven't connected to your Blog yet by clicking the Refresh button - do you want to now?", Dialog_Main.m_strAppName, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes) {
            refreshClick();
            e.Cancel = true;
          }
        }
      }
    }

    private void btnRefresh_Click(object sender, EventArgs e) {
      refreshClick();
    }

    private void refreshClick() {
      if (!ValidateHost())
        return;

      if (!ValidateCgi())
        return;

      Cursor.Current = Cursors.WaitCursor;
      // Go get the list of thingies
      string str = string.Format("http://{0}{1}", ebHost.Text, ebCgi.Text);
      string strXml = string.Format("<?xml version=\"1.0\"?><methodCall><methodName>blogger.getUsersBlogs</methodName><params>" +
        "<param><value><string>{0}</string></value></param>" +
        "<param><value><string>{1}</string></value></param>" +
        "<param><value><string>{2}</string></value></param>" +
        "</params></methodCall>", Dialog_Main.m_strBloggerAppKey, ebUsername.Text, ebPassword.Text);
      byte[] bytes = null;
      bytes = System.Text.Encoding.ASCII.GetBytes(strXml);

      HttpWebRequest wbRequest = (HttpWebRequest)WebRequest.Create(str);
      // update with new proxy information
      if (ckbUseProxy.Checked) {
        try {
          WebProxy netProxy = new WebProxy();

          // Create a new Uri object.
          Uri uriProxy = new Uri(string.Format("http://{0}:{1}", ebProxyUrl.Text, ebProxyPort.Text));

          // Associate the newUri object to 'myProxy' object so that new myProxy settings can be set.
          netProxy.Address = uriProxy;

          // Create a NetworkCredential object and associate it with the Proxy property of request object.
          if (ckbProxyAuthentication.Checked) {
            //NetworkCredential nCred = new NetworkCredential(ebProxyUserName.Text, ebProxyPassword.Text);
            //netProxy.Credentials = nCred;
            NetworkCredential netCredential = new NetworkCredential(ebProxyUserName.Text, ebProxyPassword.Text);
            CredentialCache credentialCache = new CredentialCache();
            credentialCache.Add(uriProxy, "Basic", netCredential);
            credentialCache.Add(uriProxy, "Digest", netCredential);
            credentialCache.Add(uriProxy, "NTLM", netCredential);
            credentialCache.Add(uriProxy, "Kerberos", netCredential);
            netProxy.Credentials = credentialCache;
          }
          wbRequest.Proxy = netProxy;
        }
        catch {
          MessageBox.Show("Error configuring for your proxy server!\n\nPlease verify your proxy information on the Options dialog.", Dialog_Main.m_strAppName, MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1);
          //wbRequest.Proxy = GlobalProxySelection.GetEmptyWebProxy();
        }
      }
      //else
      //  wbRequest.Proxy = GlobalProxySelection.GetEmptyWebProxy();

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
        MessageBox.Show("Error connecting to host!", Dialog_Main.m_strAppName, MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1);
        Cursor.Current = Cursors.Default;
        return;
      }

      HttpWebResponse wbResponse = null;
      try {
        wbResponse = (HttpWebResponse)wbRequest.GetResponse();
      }
      catch (WebException we) {
        MessageBox.Show(we.Message + "\r\n\r\nPlease verify that your CGI-BIN Path is correct!", Dialog_Main.m_strAppName, MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1);
        ebCgi.Focus();
        Cursor.Current = Cursors.Default;
        return;
      }

      if (wbResponse.StatusCode != HttpStatusCode.OK) {
        return;
      }

      // Get the response stream.
      Stream stmRead = wbResponse.GetResponseStream();
      StreamReader stmReader = new StreamReader(stmRead, System.Text.Encoding.ASCII);
      strXml = stmReader.ReadToEnd();
      stmRead.Close();
      wbResponse.Close();

      XmlDocument xmlDoc = new XmlDocument();
      xmlDoc.LoadXml(strXml);
      XmlNode xmlNode = xmlDoc.FirstChild;

      if (xmlNode == null) {
        MessageBox.Show("Error connecting to Blog server!", Dialog_Main.m_strAppName, MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1);
        Cursor.Current = Cursors.Default;
        return;
      }

      if (strXml.IndexOf("<name>faultString</name>") > -1) {
        xmlNode = xmlNode.NextSibling;
        strXml = xmlNode.InnerText;
        int nCharPos = strXml.IndexOf("faultCode");
        if (nCharPos > -1)
          strXml = strXml.Substring(0, nCharPos);
        strXml = strXml.Replace("faultString", "");
        MessageBox.Show(strXml, Dialog_Main.m_strAppName, MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1);
        Cursor.Current = Cursors.Default;
        return;
      }

      if (xmlNode.HasChildNodes == false)
        xmlNode = xmlNode.NextSibling;

      XmlNodeReader xmlReader = new XmlNodeReader(xmlNode);
      ma_objBlogs.Clear();
      CBlogItem objBI = new CBlogItem();
      string strValueName = "";
      bool bStartTag = true;
      string strEndTag = "struct";
      while (xmlReader.Read()) {
        if (xmlReader.Name == "name") {
          string strElement = xmlReader.ReadString();
          switch (strElement) {
            case "blogid": // blogID
            case "blogName": // blogName
            case "url": //url
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
            case "blogid": // blogID
              objBI.strId = strElement;
              break;
            case "blogName": // blogName
              objBI.strName = strElement;
              break;
            case "url": // url
              objBI.strUrl = strElement;
              break;
          }
        }
        else if (xmlReader.Name == strEndTag) {
          if (bStartTag) {
            objBI = new CBlogItem();
            bStartTag = false;
          }
          else {
            ma_objBlogs.Add(objBI);
            bStartTag = true;
          }
        }
      }

      if (ma_objBlogs.Count <= 0) {
        Cursor.Current = Cursors.Default;
        return;
      }

      int nField = 0;
      // Pop through the Array and update the list
      int nPos = cbBlogs.SelectedIndex;
      cbBlogs.Items.Clear();
      for (nField = 0; nField < ma_objBlogs.Count; nField++) {
        objBI = (CBlogItem)ma_objBlogs[nField];
        cbBlogs.Items.Add(string.Format("{0} ({1})", objBI.strName, objBI.strId));
      }
      if (nPos >= ma_objBlogs.Count) {
        nPos = 0;
      }
      cbBlogs.SelectedIndex = nPos;
      Cursor.Current = Cursors.Default;
    }

    private void ebGeneric_GotFocus(object sender, EventArgs e) {
      m_ctrlCurrent = (Control)sender;
    }

    private void ebGeneric_TextChanged(object sender, EventArgs e) {
      this.m_bMadeDirty = true;    
    }

    private void cbBlogs_SelectedIndexChanged(object sender, EventArgs e) {
      this.m_bMadeDirty = true;
    }

    private void switchFrames(int selected) {
      switch (m_currentFrame) {
        case 0:
          serverPanel.Visible = false;
          break;
        case 1:
          proxyPanel.Hide();
          break;
        case 2:
          defaultsPanel.Visible = false;
          break;
        case 3:
          imagesPanel.Visible = false;
          break;
      }

      switch (selected) {
        case 0:
          serverPanel.Visible = true;
          ebHost.Focus();
          break;
        case 1:
          proxyPanel.Show();
          ebProxyUrl.Focus();
          break;
        case 2:
          defaultsPanel.Visible = true;
          cbStatus.Focus();
          break;
        case 3:
          imagesPanel.Visible = true;
          ebUpload.Focus();
          break;
      }

      m_currentFrame = selected;
      mniServer.Checked = serverPanel.Visible;
      mniProxy.Checked = proxyPanel.Visible;
      mniDefaults.Checked = defaultsPanel.Visible;
      mniImages.Checked = imagesPanel.Visible;
    }

    private void mniServer_Click(object sender, EventArgs e) {
      switchFrames(0);
    }

    private void mniProxy_Click(object sender, EventArgs e) {
      switchFrames(1);
    }

    private void mniDefaults_Click(object sender, EventArgs e) {
      switchFrames(2);
    }

    private void mniImages_Click(object sender, EventArgs e) {
      switchFrames(3);
    }

    private void ckbUseProxy_CheckStateChanged(object sender, EventArgs e) {
      ebProxyUrl.Enabled = ckbUseProxy.Checked;
      ebProxyPort.Enabled = ckbUseProxy.Checked;
      ckbProxyAuthentication.Enabled = ckbUseProxy.Checked;
      if (ckbProxyAuthentication.Enabled) {
        ebProxyUserName.Enabled = ckbProxyAuthentication.Checked;
        ebProxyPassword.Enabled = ckbProxyAuthentication.Checked;
      }
      else {
        ebProxyUserName.Enabled = false;
        ebProxyPassword.Enabled = false;
      }
    }

    private void ckbProxyAuthentication_CheckStateChanged(object sender, EventArgs e) {
      if (ckbUseProxy.Checked) {
        ebProxyUserName.Enabled = ckbProxyAuthentication.Checked;
        ebProxyPassword.Enabled = ckbProxyAuthentication.Checked;
      }
      else {
        ebProxyUserName.Enabled = false;
        ebProxyPassword.Enabled = false;
      }
    }

    private void ckbAllowPings_CheckStateChanged(object sender, EventArgs e) {
      this.m_bMadeDirty = true;
    }
  }
}