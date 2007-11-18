#region Using directives

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.IO;
using SharpMT.Classes;
using SharpMT.Forms;
#endregion

namespace SharpMT
{
  partial class DraftControl : UserControl
  {
    const string NotPostedStatus = "This draft has not been posted to the server.";
    const string BeenPostedStatus = "This draft has been posted.";
    const string ServerBasedStatus = "This draft is server based.";
    const string NoPingsAllowedStatus = "URLs to Ping cannot be edited via SharpMT";

    public MainForm m_mainForm = null; //m_dlgParent
    public bool m_editMode = false; //m_bEditMode
    private bool m_dirty = false; //m_bDirty
    private List<String> m_selectedCategories; //ma_strSelectCat;

    public DraftControl(MainForm parent, bool editMode)
    {
      m_mainForm = parent;
      m_editMode = editMode;
      m_selectedCategories = new List<String>();

      InitializeComponent();

      m_dirty = false;
    }

    private void DraftControl_Load(object sender, EventArgs e)
    {
      if (m_mainForm == null)
        return;

      // load up the stuffs
      for (int i = 0; i < m_mainForm.m_categoriesList.Count; i++)
      {// set the Category ID
        category.Items.Add((m_mainForm.m_categoriesList[i]).Name);
      }
      for (int i = 0; i < m_mainForm.m_textFiltersList.Count; i++)
      {// set the Category ID
        formatting.Items.Add((m_mainForm.m_textFiltersList[i]).Name);
      }

      // Default Category
      category.SelectedIndex = 0;

      // set defaults
      postStatus.SelectedIndex = m_mainForm.m_defaultAdvancedSettings.Status;
      if (m_mainForm.m_defaultAdvancedSettings.Format >= formatting.Items.Count)
        m_mainForm.m_defaultAdvancedSettings.Format = 0;
      formatting.SelectedIndex = m_mainForm.m_defaultAdvancedSettings.Format;
      comments.SelectedIndex = m_mainForm.m_defaultAdvancedSettings.Comments;
      allowPings.Checked = m_mainForm.m_defaultAdvancedSettings.AllowPings;

      // Set the font
      FontStyle fns = new FontStyle();
      fns = ((m_mainForm.m_boldFont ? FontStyle.Bold : 0) | (m_mainForm.m_italicFont ? FontStyle.Italic : 0));
      Font fnt = new Font(m_mainForm.m_fontName, m_mainForm.m_fontPointSize, fns);
      entryBody.Font = fnt;
      excerpt.Font = fnt;
      extendedEntry.Font = fnt;
      keywords.Font = fnt;

      // Set the CatButton
      if (category.Items.Count > 2)
        selectCategories.Enabled = true;
      else
        selectCategories.Enabled = false;

      if (m_mainForm.m_defaultAdvancedSettings.UseServerTime)
        authoredOn.Text = MainForm.UseDefaultDateTime;
      else
      {
        DateTime dt = DateTime.Now;
        authoredOn.Text = dt.ToString("s");
      }

      // required to work around the HTML bug that appears on the closing/disposing method
      Visible = true;
      modeTabs.SelectedTab = previewPage;
      modeTabs.SelectedTab = mainPage;

      title.Focus();

      m_dirty = false;
      if (!m_editMode)
        m_mainForm.draftTabs.SelectedTab.Title = "untitled";
    }

