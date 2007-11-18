#region Using directives

using System;
using System.Drawing;
using System.IO;
using System.ComponentModel;
using System.Windows.Forms;
using System.Threading;
using Crownwood.Magic.Docking;
using SharpMT.Forms;
using SharpMT.Classes;

#endregion

namespace SharpMT
{
  partial class MainForm
  {
    private void genericToolStripMenuPopup_Click(object sender, EventArgs e)
    {
      if (ActiveControl == null) {
        //UpdateTextBoxMenuToolbar(false, false);
        return;
      }

      Control control = DrillDownEdit(ActiveControl);
      if (!CheckTextBox(control))
      {
        UpdateTextBoxMenuToolbar(false, false);
        return;
      }

      if (((TextBox)control).SelectionLength > 0)
      {
        UpdateTextBoxMenuToolbar(true, true);
      }
      else
      {
        UpdateTextBoxMenuToolbar(false, true);
      }
    }

    private void m_dockingManager_ContextMenu(Crownwood.Magic.Menus.PopupMenu pm, CancelEventArgs cea)
    {
      cea.Cancel = true;
    }

    private void newDraftToolStripMenuItem_Click(object sender, EventArgs e)
    {
      AddDraftTab("untitled");

      postToServerToolStripButton.Enabled = false;
      postToServerToolStripMenuItem.Enabled = false;
      postAllOpenDraftsToolStripMenuItem.Enabled = false;

      statusStripPanelMain.Text = "Ready";
    }

    private void viewBlogLinksToolStripMenuItem_Click(object sender, EventArgs e)
    {
      Content c = m_dockingManager.Contents["Blog Links"];
      if (c == null)
        return;
      if (c.Visible)
        m_dockingManager.HideContent(c);
      else
        m_dockingManager.ShowContent(c);

      viewBlogLinksToolStripMenuItem.Checked = c.Visible;
      //ResizeStatusBarPanel();
    }

