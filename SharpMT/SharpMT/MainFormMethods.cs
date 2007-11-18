#region Using directives

using System;
using System.Collections.Generic;
using System.Xml;
using SharpMT.Classes;
using SharpMT.Forms;
using System.Windows.Forms;
using System.IO;
using System.Threading;
using System.Collections;
using Microsoft.Win32;
using RandyRants.SharpMTExtension;

#endregion

namespace SharpMT
{
  partial class MainForm
  {
    private void UpdateMruList(bool clear)
    {
      if (clear)
      {
        for (int i = 0; i < recentDraftsToolStripMenuItem.DropDownItems.Count; i++)
        {
          recentDraftsToolStripMenuItem.DropDownItems[i].Text = String.Format("&{0}", i + 1);
          recentDraftsToolStripMenuItem.DropDownItems[i].Visible = false;
        }
      }
      // Update MRU
      for (int i = 0; i < m_mruDraftsList.Count; i++)
      {
        String str = m_mruDraftsList[i];
        if (str.IndexOf(m_draftsFolder) == 0)
          str = str.Replace(m_draftsFolder, "");
        recentDraftsToolStripMenuItem.DropDownItems[i].Text = String.Format("&{0} {1}", i + 1, str);
        recentDraftsToolStripMenuItem.DropDownItems[i].Visible = true;
      }

      if (m_mruDraftsList.Count == 0)
      {
        recentDraftsToolStripMenuItem.DropDownItems[0].Visible = true;
        recentDraftsToolStripMenuItem.DropDownItems[0].Enabled = false;
        recentDraftsToolStripMenuItem.DropDownItems[0].Text = "(recent drafts)";
      }
      else
        recentDraftsToolStripMenuItem.DropDownItems[0].Enabled = true;
    }

    private void UpdateConnectionMenuToolbar()
    {
      bool state = true;
      if (m_blogId == "-1")
      {
        state = false;
        optionsToolStripButton.ToolTipText = "Options - Setup First!";
        optionsToolStripMenuItem.Text = "&Options... << Setup First!";
        UpdateTextBoxMenuToolbar(false, false);
      }
      else
      {
        optionsToolStripButton.ToolTipText = "Options";
        optionsToolStripMenuItem.Text = "&Options...";
      }

      updateLinksToolStripButton.Enabled = state;
      updateBlogLinksToolStripMenuItem.Enabled = state;
      updateCategoriesToolStripButton.Enabled = state;
      updateCategoriesToolStripMenuItem.Enabled = state;
      updateTextFiltersToolStripButton.Enabled = state;
      updateTextFiltersToolStripMenuItem.Enabled = state;
      uploadImageToolStripButton.Enabled = state;
      uploadImageToolStripMenuItem.Enabled = state;
      openDraftToolStripButton.Enabled = state;
      openDraftToolStripMenuItem.Enabled = state;
      newDraftToolStripButton.Enabled = state;
      newDraftToolStripMenuItem.Enabled = state;
      saveDraftToolStripButton.Enabled = state;
      saveDraftToolStripMenuItem.Enabled = state;
      saveAllDraftsToolStripMenuItem.Enabled = state;
    }

    private void UpdateCustomTags()
    {
      // Menu
      for (int i = 0; i < customTagsToolStripMenuItem.DropDownItems.Count; i++)
      {
        customTagsToolStripMenuItem.DropDownItems[i].Visible = false;
        if (i < 9)
          customTagsToolStripMenuItem.DropDownItems[i].Text = string.Format("Custom Tag &{0}", i + 1);
        else
          customTagsToolStripMenuItem.DropDownItems[i].Text = "Custom Tag 1&0";
      }

      // Toolbar
      for (int i = 0; i < customTagsToolStripButton.DropDownItems.Count; i++)
      {
        customTagsToolStripButton.DropDownItems[i].Visible = false;
        if (i < 9)
          customTagsToolStripButton.DropDownItems[i].Text = string.Format("Custom Tag &{0}", i + 1);
        else
          customTagsToolStripButton.DropDownItems[i].Text = "Custom Tag 1&0";
      }

      // Rebuild both
      for (int i = 0; i < m_customTagsList.Count; i++)
      {
        customTagsToolStripMenuItem.DropDownItems[i].Visible = true;
        customTagsToolStripMenuItem.DropDownItems[i].Enabled = true;
        customTagsToolStripMenuItem.DropDownItems[i].Tag = m_customTagsList[i];
        customTagsToolStripButton.DropDownItems[i].Visible = true;
        customTagsToolStripButton.DropDownItems[i].Enabled = true;
        customTagsToolStripButton.DropDownItems[i].Tag = m_customTagsList[i];
        if (i < 9)
        {
          customTagsToolStripMenuItem.DropDownItems[i].Text = string.Format("&{0} <{1}>", i + 1, m_customTagsList[i].Tag);
          customTagsToolStripButton.DropDownItems[i].Text = string.Format("&{0} <{1}>", i + 1, m_customTagsList[i].Tag);
        }
        else
        {
          customTagsToolStripMenuItem.DropDownItems[i].Text = string.Format("1&0 <{0}>", m_customTagsList[i].Tag);
          customTagsToolStripButton.DropDownItems[i].Text = string.Format("1&0 <{0}>", m_customTagsList[i].Tag);
        }
      }
    }

