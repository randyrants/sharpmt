#region Using directives

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.IO;
using System.Xml;
using SharpMT.Classes;

#endregion

namespace SharpMT.Forms
{
  partial class OptionsForm : Form
  {
    public string m_fontName; //m_strFontName
    public float m_fontPointSize; //m_fFontPoint
    public bool m_boldFont, m_italicFont; //m_bFontBold, m_bFontItalic;
    public int m_selectedBlogId; //m_nSelBlog
    public List<BlogItem> m_blogList; //ma_objBlogs
    public List<CategoryItem> m_textFiltersList; //ma_objTextFilters
    public bool m_isDirty; //m_bMadeDirty
    public bool m_clearMru; //m_bClearMru

    public OptionsForm()
    {
      InitializeComponent();

      m_blogList = new List<BlogItem>();
      m_textFiltersList = null;
      m_selectedBlogId = 0;
      m_isDirty = false;
      m_clearMru = false;
    }

    private void textBox_TextChanged(object sender, System.EventArgs e)
    {
      m_isDirty = true;
    }

    private void comboBox_SelectedIndexChanged(object sender, System.EventArgs e)
    {
      m_isDirty = true;
    }

    private void hostLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
      MessageBox.Show("If your link to access your MovableType Blog settings is http://www.hostname.com/cgi-bin/mt.cgi, your Host Name is:\r\n\r\nwww.hostname.com\r\n\r\nIf you are using TypePad, your Host Name is:\r\n\r\nwww.typepad.com");
    }