    private void mruToolStripMenuItem_Click(object sender, EventArgs e)
    {
      String open = ((ToolStripMenuItem)sender).Text;
      open = open.Substring(3);
      // check for short name
      if ((open.IndexOf(":") == -1) && (open.Substring(0, 2) != @"\\"))
      {
        open = m_draftsFolder + open;
      }

      Cursor = Cursors.WaitCursor;
      statusStripPanelMain.Text = "Opening Draft...";

      if (File.Exists(open) != true) {
        MessageBox.Show("This draft file could not be found!", MainForm.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Stop);
        RemoveFromTheMruArray(open);
      }
      else {
        AddDraftTab(open.Substring(open.LastIndexOf(@"\") + 1));
        m_currentDraft.OpenFile(open);

        // update the MRU!
        UpdateTheMruArray();
      }

      statusStripPanelMain.Text = "Ready";
      Cursor = Cursors.Default;
    }

    private void customTagToolStripMenuItem_Click(object sender, EventArgs e)
    {
      Control control = DrillDownEdit(ActiveControl);
      if (!CheckTextBox(control))
      {
        return;
      }

      ToolStripMenuItem menuItem = ((ToolStripMenuItem)sender);
      if (menuItem.Tag == null)
        return;

      CustomTag customTag = (CustomTag)menuItem.Tag;
      InsertTheTag(((TextBox)control), customTag);
    }

    private void plugInToolStripMenuItem_Click(object sender, System.EventArgs e)
    {
      Control control = DrillDownEdit(ActiveControl);
      if (!CheckTextBox(control))
      {
        return;
      }

      ToolStripMenuItem menuItem = ((ToolStripMenuItem)sender);
      if (menuItem.Tag == null)
        return;

      PlugInItem plugInItem = (PlugInItem)menuItem.Tag;
      RunThePlugIn(((TextBox)control), plugInItem);
    }

    private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
    {
      OptionsForm optionsForm = new OptionsForm();
      // server
      if (m_blogId == "-1")
      {
        optionsForm.blogList.SelectedIndex = 0;
      }
      optionsForm.hostName.Text = m_hostName;
      optionsForm.cgiPath.Text = m_cgiPath;
      optionsForm.userName.Text = m_userName;
      optionsForm.password.Text = m_password;
      optionsForm.port.Text = string.Format("{0}", m_port);
      optionsForm.ssl.Checked = m_useSsl;
      // set the lists
      optionsForm.m_blogList = m_blogList;
      optionsForm.m_textFiltersList = m_textFiltersList;
      optionsForm.m_selectedBlogId = m_selectedBlogId;
      optionsForm.posts.Text = m_maxLinksToRefresh;
      // set the radio buttons
      if (m_refreshAllPosts)
        optionsForm.replaceLinks.Checked = true;
      else
        optionsForm.updateLinks.Checked = true;

      // editor
      optionsForm.m_fontName = m_fontName;
      optionsForm.m_fontPointSize = m_fontPointSize;
      optionsForm.m_boldFont = m_boldFont;
      optionsForm.m_italicFont = m_italicFont;

      optionsForm.draftFolder.Text = m_draftsFolder;
      optionsForm.musicTag.Text = m_musicTag;

      optionsForm.showTracingWindow.Checked = m_tracing;
      optionsForm.minimizeToSysTray.Checked = m_minimizeToSysTray;

      // proxy
      optionsForm.useProxy.Checked = m_proxy;
      optionsForm.useAuthentication.Checked = m_proxyAuthentication;
      optionsForm.proxyServer.Text = m_proxyUrl;
      optionsForm.proxyUserName.Text = m_proxyUserName;
      optionsForm.proxyPassword.Text = m_proxyPassword;
      optionsForm.proxyPort.Text = string.Format("{0}", m_proxyPort);

      // defaults
      optionsForm.postStatus.SelectedIndex = m_defaultAdvancedSettings.Status;
      optionsForm.comments.SelectedIndex = m_defaultAdvancedSettings.Comments;
      for (int i = 0; i < m_textFiltersList.Count; i++)
      {
        optionsForm.textFormatting.Items.Add(m_textFiltersList[i].Name);
      }
      optionsForm.textFormatting.SelectedIndex = m_defaultAdvancedSettings.Format;
      optionsForm.allowPings.Checked = m_defaultAdvancedSettings.AllowPings;
      optionsForm.useServerTime.Checked = m_defaultAdvancedSettings.UseServerTime;
      optionsForm.uploadPath.Text = m_uploadPath;

      // tags
      optionsForm.boldTag.Text = m_boldTag;
      optionsForm.italicsTag.Text = m_italicsTag;
      optionsForm.underlineTag.Text = m_underlineTag;
      optionsForm.imageTag.Text = m_imageTag;
      optionsForm.target.Text = m_target;
      for (int i = 0; i < m_customTagsList.Count; i++)
      {
        ListViewItem item = optionsForm.customTags.Items.Add(Convert.ToString(i + 1));
        item.Tag = m_customTagsList[i];
      }

      // plugings
      for (int i=0; i < m_plugInsList.Count; i++) {
        ListViewItem item = optionsForm.plugIns.Items.Add(Convert.ToString(i+1));
        item.Tag = m_plugInsList[i];
      }
      optionsForm.rssField.SelectedIndex = m_rssField;

      if (optionsForm.ShowDialog() == DialogResult.OK)
      {
        // do proxy stuff first
        m_proxy = optionsForm.useProxy.Checked;
        m_proxyAuthentication = optionsForm.useAuthentication.Checked;
        m_proxyUrl = optionsForm.proxyServer.Text;
        m_proxyUserName = optionsForm.proxyUserName.Text;
        m_proxyPassword = optionsForm.proxyPassword.Text;
        m_proxyPort = Convert.ToInt32(optionsForm.proxyPort.Text);
        SetupProxyInformation();

        m_draftsFolder = optionsForm.draftFolder.Text;
        m_tracing = optionsForm.showTracingWindow.Checked;
        m_minimizeToSysTray = optionsForm.minimizeToSysTray.Checked;
        m_hostName = optionsForm.hostName.Text;
        if (m_hostName.IndexOf("typepad.com") > -1)
          m_blogMode = BlogEngine.TypePad;
        else
          m_blogMode = BlogEngine.MovableType;
        m_port = Convert.ToInt32(optionsForm.port.Text);
        m_useSsl = optionsForm.ssl.Checked;

        m_cgiPath = optionsForm.cgiPath.Text;
        m_userName = optionsForm.userName.Text;
        m_password = optionsForm.password.Text;

        m_selectedBlogId = optionsForm.blogList.SelectedIndex;
        m_maxLinksToRefresh = optionsForm.posts.Text;
        // grab the lists
        m_blogList = optionsForm.m_blogList;
        //set the blog number
        if ((m_selectedBlogId != -1) && (m_selectedBlogId < m_blogList.Count))
        {
          BlogItem blogItem = m_blogList[m_selectedBlogId];
          m_blogId = blogItem.ID;
          statusStripPanelBlog.Text = string.Format("{0} ({1})", blogItem.Name, blogItem.ID);
          if (optionsForm.m_isDirty)
          {
            SetCursors(true);
            PrepProgress(true);
            UpdateCategoriesThread();

            SetCursors(true);
            PrepProgress(true);
            UpdateTextFiltersThread();
          }
        }
        else
        {
          m_blogId = "-1";
        }

        // get the radio buttons
        m_refreshAllPosts = optionsForm.replaceLinks.Checked;

        if ((optionsForm.m_fontPointSize != m_fontPointSize) || (optionsForm.m_fontName != m_fontName) ||
          (optionsForm.m_boldFont != m_boldFont) || (optionsForm.m_italicFont != m_italicFont))
        {

          m_fontName = optionsForm.m_fontName;
          m_fontPointSize = optionsForm.m_fontPointSize;
          m_boldFont = optionsForm.m_boldFont;
          m_italicFont = optionsForm.m_italicFont;

          FontStyle fns = ((m_boldFont ? FontStyle.Bold : 0) | (m_italicFont ? FontStyle.Italic : 0));
          Font fnt = new Font(m_fontName, m_fontPointSize, fns);

          for (int i = 0; i < draftTabs.TabPages.Count; i++)
          {
            DraftControl ctrlDraft = (DraftControl)draftTabs.TabPages[i].Controls[0];
            ctrlDraft.entryBody.Font = fnt;
            ctrlDraft.excerpt.Font = fnt;
            ctrlDraft.extendedEntry.Font = fnt;
            ctrlDraft.keywords.Font = fnt;
          }
        }

        // make sure the draft directory exists!
        Directory.CreateDirectory(m_draftsFolder);

        if (optionsForm.m_clearMru)
        {
          m_mruDraftsList.Clear();
        }
        UpdateMruList(true);

        // change the draft for the defaults
        m_defaultAdvancedSettings.Status = optionsForm.postStatus.SelectedIndex;
        m_defaultAdvancedSettings.Comments = optionsForm.comments.SelectedIndex;
        m_defaultAdvancedSettings.Format = optionsForm.textFormatting.SelectedIndex;
        m_defaultAdvancedSettings.AllowPings = optionsForm.allowPings.Checked;
        m_defaultAdvancedSettings.UseServerTime = optionsForm.useServerTime.Checked;

        m_boldTag = optionsForm.boldTag.Text;
        m_italicsTag = optionsForm.italicsTag.Text;
        m_underlineTag = optionsForm.underlineTag.Text;
        m_imageTag = optionsForm.imageTag.Text;

        m_customTagsList.Clear();
        for (int i = 0; i < optionsForm.customTags.Items.Count; i++)
        {
          ListViewItem item = optionsForm.customTags.Items[i];
          m_customTagsList.Add((CustomTag)item.Tag);
        }
        UpdateCustomTags();

        m_plugInsList.Clear();
        for (int i = 0; i < optionsForm.plugIns.Items.Count; i++)
        {
          ListViewItem item = optionsForm.plugIns.Items[i];
          m_plugInsList.Add((PlugInItem)item.Tag);
        }
        UpdatePlugIns();

        m_musicTag = optionsForm.musicTag.Text;
        m_uploadPath = optionsForm.uploadPath.Text;
        m_target = optionsForm.target.Text;

        m_rssField = optionsForm.rssField.SelectedIndex;
      }

      // update menu/toolbar!
      Control ctrl = this.ActiveControl;
      UpdateConnectionMenuToolbar();
      SaveRegistrySettings();
      if (ctrl != null)
        ctrl.Focus();
    }

    private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
    {
      AboutForm aboutForm = new AboutForm();
      aboutForm.ShowDialog();
    }

    private void updateCategoriesToolStripMenuItem_Click(object sender, EventArgs e)
    {
      SetCursors(true);
      PrepProgress(true);

      Thread t = new Thread(new ThreadStart(UpdateCategoriesThread));
      t.Start();
    }

    private void updateTextFiltersToolStripMenuItem_Click(object sender, EventArgs e)
    {
      SetCursors(true);
      PrepProgress(true);

      Thread t = new Thread(new ThreadStart(UpdateTextFiltersThread));
      t.Start();
    }

    private void updateBlogLinksToolStripMenuItem_Click(object sender, EventArgs e)
    {
      SetCursors(true);
      PrepProgress(true);

      Thread t = new Thread(new ThreadStart(UpdateLinksThread));
      t.Start();
    }

    private void updateLinksToolStripMenuItem_Click(object sender, EventArgs e)
    {
      updateBlogLinksToolStripMenuItem_Click(sender, e);
    }

    private void findToolStripMenuItem_Click(object sender, EventArgs e)
    {
      Control control  = DrillDownEdit(ActiveControl);
      if (!CheckTextBox(control))
      {
        return;
      }

      if (m_findForm == null)
      {
        m_findForm = new FindForm();
        m_findForm.Owner = this;
        m_findForm.StartPosition = FormStartPosition.CenterParent;
      }
      m_findForm.m_textBox = (TextBox)control;
      m_findForm.findWhat.SelectAll();
      m_findForm.Show();
      m_findForm.Focus();

    }

    private void openDraftToolStripMenuItem_Click(object sender, EventArgs e)
    {
      string fileTitle = "";
      OpenFileDialog openFileDialog = new OpenFileDialog();
      openFileDialog.Filter = "SharpMT Drafts (*.smt)|*.SMT";
      openFileDialog.Title = "Open Draft";
      openFileDialog.DefaultExt = "smt";
      openFileDialog.InitialDirectory = MainForm.m_draftsFolder;
      openFileDialog.CheckPathExists = true;
      openFileDialog.RestoreDirectory = true;
      openFileDialog.Multiselect = true;
      openFileDialog.ShowHelp = false;
      if (openFileDialog.ShowDialog() != DialogResult.OK)
      {
        return;
      }

      Cursor = Cursors.WaitCursor;
      statusStripPanelMain.Text = "Opening Draft(s)...";

      for (int i = 0; i < openFileDialog.FileNames.Length; i++)
      {
        fileTitle = openFileDialog.FileNames[i];
        AddDraftTab(fileTitle.Substring(fileTitle.LastIndexOf(@"\") + 1));
        m_currentDraft.OpenFile(fileTitle);

        // update the MRU!
        UpdateTheMruArray();
      }

      statusStripPanelMain.Text = "Ready";
      Cursor = Cursors.Default;
    }

    private void saveDraftToolStripMenuItem_Click(object sender, EventArgs e)
    {
      Cursor = Cursors.WaitCursor;
      statusStripPanelMain.Text = "Saving changes...";

      this.m_currentDraft = (DraftControl)draftTabs.SelectedTab.Controls[0];

      m_currentDraft.SaveDraft();
      // update the MRU!
      UpdateTheMruArray();

      statusStripPanelMain.Text = "Saved";
      Cursor = Cursors.Default;
    }

    private void saveAllDraftsToolStripMenuItem_Click(object sender, EventArgs e)
    {
      Cursor = Cursors.WaitCursor;
      statusStripPanelMain.Text = "Saving all changes...";

      for (int i = 0; i < draftTabs.TabPages.Count; i++)
      {
        DraftControl draftControl = (DraftControl)draftTabs.TabPages[i].Controls[0];
        if (draftControl.IsDirty())
        {
          draftControl.SaveDraft(draftTabs.TabPages[i]);

          // update the MRU!
          UpdateTheMruArray();
        }
      }

      statusStripPanelMain.Text = "Saved";
      Cursor = Cursors.Default;
    }
    
    private void copyToolStripMenuItem_Click(object sender, EventArgs e)
    {
      Control control = DrillDownEdit(ActiveControl);
      if (!CheckTextBox(control))
      {
        return;
      }
      ((TextBox)control).Copy();
    }

    private void cutToolStripMenuItem_Click(object sender, EventArgs e)
    {
      Control control = DrillDownEdit(ActiveControl);
      if (!CheckTextBox(control))
      {
        return;
      }
      ((TextBox)control).Cut();
    }

    private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
    {
      Control control = DrillDownEdit(ActiveControl);
      if (!CheckTextBox(control))
      {
        return;
      }
      ((TextBox)control).Paste();
    }

    private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
    {
      Control control = DrillDownEdit(ActiveControl);
      if (!CheckTextBox(control))
      {
        return;
      }
      ((TextBox)control).SelectedText = "";
    }

    private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
    {
      Control control = DrillDownEdit(ActiveControl);
      if (!CheckTextBox(control))
      {
        return;
      }
      ((TextBox)control).SelectAll();
      if (((TextBox)control).SelectionLength > 0)
      {
        UpdateTextBoxMenuToolbar(true, true);
      }
      else
      {
        UpdateTextBoxMenuToolbar(false, true);
      }
    }

    private void boldToolStripMenuItem_Click(object sender, EventArgs e)
    {
      Control control = DrillDownEdit(ActiveControl);
      if (!CheckTextBox(control))
      {
        return;
      }
      string updatedText = string.Format("<{0}>{1}</{2}>", m_boldTag, ((TextBox)control).SelectedText, m_boldTag);
      ((TextBox)control).SelectedText = updatedText;
    }

    private void italicToolStripMenuItem_Click(object sender, EventArgs e)
    {
      Control control = DrillDownEdit(ActiveControl);
      if (!CheckTextBox(control))
      {
        return;
      }
      string updatedText = string.Format("<{0}>{1}</{2}>", m_italicsTag, ((TextBox)control).SelectedText, m_italicsTag);
      ((TextBox)control).SelectedText = updatedText;
    }

    private void underlineToolStripMenuItem_Click(object sender, EventArgs e)
    {
      Control control = DrillDownEdit(ActiveControl);
      if (!CheckTextBox(control))
      {
        return;
      }
      string updatedText = string.Format("<{0}>{1}</{2}>", m_underlineTag, ((TextBox)control).SelectedText, m_underlineTag);
      ((TextBox)control).SelectedText = updatedText;
    }

    private void urlToolStripMenuItem_Click(object sender, EventArgs e)
    {
      Control control = DrillDownEdit(ActiveControl);
      if (!CheckTextBox(control))
      {
        return;
      }
      // open the Dialog 
      string selectedText = ((TextBox)control).SelectedText;
      AddUrlForm addUrlForm = new AddUrlForm();
      addUrlForm.m_url = m_urlPrefix;
      addUrlForm.m_text = selectedText;
      addUrlForm.tabs.SelectedIndex = m_selectedUrlTab;
      addUrlForm.linksListView.SmallImageList = iconsImageList;
      addUrlForm.m_columnTitle = m_urlLinksTitleWidth;
      addUrlForm.m_columnId = m_urlLinksIdWidth;
      addUrlForm.m_sortingColumn = m_currentSortingUrlLinks;
      addUrlForm.m_ascending = m_ascendingSortForUrlLinks;
      addUrlForm.m_target = m_target;
      for (int i = 0; i < linksListView.Items.Count; i++)
      {
        ListViewItem listViewItem = (ListViewItem)linksListView.Items[i].Clone();
        addUrlForm.linksListView.Items.Add(listViewItem);
      }
      addUrlForm.favoritesListView.SmallImageList = iconsImageList;
      for (int i=0; i < m_urlList.Count; i++)
      {
        addUrlForm.urlTyped.Items.Add(m_urlList[i]);
      }

      if (addUrlForm.ShowDialog() == DialogResult.OK)
      {
        string str = "";
        m_selectedUrlTab = addUrlForm.tabs.SelectedIndex;
        string linkTitle = "";
        if (addUrlForm.m_title.Length > 0)
          linkTitle = string.Format(" title=\"{0}\"", addUrlForm.m_title);
        switch (m_selectedUrlTab)
        {
          case 0:
            if (addUrlForm.m_target.Length > 0)
              str = string.Format("<a href=\"{0}\" target=\"{1}\"{2}>{3}</a>", addUrlForm.m_url, addUrlForm.m_target, linkTitle, addUrlForm.m_text);
            else
              str = string.Format("<a href=\"{0}\"{1}>{2}</a>", addUrlForm.m_url, linkTitle, addUrlForm.m_text);

            m_urlList.Clear();
            for (int i = 0; i < addUrlForm.urlTyped.Items.Count; i++)
            {
              m_urlList.Add(addUrlForm.urlTyped.Items[i].ToString());
            }
            break;
          case 1:
            ListView.SelectedIndexCollection indexCollection = addUrlForm.linksListView.SelectedIndices;
            if (indexCollection.Count > 0)
            {
              string urlText = ((EntryItem)addUrlForm.linksListView.Items[indexCollection[0]].Tag).Url;
              if (addUrlForm.m_target.Length > 0)
                str = string.Format("<a href=\"{0}\" target=\"{1}\"{2}>{3}</a>", urlText, addUrlForm.m_target, linkTitle, addUrlForm.m_text);
              else
                str = string.Format("<a href=\"{0}\"{1}>{2}</a>", urlText, linkTitle, addUrlForm.m_text);
            }
            break;
          case 2:
            if (addUrlForm.m_target.Length > 0)
              str = string.Format("<a href=\"{0}\" target=\"{1}\"{2}>{3}</a>", addUrlForm.m_url, addUrlForm.m_target, linkTitle, addUrlForm.m_text);
            else
              str = string.Format("<a href=\"{0}\"{1}>{2}</a>", addUrlForm.m_url, linkTitle, addUrlForm.m_text);
            break;
        }
        ((TextBox)control).SelectedText = str;
      }

      // always save the sizes
      m_urlLinksTitleWidth = addUrlForm.m_columnTitle;
      m_urlLinksIdWidth = addUrlForm.m_columnId;
      m_currentSortingUrlLinks = addUrlForm.m_sortingColumn;
      m_ascendingSortForUrlLinks = addUrlForm.m_ascending;
    }

    private void nowPlayingToolStripMenuItem_Click(object sender, EventArgs e)
    {
      Control control = DrillDownEdit(ActiveControl);
      if (!CheckTextBox(control))
      {
        return;
      }

      string str = "";
      if (FillInMusicString(ref str) == false)
      {
        MessageBox.Show(str, MainForm.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Stop);
        return;
      }
      ((TextBox)control).SelectedText = str;
    }

    private void spellCheckToolStripMenuItem_Click(object sender, EventArgs e)
    {
      m_currentDraft = (DraftControl)draftTabs.SelectedTab.Controls[0];
      SpellCheck(m_currentDraft.title);
      if (m_currentDraft.modeTabs.SelectedTab == m_currentDraft.mainPage)
      {
        SpellCheck(m_currentDraft.entryBody);
        SpellCheck(m_currentDraft.extendedEntry);
        SpellCheck(m_currentDraft.excerpt);
      }
      MessageBox.Show("The spelling check is complete", MainForm.ApplicationName);
    }

    private void spellCheckOptionsToolStripMenuItem_Click(object sender, EventArgs e)
    {
      // Begin:SPELLCHECK_REM
      //axSpellicanCtrl1.ShowOptions(m_spellicanConfigFile);
      // End:SPELLCHECK_REM
    }

    private void postToServerToolStripMenuItem_Click(object sender, EventArgs e)
    {
      // Save the post
      if (saveDraftToolStripMenuItem.Enabled)
      {
        saveDraftToolStripMenuItem.PerformClick();
        if (m_currentDraft.IsDirty())
          return;
      }

      SetCursors(true);
      PrepProgress(true);
      
      UpdatePost(false);

//      Thread t = new Thread(new ThreadStart(UpdateSinglePostThread));
//      t.Start();
    }

    private void postAllOpenDraftsToolStripMenuItem_Click(object sender, EventArgs e)
    {
      // Save the post
      saveAllDraftsToolStripMenuItem.PerformClick();

      SetCursors(true);
      PrepProgress(true);

      UpdatePost(true);

//      Thread t = new Thread(new ThreadStart(UpdateMultiplePostsThread));
//      t.Start();
    }

    private void uploadImageToolStripMenuItem_Click(object sender, EventArgs e)
    {
      // reset the insert link no matter
      m_imageLink = "";
      m_altImageTag = "";
      Control control = DrillDownEdit(ActiveControl);
      if (CheckTextBox(control))
      {
        m_currentControl = control;
      }
      else
        m_currentControl = null;

      // Get the Image names (local and remote)
      UploadForm uploadForm = new UploadForm();
      uploadForm.urlLink.Text = m_blogList[m_selectedBlogId].Url;
      uploadForm.remoteFileName.Text = m_uploadPath;
      uploadForm.m_uploadPath = m_uploadPath;
      if (uploadForm.urlLink.Text.Length <= 0)
      {
        uploadForm.urlLink.Text = "SharpMT couldn't find a URL for this Blog!";
      }
      if (m_insertImageUrl)
        uploadForm.insertTag.Checked = true;

      if (m_currentControl == null)
      {
        uploadForm.insertTag.Enabled = false;
        uploadForm.altLabel.Enabled = false;
        uploadForm.altAttribute.Enabled = false;
      }

      if (uploadForm.ShowDialog() == DialogResult.Cancel)
      {
        return;
      }

      m_insertImageUrl = uploadForm.insertTag.Checked;
      if (m_insertImageUrl)
      {
        m_imageLink = uploadForm.urlLink.Text + uploadForm.remoteFileName.Text;
        m_altImageTag = uploadForm.altAttribute.Text;
      }

      // Update the UI if true!
      SetCursors(true);
      PrepProgress(true);

      m_localFileName = uploadForm.localFileName.Text;
      m_remoteFileName = uploadForm.remoteFileName.Text;
      statusStripPanelMain.Text = "Uploading file...";
      Thread t = new Thread(new ThreadStart(UploadFileThread));
      t.Start();
    }

    private void mainModeToolStripMenuItem_Click(object sender, EventArgs e)
    {
      if (m_currentDraft.modeTabs.SelectedTab != m_currentDraft.mainPage)
      {
        m_currentDraft.modeTabs.SelectedTab = m_currentDraft.mainPage;
      }
    }

    private void advancedModeToolStripMenuItem_Click(object sender, EventArgs e)
    {
      if (m_currentDraft.modeTabs.SelectedTab != m_currentDraft.advancedPage)
      {
        m_currentDraft.modeTabs.SelectedTab = m_currentDraft.advancedPage;
      }
    }

    private void previewModeToolStripMenuItem_Click(object sender, EventArgs e)
    {
      if (m_currentDraft.modeTabs.SelectedTab != m_currentDraft.previewPage)
      {
        m_currentDraft.modeTabs.SelectedTab = m_currentDraft.previewPage;
      }
    }

    private void nextDraftToolStripMenuItem_Click(object sender, EventArgs e)
    {
      int pos = draftTabs.SelectedIndex + 1;
      if (pos >= draftTabs.TabPages.Count)
        pos = 0;
      draftTabs.SelectedIndex = pos;
    }

    private void previousDraftToolStripMenuItem_Click(object sender, EventArgs e)
    {
      int pos = draftTabs.SelectedIndex - 1;
      if (pos < 0)
        pos = draftTabs.TabPages.Count - 1;
      draftTabs.SelectedIndex = pos;
    }

    private void viewSiteToolStripMenuItem_Click(object sender, EventArgs e)
    {
      if (m_blogId == "-1")
      {
        MessageBox.Show("Please update your Blog list in Options", MainForm.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Stop);
        return;
      }

      string siteUrl = m_blogList[m_selectedBlogId].Url;
      if (siteUrl.Length <= 0)
      {
        MessageBox.Show("SharpMT couldn't find a URL for this Blog!\r\n\r\nPlease update your Blog list in Options", MainForm.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Stop);
        return;
      }

      try
      {
        System.Diagnostics.Process.Start(siteUrl);
      }
      catch
      {
        MessageBox.Show("SharpMT couldn't find a URL for this Blog!\r\n\r\nPlease update your Blog list in Options", MainForm.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Stop);
      }

    }

    private void helpToolStripMenuItem1_Click(object sender, EventArgs e)
    {
      try
      {
        System.Diagnostics.Process.Start("sharpmt.chm");
      }
      catch
      {
        MessageBox.Show("Could not find the Help file - Please go to http://www.randyrants.com/sharpmt for the online FAQ", MainForm.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Stop);
      }
    }

    private void fAQToolStripMenuItem_Click(object sender, EventArgs e)
    {
      try
      {
        System.Diagnostics.Process.Start("faq.htm");
      }
      catch
      {
        MessageBox.Show("Could not find the FAQ file - Please go to http://www.randyrants.com/sharpmt for the online FAQ", MainForm.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Stop);
      }
    }

    private void exitToolStripMenuItem_Click(object sender, EventArgs e)
    {
      Application.Exit();
    }

    #region ListView Menu
    private void editDraftToolStripMenuItem_Click(object sender, EventArgs e)
    {
      OpenLinkInEditMode();
    }

    private void openInBrowserToolStripMenuItem_Click(object sender, EventArgs e)
    {
      ListView.SelectedIndexCollection indexCollection = linksListView.SelectedIndices;
      if (indexCollection.Count <= 0)
        return;

      EntryItem entryItem = (EntryItem)linksListView.Items[indexCollection[0]].Tag;

      if (entryItem.Url.Length == 0)
        return;

      try
      {
        System.Diagnostics.Process.Start(entryItem.Url);
      }
      catch
      {
        MessageBox.Show("Could not open this Blog Link!", MainForm.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Stop);
      }
    }

    private void editWithBrowserToolStripMenuItem_Click(object sender, EventArgs e)
    {
      ListView.SelectedIndexCollection indexCollection = linksListView.SelectedIndices;
      if (indexCollection.Count <= 0)
        return;

      EntryItem entryItem = (EntryItem)linksListView.Items[indexCollection[0]].Tag;

      string entryUrl= null;
      string ssl = "", port = "";
      if (m_useSsl) {
        ssl = "s";
      }
      if (m_port != 80) {
        port = string.Format(":{0}", m_port);
      }

      switch (m_blogMode)
      {
        case BlogEngine.MovableType:
          entryUrl = string.Format("http{0}://{1}{2}{3}?__mode=view&_type=entry&id={2}&blog_id={4}",
                    ssl, m_hostName, port, m_cgiPath, entryItem.ID, m_blogId);
          break;
        case BlogEngine.TypePad:
          entryUrl = string.Format("https://{0}{1}?__mode=edit_entry&id={2}&blog_id={3}",
                    "www.typepad.com", "/t/app/weblog/post", entryItem.ID, m_blogId);
          break;
      }

      entryUrl = entryUrl.Replace("mt-xmlrpc.cgi", "mt.cgi");

      if (entryUrl.Length == 0)
        return;

      try
      {
        System.Diagnostics.Process.Start(entryUrl);
      }
      catch
      {
        MessageBox.Show("Could not open this Blog's edit link!", MainForm.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Stop);
      }
    }

    private void deleteLinkToolStripMenuItem_Click(object sender, EventArgs e)
    {
      ListView.SelectedIndexCollection indexCollection = linksListView.SelectedIndices;
      if (indexCollection.Count > 0)
        linksListView.ListViewItemSorter = null;
      for (int i = indexCollection.Count - 1; i >= 0; i--)
      {
        linksListView.Items.RemoveAt(indexCollection[i]);
      }
      if (linksListView.ListViewItemSorter == null)
      {
        if (m_currentSortedColumn == 0)
          this.linksListView.ListViewItemSorter = new ListViewItemStringComparer(m_ascendingSortForLinks);
        else
          this.linksListView.ListViewItemSorter = new ListViewItemIntComparer(m_ascendingSortForLinks);
        linksListView.Sort();
      }
      // update the top link
      m_topId = -1;
      for (int i = 0; i < linksListView.Items.Count; i++)
      {
        String id = ((EntryItem)linksListView.Items[i].Tag).ID;
        if (Convert.ToInt32(id) > m_topId)
          m_topId = Convert.ToInt32(id);
      }
      statusStripPanelLinks.Text = string.Format("Links: {0}", linksListView.Items.Count);

    }

    private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
    {
      linksBody.Visible = !linksBody.Visible;
      showDetailsToolStripMenuItem.Checked = linksBody.Visible;
    }

    private void linksContextMenuStrip_Opened(object sender, EventArgs e)
    {
      //if (linksListView.SelectedIndices.Count > 0)
      //{
      //  deleteLinkToolStripMenuItem.Enabled = true;
      //}
      //else
      //{
      //  deleteLinkToolStripMenuItem.Enabled = false;
      //}

      //if (linksListView.SelectedIndices.Count != 1)
      //{
      //  openInBrowserTtoolStripMenuItem.Enabled = false;
      //  editDraftToolStripMenuItem.Enabled = false;
      //  editWithBrowserToolStripMenuItem.Enabled = false;
      //}
      //else
      //{
      //  openInBrowserTtoolStripMenuItem.Enabled = true;
      //  if (m_blogId == "-1")
      //    editDraftToolStripMenuItem.Enabled = false;
      //  else
      //    editDraftToolStripMenuItem.Enabled = true;
      //  editWithBrowserToolStripMenuItem.Enabled = editDraftToolStripMenuItem.Enabled;
      //}
    }
    #endregion
  }
}