    private void UpdatePlugIns()
    {
      // Menu
      for (int i = 0; i < plugInsToolStripMenuItem.DropDownItems.Count; i++)
      {
        plugInsToolStripMenuItem.DropDownItems[i].Visible = false;
        if (i < 9)
          plugInsToolStripMenuItem.DropDownItems[i].Text = string.Format("Plug-In &{0}", i + 1);
        else
          plugInsToolStripMenuItem.DropDownItems[i].Text = "Plug-In 1&0";
      }

      // Toolbar
      for (int i = 0; i < plugInsToolStripButton.DropDownItems.Count; i++)
      {
        plugInsToolStripButton.DropDownItems[i].Visible = false;
        if (i < 9)
          plugInsToolStripButton.DropDownItems[i].Text = string.Format("Plug-In &{0}", i + 1);
        else
          plugInsToolStripButton.DropDownItems[i].Text = "Plug-In 1&0";
      }

      // Rebuild both
      for (int i = 0; i < m_plugInsList.Count; i++)
      {
        plugInsToolStripMenuItem.DropDownItems[i].Visible = true;
        plugInsToolStripMenuItem.DropDownItems[i].Enabled = true;
        plugInsToolStripMenuItem.DropDownItems[i].Tag = m_plugInsList[i];
        plugInsToolStripButton.DropDownItems[i].Visible = true;
        plugInsToolStripButton.DropDownItems[i].Enabled = true;
        plugInsToolStripButton.DropDownItems[i].Tag = m_plugInsList[i];
        if (i < 9)
        {
          plugInsToolStripMenuItem.DropDownItems[i].Text = string.Format("&{0} {1}", i + 1, m_plugInsList[i].Name);
          plugInsToolStripButton.DropDownItems[i].Text = string.Format("&{0} {1}", i + 1, m_plugInsList[i].Name);
        }
        else
        {
          plugInsToolStripMenuItem.DropDownItems[i].Text = string.Format("1&0 {0}", m_plugInsList[i].Name);
          plugInsToolStripButton.DropDownItems[i].Text = string.Format("1&0 {0}", m_plugInsList[i].Name);
        }
      }
    }

    internal void UpdateTextBoxMenuToolbar(bool isTextSelected, bool isInEditBox)
    {
      cutToolStripMenuItem.Enabled = isTextSelected;
      copyToolStripMenuItem.Enabled = isTextSelected;
      pasteToolStripMenuItem.Enabled = isTextSelected;
      deleteToolStripMenuItem.Enabled = isTextSelected;
      findToolStripMenuItem.Enabled = isInEditBox;
      selectAllToolStripMenuItem.Enabled = isInEditBox;
      boldToolStripMenuItem.Enabled = isInEditBox;
      italicToolStripMenuItem.Enabled = isInEditBox;
      underlineToolStripMenuItem.Enabled = isInEditBox;
      urlToolStripMenuItem.Enabled = isInEditBox;
      nowPlayingToolStripMenuItem.Enabled = isInEditBox;
      customTagsToolStripMenuItem.Enabled = isInEditBox;
      plugInsToolStripMenuItem.Enabled = isInEditBox;

      cutToolStripButton.Enabled = cutToolStripMenuItem.Enabled;
      copyToolStripButton.Enabled = copyToolStripMenuItem.Enabled;
      pasteToolStripButton.Enabled = pasteToolStripMenuItem.Enabled;
      deleteToolStripButton.Enabled = deleteToolStripMenuItem.Enabled;
      findToolStripButton.Enabled = findToolStripMenuItem.Enabled;
      boldToolStripButton.Enabled = boldToolStripMenuItem.Enabled;
      italicToolStripButton.Enabled = italicToolStripMenuItem.Enabled;
      underlineToolStripButton.Enabled = underlineToolStripMenuItem.Enabled;
      urlToolStripButton.Enabled = urlToolStripMenuItem.Enabled;
      nowPlayingToolStripButton.Enabled = nowPlayingToolStripMenuItem.Enabled;
      customTagsToolStripButton.Enabled = customTagsToolStripMenuItem.Enabled;
      plugInsToolStripButton.Enabled = plugInsToolStripMenuItem.Enabled;
    }

