#region Using directives

using System;
using System.Drawing;
using SharpMT.Classes;
using System.IO;
using System.Xml;
using Microsoft.Win32;

#endregion

namespace SharpMT
{
  partial class MainForm
  {
    #region Delegates
    // this makes the Member open on the same thread (to avoid IE problems)
    internal delegate void OpenFileDelegate();
    #endregion

    private void LoadRegistrySettings()
    {
      RegistryKey regKey = Registry.CurrentUser.OpenSubKey(RegistryKeyName);
      int status = 0, formatting = 0, comment = 0;//nStatus = 0, nFormatting = 0, nComment = 0;
      Rectangle rc = new Rectangle(10, 10, 750, 550);
      int winState = 0;//nWinState = 0;
      bool showLinks = false, showLinksDetails = false, setPings = false, useServerTime = true; 
      //bLinks = false, bLinksDet = false, bTool = false, bPings = false, bUseServerTime = true;
      string draftDir = "";// strDraftDir = "";

      if (regKey != null)
      {
        // Load draft directory
        draftDir = (string)regKey.GetValue("DraftDirectory", "");
        if (draftDir.Length > 0)
        {
          m_draftsFolder = draftDir;
        }
        if (m_draftsFolder.Substring(m_draftsFolder.Length - 1) != @"\")
          m_draftsFolder += @"\";

        // Load DropDown settings
        status = (int)regKey.GetValue("CurStatus", 0);
        formatting = (int)regKey.GetValue("CurFormatting", 0);
        comment = (int)regKey.GetValue("CurComment", 0);
        int n = 0;
        n = (int)regKey.GetValue("CurPing", 0);
        if (n == 1)
          setPings = true;

        n = 1;
        n = (int)regKey.GetValue("CurTime", 1);
        if (n == 0)
          useServerTime = false;

        m_rssField = (int)regKey.GetValue("RSSField", 0);

        // Load Window Pos
        winState = (int)regKey.GetValue("MainWinState", 0);
        rc.X = (int)regKey.GetValue("MainX", 10);
        rc.Y = (int)regKey.GetValue("MainY", 10);
        rc.Width = (int)regKey.GetValue("MainCX", 750);
        rc.Height = (int)regKey.GetValue("MainCY", 550);
        linksBody.Height = (int)regKey.GetValue("LinksDetCY", 80);

        m_headerHeight = (int)regKey.GetValue("HeaderCY", 53);
        m_bodyHeight = (int)regKey.GetValue("BodyCY", 150);
        m_footerHeight = (int)regKey.GetValue("FooterCY", 90);

        n = 0;
        n = (int)regKey.GetValue("ShowLinks", 1);
        if (n == 1)
          showLinks = true;
        n = 0;
        n = (int)regKey.GetValue("Tracing", 0);
        if (n == 1)
          m_tracing = true;
        n = 0;
        n = (int)regKey.GetValue("MinToTray", 0);
        if (n == 1)
          m_minimizeToSysTray = true;
        n = 0;
        n = (int)regKey.GetValue("UseProxy", 0);
        if (n == 1)
          m_proxy = true;
        n = 0;
        n = (int)regKey.GetValue("UseProxyAuthentication", 0);
        if (n == 1)
          m_proxyAuthentication = true;

        // Proxy stuff
        m_proxyUrl = (string)regKey.GetValue("ProxyUrl", "");
        m_proxyUserName = (string)regKey.GetValue("ProxyUserName", "");
        m_proxyPassword = (string)regKey.GetValue("ProxyPassport", "");
        m_proxyPort = (int)regKey.GetValue("ProxyPort", 80);

        // Tags
        m_boldTag = (string)regKey.GetValue("BoldTag", "b");
        m_italicsTag = (string)regKey.GetValue("ItalicTag", "i");
        m_underlineTag = (string)regKey.GetValue("UnderlineTag", "u");
        m_musicTag = (string)regKey.GetValue("MusicTag", "[ARTIST] - [SONG]");
        m_uploadPath = (string)regKey.GetValue("UploadPath", "");
        m_imageTag = (string)regKey.GetValue("ImageTag", "<img src=\"[IMAGELINK]\">");

        // Site info
        m_blogId = (string)regKey.GetValue("BlogId", "-1");
        m_userName = (string)regKey.GetValue("UserName", "");
        m_password = (string)regKey.GetValue("Password", "");
        m_hostName = (string)regKey.GetValue("HostName", "www.hostname.com");
        if (m_hostName.IndexOf("typepad.com") > -1)
          m_blogMode = BlogEngine.TypePad;
        else
          m_blogMode = BlogEngine.MovableType;

        m_cgiPath = (string)regKey.GetValue("CgiPath", "/cgipath/mt-xmlrpc.cgi");
        m_port = (int)regKey.GetValue("Port", 80);
        n = 0;
        n = (int)regKey.GetValue("UseSsl", 0);
        if (n == 1)
          m_useSsl = true;
        

        m_selectedBlogId = (int)regKey.GetValue("SelBlog", 0);
        m_maxLinksToRefresh = (string)regKey.GetValue("Posts", "10");
        m_selectedUrlTab = (int)regKey.GetValue("UrlTab", 0);
        n = 0;
        n = (int)regKey.GetValue("RefreshAll", 0);
        if (n == 1)
          m_refreshAllPosts = true;

        n = 0;
        n = (int)regKey.GetValue("LinkDetails", 0);
        if (n == 1)
          showLinksDetails = true;

        // font information
        n = 0;
        n = (int)regKey.GetValue("FontBold", 0);
        if (n == 1)
          m_boldFont = true;
        n = 0;
        n = (int)regKey.GetValue("FontItalic", 0);
        if (n == 1)
          m_italicFont = true;

        m_fontName = (string)regKey.GetValue("FontName", "Microsoft Sans Serif");
        m_fontPointSize = (float)Convert.ToSingle(regKey.GetValue("FontSize", "8.25"));

        // insert url after upload
        n = 1;
        n = (int)regKey.GetValue("InsertImageUrl", 1);
        if (n == 0)
          m_insertImageUrl = false;

        m_titleColumnWidth = (int)regKey.GetValue("ColTitle", -1);
        m_idColumnWidth = (int)regKey.GetValue("ColID", 40);
        m_currentSortedColumn = (int)regKey.GetValue("ColSorted", 1);
        n = 0;
        n = (int)regKey.GetValue("ColSortedOrder", 0);
        if (n == 1)
          m_ascendingSortForLinks = true;

        m_urlLinksTitleWidth = (int)regKey.GetValue("UrlColTitle", 700);
        m_urlLinksIdWidth = (int)regKey.GetValue("UrlColID", 40);
        m_currentSortingUrlLinks = (int)regKey.GetValue("UrlColSorted", 1);
        n = 0;
        n = (int)regKey.GetValue("UrlColSortedOrder", 0);
        if (n == 1)
          m_ascendingSortForUrlLinks = true;

        m_target = (string)regKey.GetValue("DefaultTarget", "");
        m_urlPrefix = (string)regKey.GetValue("UrlPrefix", "http://");

        // read in the Blog Lists
        RegistryKey regSubKey = Registry.CurrentUser.OpenSubKey(RegistryKeyName + @"\BlogList");
        if (regSubKey != null)
        {
          int nCount = regSubKey.ValueCount / 2;
          for (int i = 0; i < nCount; i++)
          {
            string id = (string)regSubKey.GetValue(String.Format("Id{0}", i));
            string name = (string)regSubKey.GetValue(String.Format("Name{0}", i));
            string url = (string)regSubKey.GetValue(String.Format("Url{0}", i), "");
            if ((id != null) && (name != null))
            {
              BlogItem blogItem = new BlogItem(id, name, url);
              m_blogList.Add(blogItem);
            }
          }
          regSubKey.Close();
        }

        regSubKey = Registry.CurrentUser.OpenSubKey(RegistryKeyName + @"\CategoryList");
        if (regSubKey != null)
        {
          int nCount = regSubKey.ValueCount / 2;
          for (int i = 0; i < nCount; i++)
          {
            string id = (string)regSubKey.GetValue(String.Format("Id{0}", i));
            string name = (string)regSubKey.GetValue(String.Format("Name{0}", i));
            if ((id != null) && (name != null))
            {
              CategoryItem categoryItem = new CategoryItem(id, name);
              m_categoriesList.Add(categoryItem);
            }
          }
          regSubKey.Close();
        }

        regSubKey = Registry.CurrentUser.OpenSubKey(RegistryKeyName + @"\TextFilterList");
        if (regSubKey != null)
        {
          int nCount = regSubKey.ValueCount / 2;
          for (int i = 0; i < nCount; i++)
          {
            string id = (string)regSubKey.GetValue(String.Format("Id{0}", i));
            string name = (string)regSubKey.GetValue(String.Format("Name{0}", i));
            if ((id != null) && (name != null))
            {
              CategoryItem textFilter = new CategoryItem(id, name);
              m_textFiltersList.Add(textFilter);
            }
          }
          regSubKey.Close();
        }

        regSubKey = Registry.CurrentUser.OpenSubKey(RegistryKeyName + @"\MruDraftList");
        if (regSubKey != null)
        {
          int nCount = regSubKey.ValueCount;
          if (nCount > m_maxMRUDrafts)
            nCount = m_maxMRUDrafts;
          for (int i = 0; i < nCount; i++)
          {
            string name = (string)regSubKey.GetValue(String.Format("Name{0}", i));
            if (name != null)
            {
              m_mruDraftsList.Add(name);
            }
          }
          regSubKey.Close();
        }

        // custom tags
        regSubKey = Registry.CurrentUser.OpenSubKey(RegistryKeyName + @"\CustomTags");
        if (regSubKey != null)
        {
          int nCount = regSubKey.ValueCount / 2;
          for (int i = 0; i < nCount; i++)
          {
            string name = (string)regSubKey.GetValue(String.Format("Name{0}", i));
            int enclose = (int)regSubKey.GetValue(String.Format("Enclose{0}", i), 0);
            if (name != null)
            {
              CustomTag customTag = new CustomTag(name, enclose);
              this.m_customTagsList.Add(customTag);
            }
          }
          regSubKey.Close();
        }

        // plugins
        regSubKey = Registry.CurrentUser.OpenSubKey(RegistryKeyName + @"\PlugIns");
        if (regSubKey != null)
        {
          int nCount = regSubKey.ValueCount / 2;
          for (int i = 0; i < nCount; i++)
          {
            string name= (string)regSubKey.GetValue(String.Format("Name{0}", i));
            string path = (string)regSubKey.GetValue(String.Format("Path{0}", i), 0);
            if (name != null)
            {
              PlugInItem plugInItem = new PlugInItem(name, path);
              this.m_plugInsList.Add(plugInItem);
            }
          }
          regSubKey.Close();
        }

        // links list
        regSubKey = Registry.CurrentUser.OpenSubKey(RegistryKeyName + @"\Urls");
        if (regSubKey != null)
        {
          int nCount = regSubKey.ValueCount;
          for (int i = 0; i < nCount; i++)
          {
            string url = (string)regSubKey.GetValue(String.Format("Name{0}", i));
            if (url != null)
            {
              this.m_urlList.Add(url);
            }
          }
          regSubKey.Close();
        }

        regKey.Close();
      }

      UpdateMruList(false);

      // Update object
      m_defaultAdvancedSettings.Status = status;
      m_defaultAdvancedSettings.Format = formatting;
      m_defaultAdvancedSettings.Comments = comment;
      m_defaultAdvancedSettings.AllowPings = setPings;
      m_defaultAdvancedSettings.UseServerTime = useServerTime;

      // make sure the draft directory exists!
      Directory.CreateDirectory(m_draftsFolder);

      // read links
      XmlTextReader xmlReader = null;
      try
      {
        xmlReader = new XmlTextReader(m_dataFolder + "blogLinks.xml");
        xmlReader.WhitespaceHandling = WhitespaceHandling.None;
        EntryItem entryItem = new EntryItem();
        while (xmlReader.Read())
        {
          string strElement = xmlReader.ReadString();
          switch (xmlReader.Name)
          {
            case "id": //linkID
              entryItem.ID = strElement;
              break;
            case "title": // title
              entryItem.Title = strElement;
              break;
            case "body": //body
              entryItem.Body = strElement;
              break;
            case "datetime": //dateTime
              entryItem.DateTime = strElement;
              break;
            case "url": //url
              entryItem.Url = strElement;
              System.Windows.Forms.ListViewItem item = linksListView.Items.Add(entryItem.Title, 1);
              item.Tag = entryItem;
              item.SubItems.Add(entryItem.ID);
              if (Convert.ToInt32(entryItem.ID) > m_topId)
                m_topId = Convert.ToInt32(entryItem.ID);
              entryItem = new EntryItem();
              break;
          }
        }
      }
      catch
      {
      }
      finally
      {
        if (xmlReader != null)
          xmlReader.Close();
      }

      statusStripPanelLinks.Text = string.Format("Links: {0}", linksListView.Items.Count);

      if (showLinks)
        m_dockingManager.ShowContent(m_dockingManager.Contents["Blog Links"]);
      else
        m_dockingManager.HideContent(m_dockingManager.Contents["Blog Links"]);

      // Set the details
      linksBody.Visible = showLinksDetails;
      this.showDetailsToolStripMenuItem.Checked = showLinksDetails;

      // Set the WinPos
      m_windowsRectangle = rc;
      DesktopBounds = m_windowsRectangle;
      WindowState = (System.Windows.Forms.FormWindowState)winState;

      if (this.m_launchParameters.Length == 0)
      {
        SetFileTypeEntry();
        SetUrlTypeEntry();
      }
    }

    private void SetFileTypeEntry()
    {
      RegistryKey regOpenKey = Registry.ClassesRoot.OpenSubKey(@"SharpMTDraft\shell\open\command");

      if (regOpenKey != null)
        return;

      RegistryKey regKey = Registry.ClassesRoot.CreateSubKey(".smt");

      regKey.SetValue("", "SharpMTDraft");
      regKey.SetValue("Content Type", "text/xml");

      regKey.Close();

      regKey = null;

      regKey = Registry.ClassesRoot.CreateSubKey("SharpMTDraft");
      regKey.SetValue("", "SharpMT Draft");

      RegistryKey regIcon = regKey.CreateSubKey("DefaultIcon");
      regIcon.SetValue("", m_applicationFolder);
      regIcon.Close();

      RegistryKey regShell = regKey.CreateSubKey(@"shell\open\command");
      regShell.SetValue("", m_applicationFolder + " \"%l\""); //l for the long file name
      regShell.Close();

      regKey.Close();

      regKey = null;
    }

    private void SetUrlTypeEntry()
    {
      RegistryKey regOpenKey = Registry.ClassesRoot.OpenSubKey(@"sharpmt\shell\open\command");

      if (regOpenKey != null)
        return;

      // now the URL stuff
      RegistryKey regKey = Registry.ClassesRoot.CreateSubKey("sharpmt");

      regKey.SetValue("", "URL:SharpMT");
      regKey.SetValue("URL Protocol", "");
      regKey.SetValue("EditFlags", 2);

      RegistryKey regIcon = regKey.CreateSubKey("DefaultIcon");
      regIcon.SetValue("", m_applicationFolder);
      regIcon.Close();

      RegistryKey regShell = regKey.CreateSubKey(@"shell\open\command");
      regShell.SetValue("", m_applicationFolder + " \"%l\""); //l for the long file name
      regShell.Close();

      regKey.Close();

      regKey = null;
    }

    private void SaveRegistrySettings()
    {
      RegistryKey regKey = Registry.CurrentUser.CreateSubKey(RegistryKeyName);

      // save the drafts directory
      regKey.SetValue("DraftDirectory", m_draftsFolder);

      // drop downs
      regKey.SetValue("CurStatus", m_defaultAdvancedSettings.Status);
      regKey.SetValue("CurFormatting", m_defaultAdvancedSettings.Format);
      regKey.SetValue("CurComment", m_defaultAdvancedSettings.Comments);
      int n = 0;
      if (m_defaultAdvancedSettings.AllowPings)
        n = 1;
      regKey.SetValue("CurPing", n);

      n = 0;
      if (m_defaultAdvancedSettings.UseServerTime)
        n = 1;
      regKey.SetValue("CurTime", n);

      regKey.SetValue("RSSField", m_rssField);

      // Save Window Pos
      regKey.SetValue("MainWinState", (int)WindowState);
      regKey.SetValue("MainX", m_windowsRectangle.X);
      regKey.SetValue("MainY", m_windowsRectangle.Y);
      regKey.SetValue("MainCX", m_windowsRectangle.Width);
      regKey.SetValue("MainCY", m_windowsRectangle.Height);

      regKey.SetValue("HeaderCY", m_headerHeight);
      regKey.SetValue("BodyCY", m_bodyHeight);
      regKey.SetValue("FooterCY", m_footerHeight);

      // Save Link Show
      n = 0;
      if (m_dockingManager.Contents["Blog Links"].Visible == true)
        n = 1;
      regKey.SetValue("ShowLinks", n);

      // Save Tracing
      n = 0;
      if (m_tracing == true)
        n = 1;
      regKey.SetValue("Tracing", n);
      // Save MinToTray
      n = 0;
      if (m_minimizeToSysTray == true)
        n = 1;
      regKey.SetValue("MinToTray", n);
      // Save Proxy flag
      n = 0;
      if (m_proxy == true)
        n = 1;
      regKey.SetValue("UseProxy", n);
      n = 0;
      if (m_proxyAuthentication == true)
        n = 1;
      regKey.SetValue("UseProxyAuthentication", n);

      // Proxy stuff
      regKey.SetValue("ProxyUrl", m_proxyUrl);
      regKey.SetValue("ProxyUserName", m_proxyUserName);
      regKey.SetValue("ProxyPassport", m_proxyPassword);
      regKey.SetValue("ProxyPort", m_proxyPort);

      // Tags
      regKey.SetValue("BoldTag", m_boldTag);
      regKey.SetValue("ItalicTag", m_italicsTag);
      regKey.SetValue("UnderlineTag", m_underlineTag);
      regKey.SetValue("MusicTag", m_musicTag);
      regKey.SetValue("UploadPath", m_uploadPath);
      regKey.SetValue("ImageTag", m_imageTag);

      regKey.SetValue("BlogId", m_blogId);
      regKey.SetValue("UserName", m_userName);
      regKey.SetValue("Password", m_password);
      regKey.SetValue("HostName", m_hostName);
      regKey.SetValue("CgiPath", m_cgiPath);
      regKey.SetValue("SelBlog", m_selectedBlogId);
      regKey.SetValue("Posts", m_maxLinksToRefresh);
      regKey.SetValue("UrlTab", m_selectedUrlTab);
      regKey.SetValue("Port", m_port);
      n = 0;
      if (m_useSsl)
        n = 1;
      regKey.SetValue("UseSsl", n);

      n = 0;
      if (m_refreshAllPosts)
        n = 1;
      regKey.SetValue("RefreshAll", n);

      n = 0;
      if (linksBody.Visible)
        n = 1;
      regKey.SetValue("LinkDetails", n);
      regKey.SetValue("LinksDetCY", linksBody.Height);

      // Font details
      n = 0;
      if (m_boldFont)
        n = 1;
      regKey.SetValue("FontBold", n);
      n = 0;
      if (m_italicFont)
        n = 1;
      regKey.SetValue("FontItalic", n);

      regKey.SetValue("FontName", m_fontName);
      regKey.SetValue("FontSize", m_fontPointSize);
      regKey.SetValue("UrlPrefix", m_urlPrefix);

      regKey.SetValue("ColTitle", m_titleColumnWidth);
      regKey.SetValue("ColID", m_idColumnWidth);
      regKey.SetValue("ColSorted", m_currentSortedColumn);
      n = 0;
      if (m_ascendingSortForLinks)
        n = 1;
      regKey.SetValue("ColSortedOrder", n);

      regKey.SetValue("UrlColTitle", m_urlLinksTitleWidth);
      regKey.SetValue("UrlColID", m_urlLinksIdWidth);
      regKey.SetValue("UrlColSorted", m_currentSortingUrlLinks);
      n = 0;
      if (m_ascendingSortForUrlLinks)
        n = 1;
      regKey.SetValue("UrlColSortedOrder", n);

      // Save insert image flag
      n = 0;
      if (m_insertImageUrl == true)
        n = 1;
      regKey.SetValue("InsertImageUrl", n);

      regKey.SetValue("DefaultTarget", m_target);

      // set the BlogLists
      RegistryKey regSubKey = Registry.CurrentUser.OpenSubKey(RegistryKeyName + @"\BlogList", true);
      // remove if it existed
      if (regSubKey != null)
      {
        regSubKey.Close();
        regKey.DeleteSubKey("BlogList");
      }
      // create new
      regSubKey = Registry.CurrentUser.CreateSubKey(RegistryKeyName + @"\BlogList");
      for (int i = 0; i < m_blogList.Count; i++)
      {
        BlogItem blogItem = m_blogList[i];
        regSubKey.SetValue(String.Format("Id{0}", i), blogItem.ID);
        regSubKey.SetValue(String.Format("Name{0}", i), blogItem.Name);
        regSubKey.SetValue(String.Format("Url{0}", i), blogItem.Url);
      }
      regSubKey.Close();

      // set the CategoriesLists
      regSubKey = Registry.CurrentUser.OpenSubKey(RegistryKeyName + @"\CategoryList", true);
      // remove if it existed
      if (regSubKey != null)
      {
        regSubKey.Close();
        regKey.DeleteSubKey("CategoryList");
      }
      // create new
      regSubKey = Registry.CurrentUser.CreateSubKey(RegistryKeyName + @"\CategoryList");
      for (int i = 0; i < m_categoriesList.Count; i++)
      {
        CategoryItem categoryItem = m_categoriesList[i];
        regSubKey.SetValue(String.Format("Id{0}", i), categoryItem.ID);
        regSubKey.SetValue(String.Format("Name{0}", i), categoryItem.Name);
      }
      regSubKey.Close();

      // set the TextFilterLists
      regSubKey = Registry.CurrentUser.OpenSubKey(RegistryKeyName + @"\TextFilterList", true);
      // remove if it existed
      if (regSubKey != null)
      {
        regSubKey.Close();
        regKey.DeleteSubKey("TextFilterList");
      }
      // create new
      regSubKey = Registry.CurrentUser.CreateSubKey(RegistryKeyName + @"\TextFilterList");
      for (int i = 0; i < m_textFiltersList.Count; i++)
      {
        CategoryItem textFilterItem = m_textFiltersList[i];
        regSubKey.SetValue(String.Format("Id{0}", i), textFilterItem.ID);
        regSubKey.SetValue(String.Format("Name{0}", i), textFilterItem.Name);
      }
      regSubKey.Close();

      // set the MruLinks
      regSubKey = Registry.CurrentUser.OpenSubKey(RegistryKeyName + @"\MruDraftList", true);
      // remove if it existed
      if (regSubKey != null)
      {
        regSubKey.Close();
        regKey.DeleteSubKey("MruDraftList");
      }
      // create new
      regSubKey = Registry.CurrentUser.CreateSubKey(RegistryKeyName + @"\MruDraftList");
      for (int i = 0; i < m_mruDraftsList.Count; i++)
      {
        regSubKey.SetValue(String.Format("Name{0}", i), m_mruDraftsList[i]);
      }
      regSubKey.Close();

      // set the tags
      regSubKey = Registry.CurrentUser.OpenSubKey(RegistryKeyName + @"\CustomTags", true);
      // remove if it existed
      if (regSubKey != null)
      {
        regSubKey.Close();
        regKey.DeleteSubKey("CustomTags");
      }
      // create new
      regSubKey = Registry.CurrentUser.CreateSubKey(RegistryKeyName + @"\CustomTags");
      for (int i = 0; i < m_customTagsList.Count; i++)
      {
        CustomTag customTag = m_customTagsList[i];
        regSubKey.SetValue(String.Format("Name{0}", i), customTag.Tag);
        regSubKey.SetValue(String.Format("Enclose{0}", i), (customTag.Closed ? 1 : 0));
      }
      regSubKey.Close();

      // set plugins
      regSubKey = Registry.CurrentUser.OpenSubKey(RegistryKeyName + @"\PlugIns", true);
      // remove if it existed
      if (regSubKey != null)
      {
        regSubKey.Close();
        regKey.DeleteSubKey("PlugIns");
      }
      // create new
      regSubKey = Registry.CurrentUser.CreateSubKey(RegistryKeyName + @"\PlugIns");
      for (int i = 0; i < m_plugInsList.Count; i++)
      {
        PlugInItem plugInItem = m_plugInsList[i];
        regSubKey.SetValue(String.Format("Name{0}", i), plugInItem.Name);
        regSubKey.SetValue(String.Format("Path{0}", i), plugInItem.Path);
      }
      regSubKey.Close();

      // set the url MRU list
      regSubKey = Registry.CurrentUser.OpenSubKey(RegistryKeyName + @"\Urls", true);
      // remove if it existed
      if (regSubKey != null)
      {
        regSubKey.Close();
        regKey.DeleteSubKey("Urls");
      }
      // create new
      regSubKey = Registry.CurrentUser.CreateSubKey(RegistryKeyName + @"\Urls");
      for (int i = 0; i < m_urlList.Count; i++)
      {
        regSubKey.SetValue(String.Format("Name{0}", i), m_urlList[i]);
      }
      regSubKey.Close();

      regKey.Close();

      m_dockingManager.SaveConfigToFile(m_magicConfigurationFile);
    }

    public void RegistrKeyChanged(object state, bool timedOut)
    {
      if (!timedOut)
      {
        // get the registry key
        RegistryKey regKey = Registry.CurrentUser.OpenSubKey(m_notifiedKeyName, true);
        if (regKey == null)
        {
          return; //nothing to do here
        }
        else
        {
          string value = (string)regKey.GetValue("Argument", "");
          if (value.Length == 0)
          {
            // value wasn't there (means it's closing)
            regKey.Close();
            return;
          }
          else
          {
            // remove the key to avoid multiple pile ups
            regKey.DeleteValue("Argument");
            regKey.Close();

            // new window was requested, so do nothing
            if (value == "ShartpMT.OpenNewWindow")
            {
            }
            else
            {
              // delegate stuff is here for the benefit of processing arguments
              OpenFileDelegate openFileDelegate = new OpenFileDelegate(ProcessTheOpenCommand);
              if (value.StartsWith("/plug-in:"))
              {
                // this comes from the plug in
                m_launchParameters = value.Replace("/plug-in:", "");
                m_validFileAndBlog = false;
              }
              else if (value.StartsWith("sharpmt://")) {
                m_launchParameters = value.Replace("sharpmt://", "");
                m_validFileAndBlog = false;
              }
              else
              {
                // this comes from a .SMT file
                m_launchParameters = value;
                m_validFileAndBlog = true;
              }
              // invoke the delegate for safe threading
              this.Invoke(openFileDelegate);
            }
          }
        }

        // if you've gotten this far, always show the window
        Invoke((System.Windows.Forms.MethodInvoker)delegate
        {
          if (this.WindowState == System.Windows.Forms.FormWindowState.Minimized)
            this.WindowState = System.Windows.Forms.FormWindowState.Normal;
          this.Activate();
        });
        // close the monitoring key and reopen it
        NativeCode.RegCloseKey(m_notifiedKeyReturnValue);
        NativeCode.RegOpenKeyEx((int)Microsoft.Win32.RegistryHive.CurrentUser, m_notifiedKeyName, 0, NativeCode.KEY_READ, out m_notifiedKeyReturnValue);
        if (m_notifiedKeyReturnValue != 0)
        {
          //ask for notification
          //NativeCode.RegNotifyChangeKeyValue(m_notifiedKeyReturnValue, 1, NativeCode.REG_NOTIFY_CHANGE_LAST_SET, m_mainWaitHandle.Handle.ToInt32(), 1);
          NativeCode.RegNotifyChangeKeyValue(m_notifiedKeyReturnValue, 1, NativeCode.REG_NOTIFY_CHANGE_LAST_SET, m_mainWaitHandle.SafeWaitHandle.DangerousGetHandle().ToInt32(), 1);

          //let thread pool handle the rest
          System.Threading.ThreadPool.RegisterWaitForSingleObject(m_mainWaitHandle,
            new System.Threading.WaitOrTimerCallback(RegistrKeyChanged), m_notifiedKeyName, -1, true);
        }
      }
    }
  }
}
