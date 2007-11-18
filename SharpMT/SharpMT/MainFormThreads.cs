#region Using directives

using System;
using System.Xml;
using System.Windows.Forms;
using System.Reflection;
using System.Threading;
using System.Collections.Generic;
using System.Text;
using SharpMT.Forms;
using SharpMT.Classes;

#endregion

namespace SharpMT
{
  partial class MainForm
  {
    private static void SplashScreenThread()
    {
      m_splashScreen = new SplashScreenForm();
      m_splashScreen.ShowDialog();
    }

    private void GetEditThread()
    {
      if (m_linkId.Length == 0)
      {
        MessageBox.Show("Please select a Blog Link to edit!", MainForm.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Error);
        return;
      }

      string xmlText = "";
      Invoke((MethodInvoker)delegate
      {
        statusStripPanelMain.Text = "Getting post data...";
      });

      xmlText = GetEditPostData();

      if (xmlText.Length == 0)
      {
        MessageBox.Show("Error connecting to Blog server!", MainForm.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Error);
        Invoke((MethodInvoker)delegate { TurnOffTheWaiting(); });
        return;
      }
      
      XmlDocument document = new XmlDocument();
      XmlNode xmlNode = null;
      try
      {
        ﻿if (xmlText[0] == MainForm.m_deadCharacter) //clean up the garbage from Spaces
          xmlText = xmlText.Remove(0, 1);
        document.LoadXml(xmlText);
        xmlNode = document.SelectSingleNode("/methodResponse/params/param/value/struct");
      }
      catch
      {
        xmlNode = null;
      }

      if (xmlNode == null)
      {
        xmlNode = document.SelectSingleNode("/methodResponse/fault/value/struct/member/value/string");
        if (xmlNode == null)
          MessageBox.Show("Error connecting to Blog server!", MainForm.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Error);
        else
          MessageBox.Show(xmlNode.InnerXml, MainForm.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Error);

        Invoke((MethodInvoker)delegate { TurnOffTheWaiting(); });
        return;
      }

      XmlNodeReader xmlReader = new XmlNodeReader(xmlNode);
      PostItem postItem = new PostItem();
      bool startTag = true;
      string valueName = "";
      string endTag = "struct";
      while (xmlReader.Read())
      {
        if (xmlReader.Name == "name")
        {
          string element = xmlReader.ReadString();
          switch (element)
          {
            case "userid": // userid
            case "dateCreated": // dateCreated
            case "postid": // postid
            case "description": // description
            case "title": // title
            case "link": // link
            case "permaLink": // permaLink
            case "mt_excerpt": // mt_excerpt
            case "mt_text_more": // mt_text_more
            case "mt_allow_comments": // mt_allow_comments
            case "mt_allow_pings": // mt_allow_pings
            case "mt_convert_breaks": // mt_convert_breaks
            case "mt_keywords": // mt_keywords
              valueName = element;
              break;
            default:
              valueName = "";
              break;
          }
        }
        else if ((xmlReader.Name == "string") || (xmlReader.Name == "int") || (xmlReader.Name == "dateTime.iso8601"))
        {
          string element = xmlReader.ReadString();
          switch (valueName)
          {
            case "userid": // userid
              break;
            case "dateCreated": // dateCreated
              postItem.DateTime = element;
              if (m_blogMode == BlogEngine.MovableType) {
                postItem.DateTime = postItem.DateTime.Insert(4, "-"); //0123-
                postItem.DateTime = postItem.DateTime.Insert(7, "-"); //0123456-
              }
              break;
            case "postid": // postid
              postItem.PostId = element;
              break;
            case "description": // description
              postItem.Entry = element.Replace("\n", "\r\n");
              break;
            case "title": // title
              postItem.Title = element;
              break;
            case "link": // link
              break;
            case "permaLink": // permaLink
              break;
            case "mt_excerpt": // mt_excerpt
              postItem.Excerpt = element.Replace("\n", "\r\n");
              break;
            case "mt_text_more": // mt_text_more
              postItem.Extended = element.Replace("\n", "\r\n");
              break;
            case "mt_allow_comments": // mt_allow_comments
              postItem.AllowComments = element;
              break;
            case "mt_allow_pings": // mt_allow_pings
              postItem.AllowPings = element;
              break;
            case "mt_convert_breaks": // mt_convert_breaks
              postItem.TextFormatting = element;
              break;
            case "mt_keywords": // mt_keywords
              postItem.Keyword = element;
              break;
          }
        }
        else if (xmlReader.Name == endTag)
        {
          if (startTag)
          {
            startTag = false;
          }
          else
          {
            postItem.PostStatus = "1"; // Status = Post;
            postItem.IsPosted = true;
            break;
          }
        }
      }

      // now get the categories
      statusStripPanelMain.Text = "Getting post categories...";
      xmlText = GetEditCategoryData();

      if (xmlText.Length == 0)
      {
        MessageBox.Show("Error connecting to Blog server!", MainForm.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Error);
        Invoke((MethodInvoker)delegate { TurnOffTheWaiting(); });
        return;
      }
      document = new XmlDocument();
      try
      {
        ﻿if (xmlText[0] == MainForm.m_deadCharacter) //clean up the garbage from Spaces
          xmlText = xmlText.Remove(0, 1);
        document.LoadXml(xmlText);
        xmlNode = document.SelectSingleNode("/methodResponse/params/param/value/array/data");
      }
      catch
      {
        xmlNode = null;
      }

      if (xmlNode == null)
      {
        xmlNode = document.SelectSingleNode("/methodResponse/fault/value/struct/member/value/string");
        if (xmlNode == null)
          MessageBox.Show("Error connecting to Blog server!", MainForm.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Error);
        else
          MessageBox.Show(xmlNode.InnerXml, MainForm.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Error);

        Invoke((MethodInvoker)delegate { TurnOffTheWaiting(); });
        return;
      }

      xmlReader = new XmlNodeReader(xmlNode);
      startTag = true;
      valueName = "";
      endTag = "struct";
      string category = "";
      bool isPrimary = false;
      while (xmlReader.Read())
      {
        if (xmlReader.Name == "name")
        {
          string element = xmlReader.ReadString();
          switch (element)
          {
            case "categoryId": // categoryId
            case "isPrimary": // isPrimary
            case "categoryName": // categoryName
              valueName = element;
              break;
            default:
              valueName = "";
              break;
          }
        }
        else if ((xmlReader.Name == "string") || (xmlReader.Name == "boolean"))
        {
          string element = xmlReader.ReadString();
          switch (valueName)
          {
            case "categoryId": // categoryId
              category = element;
              break;
            case "isPrimary": // isPrimary
              if (element == "1")  // true
                isPrimary = true;
              else
                isPrimary = false;
              break;
            case "categoryName": // categoryName
              break;
          }
        }
        else if (xmlReader.Name == endTag)
        {
          if (startTag)
          {
            startTag = false;
          }
          else
          {
            if (isPrimary)
              postItem.Categories.Insert(0, category);
            else
              postItem.Categories.Add(category);
            isPrimary = false;
            category = "";
            startTag = true;
          }
        }
      }

      // populate the tab
      Invoke((MethodInvoker)delegate
      {
        m_currentDraft.PushUiData(postItem);
        TurnOffTheWaiting(); 
      });
    }