    private void AddDraftTab(string title)
    {
      // unique case when opening the first one
      if ((draftTabs.TabPages.Count == 1) && (draftTabs.SelectedTab.Title == "untitled"))
      {
        //m_ctrlCurDraft = ((Control_Draft)draftTabs.SelectedTab.Controls[0]);
        draftTabs.SelectedTab.Title = title;
        return;
      }

      Crownwood.Magic.Controls.TabPage defaultTabPage = null;

      SharpMT.DraftControl draftControl = null;

      draftControl = new SharpMT.DraftControl(this, false);
      draftControl.Dock = System.Windows.Forms.DockStyle.Fill;
      draftControl.Location = new System.Drawing.Point(0, 0);
      draftControl.Name = "draftControl" + draftTabs.TabPages.Count;
      draftControl.Size = new System.Drawing.Size(734, 549);
      draftControl.TabIndex = 1;
      draftControl.header.Height = m_headerHeight;
      if (m_headerHeight == draftControl.splitter.MinSize)
        draftControl.minimizeHeader.Text = "Restore";
      draftControl.footer.Height = m_footerHeight;
      if (m_footerHeight == draftControl.splitter.MinSize)
        draftControl.minimizeFooter.Text = "Restore";
      draftControl.body.Height = m_bodyHeight;

      defaultTabPage = new Crownwood.Magic.Controls.TabPage();

      defaultTabPage.Controls.Add(draftControl);
      defaultTabPage.Location = new System.Drawing.Point(0, 25);
      defaultTabPage.Name = "defaultTabPage" + draftTabs.TabPages.Count; //tbpDefault
      defaultTabPage.Size = new System.Drawing.Size(734, 549);
      defaultTabPage.TabIndex = 3;
      defaultTabPage.Title = title;
      defaultTabPage.ImageIndex = 0;

      draftTabs.TabPages.Add(defaultTabPage);
      draftTabs.SelectedIndex = draftTabs.TabPages.Count - 1;

      // Multi-draft
      m_currentDraft = draftControl;

      // Begin:SPELLCHECK_REM
      //axSpellicanCtrl1.AttachAllWindows((int)CP.Windows.Forms.UnManagedMethods.FindWindow(null, "SharpMT"));
      // End:SPELLCHECK_REM
    }

    private void AddEditTab(string editTitle)
    {
      // unique case when opening the first one
      if ((draftTabs.TabPages.Count == 1) && (draftTabs.SelectedTab.Title == "untitled") && (((DraftControl)draftTabs.SelectedTab.Controls[0]).m_editMode == false))
      {
        draftTabs.TabPages.RemoveAt(0);
      }

      Crownwood.Magic.Controls.TabPage defaultTabPage = null;// tbpDefault = null;
      SharpMT.DraftControl draftControl = null; // ctrlDraft = null;

      draftControl = new SharpMT.DraftControl(this, true);
      draftControl.Dock = System.Windows.Forms.DockStyle.Fill;
      draftControl.Location = new System.Drawing.Point(0, 0);
      draftControl.Name = "draftControl" + draftTabs.TabPages.Count; //"ctrlDraft"
      draftControl.Size = new System.Drawing.Size(734, 549);
      draftControl.TabIndex = 1;
      draftControl.header.Height = m_headerHeight;
      if (m_headerHeight == draftControl.splitter.MinSize)
        draftControl.minimizeHeader.Text = "Restore";
      draftControl.footer.Height = m_footerHeight;
      if (m_footerHeight == draftControl.splitter.MinSize)
        draftControl.minimizeFooter.Text = "Restore";
      draftControl.body.Height = m_bodyHeight;

      defaultTabPage = new Crownwood.Magic.Controls.TabPage();
      defaultTabPage.Controls.Add(draftControl);
      defaultTabPage.Location = new System.Drawing.Point(0, 25);
      defaultTabPage.Name = "defaultTabPage" + draftTabs.TabPages.Count; //"tbpDefault"
      defaultTabPage.Size = new System.Drawing.Size(734, 549);
      defaultTabPage.TabIndex = 3;
      defaultTabPage.Title = editTitle;
      defaultTabPage.ImageIndex = 1;

      draftTabs.TabPages.Add(defaultTabPage);
      draftTabs.SelectedIndex = draftTabs.TabPages.Count - 1;

      // Multi-draft
      m_currentDraft = draftControl;

      // Begin:SPELLCHECK_REM
      //axSpellicanCtrl1.AttachAllWindows((int)CP.Windows.Forms.UnManagedMethods.FindWindow(null, "SharpMT"));
      // End:SPELLCHECK_REM
    }