    private void modeTabs_SelectionChanged(object sender, EventArgs e)
    {
      if (m_mainForm == null)
        return;

      if (modeTabs.SelectedTab == mainPage) {
        m_mainForm.previewModeToolStripMenuItem.Checked = false;
        m_mainForm.advancedModeToolStripMenuItem.Checked = false;
        m_mainForm.mainModeToolStripMenuItem.Checked = true;
      }
      else if (modeTabs.SelectedTab == advancedPage)
      {
        m_mainForm.previewModeToolStripMenuItem.Checked = false;
        m_mainForm.mainModeToolStripMenuItem.Checked = false;
        m_mainForm.advancedModeToolStripMenuItem.Checked = true;
      }
      else
      {
        m_mainForm.mainModeToolStripMenuItem.Checked = false;
        m_mainForm.advancedModeToolStripMenuItem.Checked = false;
        m_mainForm.previewModeToolStripMenuItem.Checked = true;

        String html = "", str = "";
        bool isFormatted = false;
        if (formatting.Text == "Convert Line Breaks")
        { // 0 = None, 1 = __default__
          isFormatted = true;
        }

        try
        {
          using (FileStream fileStream = new FileStream(MainForm.m_homeFolder + "previewHtml.htm", FileMode.Open, FileAccess.Read, FileShare.Read))
          {
            byte[] bytes = new byte[1024];
            int n = fileStream.Read(bytes, 0, bytes.Length);
            System.Text.ASCIIEncoding encoding = new System.Text.ASCIIEncoding();
            while (n > 0)
            {
              html += encoding.GetString(bytes, 0, n);
              n = fileStream.Read(bytes, 0, bytes.Length);
            }
            fileStream.Close();
          }
        }
        catch
        {
        }

        if (html.Length == 0)
        {
          html = "<html><body>Title: <$MTEntryTitle$><br/>Category: <$MTEntryCategory$><hr/>" +
            "Entry Body: <br/><$MTEntryBody$><hr/>" +
            "Extended Entry: <br/><$MTEntryMore$><hr/>" +
            "Excerpt: <br/><$MTEntryExcerpt$>" +
            "</body></html>";
        }
        html = html.Replace("<$MTEntryTitle$>", title.Text);
        html = html.Replace("<$MTEntryCategory$>", category.Text);
        str = entryBody.Text;
        if (isFormatted)
        {
          str = str.Replace("\r\n", "\n");
          str = str.Replace("\n", "<br/>");
        }
        html = html.Replace("<$MTEntryBody$>", str);

        str = extendedEntry.Text;
        if (isFormatted)
        {
          str = str.Replace("\r\n", "\n");
          str = str.Replace("\n", "<br/>");
        }
        html = html.Replace("<$MTEntryMore$>", str);

        str = excerpt.Text;
        if (isFormatted)
        {
          str = str.Replace("\r\n", "\n");
          str = str.Replace("\n", "<br/>");
        }
        html = html.Replace("<$MTEntryExcerpt$>", str);

        webBrowser.DocumentText = html;
        webBrowser.Update();
      }
    }

    private void genericTextBox_GotFocus(object sender, System.EventArgs e)
    {
      if (m_mainForm == null)
        return;

      m_mainForm.UpdateTextBoxMenuToolbar(false, true);
      // update the find dialog

      if (MainForm.m_findForm != null)
        MainForm.m_findForm.m_textBox = (TextBox)sender;
    }

    private void genericTextBox_LostFocus(object sender, System.EventArgs e)
    {
      if (m_mainForm == null)
        return;

      m_mainForm.UpdateTextBoxMenuToolbar(false, false);

      // only hide selection when Find isn't open
      if ((MainForm.m_findForm != null) && (!MainForm.m_findForm.Visible))
        ((TextBox)sender).HideSelection = true;
    }

    private void genericTextBox_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
    {
      if (m_mainForm == null)
        return;

      if (((TextBox)sender).SelectionLength > 0)
      {
        m_mainForm.UpdateTextBoxMenuToolbar(true, true);
      }
      else
      {
        m_mainForm.UpdateTextBoxMenuToolbar(false, true);
      }
    }

    private void genericTextBox_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
    {
      if (m_mainForm == null)
        return;

      if (((TextBox)sender).SelectionLength > 0)
      {
        m_mainForm.UpdateTextBoxMenuToolbar(true, true);
      }
      else
      {
        m_mainForm.UpdateTextBoxMenuToolbar(false, true);
      }
    }