    private void UpdateCategoriesThread()
    {
      Invoke((MethodInvoker)delegate
      {
        statusStripPanelMain.Text = "Updating categories...";
      });

      string xml = GetOtherData("mt.getCategoryList", m_blogId, m_userName, m_password);

      if (xml.Length == 0)
      {
        MessageBox.Show("Error connecting to Blog server!", MainForm.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Error);

        Invoke((MethodInvoker)delegate { TurnOffTheWaiting(); });
        return;
      }

      XmlDocument document = new XmlDocument();
      XmlNode xmlNode = null;
      try
      {
        ﻿if (xml[0] == MainForm.m_deadCharacter) //clean up the garbage from Spaces
           xml = xml.Remove(0, 1);
        document.LoadXml(xml);
        xmlNode = document.SelectSingleNode("/methodResponse/params/param/value/array/data");
      }
      catch
      {
        xmlNode = null;
      }

      if (xmlNode == null)
      {
        xmlNode = document.SelectSingleNode("/methodResponse/fault/value/struct/member/value/string");
        if (xmlNode == null)
          MessageBox.Show("Error connecting to Blog server!", MainForm.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Error);
        else
          MessageBox.Show(xmlNode.InnerXml, MainForm.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Error);

        Invoke((MethodInvoker)delegate { TurnOffTheWaiting(); });
        return;
      }

      XmlNodeReader xmlReader = new XmlNodeReader(xmlNode);
      m_categoriesList.Clear();
      CategoryItem categoryItem = new CategoryItem();
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
            case "categoryId": // categoryId
            case "categoryName": // categoryName
              valueName = element;
              break;
            default:
              valueName = "";
              break;
          }
        }
        else if (xmlReader.Name == "string")
        {
          string element = xmlReader.ReadString();
          switch (valueName)
          {
            case "categoryId": // categoryId
              categoryItem.ID = element;
              break;
            case "categoryName": // categoryName
              categoryItem.Name = element;
              break;
          }
        }
        else if (xmlReader.Name == endTag)
        {
          if (isStartTag)
          {
            categoryItem = new CategoryItem();
            isStartTag = false;
          }
          else
          {
            m_categoriesList.Add(categoryItem);
            isStartTag = true;
          }
        }
      }

      // Sort the array
      Comparison<CategoryItem> comp = new Comparison<CategoryItem>(CompareCategories);
      m_categoriesList.Sort(comp);

      Invoke((MethodInvoker)delegate
      {
        // Pop through the Array and update the list(s)
        int currentTabIndex = draftTabs.SelectedIndex;

        int tabIndex = draftTabs.TabPages.Count - 1;
        while (tabIndex > -1)
        {
          draftTabs.SelectedIndex = tabIndex;
          DraftControl currentControl = (DraftControl)draftTabs.TabPages[tabIndex].Controls[0];

          int pos = currentControl.category.SelectedIndex;
          currentControl.category.Items.Clear();
          currentControl.category.Items.Add("(none)");
          for (int field = 0; field < m_categoriesList.Count; field++)
          {
            categoryItem = m_categoriesList[field];
            currentControl.category.Items.Add(categoryItem.Name);
          }
          if (pos >= m_categoriesList.Count)
          {
            pos = 0;
          }
          currentControl.category.SelectedIndex = pos;
          currentControl.category.Focus();

          // Set the CatButton
          if (currentControl.category.Items.Count > 2)
            currentControl.selectCategories.Enabled = true;
          else
            currentControl.selectCategories.Enabled = false;

          tabIndex--;
        }
        draftTabs.SelectedIndex = currentTabIndex;

        SaveDataFiles();

        TurnOffTheWaiting();
      });
    }

    private void UpdateTextFiltersThread()
    {
      Invoke((MethodInvoker)delegate
      {
        statusStripPanelMain.Text = "Updating text filters...";
      });

      string xml = GetTextFilterData("mt.supportedTextFilters");

      if (xml.Length == 0)
      {
        MessageBox.Show("Error connecting to Blog server!", MainForm.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Error);

        Invoke((MethodInvoker)delegate { TurnOffTheWaiting(); });
        return;
      }
      XmlDocument document = new XmlDocument();
      XmlNode xmlNode = null;
      try
      {
        ﻿if (xml[0] == MainForm.m_deadCharacter) //clean up the garbage from Spaces
           xml = xml.Remove(0, 1);
        document.LoadXml(xml);
        xmlNode = document.SelectSingleNode("/methodResponse/params/param/value/array/data");
      }
      catch
      {
        xmlNode = null;
      }

      if (xmlNode == null)
      {
        xmlNode = document.SelectSingleNode("/methodResponse/fault/value/struct/member/value/string");
        if (xmlNode == null)
          MessageBox.Show("Error connecting to Blog server!", MainForm.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Error);
        else
          MessageBox.Show(xmlNode.InnerXml, MainForm.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Error);

        Invoke((MethodInvoker)delegate { TurnOffTheWaiting(); });
        return;
      }

      XmlNodeReader xmlReader = new XmlNodeReader(xmlNode);
      m_textFiltersList.Clear();
      CategoryItem textFilter = new CategoryItem();
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
            case "key": // key
            case "label": // label
              valueName = element;
              break;
            default:
              valueName = "";
              break;
          }
        }
        else if (xmlReader.Name == "string")
        {
          string element = xmlReader.ReadString();
          switch (valueName)
          {
            case "key": // key
              textFilter.ID = element;
              break;
            case "label": // label
              textFilter.Name = element;
              break;
          }
        }
        else if (xmlReader.Name == endTag)
        {
          if (isStartTag)
          {
            textFilter = new CategoryItem();
            isStartTag = false;
          }
          else
          {
            m_textFiltersList.Add(textFilter);
            isStartTag = true;
          }
        }
      }

      Invoke((MethodInvoker)delegate
      {
        // Pop through the Array and update the list(s)
        int currentTabIndex = draftTabs.SelectedIndex;

        int tabIndex = draftTabs.TabPages.Count - 1;
        while (tabIndex > -1)
        {
          draftTabs.SelectedIndex = tabIndex;
          DraftControl currentControl = (DraftControl)draftTabs.TabPages[tabIndex].Controls[0];

          int pos = currentControl.formatting.SelectedIndex;
          currentControl.formatting.Items.Clear();
          currentControl.formatting.Items.Add("None");
          for (int field = 0; field < m_textFiltersList.Count; field++)
          {
            textFilter = m_textFiltersList[field];
            currentControl.formatting.Items.Add(textFilter.Name);
          }
          if (pos >= m_textFiltersList.Count)
          {
            pos = 0;
          }
          currentControl.formatting.SelectedIndex = pos;

          tabIndex--;
        }
        draftTabs.SelectedIndex = currentTabIndex;

        SaveDataFiles();
      
        TurnOffTheWaiting();
      });
    }

    private void UpdateLinksThread()
    {
      bool refreshAllPosts = false;

      Invoke((MethodInvoker)delegate
      {
        // if no links, force a complete refresh
        if (linksListView.Items.Count <= 0)
        {
          m_refreshAllPosts = true;
        }

        linksListView.ListViewItemSorter = null;

        refreshAllPosts = m_refreshAllPosts;
      });

      string testId = "";
      int update = 0, tempTop = 0;

      if (!refreshAllPosts)
      {
        Invoke((MethodInvoker)delegate
        {
          statusStripPanelMain.Text = "Determining link status...";
          if (m_topId < 0)
            m_topId = 0;
        });

        // grab the first ID and compare it to the first in the list
        string xmlLocal = GetSinglePostData(m_blogId, m_userName, m_password);

        if (xmlLocal.Length == 0)
        {
          MessageBox.Show("Error connecting to Blog server!", MainForm.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Error);

          Invoke((MethodInvoker)delegate { TurnOffTheWaiting(); }); 
          return;
        }
        XmlDocument documentLocal = new XmlDocument();
        XmlNode xmlNodeLocal = null;
        try
        {
        ﻿  if (xmlLocal[0] == MainForm.m_deadCharacter) //clean up the garbage from Spaces
            xmlLocal = xmlLocal.Remove(0, 1);
          documentLocal.LoadXml(xmlLocal);
          xmlNodeLocal = documentLocal.SelectSingleNode("/methodResponse/params/param/value/array/data");
        }
        catch
        {
          xmlNodeLocal = null;
        }

        if (xmlNodeLocal == null)
        {
          xmlNodeLocal = documentLocal.SelectSingleNode("/methodResponse/fault/value/struct/member/value/string");
          if (xmlNodeLocal == null)
            MessageBox.Show("Error connecting to Blog server!", MainForm.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Error);
          else
            MessageBox.Show(xmlNodeLocal.InnerXml, MainForm.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Error);

          Invoke((MethodInvoker)delegate { TurnOffTheWaiting(); }); 
          return;
        }

        XmlNodeReader xmlReaderLocal = new XmlNodeReader(xmlNodeLocal);
        string valueNameLocal = "";
        bool isStopLocal = false;
        while ((xmlReaderLocal.Read()) && (!isStopLocal))
        {
          if (xmlReaderLocal.Name == "name")
          {
            string elementLocal = xmlReaderLocal.ReadString();
            switch (elementLocal)
            {
              case "postid": // postId
                valueNameLocal = elementLocal;
                break;
              default:
                valueNameLocal = "";
                break;
            }
          }
          else if (xmlReaderLocal.Name == "string")
          {
            string elementLocal = xmlReaderLocal.ReadString();
            switch (valueNameLocal)
            {
              case "postid": // postId
                testId = elementLocal;
                isStopLocal = true;
                break;
            }
          }
        }

        Invoke((MethodInvoker)delegate { 
          // find out if there's a more up to date version on the server
          tempTop = m_topId;
          update = Convert.ToInt32(testId) - m_topId;
          if (update <= 0)
          { // they are the same, so don't synchronize
            TurnOffTheWaiting();
            return;
          }
          // cap the number of downloads
          if (update > Convert.ToInt32(m_maxLinksToRefresh))
          {
            update = Convert.ToInt32(m_maxLinksToRefresh);
          }
          statusStripPanelMain.Text = "Updating links...";
        }); 
      }
      else
      {
        Invoke((MethodInvoker)delegate { 
          // doing a refresh, so clear all
          linksListView.Items.Clear();
          m_topId = -1;
          statusStripPanelMain.Text = "Downloading all links... (this may take a while)";
        });
      }

      // grab the rest of the posts
      string xml = GetRecentPostData(m_blogId, m_userName, m_password, m_maxLinksToRefresh);

      if (xml.Length == 0)
      {
        MessageBox.Show("Error connecting to Blog server!", MainForm.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Error);

        Invoke((MethodInvoker)delegate { TurnOffTheWaiting(); });
        return;
      }
      XmlDocument document = new XmlDocument();
      XmlNode xmlNode = null;
      try
      {
         ﻿if (xml[0] == MainForm.m_deadCharacter) //clean up the garbage from Spaces
           xml = xml.Remove(0, 1);
         document.LoadXml(xml);
         xmlNode = document.SelectSingleNode("/methodResponse/params/param/value/array/data");
      }
      catch
      {
         xmlNode = null;
      }
      if (xmlNode == null)
      {
        xmlNode = document.SelectSingleNode("/methodResponse/fault/value/struct/member/value/string");
        if (xmlNode == null)
          MessageBox.Show("Error connecting to Blog server!", MainForm.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Error);
        else
          MessageBox.Show(xmlNode.InnerXml, MainForm.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Error);

        Invoke((MethodInvoker)delegate { TurnOffTheWaiting(); });
        return;
      }

      XmlNodeReader xmlReader = new XmlNodeReader(xmlNode);
      int inserted = 0;
      EntryItem entryItem = new EntryItem();
      bool stop = false;
      string valueName = "";
      bool isStartTag = true;
      string endTag = "struct";
      while ((xmlReader.Read()) && (!stop))
      {
        if (xmlReader.Name == "name")
        {
          string element = xmlReader.ReadString();
          switch (element)
          {
            case "permaLink": //entryURL
            case "description": //entryDescription
            case "title": // entryTitle
            case "postid": // entryId
            case "dateCreated": // dateCreated
              valueName = element;
              break;
            default:
              valueName = "";
              break;
          }
        }
        else if ((xmlReader.Name == "string") || (xmlReader.Name == "dateTime.iso8601"))
        {
          string element = xmlReader.ReadString();
          switch (valueName)
          {
            case "permaLink": //entryURL
              entryItem.Url = element;
              break;
            case "description": //entryDescription
              entryItem.Body = element;
              break;
            case "title": // entryTitle
              entryItem.Title = element;
              break;
            case "postid": // entryId
              entryItem.ID = element;
              break;
            case "dateCreated": // entryDate
              entryItem.DateTime = element;
              if (m_blogMode == BlogEngine.MovableType)
              {
                entryItem.DateTime = entryItem.DateTime.Insert(4, "-"); //0123-
                entryItem.DateTime = entryItem.DateTime.Insert(7, "-"); //0123456-
              }
              break;
          }
        }
        else if (xmlReader.Name == endTag)
        {
          if (isStartTag)
          {
            entryItem = new EntryItem();
            isStartTag = false;
          }
          else
          {
            // check for partial updates
            if (!refreshAllPosts)
            {
              // if doing a partial and there is an overlap, stop and get out
              if (entryItem.ID == Convert.ToString(tempTop))
              {
                stop = true;
                break;
              }
            }
            Invoke((MethodInvoker)delegate
            {
              // either way, just add it to the array
              ListViewItem item = linksListView.Items.Add(entryItem.Title, 1);
              item.Tag = entryItem;
              item.SubItems.Add(entryItem.ID);
              if (Convert.ToInt32(entryItem.ID) > m_topId)
                m_topId = Convert.ToInt32(entryItem.ID);
              inserted++;

              statusStripPanelMain.Text = string.Format("Processing links ({0})...", inserted);
            });
            entryItem = new EntryItem();
            isStartTag = true;
          }
        }
      }


      Invoke((MethodInvoker)delegate
      {
        // reactivate the sorting
        if (m_currentSortedColumn == 0)
          linksListView.ListViewItemSorter = new ListViewItemStringComparer(m_ascendingSortForLinks);
        else
          linksListView.ListViewItemSorter = new ListViewItemIntComparer(m_ascendingSortForLinks);
        linksListView.Sort();

        if (linksListView.Visible)
          linksListView.Focus();

        SaveDataFiles();
        statusStripPanelLinks.Text = string.Format("Links: {0}", linksListView.Items.Count);
        TurnOffTheWaiting();
      });
    }

    private void UpdatePostThread(object list)
    {
      List<PostItem> postItemList = (List<PostItem>)list;
      int successfulPosts = 0;

      for (int i = 0; i < postItemList.Count; i++)
      {
        PostItem postItem = postItemList[i];
        string xml = GetPostData(postItem, postItem.NewDraft, i);

        if (xml.Length > 0)
        {
          XmlDocument document = new XmlDocument();
          XmlNode xmlNode = null;
          try
          {
            ﻿ if (xml[0] == MainForm.m_deadCharacter) //clean up the garbage from Spaces
               xml = xml.Remove(0, 1);
             document.LoadXml(xml);
             xmlNode = document.SelectSingleNode("/methodResponse/params/param/value");
          }
          catch
          {
            xmlNode = null;
          }

          if (xmlNode != null)
          {
            XmlNodeReader xmlReader = new XmlNodeReader(xmlNode);
            string newPostId = "";
            if (postItem.NewDraft)
            {
              while (xmlReader.Read())
              {
                if (xmlReader.Name == "string")
                {
                  string element = xmlReader.ReadString();
                  newPostId = element;
                  break;
                }
              }
            }
            else
            {
              newPostId = postItem.PostId;
            }

            // now set the Category - also allows for NO category
            if (postItem.Categories.Count > 0)
            {
              Invoke((MethodInvoker)delegate { statusStripPanelMain.Text = "Setting categories of new entry..."; });
              string returnValue = SetCategoryData(newPostId, postItem.Categories);
              if (returnValue.Length > 0)
              {
                //form the rebuild
                Invoke((MethodInvoker)delegate { statusStripPanelMain.Text = "Rebuilding entry..."; });
                SetRebuildMT(newPostId);
              }
            }

            if (postItem.NewDraft)
            {
              Invoke((MethodInvoker)delegate
              {
                int currentIndex = postItem.CurrentIndex;
                if (currentIndex == -1)
                  currentIndex = (postItemList.Count - 1) - i;

                draftTabs.SelectedIndex = currentIndex;
                ((DraftControl)draftTabs.TabPages[currentIndex].Controls[0]).SetPosted(true);
                saveDraftToolStripMenuItem.PerformClick();
                successfulPosts++;
              });
            }
          }
          else
          {
            xmlNode = document.SelectSingleNode("/methodResponse/fault/value/struct/member/value/string");
            if (xmlNode == null)
              MessageBox.Show("Error connecting to Blog server!", MainForm.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
              MessageBox.Show(xmlNode.InnerXml, MainForm.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Error);
          }
        }
        else
        {
          MessageBox.Show("Error connecting to Blog server!", MainForm.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
      }

      if (successfulPosts > 0)
      {
        bool keepUpdate = m_refreshAllPosts;
        string keepPosts = m_maxLinksToRefresh;
        m_refreshAllPosts = false;
        m_maxLinksToRefresh = string.Format("{0}", successfulPosts);
        UpdateLinksThread();
        // reset values
        m_refreshAllPosts = keepUpdate;
        m_maxLinksToRefresh = keepPosts;
      }

      Invoke((MethodInvoker)delegate { TurnOffTheWaiting(); });
    }

    private void UploadFileThread()
    {
      UploadFileData(m_localFileName, m_remoteFileName);

      // clean up
      m_localFileName = "";
      m_remoteFileName = "";

      // done!
      Invoke((MethodInvoker)delegate { TurnOffTheWaiting(); });

      if (m_imageLink.Length > 0)
      {
        if (m_currentControl != null)
        {
          m_currentControl.Focus();

          string str = m_imageTag;
          str = str.Replace("[IMAGELINK]", m_imageLink);
          str = str.Replace("[ALTTAG]", m_altImageTag);
          ((TextBox)m_currentControl).SelectedText = str;
        }
      }
    }
  }
}