    //private void ResizeStatusBarPanel()
    //{
    //  statusStripPanelMain.Width = statusStripPanelLinks.Bounds.Left - statusStripPanelMain.Bounds.Left;
    //}

    private void SaveDataFiles()
    {
      // set the LinksList
      XmlTextWriter xmlWriter = new XmlTextWriter(m_dataFolder + "blogLinks.xml", System.Text.Encoding.ASCII);
      xmlWriter.Formatting = Formatting.Indented;
      xmlWriter.Namespaces = false;
      xmlWriter.WriteStartDocument();
      xmlWriter.WriteStartElement("blogLinks");
      for (int i = 0; i < linksListView.Items.Count; i++)
      {
        EntryItem entryItem = (EntryItem)linksListView.Items[i].Tag;
        xmlWriter.WriteStartElement("entryItem");
        xmlWriter.WriteAttributeString("id", entryItem.ID);
        xmlWriter.WriteElementString("name", entryItem.ID);
        xmlWriter.WriteElementString("id", entryItem.ID);
        xmlWriter.WriteElementString("title", entryItem.Title);
        xmlWriter.WriteElementString("body", entryItem.Body);
        xmlWriter.WriteElementString("datetime", entryItem.DateTime);
        xmlWriter.WriteElementString("url", entryItem.Url);
        xmlWriter.WriteEndElement();
      }
      xmlWriter.WriteEndElement();
      xmlWriter.WriteEndDocument();
      xmlWriter.Close();
    }

    internal void TurnOffTheWaiting()
    {
      SetCursors(false);
      PrepProgress(false);
      statusStripPanelMain.Text = "Ready";
    }

    private void SetCursors(bool wait)
    {
      Cursor cr = (wait ? Cursors.WaitCursor : Cursors.Default);
      this.Cursor = cr;

      for (int i = 0; i < Controls.Count; i++)
      {
        Controls[i].Enabled = !wait;
        Controls[i].Cursor = cr;
      }
    }

    private void PrepProgress(bool start)
    {
      statusStripPanelBlog.Visible = !start;
      toolStripProgressBar.Visible = start;

      if (start)
      {
        statusStrip.Enabled = true;
      }
      else
      {
        SetCursors(false);
      }
    }