    private void genericTextBox_TextChanged(object sender, System.EventArgs e)
    {
      if (m_mainForm == null)
        return;

      if (((TextBox)sender).Text.Length > 0)
      {
        if (!m_dirty)
          MakeDirty();
        if (m_mainForm.m_blogId == "-1")
        {
          m_mainForm.postToServerToolStripButton.Enabled = false;
          m_mainForm.postToServerToolStripMenuItem.Enabled = false;
          m_mainForm.postAllOpenDraftsToolStripMenuItem.Enabled = false;
        }
        else
        {
          m_mainForm.postToServerToolStripButton.Enabled = true;
          m_mainForm.postToServerToolStripMenuItem.Enabled = true;
          if (m_mainForm.draftTabs.TabPages.Count > 1)
          {
            m_mainForm.postAllOpenDraftsToolStripMenuItem.Enabled = true;
          }
          else
          {
            m_mainForm.postAllOpenDraftsToolStripMenuItem.Enabled = false;
          }
        }
      }

      if (((TextBox)sender).SelectionLength > 0)
      {
        m_mainForm.UpdateTextBoxMenuToolbar(true, true);
      }
      else
      {
        m_mainForm.UpdateTextBoxMenuToolbar(false, true);
      }
    }

    private void genericComboBox_SelectedIndexChanged(object sender, System.EventArgs e)
    {
      MakeDirty();
    }

    private void allowPings_CheckedChanged(object sender, EventArgs e)
    {
      MakeDirty();
    }

    private void authoredOn_Clicked(object sender, System.EventArgs e)
    {
      DateTimeForm dateTimeForm = new DateTimeForm();
      if (authoredOn.Text == MainForm.UseDefaultDateTime)
      {
        dateTimeForm.datePicker.Enabled = false;
        dateTimeForm.timePicker.Enabled = false;
        dateTimeForm.useServerTime.Checked = true;
      }
      else
      {
        // set the time
        DateTime dateTime = DateTime.Parse(authoredOn.Text);
        dateTimeForm.datePicker.Value = dateTime;
        dateTimeForm.timePicker.Value = dateTime;
      }
      if (dateTimeForm.ShowDialog() == DialogResult.OK)
      {
        if (dateTimeForm.useServerTime.Checked)
        {
          authoredOn.Text = MainForm.UseDefaultDateTime;
        }
        else
        {
          DateTime date = dateTimeForm.datePicker.Value;
          DateTime time = dateTimeForm.timePicker.Value;
          DateTime dateTime = new DateTime(date.Year, date.Month, date.Day, time.Hour, time.Minute, time.Second, time.Millisecond);
          authoredOn.Text = dateTime.ToString("s");
        }

        MakeDirty();
      }
    }

    private void selectCategories_Click(object sender, System.EventArgs e)
    {
      if (category.SelectedIndex == 0)
      {
        MessageBox.Show("Please select a primary category before continuing!", MainForm.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Stop);
        category.Focus();
        return;
      }
      string primary = category.Text;
      if (CategoriesClicked(primary))
        MakeDirty();
    }

    internal bool CategoriesClicked(string primary)
    {
      bool changed = false;

      List<String> idList= new List<String>();
      CategoriesForm categoriesForm = new CategoriesForm();
      for (int i = 0; i < m_mainForm.m_categoriesList.Count; i++)
      {
        string name = m_mainForm.m_categoriesList[i].Name;
        if (name == primary)
          categoriesForm.primaryCategory.Text = primary;
        else
        {
          categoriesForm.categories.Items.Add(name);
          idList.Add(m_mainForm.m_categoriesList[i].ID);
        }
      }

      for (int i = 0; i < m_selectedCategories.Count; i++)
      {
        // check the selected items
        for (int n = 0; n < idList.Count; n++)
        {
          if (m_selectedCategories[i] == idList[n])
          {
            categoriesForm.categories.SetItemChecked(n, true);
            break;
          }
        }
      }
      if (categoriesForm.ShowDialog() == DialogResult.OK)
      {
        changed = true;
        m_selectedCategories.Clear();
        for (int i = 0; i < categoriesForm.categories.CheckedItems.Count; i++)
        {
          string name = (string)categoriesForm.categories.CheckedItems[i];
          for (int n = 0; n < m_mainForm.m_categoriesList.Count; n++)
          {
            if (name == m_mainForm.m_categoriesList[n].Name)
            {
              m_selectedCategories.Add(m_mainForm.m_categoriesList[n].ID);
              break;
            }
          }
        }
      }
      return changed;
    }