    private void cgibinLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
      MessageBox.Show("If your link to access your MovableType Blog settings is http://www.hostname.com/cgi-bin/mt.cgi, your CGI-BIN path is:\r\n\r\n/cgi-bin/mt-xmlrpc.cgi\r\n\r\nIf you are using TypePad, your CGI-BIN path is:\r\n\r\n/t/api");
    }

    private void defaultButton_Click(object sender, EventArgs e)
    {
      draftFolder.Text = Environment.GetFolderPath(Environment.SpecialFolder.Personal) + @"\My Drafts\";
    }

    private void addMusicItemButton_Click(object sender, EventArgs e)
    {
      switch (musicItems.SelectedIndex)
      {
        case 0:
          musicTag.SelectedText = "[ALBUM]";
          break;
        case 1:
          musicTag.SelectedText = "[ARTIST]";
          break;
        case 2:
          musicTag.SelectedText = "[DURATION]";
          break;
        case 3:
          musicTag.SelectedText = "[SONG]";
          break;
      }
    }

    private void browseButton_Click(object sender, EventArgs e)
    {
      // Show the FolderBrowserDialog.
      folderBrowser.SelectedPath = draftFolder.Text;
      if (folderBrowser.ShowDialog() == DialogResult.OK)
      {
        draftFolder.Text = folderBrowser.SelectedPath + @"\";
      }
    }

    private void fontOptions_Click(object sender, EventArgs e)
    {
      FontStyle fontStyle = ((m_boldFont ? FontStyle.Bold : 0) | (m_italicFont ? FontStyle.Italic : 0));
      Font font = new Font(m_fontName, m_fontPointSize, fontStyle);
      fontDialog.Font = font;
      if (fontDialog.ShowDialog() == DialogResult.OK)
      {
        m_fontName = fontDialog.Font.Name;
        m_fontPointSize = fontDialog.Font.Size;
        m_boldFont = fontDialog.Font.Bold;
        m_italicFont = fontDialog.Font.Italic;

        m_isDirty = true;
      }
    }

    private void useProxy_CheckedChanged(object sender, EventArgs e)
    {
      proxyServer.Enabled = useProxy.Checked;
      proxyPort.Enabled = useProxy.Checked;
      useAuthentication.Enabled = useProxy.Checked;
      if (useAuthentication.Enabled)
      {
        proxyUserName.Enabled = useAuthentication.Checked;
        proxyPassword.Enabled = useAuthentication.Checked;
      }
      else
      {
        proxyUserName.Enabled = false;
        proxyPassword.Enabled = false;
      }
    }

    private void useAuthentication_CheckedChanged(object sender, EventArgs e)
    {
      if (useProxy.Enabled)
      {
        proxyUserName.Enabled = useAuthentication.Checked;
        proxyPassword.Enabled = useAuthentication.Checked;
      }
      else
      {
        proxyUserName.Enabled = false;
        proxyPassword.Enabled = false;
      }
    }

    private void restoreTags_Click(object sender, EventArgs e)
    {
      boldTag.Text = "b";
      italicsTag.Text = "i";
      underlineTag.Text = "u";
      imageTag.Text = "<img scr=\"[IMAGELINK]\">";
    }

    private void addTag_Click(object sender, EventArgs e)
    {
      if (customTags.Items.Count == 10)
      {
        MessageBox.Show("You already have 10 tags and cannot add another!", MainForm.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Error);
        return;
      }
      AddTagForm addTagForm = new AddTagForm();
      if (addTagForm.ShowDialog() == DialogResult.OK)
      {
        ListViewItem item = customTags.Items.Add(string.Format("{0}", customTags.Items.Count + 1));
        CustomTag customTag = new CustomTag(addTagForm.tagText.Text, addTagForm.enclose.Checked);
        item.Tag = customTag;
        item.SubItems.Add(ShowTextTag(customTag));
        item.Selected = true;
        customTags.EnsureVisible(item.Index);
      }
    }

    private string ShowTextTag(CustomTag customTag)
    {
      return ShowTextTag(customTag.Tag, customTag.Closed);
    }

    private string ShowTextTag(string tag, bool enclose)
    {
      if (enclose)
      {
        String backTag = tag;
        if (tag.IndexOf(" ") > -1)
        {
          backTag = tag.Substring(0, tag.IndexOf(" "));
        }
        return string.Format("Enclosing tag: <{0}></{1}>", tag, backTag);
      }
      else
      {
        return string.Format("Contained tag: <{0}>", tag);
      }
    }

    private void editTag_Click(object sender, EventArgs e)
    {
      if (customTags.SelectedItems.Count <= 0)
      {
        MessageBox.Show("You need to select a tag before you can edit one!", MainForm.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Error);
        return;
      }

      AddTagForm addTagForm = new AddTagForm();
      ListViewItem item = customTags.SelectedItems[0];
      CustomTag customTag = (CustomTag)item.Tag;
      addTagForm.tagText.Text = customTag.Tag;
      addTagForm.enclose.Checked = customTag.Closed;

      if (addTagForm.ShowDialog() == DialogResult.OK)
      {
        customTag.Tag = addTagForm.tagText.Text;
        customTag.Closed = addTagForm.enclose.Checked;
        item.Tag = customTag;
        item.SubItems[1].Text = ShowTextTag(customTag);
        item.Selected = true;
        customTags.EnsureVisible(item.Index);
      }
    }

    private void DeleteButtonClicked(ListView ctrl)
    {
      if (ctrl.SelectedItems.Count <= 0)
      {
        MessageBox.Show("You need to select an item before you can delete one!", MainForm.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Error);
        return;
      }
      int index = ctrl.SelectedIndices[0];
      ctrl.Items.RemoveAt(index);

      ReorderTheList(ctrl, index);
    }

    private void MoveItemUp(ListView ctrl)
    {
      if (ctrl.SelectedItems.Count <= 0)
      {
        MessageBox.Show("You need to select an item before you can move one!", MainForm.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Error);
        return;
      }
      ListViewItem item = ctrl.SelectedItems[0];
      int index = item.Index;
      ctrl.Items.Remove(item);
      index -= 1;
      if (index < 0)
      {
        ctrl.Items.Add(item);
        index = item.Index;
      }
      else
      {
        ctrl.Items.Insert(index, item);
      }

      ReorderTheList(ctrl, index);
    }

    private void MoveItemDown(ListView ctrl)
    {
      if (ctrl.SelectedItems.Count <= 0)
      {
        MessageBox.Show("You need to select an item before you can move one!", MainForm.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Error);
        return;
      }

      ListViewItem item = ctrl.SelectedItems[0];
      int index = item.Index;
      ctrl.Items.Remove(item);
      index += 1;
      if (index > ctrl.Items.Count)
      {
        index = 0;
      }
      ctrl.Items.Insert(index, item);

      ReorderTheList(ctrl, index);
    }

    private void ReorderTheList(ListView ctrl, int index)
    {
      for (int i = 0; i < ctrl.Items.Count; i++)
      {
        ctrl.Items[i].Text = Convert.ToString(i + 1);
      }

      if (index < ctrl.Items.Count)
      {
        ctrl.Items[index].Selected = true;
      }
      else if (ctrl.Items.Count > 0)
      {
        index = ctrl.Items.Count - 1;
        ctrl.Items[index].Selected = true;
        ctrl.EnsureVisible(index);
      }
    }

    private void deleteTag_Click(object sender, EventArgs e)
    {
      DeleteButtonClicked(customTags);
    }

    private void deleteAllTags_Click(object sender, EventArgs e)
    {
      if (MessageBox.Show("All custom tags will be removed from the list - are you sure you want to continue?", MainForm.ApplicationName, MessageBoxButtons.YesNo, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
      {
        customTags.Items.Clear();
      }
    }

    private void moveTagUp_Click(object sender, EventArgs e)
    {
      MoveItemUp(customTags);
    }

    private void moveTagDown_Click(object sender, EventArgs e)
    {
      MoveItemDown(customTags);
    }

    private void movePlugInUp_Click(object sender, EventArgs e)
    {
      MoveItemUp(plugIns);
    }

    private void movePlugInDown_Click(object sender, EventArgs e)
    {
      MoveItemDown(plugIns);
    }

    private void addPlugIn_Click(object sender, EventArgs e)
    {
      if (plugIns.Items.Count == 10)
      {
        MessageBox.Show("You already have 10 Plug-Ins and cannot add another!", MainForm.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Error);
        return;
      }
      AddPlugInForm addPlugInForm = new AddPlugInForm();
      if (addPlugInForm.ShowDialog() == DialogResult.OK)
      {
        ListViewItem item = plugIns.Items.Add(String.Format("{0}", plugIns.Items.Count + 1));
        PlugInItem plugInItem = new PlugInItem(addPlugInForm.plugInName.Text, addPlugInForm.location.Text);
        item.Tag = plugInItem;
        item.SubItems.Add(ShowPlugIn(plugInItem));
        item.Selected = true;
        plugIns.EnsureVisible(item.Index);
      }
    }

    private void deletePlugIn_Click(object sender, EventArgs e)
    {
      DeleteButtonClicked(plugIns);
    }

    private void deleteAllPlugIn_Click(object sender, EventArgs e)
    {
      if (MessageBox.Show("All Plug-Ins will be removed from the list - are you sure you want to continue?", MainForm.ApplicationName, MessageBoxButtons.YesNo, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
      {
        plugIns.Items.Clear();
      }
    }

    private string ShowPlugIn(PlugInItem plugInItem)
    {
      return ShowPlugIn(plugInItem.Name, plugInItem.Path);
    }

    private string ShowPlugIn(string name, string path)
    {
      return string.Format("{0} ({1})", name, path);
    }

    private void OptionsForm_Load(object sender, EventArgs e)
    {
      if (m_blogList.Count > 0)
      {
        // Pop through the Array and update the list
        blogList.Items.Clear();
        for (int i = 0; i < m_blogList.Count; i++)
        {
          BlogItem blogItem = (BlogItem)m_blogList[i];
          blogList.Items.Add(string.Format("{0} ({1})", blogItem.Name, blogItem.ID));
        }
        blogList.SelectedIndex = m_selectedBlogId;
      }
      if (hostName.Text == "")
      {
        hostName.Text = "www.hostname.com";
      }
      if (cgiPath.Text == "")
      {
        cgiPath.Text = "/cgipath/mt-xmlrpc.cgi";
      }
      musicItems.SelectedIndex = 0;

      // set up the tags listview
      for (int i = 0; i < customTags.Items.Count; i++)
      {
        ListViewItem item = customTags.Items[i];
        item.SubItems.Add(ShowTextTag((CustomTag)item.Tag));
      }
      if (customTags.Items.Count > 0)
        customTags.Items[0].Selected = true;

      // set up the plugins listview
      for (int i = 0; i < plugIns.Items.Count; i++)
      {
        ListViewItem item = plugIns.Items[i];
        item.SubItems.Add(ShowPlugIn((PlugInItem)item.Tag));
      }
      if (plugIns.Items.Count > 0)
        plugIns.Items[0].Selected = true;

      m_isDirty = false;
    }

    private void refreshButton_Click(object sender, EventArgs e)
    {
      if (!ValidateHost())
        return;

      if (!ValidateCgi())
        return;

      Cursor = Cursors.WaitCursor;
      // Go get the list of thingies

      string https = "", portNumber = "";
      if (ssl.Checked == true) {
        https = "s";
      }
      if (port.Text != "80") {
        portNumber = string.Format(":{0}", port.Text);
      }

      string str = string.Format("http{0}://{1}{2}{3}", https, hostName.Text, portNumber, cgiPath.Text);
      string xml = string.Format("<?xml version=\"1.0\"?><methodCall><methodName>blogger.getUsersBlogs</methodName><params>" +
        "<param><value><string>{0}</string></value></param>" +
        "<param><value><string>{1}</string></value></param>" +
        "<param><value><string>{2}</string></value></param>" +
        "</params></methodCall>", MainForm.BloggerKey, userName.Text, password.Text);
      byte[] bytes = null;
      bytes = System.Text.Encoding.ASCII.GetBytes(xml);

      if (showTracingWindow.Checked)
      {
        if (MainForm.m_tracingForm == null)
        {
          MainForm.m_tracingForm = new TracingForm();
          MainForm.m_tracingForm.Show();
        }
        if (MainForm.m_tracingForm != null)
          MainForm.m_tracingForm.Log.Text = MainForm.m_tracingForm.Log.Text + "\r\n" + "Outbound: " + xml;
      }

      HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(str);
      // update with new proxy information
      if (useProxy.Checked)
      {
        try
        {
          WebProxy webProxy = new WebProxy();

          // Create a new Uri object.
          Uri proxyUri = new Uri(string.Format("http://{0}:{1}", proxyServer.Text, proxyPort.Text));

          // Associate the newUri object to 'myProxy' object so that new myProxy settings can be set.
          webProxy.Address = proxyUri;

          // Create a NetworkCredential object and associate it with the Proxy property of request object.
          if (useAuthentication.Checked)
          {
            NetworkCredential netCredential = new NetworkCredential(proxyUserName.Text, proxyPassword.Text);
            CredentialCache credentialCache = new CredentialCache();
            credentialCache.Add(proxyUri, "Basic", netCredential);
            credentialCache.Add(proxyUri, "Digest", netCredential);
            credentialCache.Add(proxyUri, "NTLM", netCredential);
            credentialCache.Add(proxyUri, "Kerberos", netCredential);
            webProxy.Credentials = credentialCache;
          }
          webRequest.Proxy = webProxy;
        }
        catch
        {
          MessageBox.Show("Error configuring for your proxy server!\n\nPlease verify your proxy information on the Options dialog.", MainForm.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Error);
          //wbRequest.Proxy = GlobalProxySelection.GetEmptyWebProxy();
        }
      }
      //else
      //  wbRequest.Proxy = GlobalProxySelection.GetEmptyWebProxy();

      webRequest.UserAgent = MainForm.UserAgent;
      webRequest.Method = "POST";
      webRequest.ContentType = "text/xml";
      webRequest.ContentLength = bytes.Length;
      try
      {
        Stream outStream = webRequest.GetRequestStream();
        outStream.Write(bytes, 0, bytes.Length);
        outStream.Close();
      }
      catch
      {
        MessageBox.Show("Error connecting to host!", MainForm.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Error);
        Cursor = Cursors.Default;
        return;
      }

      HttpWebResponse webResponse = null;
      try
      {
        webResponse = (HttpWebResponse)webRequest.GetResponse();
      }
      catch (WebException we)
      {
        MessageBox.Show(we.Message + "\r\n\r\nPlease verify that your CGI-BIN Path is correct!", MainForm.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Error);
        cgiPath.Focus();
        Cursor = Cursors.Default;
        return;
      }

      if (webResponse.StatusCode != HttpStatusCode.OK)
      {
        return;
      }

      // Get the response stream.
      Stream readStream = webResponse.GetResponseStream();
      StreamReader streamReader = new StreamReader(readStream, System.Text.Encoding.ASCII);
      xml = streamReader.ReadToEnd();
      readStream.Close();
      webResponse.Close();
      
      if (showTracingWindow.Checked)
      {
        if (MainForm.m_tracingForm == null)
        {
          MainForm.m_tracingForm = new TracingForm();
          MainForm.m_tracingForm.Show();
        }
        if (MainForm.m_tracingForm != null)
          MainForm.m_tracingForm.Log.Text = MainForm.m_tracingForm.Log.Text + "\r\n" + " Inbound: " + xml;
      }

      XmlDocument xmlDocument = new XmlDocument();
      XmlNode xmlNode = null;
      try
      {
        ﻿if (xml[0] == MainForm.m_deadCharacter) //clean up the garbage from Spaces
          xml = xml.Remove(0, 1);

        xmlDocument.LoadXml(xml);
        xmlNode = xmlDocument.SelectSingleNode("/methodResponse/params/param/value/array/data");
      }
      catch
      {
        xmlNode = null;
      }

      if (xmlNode == null)
      {
        xmlNode = xmlDocument.SelectSingleNode("/methodResponse/fault/value/struct/member/value/string");
        if (xmlNode == null)
          MessageBox.Show("Error connecting to Blog server!", MainForm.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Error);
        else
          MessageBox.Show(xmlNode.InnerXml, MainForm.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Error);
        Cursor = Cursors.Default;
        return;
      }

      XmlNodeReader xmlReader = new XmlNodeReader(xmlNode);
      m_blogList.Clear();
      BlogItem blogItem = new BlogItem();
      string valueName = "";
      bool isStartTag = true;
      string endTag = "struct";
      while (xmlReader.Read())
      {
        if (xmlReader.Name == "name")
        {
          string element = xmlReader.ReadString();
          switch (element)
          {
            case "blogid": // blogID
            case "blogName": // blogName
            case "url": //url
              valueName = element;
              break;
            default:
              valueName = "";
              break;
          }
        }
        else if (xmlReader.Name == "string") //this would be where you change from string to value, for Spaces
        {
          string element = xmlReader.ReadString();
          switch (valueName)
          {
            case "blogid": // blogID
              blogItem.ID = element;
              break;
            case "blogName": // blogName
              blogItem.Name = element;
              break;
            case "url": // url
              blogItem.Url = element;
              break;
          }
        }
        else if (xmlReader.Name == endTag)
        {
          if (isStartTag)
          {
            blogItem = new BlogItem();
            isStartTag = false;
          }
          else
          {
            m_blogList.Add(blogItem);
            isStartTag = true;
          }
        }
      }

      if (m_blogList.Count <= 0)
      {
        Cursor = Cursors.Default;
        return;
      }

      int field = 0;
      // Pop through the Array and update the list
      int pos = blogList.SelectedIndex;
      blogList.Items.Clear();
      for (field = 0; field < m_blogList.Count; field++)
      {
        blogItem = m_blogList[field];
        blogList.Items.Add(string.Format("{0} ({1})", blogItem.Name, blogItem.ID));
      }
      if (pos >= m_blogList.Count)
      {
        pos = 0;
      }
      blogList.SelectedIndex = pos;
      Cursor = Cursors.Default;
    }

    private bool ValidateHost()
    {
      bool b = true;
      string str = hostName.Text;
      if (str.Length <= 0)
      {
        MessageBox.Show("Please enter your Web Server Name!", MainForm.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Stop);
        hostName.Focus();
        b = false;
      }
      str = str.ToLower();
      str = str.Replace("http://", "");
      hostName.Text = str;
      return b;
    }

    private bool ValidateCgi()
    {
      bool b = true;
      string str = cgiPath.Text;
      if (str.Length <= 0)
      {
        MessageBox.Show("Please enter your CGI-BIN Path!", MainForm.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Stop);
        cgiPath.Focus();
        b = false;
      }
      if (str[0] != '/')
        str = "/" + str;
      cgiPath.Text = str;
      return b;
    }

    private bool ValidatePosts()
    {
      string str = posts.Text;
      if (str.Length <= 0)
      {
        MessageBox.Show("Please enter a number of Posts to retrieve!", MainForm.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Stop);
        posts.Text = "50";
        posts.Focus();
        return false;
      }
      try
      {
        int n = Convert.ToInt32(str, 10);
      }
      catch
      {
        MessageBox.Show("Please enter a number of Posts to retrieve!", MainForm.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Stop);
        posts.Text = "50";
        posts.Focus();
        return false;
      }
      return true;
    }

    private bool ValidateProxyHost()
    {
      bool b = true;
      string str = proxyServer.Text;
      if ((useProxy.Checked) && (str.Length <= 0))
      {
        MessageBox.Show("Please enter a proxy server name or turn off proxy support!", MainForm.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Stop);
        useProxy.Focus();
        b = false;
      }
      str = str.ToLower();
      str = str.Replace("http://", "");
      proxyServer.Text = str;
      return b;
    }

    private void OptionsForm_FormClosing(object sender, FormClosingEventArgs e)
    {
      base.OnClosing(e);
      if (DialogResult == DialogResult.OK)
      {
        if (ValidateHost() == false)
        {
          e.Cancel = true;
          return;
        }
        if (ValidateCgi() == false)
        {
          e.Cancel = true;
          return;
        }
        if (ValidatePosts() == false)
        {
          e.Cancel = true;
          return;
        }
        if (ValidateProxyHost() == false)
        {
          e.Cancel = true;
          return;
        }
        if (blogList.Text == "Click Refresh to refresh list")
        {
          if (MessageBox.Show("You haven't connected to your Blog yet by pressing the Refresh button - do you want to now?", MainForm.ApplicationName, MessageBoxButtons.YesNo, MessageBoxIcon.Stop) == DialogResult.Yes)
          {
            refreshButton.PerformClick();
            e.Cancel = true;
            return;
          }
        }
        if (boldTag.Text.Length <= 0)
        {
          MessageBox.Show("Please enter a bold tag!", MainForm.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Stop);
          boldTag.Focus();
          e.Cancel = true;
          return;
        }
        if (italicsTag.Text.Length <= 0)
        {
          MessageBox.Show("Please enter an italics tag!", MainForm.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Stop);
          italicsTag.Focus();
          e.Cancel = true;
          return;
        }
        if (underlineTag.Text.Length <= 0)
        {
          MessageBox.Show("Please enter an underline tag!", MainForm.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Stop);
          underlineTag.Focus();
          e.Cancel = true;
          return;
        }
        try
        {
          if (Convert.ToInt32(proxyPort.Text) > 66000)
          {
            MessageBox.Show("Please enter a lower number for a proxy port!", MainForm.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Stop);
            proxyPort.Focus();
            e.Cancel = true;
            return;
          }
        }
        catch
        {
          MessageBox.Show("Please enter a number for a proxy port!", MainForm.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Stop);
          proxyPort.Focus();
          e.Cancel = true;
          return;
        }
        try {
          if (Convert.ToInt32(port.Text) > 66000) {
            MessageBox.Show("Please enter a lower number for a port!", MainForm.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Stop);
            port.Focus();
            e.Cancel = true;
            return;
          }
        }
        catch {
          MessageBox.Show("Please enter a number for a port!", MainForm.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Stop);
          port.Focus();
          e.Cancel = true;
          return;
        }
      }
    }

    private void clearMruList_Click(object sender, EventArgs e)
    {
      m_clearMru = true;
    }

    private void ssl_Click(object sender, EventArgs e) {
      m_isDirty = true;
    }
  }
}