    private void ProcessTheOpenCommand()
    {
      int currentTab = draftTabs.SelectedIndex;
      if ((m_launchParameters.Length > 0) && (m_selectedBlogId != -1))
      {
        if (m_validFileAndBlog)
        {
          if (File.Exists(m_launchParameters))
          {
            // only open an existing thing IF it's there and sent in AND the blog has been initialized!
            string title = m_launchParameters;
            AddDraftTab(title.Substring(title.LastIndexOf(@"\") + 1));
            m_currentDraft.OpenFile(title);
          }
        }
        else
        {
          String rss = "";
          // open a new item either way!
          newDraftToolStripButton.PerformClick();
          
          if (File.Exists(m_launchParameters))
          {
            // text came from the BlogThis plug in
            using (FileStream fs = new FileStream(m_launchParameters, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
              byte[] bf = new byte[1024];
              int n = fs.Read(bf, 0, bf.Length);
              System.Text.ASCIIEncoding utf = new System.Text.ASCIIEncoding();
              while (n > 0)
              {
                rss += utf.GetString(bf, 0, n);
                n = fs.Read(bf, 0, bf.Length);
              }
              fs.Close();
            }
            File.Delete(m_launchParameters);
          }
          else {
            // text came from a sharpmt:// URL
            rss = m_launchParameters;

            rss = rss.Remove(rss.Length - 1); // remove the Last character
            if (rss.Length == 0)
            {
              MessageBox.Show("No text was sent from your browser!", MainForm.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Information);
              return;
            }

            rss = System.Web.HttpUtility.UrlDecode(rss);
          }
          
          switch (m_rssField)
          {
            case 0:
              m_currentDraft.entryBody.Text = rss;
              break;
            case 1:
              m_currentDraft.extendedEntry.Text = rss;
              break;
            case 2:
              m_currentDraft.excerpt.Text = rss;
              break;
            case 3:
              m_currentDraft.keywords.Text = rss;
              break;
            case 4:
              m_currentDraft.title.Text = rss;
              break;
          }
        }
      }
      else
      {
        // open a new thingy
        newDraftToolStripButton.PerformClick();
      }

      // if it was posting when something was asked for, restore the tab for obvious reasons!
      if (draftTabs.Enabled == false)
      {
        if (currentTab > -1)
          draftTabs.SelectedIndex = currentTab;
      }
    }

    private void OpenLinkInEditMode()
    {
      ListView.SelectedIndexCollection indexCollection = linksListView.SelectedIndices;
      if (indexCollection.Count <= 0)
        return;

      EntryItem entryItem = (EntryItem)linksListView.Items[indexCollection[0]].Tag;
      m_linkId = entryItem.ID;

      SetCursors(true);
      PrepProgress(true);

      AddEditTab(entryItem.Title);

      Thread t = new Thread(new ThreadStart(GetEditThread));
      t.Start();
    }

    private int CompareCategories(CategoryItem x, CategoryItem y)
    {
      return ((new CaseInsensitiveComparer()).Compare(x.Name, y.Name));
    }

    private Control DrillDownEdit(Control control)
    {
      if (control == null)
        return control;

      if (control.Name.IndexOf("draftControl") > -1)
      {
        DraftControl draftControl = (DraftControl)control;
        return draftControl.ActiveControl;
      }
      return control;
    }

    private bool CheckTextBox(Control control)
    {
      switch (control.Name)
      {
        case "title":
        case "entryBody":
        case "extendedEntry":
        case "excerpt":
        case "linksBody":
        case "keywords":
        case "pings":
          return true;
      }
      return false;
    }

    private void UpdateTheMruArray()
    {
      if (m_currentDraft.localFilename.Text != "")
      {
        for (int i = 0; i < m_mruDraftsList.Count; i++)
        {
          if (m_mruDraftsList[i] == m_currentDraft.localFilename.Text)
          {
            m_mruDraftsList.RemoveAt(i);
            break;
          }
        }

        while (m_mruDraftsList.Count >= m_maxMRUDrafts)
        {
          m_mruDraftsList.RemoveAt(m_mruDraftsList.Count - 1);
        }
        m_mruDraftsList.Insert(0, m_currentDraft.localFilename.Text);
        UpdateMruList(true);
      }
    }

    private void RemoveFromTheMruArray(string filename) {
      for (int i = 0; i < m_mruDraftsList.Count; i++) {
        if (m_mruDraftsList[i] == filename) {
          m_mruDraftsList.RemoveAt(i);
          break;
        }
      }
      UpdateMruList(true);
    }

    private bool FillInMusicString(ref string returnString)
    {
      RegistryKey regKey = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\MediaPlayer\CurrentMetaData");
      if (regKey == null)
      {
        returnString = "Could not find music playing!\r\n\r\nHave you installed a music plug-in yet?";
        return false;
      }

      string musicTag = m_musicTag;
      string str = "";
      int n = 0;
      str = (string)regKey.GetValue("Author", "");
      if (str == "")
        n++;
      musicTag = musicTag.Replace("[ARTIST]", str);

      str = (string)regKey.GetValue("Album", "");
      if (str == "")
        n++;
      musicTag = musicTag.Replace("[ALBUM]", str);

      str = (string)regKey.GetValue("DurationString", "");
      if (str == "")
        n++;
      musicTag = musicTag.Replace("[DURATION]", str);

      str = (string)regKey.GetValue("Title", "");
      if (str == "")
        n++;
      musicTag = musicTag.Replace("[SONG]", str);

      regKey.Close();
      if (n == 4)
      {
        returnString = "No music is playing!";
        return false;
      }

      returnString = musicTag;
      return true;
    }

    private void InsertTheTag(TextBox control, CustomTag customTag)
    {
      string tag;
      if (customTag.Closed)
      {
        String closingTag = customTag.Tag;
        if (customTag.Tag.IndexOf(" ") > -1)
        {
          closingTag = customTag.Tag.Substring(0, customTag.Tag.IndexOf(" "));
        }
        tag = string.Format("<{0}>{1}</{2}>", customTag.Tag, control.SelectedText, closingTag);
      }
      else
        tag = string.Format("<{0}>", customTag.Tag);

      control.SelectedText = tag;
    }

    private void RunThePlugIn(TextBox control, PlugInItem plugInItem)
    {
      ISharpMTExtension extension = null;
      String version = "";
      try
      {
        // Load the assembly based on file name
        System.Reflection.Assembly assembly = System.Reflection.Assembly.LoadFrom(plugInItem.Path);
        // Load in the list of available types
        Type[] typeList = assembly.GetTypes();
        Type typePlugin = null;
        // Go through the list of types
        for (int i = 0; i < typeList.Length; i++)
        {
          // Check to see if the current class/type supports my Interface
          if (typeList[i].GetInterface(typeof(ISharpMTExtension).FullName) != null)
          {
            // if the interface is supported, break the search
            typePlugin = typeList[i];
            break;
          }
        }

        // if an interface was found in the plug in
        if (typePlugin != null)
        {
          // create an instance and set the crap up
          extension = (ISharpMTExtension)Activator.CreateInstance(typePlugin);
          version = assembly.GetName().Version.ToString();
        }
      }
      catch
      {
        MessageBox.Show("This DLL did not respond as a SharpMT Extension Plug-In should!\n\nPlease verify that it is a proper Plug-In and try again.", MainForm.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Stop);
        return;
      }

      // check to see if #MT has to supply the UI
      if (extension.HasInputGUI)
      {
        SetCursors(true);
        PrepProgress(true);

        ExecuteStringThread executeStringThread = new ExecuteStringThread(extension, control, this);
        Thread thread = new Thread(new ThreadStart(executeStringThread.ThreadProc));
        thread.Start();
      }
      else
      {
        // Open the dialog to grab params
        InsertPlugInDataForm insertPlugInDataForm = new InsertPlugInDataForm();
        insertPlugInDataForm.m_extension = extension;
        if (extension.ParametersPassed >= 1)
        {
          insertPlugInDataForm.labelOne.Visible = true;
          insertPlugInDataForm.labelOne.Text = extension.ParamOne + ":";
          insertPlugInDataForm.textBoxOne.Visible = true;
        }
        if (extension.ParametersPassed >= 2)
        {
          insertPlugInDataForm.labelTwo.Visible = true;
          insertPlugInDataForm.labelTwo.Text = extension.ParamTwo + ":";
          insertPlugInDataForm.textBoxTwo.Visible = true;
        }
        if (extension.ParametersPassed >= 3)
        {
          insertPlugInDataForm.labelThree.Visible = true;
          insertPlugInDataForm.labelThree.Text = extension.ParamThree + ":";
          insertPlugInDataForm.textBoxThree.Visible = true;
        }

        insertPlugInDataForm.m_version = version;
        // show the right results box, depending on which mode you're in
        insertPlugInDataForm.m_showList = extension.ReturnsList;

        // show the dialog
        if (insertPlugInDataForm.ShowDialog() == DialogResult.OK)
        {
          if (!extension.ReplaceSelectedText) {
            control.SelectionStart = control.SelectionStart + control.SelectionLength;
            control.SelectionLength = 0; // prevents an overwrite
          }
          if (extension.ReturnsList)
            control.SelectedText = insertPlugInDataForm.listBoxResults.SelectedItem.ToString();
          else
            control.SelectedText = insertPlugInDataForm.textBoxResults.Text;
        }
      }
    }

    internal void UpdateTheUIFromThePlugIn(string returnValue, TextBox control, bool hasGUI, bool replaceSelectedText)
    {
      if (!replaceSelectedText) {
        control.SelectionStart = control.SelectionStart + control.SelectionLength;
        control.SelectionLength = 0; // prevents an overwrite
      }
      control.SelectedText = returnValue;

      if (hasGUI)
      {
        TurnOffTheWaiting();
        control.Focus();
      }
    }

    private void SpellCheck(TextBox control)
    {
      // Begin:SPELLCHECK_REM
      //string fixedText = "";
      //fixedText = axSpellicanCtrl1.CheckSpellingEx(control.Text, true, -1, "");
      //if (fixedText == null)
      //  return;
      //else
      //  control.Text = fixedText;
      // End:SPELLCHECK_REM
    }

    private void UpdatePost(bool multiPost)
    {
      int currentTab = draftTabs.TabPages.Count - 1;
      List<PostItem> postItemList = new List<PostItem>();

      // run through the tabs, building a list of PostItems
      while (currentTab > -1)
      {
        DraftControl draftControl = null;
        if (!multiPost)
        {
          draftControl = (DraftControl)draftTabs.TabPages[draftTabs.SelectedIndex].Controls[0];
          if (draftControl.m_editMode)
            statusStripPanelMain.Text = "Posting updated entry...";
          else
            statusStripPanelMain.Text = "Posting new entry...";

        }
        else
        {
          draftTabs.SelectedIndex = currentTab;
          draftControl = (DraftControl)draftTabs.TabPages[draftTabs.SelectedIndex].Controls[0];
          statusStripPanelMain.Text = string.Format("Posting entry #{0}...", postItemList.Count);
        }
        // Get the most recent data
        PostItem postItem = draftControl.GrabUiData();
        if (draftControl.m_editMode)
        {
          postItem.NewDraft = false;
        }
        else
        {
          postItem.NewDraft = true;
        }
        postItemList.Add(postItem);

        // break outta the loop b/c there's only one
        if (!multiPost)
        {
          postItemList[0].CurrentIndex = draftTabs.SelectedIndex;
          break;
        }

        currentTab--;
      }

      // spawn the thread to post the items
      Thread t = new Thread(new ParameterizedThreadStart(UpdatePostThread));
      t.Start(postItemList);
    }

    private string GetPostData(PostItem postItem, bool newDraft, int currentDraft)
    {
      postItem.EncodeHTML();

      // Go get the list of thingies
      string xml = "";
      string[] pingArray = postItem.Pings.Split('\n');

      string time = string.Format(m_dataFolder + "temp{0}_{1}.xml", DateTime.Now.Ticks, currentDraft);
      XmlTextWriter xmlWriter = new XmlTextWriter(time, System.Text.Encoding.ASCII);
      xmlWriter.Formatting = Formatting.None;
      xmlWriter.Namespaces = false;
      xmlWriter.WriteStartDocument();
      xmlWriter.WriteStartElement("methodCall");
      if (newDraft)
        xmlWriter.WriteElementString("methodName", "metaWeblog.newPost");
      else
        xmlWriter.WriteElementString("methodName", "metaWeblog.editPost");
      xmlWriter.WriteStartElement("params");
      if (newDraft)
        WriteMTParam(ref xmlWriter, "string", m_blogId);
      else
        WriteMTParam(ref xmlWriter, "string", postItem.PostId);
      WriteMTParam(ref xmlWriter, "string", m_userName);
      WriteMTParam(ref xmlWriter, "string", m_password);
      xmlWriter.WriteStartElement("param");
      xmlWriter.WriteStartElement("value");
      xmlWriter.WriteStartElement("struct");
      WriteMTMember(ref xmlWriter, "title", "string", postItem.Title);
      WriteMTMember(ref xmlWriter, "description", "string", postItem.Entry);
      WriteMTMember(ref xmlWriter, "mt_allow_comments", "string", postItem.AllowComments);
      WriteMTMember(ref xmlWriter, "mt_allow_pings", "string", postItem.AllowPings);
      WriteMTMember(ref xmlWriter, "mt_convert_breaks", "string", postItem.TextFormatting);
      WriteMTMember(ref xmlWriter, "mt_text_more", "string", postItem.Extended);
      WriteMTMember(ref xmlWriter, "mt_excerpt", "string", postItem.Excerpt);
      WriteMTMember(ref xmlWriter, "mt_keywords", "string", postItem.Keyword);
      if (postItem.DateTime.Length > 0)
      {
        String str = postItem.DateTime;
        str = str.Replace("-", "");
        WriteMTMember(ref xmlWriter, "dateCreated", /*"dateTime.iso8601"*/"string", str);
      }

      if (pingArray.Length > 0)
      {
        for (int i = 0; i < pingArray.Length; i++)
        {
          if (pingArray[i].Length > 0)
          {
            xmlWriter.WriteStartElement("member");
            xmlWriter.WriteElementString("name", "mt_tb_ping_urls");
            xmlWriter.WriteStartElement("value");
            xmlWriter.WriteStartElement("array");
            xmlWriter.WriteStartElement("data");
            xmlWriter.WriteStartElement("value");
            xmlWriter.WriteElementString("string", pingArray[i]);
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
      WriteMTParam(ref xmlWriter, "boolean", postItem.PostStatus);
      xmlWriter.WriteEndElement(); //"params"
      xmlWriter.WriteEndElement(); //"methodCall"
      xmlWriter.WriteEndDocument();
      xmlWriter.Close();

      xml = "";
      using (FileStream fileStream = new FileStream(time, FileMode.Open, FileAccess.Read, FileShare.Read))
      {
        byte[] byteArray = new byte[1024];
        int n = fileStream.Read(byteArray, 0, byteArray.Length);
        System.Text.ASCIIEncoding utf = new System.Text.ASCIIEncoding();
        while (n > 0)
        {
          xml += utf.GetString(byteArray, 0, n);
          n = fileStream.Read(byteArray, 0, byteArray.Length);
        }
        fileStream.Close();
      }

      File.Delete(time);
      return GetWebData(xml);
    }

    private void WriteMTMember(ref XmlTextWriter xmlWriter, string field, string type, string name)
    {
      xmlWriter.WriteStartElement("member");
      xmlWriter.WriteElementString("name", field);
      xmlWriter.WriteStartElement("value");
      xmlWriter.WriteElementString(type, name);
      xmlWriter.WriteEndElement(); //"value"
      xmlWriter.WriteEndElement(); //"member"
    }

    private void WriteMTParam(ref XmlTextWriter xmlWriter, string type, string name)
    {
      xmlWriter.WriteStartElement("param");
      xmlWriter.WriteStartElement("value");
      xmlWriter.WriteElementString(type, name);
      xmlWriter.WriteEndElement(); //"value"
      xmlWriter.WriteEndElement(); //"param"
    }

    private string SetCategoryData(string postId, List<string> categories)
    {
      // Go get the list of thingies
      string xml;
      string categoryString = "";
      for (int i = 0; i < categories.Count; i++)
      {
        categoryString += string.Format("<value><struct><member><name>categoryId</name><value><string>{0}</string></value></member></struct></value>", categories[i]);
      }
      xml = string.Format("<?xml version=\"1.0\"?><methodCall><methodName>mt.setPostCategories</methodName><params>" +
        "<param><value><string>{0}</string></value></param>" +
        "<param><value><string>{1}</string></value></param>" +
        "<param><value><string>{2}</string></value></param>" +
        "<param><value><array><data>" +
        "{3}" +
        "</data></array></value></param>" +
        "</params></methodCall>", postId, m_userName, m_password, categoryString);

      return GetWebData(xml);
    }

    private string SetRebuildMT(string postId)
    {
      // Go get the list of thingies
      string xml;
      xml = string.Format("<?xml version=\"1.0\"?><methodCall><methodName>mt.publishPost</methodName><params>" +
        "<param><value><string>{0}</string></value></param>" +
        "<param><value><string>{1}</string></value></param>" +
        "<param><value><string>{2}</string></value></param>" +
        "</params></methodCall>", postId, m_userName, m_password);

      return GetWebData(xml);
    }

    private string UploadFileData(string absoluteFileName, string fileName)
    {
      // Go get the list of thingies
      string xml = "";

      string time = string.Format(m_dataFolder + "temp{0}.xml", DateTime.Now.Ticks);
      XmlTextWriter xmlWriter = new XmlTextWriter(time, System.Text.Encoding.ASCII);
      xmlWriter.Formatting = Formatting.None;
      xmlWriter.Namespaces = false;
      xmlWriter.WriteStartDocument();
      xmlWriter.WriteStartElement("methodCall");
      xmlWriter.WriteElementString("methodName", "metaWeblog.newMediaObject");
      xmlWriter.WriteStartElement("params");
      WriteMTParam(ref xmlWriter, "string", m_blogId);
      WriteMTParam(ref xmlWriter, "string", m_userName);
      WriteMTParam(ref xmlWriter, "string", m_password);
      xmlWriter.WriteStartElement("param");
      xmlWriter.WriteStartElement("value");
      xmlWriter.WriteStartElement("struct");
      WriteMTMember(ref xmlWriter, "bits", "base64", "");

      xmlWriter.WriteStartElement("member");
      xmlWriter.WriteElementString("name", "bits");
      xmlWriter.WriteStartElement("value");
      xmlWriter.WriteStartElement("base64");

      FileStream imageFileStream = null;
      try
      {
        imageFileStream = new FileStream(absoluteFileName, FileMode.Open, FileAccess.Read, FileShare.Read);
      }
      catch
      {
        MessageBox.Show("The selected image could not be found!", MainForm.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Error);
        return "";
      }
      BinaryReader binaryReader = new BinaryReader(imageFileStream);
      byte[] imageByteArray = new byte[1024];
      int read = 0;
      try
      {
        do
        {
          read = binaryReader.Read(imageByteArray, 0, imageByteArray.Length);
          xmlWriter.WriteBase64(imageByteArray, 0, read);
        } while (imageByteArray.Length <= read);
      }
      catch (Exception ex)
      {
        EndOfStreamException ex1 = new EndOfStreamException();

        if (ex1.Equals(ex))
        {
          Console.WriteLine("We are at end of file");
        }
        else
        {
          Console.WriteLine(ex);
        }
      }

      xmlWriter.WriteEndElement(); //"base64"
      xmlWriter.WriteEndElement(); //"value"
      xmlWriter.WriteEndElement(); //"member"

      WriteMTMember(ref xmlWriter, "name", "string", fileName);
      xmlWriter.WriteEndElement(); //"struct"
      xmlWriter.WriteEndElement(); //"value"
      xmlWriter.WriteEndElement(); //"param"
      xmlWriter.WriteEndElement(); //"params"
      xmlWriter.WriteEndElement(); //"methodCall"
      xmlWriter.WriteEndDocument();
      xmlWriter.Close();

      xml = "";
      using (FileStream fileStream = new FileStream(time, FileMode.Open, FileAccess.Read, FileShare.Read))
      {
        byte[] byteArray = new byte[1024];
        int n = fileStream.Read(byteArray, 0, byteArray.Length);
        System.Text.ASCIIEncoding utf = new System.Text.ASCIIEncoding();
        while (n > 0)
        {
          xml += utf.GetString(byteArray, 0, n);
          n = fileStream.Read(byteArray, 0, byteArray.Length);
        }
        fileStream.Close();
      }

      File.Delete(time);
      return GetWebData(xml);
    }
  }
}