    private void MakeDirty()
    {
      if (m_mainForm == null)
        return;

      if (m_editMode)
        return;

      m_dirty = true;

      string title = m_mainForm.draftTabs.SelectedTab.Title;
      if (title.IndexOf("*") == -1)
        m_mainForm.draftTabs.SelectedTab.Title += "*";

      if (m_mainForm.m_blogId == "-1")
      {
        m_mainForm.postToServerToolStripButton.Enabled = false;
        m_mainForm.postToServerToolStripMenuItem.Enabled = false;
        m_mainForm.postAllOpenDraftsToolStripMenuItem.Enabled = false;
      }
      else
      {
        m_mainForm.postToServerToolStripButton.Enabled = true;
        m_mainForm.postToServerToolStripMenuItem.Enabled = true;
        if (m_mainForm.draftTabs.TabPages.Count > 1)
        {
          m_mainForm.postAllOpenDraftsToolStripMenuItem.Enabled = true;
        }
        else
        {
          m_mainForm.postAllOpenDraftsToolStripMenuItem.Enabled = false;
        }
      }

      m_mainForm.UpdateTextBoxMenuToolbar(false, false);
    }

    private bool DirtyCheck()
    {
      if (m_dirty)
      {
        string title = m_mainForm.draftTabs.SelectedTab.Title;
        if (title.IndexOf("*") > -1)
          title = title.Replace("*", "");
        title += " has changed.\r\n\r\nDo you want to save these changes?";
        DialogResult result = MessageBox.Show(title, MainForm.ApplicationName, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Stop);
        switch (result)
        {
          case DialogResult.Cancel:
            return false;
          case DialogResult.No:
            break;
          case DialogResult.Yes:
            SaveDraft();
            // if someone says yes and clicks cancels on the save dialog, this catch prevents exiting.
            if (m_dirty)
              return false;
            break;
        }
      }
      return true;
    }

    internal bool CloseDraft()
    {
      return DirtyCheck();
    }

    internal void SaveDraft()
    {
      Crownwood.Magic.Controls.TabPage tabPage = m_mainForm.draftTabs.SelectedTab;
      SaveDraft(tabPage);
    }

    internal void SaveDraft(Crownwood.Magic.Controls.TabPage tabPage)
    {
      string title = tabPage.Title;
      if (title.IndexOf("*") > -1)
        title = title.Replace("*", ""); ;

      // check to see if there's a filename already!
      if (localFilename.Text == "")
      {
        SaveFileDialog saveDialog = new SaveFileDialog();
        saveDialog.Filter = "SharpMT Drafts (*.smt)|*.SMT";
        saveDialog.Title = "Save Draft";
        saveDialog.DefaultExt = "smt";
        saveDialog.InitialDirectory = MainForm.m_draftsFolder;
        saveDialog.CheckPathExists = true;
        saveDialog.RestoreDirectory = true;
        saveDialog.AddExtension = true;
        saveDialog.ShowHelp = false;
        saveDialog.FileName = MakeFileNameSave(this.title.Text) + ".smt";
        if (saveDialog.ShowDialog() == DialogResult.OK)
        {
          localFilename.Text = saveDialog.FileName;
        }
        else
        {
          return;
        }
      }

      m_dirty = false;

      SaveFile(localFilename.Text);

      title = localFilename.Text.Substring(localFilename.Text.LastIndexOf(@"\") + 1);
      tabPage.Title = title;
    }

    private void SaveFile(string fileName)
    {
      PostItem postItem = new PostItem();
      GrabUiData(postItem);

      XmlTextWriter xmlWriter = new XmlTextWriter(fileName, System.Text.Encoding.UTF8);
      xmlWriter.Formatting = Formatting.Indented;
      xmlWriter.Namespaces = false;
      xmlWriter.WriteStartDocument();
      xmlWriter.WriteStartElement("blogDrafts");

      xmlWriter.WriteStartElement("draftItem");
      // extra tag is required by a bug in the XML parse of .NET 1.1!
      xmlWriter.WriteElementString("name", postItem.AllowComments);
      xmlWriter.WriteElementString("comments", postItem.AllowComments);
      xmlWriter.WriteElementString("ping", postItem.AllowPings);
      for (int n = 0; n < postItem.Categories.Count; n++)
        xmlWriter.WriteElementString("category", postItem.Categories[n]);
      xmlWriter.WriteElementString("entry", postItem.Entry);
      xmlWriter.WriteElementString("excerpt", postItem.Excerpt);
      xmlWriter.WriteElementString("extended", postItem.Extended);
      xmlWriter.WriteElementString("post", postItem.PostStatus);
      xmlWriter.WriteElementString("formatting", postItem.TextFormatting);
      xmlWriter.WriteElementString("keywords", postItem.Keyword);
      xmlWriter.WriteElementString("pings", postItem.Pings);
      if (postItem.IsPosted)
        xmlWriter.WriteElementString("status", "1");
      else
        xmlWriter.WriteElementString("status", "0");
      xmlWriter.WriteElementString("datetime", postItem.DateTime);
      xmlWriter.WriteElementString("title", postItem.Title);
      xmlWriter.WriteEndElement();

      xmlWriter.WriteEndElement();
      xmlWriter.WriteEndDocument();
      xmlWriter.Close();
    }

    internal PostItem GrabUiData()
    {
      PostItem postItem = new PostItem();
      return (GrabUiData(postItem));
    }

    private PostItem GrabUiData(PostItem postItem)
    {
      // get the Draft data from the UI
      postItem.AllowComments = Convert.ToString(comments.SelectedIndex, 10); // 0 = None, 1 = Open, 2 = Closed
      postItem.AllowPings = (allowPings.Checked ? "1" : "0"); // 0 = unchecked, 1 = checked
      postItem.Categories.Clear();

      if (category.SelectedIndex > 0)
      {
        // get the primary
        postItem.Categories.Add(m_mainForm.m_categoriesList[category.SelectedIndex - 1].ID); // get the Category ID

        // get the rest of the ID's
        for (int i = 0; i < m_selectedCategories.Count; i++)
        {
          postItem.Categories.Add(m_selectedCategories[i]);
        }
      }
      postItem.PostStatus = Convert.ToString(postStatus.SelectedIndex); // 0(1) = Draft, 1(2) = Publish
      postItem.TextFormatting = Convert.ToString(formatting.SelectedIndex); // 0 = None, 1 = __default__
      if (formatting.SelectedIndex != 0)
        postItem.TextFormatting = (m_mainForm.m_textFiltersList[formatting.SelectedIndex - 1]).ID;//"__default__";
      postItem.Entry = entryBody.Text;
      postItem.Excerpt = excerpt.Text;
      postItem.Extended = extendedEntry.Text;
      postItem.Keyword = keywords.Text;
      postItem.Pings = pings.Text;
      // adds a trailing \n
      if (postItem.Pings.Length > 0) {
        if (postItem.Pings[postItem.Pings.Length-1] != '\n') {
          postItem.Pings += "\n";
        }
      }

      if (authoredOn.Text == MainForm.UseDefaultDateTime)
      {
        postItem.DateTime = "";
      }
      else
        postItem.DateTime = authoredOn.Text;
      if (beenPosted.Text == BeenPostedStatus)
        postItem.IsPosted = true;
      else
        postItem.IsPosted = false;
      postItem.Title = this.title.Text;
      if (m_editMode)
      {
        postItem.PostId = localFilename.Text;
      }
      else postItem.PostId= "";
      return postItem;
    }

    public void PushUiData(PostItem postItem)
    {
      // pust the Draft data into the UI
      if (postItem.AllowComments.Length == 0)
      {
        comments.SelectedIndex = m_mainForm.m_defaultAdvancedSettings.Comments;
      }
      else
      {
        comments.SelectedIndex = Convert.ToInt32(postItem.AllowComments, 10); // 0 = None, 1 = Open, 2 = Closed
      }
      allowPings.Checked = ((postItem.AllowPings == "1") ? true : false);// 0 = unchecked, 1 = checked
      string primaryCategory = "";
      if (postItem.Categories.Count == 0)
      {
        m_selectedCategories.Clear();
      }
      else
      {
        for (int i = 0; i < postItem.Categories.Count; i++)
        {
          // gets the list of assigned categories
          for (int n = 0; n < m_mainForm.m_categoriesList.Count; n++)
          {// set the Category ID
            if (m_mainForm.m_categoriesList[n].ID == postItem.Categories[i])
            {
              m_selectedCategories.Add(m_mainForm.m_categoriesList[n].ID);
              if (i == 0)
              {
                primaryCategory = m_mainForm.m_categoriesList[n].Name;
              }
              break;
            }
          }
        }
      }

      if (m_selectedCategories.Count <= 0)
      {
        category.SelectedIndex = 0;
      }
      else
      {
        // always set the primary
        int n = category.Items.IndexOf(primaryCategory);
        if (n > -1)
          category.SelectedIndex = n;
        else
          category.SelectedIndex = 0;
      }

      // remove it from the array to prevent overlapping
      if (m_selectedCategories.Count >= 1)
      {
        m_selectedCategories.RemoveAt(0);
      }

      postStatus.SelectedIndex = Convert.ToInt32(postItem.PostStatus); // 0 (1) = Draft, 1(2) = Publish
      if (postItem.TextFormatting == "0") // 0 = None, 1 = __default__
        formatting.SelectedIndex = 0;
      else
      {
        for (int i = 0; i < m_mainForm.m_textFiltersList.Count; i++)
        {
          CategoryItem textFilterItem = m_mainForm.m_textFiltersList[i];
          if (postItem.TextFormatting == textFilterItem.ID)
          {
            formatting.SelectedIndex = i + 1;
            break;
          }
        }
      }
      entryBody.Text = postItem.Entry;
      excerpt.Text = postItem.Excerpt;
      extendedEntry.Text = postItem.Extended;
      keywords.Text = postItem.Keyword;
      if (pings.Enabled)
        pings.Text = postItem.Pings;
      if (postItem.DateTime == "")
        authoredOn.Text = MainForm.UseDefaultDateTime;
      else
        authoredOn.Text = postItem.DateTime;
      if (m_editMode)
      {
        beenPosted.Text = ServerBasedStatus;
      }
      else
      {
        if (postItem.IsPosted)
        {
          beenPosted.Text = BeenPostedStatus;
        }
      }
      title.Text = postItem.Title;
      if (m_editMode)
      {
        local.Text = "Post ID:";
        localFilename.Text = postItem.PostId;
      }
    }

    internal void OpenFile(string fileName)
    {
      // read drafts
      XmlTextReader xmlReader = null;
      PostItem postItem = null; ;
      try
      {
        xmlReader = new XmlTextReader(fileName);
        xmlReader.WhitespaceHandling = WhitespaceHandling.None;
        postItem = new PostItem();
        bool KeepRunning = true;
        while ((xmlReader.Read()) && (KeepRunning))
        {
          string element = xmlReader.ReadString();
          switch (xmlReader.Name)
          {
            case "comments": //linkID
              if (element.Length == 0)
                element = string.Format("{0}", m_mainForm.m_defaultAdvancedSettings.Comments);
              postItem.AllowComments = element;
              break;
            case "ping": // ping
              postItem.AllowPings = element;
              break;
            case "category": //category
              postItem.Categories.Add(element);
              break;
            case "entry": //Entry
              postItem.Entry = element;
              break;
            case "excerpt": //Excerpt
              postItem.Excerpt = element;
              break;
            case "extended": //Extended
              postItem.Extended = element;
              break;
            case "post": // Post
              postItem.PostStatus = element;
              break;
            case "formatting": // textFormatting
              postItem.TextFormatting = element;
              break;
            case "keywords": // Keywords
              postItem.Keyword = element;
              break;
            case "pings": // Pings
              postItem.Pings = element;
              break;
            case "status":
              if (element == "1")
                postItem.IsPosted = true;
              else
                postItem.IsPosted = false;
              break;
            case "datetime":
              postItem.DateTime = element;
              break;
            case "title": //Title
              postItem.Title = element;
              // done!
              KeepRunning = false;
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

      if (postItem == null)
      {
        MessageBox.Show("Error loading draft!", MainForm.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Stop);
      }
      else
      {
        PushUiData(postItem);
      }

      // reset to clean
      localFilename.Text = fileName;
      m_dirty = false;
      m_mainForm.draftTabs.SelectedTab.Title = fileName.Substring(fileName.LastIndexOf(@"\") + 1);
    }

    internal bool IsDirty()
    {
      return m_dirty;
    }

    private void beenPosted_Click(object sender, System.EventArgs e)
    {
      if (this.m_editMode)
        return;
      if (beenPosted.Text == BeenPostedStatus)
      {
        beenPosted.Text = NotPostedStatus;
      }
      else
      {
        beenPosted.Text = BeenPostedStatus;
      }
    }

    internal void SetPosted(bool state)
    {
      if (state)
      {
        beenPosted.Text = BeenPostedStatus;
      }
      else
      {
        beenPosted.Text = NotPostedStatus;
      }
    }

    private void beenPosted_TextChanged(object sender, System.EventArgs e)
    {
      if (this.m_editMode)
      {
        m_mainForm.draftTabs.SelectedTab.ImageIndex = 1;
        local.Enabled = false;
        localFilename.Enabled = false;
        pingsLabel.Enabled = false;
        pings.Enabled = false;
        pings.Text = NoPingsAllowedStatus;
        return;
      }

      MakeDirty();
      if (beenPosted.Text == BeenPostedStatus)
        m_mainForm.draftTabs.SelectedTab.ImageIndex = 2;
      else
        m_mainForm.draftTabs.SelectedTab.ImageIndex = 0;
    }

    private string MakeFileNameSave(string fileName)
    {
      string safeName = fileName.Replace(@"\", "_");
      safeName = safeName.Replace("/", "_");
      safeName = safeName.Replace(":", "_");
      safeName = safeName.Replace("*", "_");
      safeName = safeName.Replace("?", "_");
      safeName = safeName.Replace("\"", "_");
      safeName = safeName.Replace("<", "_");
      safeName = safeName.Replace(">", "_");
      safeName = safeName.Replace("|", "_");
      return safeName;
    }

    private void minimizeHeader_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
      if (minimizeHeader.Text == "Minimize")
      {
        header.Height = splitter.MinSize;
        minimizeHeader.Text = "Restore";
      }
      else
      {
        if (extended.Height < 90)
        {
          splitter.SplitPosition = splitter.SplitPosition - 53 + extended.Height;
        }
        header.Height = 53;
        minimizeHeader.Text = "Minimize";
      }
    }

    private void minimizeFooter_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
    {
      if (minimizeFooter.Text == "Minimize")
      {
        footer.Height = splitter.MinSize;
        minimizeFooter.Text = "Restore";
      }
      else
      {
        if (extended.Height < 90)
        {
          splitter.SplitPosition = splitter.SplitPosition - 90 + extended.Height;
        }
        footer.Height = 90;
        minimizeFooter.Text = "Minimize";
      }
    }
  }
}
