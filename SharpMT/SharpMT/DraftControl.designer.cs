namespace SharpMT
{
  partial class DraftControl
  {
    /// <summary> 
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary> 
    /// Clean up any resources being used.
    /// </summary>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Component Designer generated code

    /// <summary> 
    /// Required method for Designer support - do not modify 
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      this.components = new System.ComponentModel.Container();
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DraftControl));
      this.modeTabs = new Crownwood.Magic.Controls.TabControl();
      this.imageList = new System.Windows.Forms.ImageList(this.components);
      this.mainPage = new Crownwood.Magic.Controls.TabPage();
      this.splitter = new System.Windows.Forms.Splitter();
      this.extended = new System.Windows.Forms.Panel();
      this.extendedEntry = new System.Windows.Forms.TextBox();
      this.label11 = new System.Windows.Forms.Label();
      this.body = new System.Windows.Forms.Panel();
      this.entryBody = new System.Windows.Forms.TextBox();
      this.label10 = new System.Windows.Forms.Label();
      this.footer = new System.Windows.Forms.Panel();
      this.label4 = new System.Windows.Forms.Label();
      this.minimizeFooter = new System.Windows.Forms.LinkLabel();
      this.excerpt = new System.Windows.Forms.TextBox();
      this.label12 = new System.Windows.Forms.Label();
      this.keywords = new System.Windows.Forms.TextBox();
      this.header = new System.Windows.Forms.Panel();
      this.minimizeHeader = new System.Windows.Forms.LinkLabel();
      this.label9 = new System.Windows.Forms.Label();
      this.category = new System.Windows.Forms.ComboBox();
      this.selectCategories = new System.Windows.Forms.Button();
      this.title = new System.Windows.Forms.TextBox();
      this.label8 = new System.Windows.Forms.Label();
      this.advancedPage = new Crownwood.Magic.Controls.TabPage();
      this.beenPosted = new System.Windows.Forms.Label();
      this.localFilename = new System.Windows.Forms.TextBox();
      this.authoredOn = new System.Windows.Forms.Button();
      this.pings = new System.Windows.Forms.TextBox();
      this.allowPings = new System.Windows.Forms.CheckBox();
      this.formatting = new System.Windows.Forms.ComboBox();
      this.comments = new System.Windows.Forms.ComboBox();
      this.postStatus = new System.Windows.Forms.ComboBox();
      this.local = new System.Windows.Forms.Label();
      this.label6 = new System.Windows.Forms.Label();
      this.pingsLabel = new System.Windows.Forms.Label();
      this.label3 = new System.Windows.Forms.Label();
      this.label2 = new System.Windows.Forms.Label();
      this.label1 = new System.Windows.Forms.Label();
      this.previewPage = new Crownwood.Magic.Controls.TabPage();
      this.panel1 = new System.Windows.Forms.Panel();
      this.webBrowser = new System.Windows.Forms.WebBrowser();
      this.modeTabs.SuspendLayout();
      this.mainPage.SuspendLayout();
      this.extended.SuspendLayout();
      this.body.SuspendLayout();
      this.footer.SuspendLayout();
      this.header.SuspendLayout();
      this.advancedPage.SuspendLayout();
      this.previewPage.SuspendLayout();
      this.panel1.SuspendLayout();
      this.SuspendLayout();
      // 
      // modeTabs
      // 
      this.modeTabs.Dock = System.Windows.Forms.DockStyle.Fill;
      this.modeTabs.IDEPixelArea = true;
      this.modeTabs.ImageList = this.imageList;
      this.modeTabs.Location = new System.Drawing.Point(0, 0);
      this.modeTabs.Name = "modeTabs";
      this.modeTabs.SelectedIndex = 2;
      this.modeTabs.SelectedTab = this.previewPage;
      this.modeTabs.Size = new System.Drawing.Size(683, 599);
      this.modeTabs.TabIndex = 0;
      this.modeTabs.TabPages.AddRange(new Crownwood.Magic.Controls.TabPage[] {
            this.mainPage,
            this.advancedPage,
            this.previewPage});
      this.modeTabs.SelectionChanged += new System.EventHandler(this.modeTabs_SelectionChanged);
      // 
      // imageList
      // 
      this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
      this.imageList.TransparentColor = System.Drawing.Color.Transparent;
      this.imageList.Images.SetKeyName(0, "newDraft.bmp");
      this.imageList.Images.SetKeyName(1, "advancedMode.bmp");
      this.imageList.Images.SetKeyName(2, "preview.bmp");
      // 
      // mainPage
      // 
      this.mainPage.Controls.Add(this.splitter);
      this.mainPage.Controls.Add(this.extended);
      this.mainPage.Controls.Add(this.body);
      this.mainPage.Controls.Add(this.footer);
      this.mainPage.Controls.Add(this.header);
      this.mainPage.ImageIndex = 0;
      this.mainPage.Location = new System.Drawing.Point(0, 0);
      this.mainPage.Name = "mainPage";
      this.mainPage.Selected = false;
      this.mainPage.Size = new System.Drawing.Size(683, 574);
      this.mainPage.TabIndex = 0;
      this.mainPage.Title = "Main";
      // 
      // splitter
      // 
      this.splitter.BackColor = System.Drawing.SystemColors.ControlDark;
      this.splitter.Dock = System.Windows.Forms.DockStyle.Top;
      this.splitter.Location = new System.Drawing.Point(0, 179);
      this.splitter.MinSize = 20;
      this.splitter.Name = "splitter";
      this.splitter.Size = new System.Drawing.Size(683, 3);
      this.splitter.TabIndex = 1;
      this.splitter.TabStop = false;
      // 
      // extended
      // 
      this.extended.Controls.Add(this.extendedEntry);
      this.extended.Controls.Add(this.label11);
      this.extended.Dock = System.Windows.Forms.DockStyle.Fill;
      this.extended.Location = new System.Drawing.Point(0, 179);
      this.extended.Name = "extended";
      this.extended.Size = new System.Drawing.Size(683, 305);
      this.extended.TabIndex = 2;
      // 
      // extendedEntry
      // 
      this.extendedEntry.AcceptsReturn = true;
      this.extendedEntry.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                  | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.extendedEntry.Location = new System.Drawing.Point(8, 29);
      this.extendedEntry.Multiline = true;
      this.extendedEntry.Name = "extendedEntry";
      this.extendedEntry.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
      this.extendedEntry.Size = new System.Drawing.Size(665, 269);
      this.extendedEntry.TabIndex = 1;
      this.extendedEntry.Enter += new System.EventHandler(this.genericTextBox_GotFocus);
      this.extendedEntry.Leave += new System.EventHandler(this.genericTextBox_LostFocus);
      this.extendedEntry.KeyUp += new System.Windows.Forms.KeyEventHandler(this.genericTextBox_KeyUp);
      this.extendedEntry.MouseUp += new System.Windows.Forms.MouseEventHandler(this.genericTextBox_MouseUp);
      this.extendedEntry.TextChanged += new System.EventHandler(this.genericTextBox_TextChanged);
      // 
      // label11
      // 
      this.label11.AutoSize = true;
      this.label11.FlatStyle = System.Windows.Forms.FlatStyle.System;
      this.label11.Location = new System.Drawing.Point(8, 9);
      this.label11.Name = "label11";
      this.label11.Size = new System.Drawing.Size(86, 13);
      this.label11.TabIndex = 0;
      this.label11.Text = "E&xtended Entry:";
      // 
      // body
      // 
      this.body.Controls.Add(this.entryBody);
      this.body.Controls.Add(this.label10);
      this.body.Dock = System.Windows.Forms.DockStyle.Top;
      this.body.Location = new System.Drawing.Point(0, 53);
      this.body.Name = "body";
      this.body.Size = new System.Drawing.Size(683, 126);
      this.body.TabIndex = 1;
      // 
      // entryBody
      // 
      this.entryBody.AcceptsReturn = true;
      this.entryBody.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                  | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.entryBody.Location = new System.Drawing.Point(8, 22);
      this.entryBody.Multiline = true;
      this.entryBody.Name = "entryBody";
      this.entryBody.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
      this.entryBody.Size = new System.Drawing.Size(665, 93);
      this.entryBody.TabIndex = 1;
      this.entryBody.Enter += new System.EventHandler(this.genericTextBox_GotFocus);
      this.entryBody.Leave += new System.EventHandler(this.genericTextBox_LostFocus);
      this.entryBody.KeyUp += new System.Windows.Forms.KeyEventHandler(this.genericTextBox_KeyUp);
      this.entryBody.MouseUp += new System.Windows.Forms.MouseEventHandler(this.genericTextBox_MouseUp);
      this.entryBody.TextChanged += new System.EventHandler(this.genericTextBox_TextChanged);
      // 
      // label10
      // 
      this.label10.AutoSize = true;
      this.label10.FlatStyle = System.Windows.Forms.FlatStyle.System;
      this.label10.Location = new System.Drawing.Point(8, 4);
      this.label10.Name = "label10";
      this.label10.Size = new System.Drawing.Size(64, 13);
      this.label10.TabIndex = 0;
      this.label10.Text = "Entry &Body:";
      // 
      // footer
      // 
      this.footer.Controls.Add(this.label4);
      this.footer.Controls.Add(this.minimizeFooter);
      this.footer.Controls.Add(this.excerpt);
      this.footer.Controls.Add(this.label12);
      this.footer.Controls.Add(this.keywords);
      this.footer.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.footer.Location = new System.Drawing.Point(0, 484);
      this.footer.Name = "footer";
      this.footer.Size = new System.Drawing.Size(683, 90);
      this.footer.TabIndex = 3;
      // 
      // label4
      // 
      this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.label4.AutoSize = true;
      this.label4.FlatStyle = System.Windows.Forms.FlatStyle.System;
      this.label4.Location = new System.Drawing.Point(342, 5);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(58, 13);
      this.label4.TabIndex = 2;
      this.label4.Text = "&Keywords:";
      // 
      // minimizeFooter
      // 
      this.minimizeFooter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.minimizeFooter.LinkArea = new System.Windows.Forms.LinkArea(0, 8);
      this.minimizeFooter.Location = new System.Drawing.Point(621, 5);
      this.minimizeFooter.Name = "minimizeFooter";
      this.minimizeFooter.Size = new System.Drawing.Size(52, 15);
      this.minimizeFooter.TabIndex = 4;
      this.minimizeFooter.TabStop = true;
      this.minimizeFooter.Text = "Minimize";
      this.minimizeFooter.TextAlign = System.Drawing.ContentAlignment.TopRight;
      this.minimizeFooter.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.minimizeFooter_LinkClicked);
      // 
      // excerpt
      // 
      this.excerpt.AcceptsReturn = true;
      this.excerpt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.excerpt.Location = new System.Drawing.Point(8, 24);
      this.excerpt.Multiline = true;
      this.excerpt.Name = "excerpt";
      this.excerpt.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
      this.excerpt.Size = new System.Drawing.Size(329, 60);
      this.excerpt.TabIndex = 1;
      this.excerpt.Enter += new System.EventHandler(this.genericTextBox_GotFocus);
      this.excerpt.Leave += new System.EventHandler(this.genericTextBox_LostFocus);
      this.excerpt.KeyUp += new System.Windows.Forms.KeyEventHandler(this.genericTextBox_KeyUp);
      this.excerpt.MouseUp += new System.Windows.Forms.MouseEventHandler(this.genericTextBox_MouseUp);
      this.excerpt.TextChanged += new System.EventHandler(this.genericTextBox_TextChanged);
      // 
      // label12
      // 
      this.label12.AutoSize = true;
      this.label12.FlatStyle = System.Windows.Forms.FlatStyle.System;
      this.label12.Location = new System.Drawing.Point(8, 5);
      this.label12.Name = "label12";
      this.label12.Size = new System.Drawing.Size(48, 13);
      this.label12.TabIndex = 0;
      this.label12.Text = "Exce&rpt:";
      // 
      // keywords
      // 
      this.keywords.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.keywords.Location = new System.Drawing.Point(343, 23);
      this.keywords.Multiline = true;
      this.keywords.Name = "keywords";
      this.keywords.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
      this.keywords.Size = new System.Drawing.Size(330, 61);
      this.keywords.TabIndex = 3;
      this.keywords.Enter += new System.EventHandler(this.genericTextBox_GotFocus);
      this.keywords.Leave += new System.EventHandler(this.genericTextBox_LostFocus);
      this.keywords.KeyUp += new System.Windows.Forms.KeyEventHandler(this.genericTextBox_KeyUp);
      this.keywords.MouseUp += new System.Windows.Forms.MouseEventHandler(this.genericTextBox_MouseUp);
      this.keywords.TextChanged += new System.EventHandler(this.genericTextBox_TextChanged);
      // 
      // header
      // 
      this.header.Controls.Add(this.minimizeHeader);
      this.header.Controls.Add(this.label9);
      this.header.Controls.Add(this.category);
      this.header.Controls.Add(this.selectCategories);
      this.header.Controls.Add(this.title);
      this.header.Controls.Add(this.label8);
      this.header.Dock = System.Windows.Forms.DockStyle.Top;
      this.header.Location = new System.Drawing.Point(0, 0);
      this.header.Name = "header";
      this.header.Size = new System.Drawing.Size(683, 53);
      this.header.TabIndex = 0;
      // 
      // minimizeHeader
      // 
      this.minimizeHeader.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.minimizeHeader.LinkArea = new System.Windows.Forms.LinkArea(0, 8);
      this.minimizeHeader.Location = new System.Drawing.Point(621, 5);
      this.minimizeHeader.Name = "minimizeHeader";
      this.minimizeHeader.Size = new System.Drawing.Size(52, 15);
      this.minimizeHeader.TabIndex = 5;
      this.minimizeHeader.TabStop = true;
      this.minimizeHeader.Text = "Minimize";
      this.minimizeHeader.TextAlign = System.Drawing.ContentAlignment.TopRight;
      this.minimizeHeader.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.minimizeHeader_LinkClicked);
      // 
      // label9
      // 
      this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.label9.AutoSize = true;
      this.label9.FlatStyle = System.Windows.Forms.FlatStyle.System;
      this.label9.Location = new System.Drawing.Point(492, 5);
      this.label9.Name = "label9";
      this.label9.Size = new System.Drawing.Size(95, 13);
      this.label9.TabIndex = 2;
      this.label9.Text = "Primary &Category:";
      // 
      // category
      // 
      this.category.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.category.DropDownHeight = 260;
      this.category.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.category.FormattingEnabled = true;
      this.category.IntegralHeight = false;
      this.category.Items.AddRange(new object[] {
            "(none)"});
      this.category.Location = new System.Drawing.Point(493, 24);
      this.category.Name = "category";
      this.category.Size = new System.Drawing.Size(152, 21);
      this.category.TabIndex = 3;
      this.category.SelectedIndexChanged += new System.EventHandler(this.genericComboBox_SelectedIndexChanged);
      // 
      // selectCategories
      // 
      this.selectCategories.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.selectCategories.FlatStyle = System.Windows.Forms.FlatStyle.System;
      this.selectCategories.Location = new System.Drawing.Point(648, 24);
      this.selectCategories.Name = "selectCategories";
      this.selectCategories.Size = new System.Drawing.Size(25, 21);
      this.selectCategories.TabIndex = 4;
      this.selectCategories.Text = "...";
      this.selectCategories.Click += new System.EventHandler(this.selectCategories_Click);
      // 
      // title
      // 
      this.title.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.title.Location = new System.Drawing.Point(8, 24);
      this.title.Name = "title";
      this.title.Size = new System.Drawing.Size(479, 21);
      this.title.TabIndex = 1;
      this.title.Enter += new System.EventHandler(this.genericTextBox_GotFocus);
      this.title.Leave += new System.EventHandler(this.genericTextBox_LostFocus);
      this.title.KeyUp += new System.Windows.Forms.KeyEventHandler(this.genericTextBox_KeyUp);
      this.title.MouseUp += new System.Windows.Forms.MouseEventHandler(this.genericTextBox_MouseUp);
      this.title.TextChanged += new System.EventHandler(this.genericTextBox_TextChanged);
      // 
      // label8
      // 
      this.label8.AutoSize = true;
      this.label8.FlatStyle = System.Windows.Forms.FlatStyle.System;
      this.label8.Location = new System.Drawing.Point(8, 5);
      this.label8.Name = "label8";
      this.label8.Size = new System.Drawing.Size(31, 13);
      this.label8.TabIndex = 0;
      this.label8.Text = "&Title:";
      // 
      // advancedPage
      // 
      this.advancedPage.Controls.Add(this.beenPosted);
      this.advancedPage.Controls.Add(this.localFilename);
      this.advancedPage.Controls.Add(this.authoredOn);
      this.advancedPage.Controls.Add(this.pings);
      this.advancedPage.Controls.Add(this.allowPings);
      this.advancedPage.Controls.Add(this.formatting);
      this.advancedPage.Controls.Add(this.comments);
      this.advancedPage.Controls.Add(this.postStatus);
      this.advancedPage.Controls.Add(this.local);
      this.advancedPage.Controls.Add(this.label6);
      this.advancedPage.Controls.Add(this.pingsLabel);
      this.advancedPage.Controls.Add(this.label3);
      this.advancedPage.Controls.Add(this.label2);
      this.advancedPage.Controls.Add(this.label1);
      this.advancedPage.ImageIndex = 1;
      this.advancedPage.Location = new System.Drawing.Point(0, 0);
      this.advancedPage.Name = "advancedPage";
      this.advancedPage.Selected = false;
      this.advancedPage.Size = new System.Drawing.Size(683, 574);
      this.advancedPage.TabIndex = 0;
      this.advancedPage.Title = "Advanced";
      this.advancedPage.Visible = false;
      this.advancedPage.Click += new System.EventHandler(this.beenPosted_Click);
      // 
      // beenPosted
      // 
      this.beenPosted.Location = new System.Drawing.Point(120, 254);
      this.beenPosted.Name = "beenPosted";
      this.beenPosted.Size = new System.Drawing.Size(396, 14);
      this.beenPosted.TabIndex = 15;
      this.beenPosted.Text = "This draft has not been posted to the server.";
      this.beenPosted.Click += new System.EventHandler(this.beenPosted_Click);
      this.beenPosted.TextChanged += new System.EventHandler(this.beenPosted_TextChanged);
      // 
      // localFilename
      // 
      this.localFilename.Location = new System.Drawing.Point(120, 226);
      this.localFilename.Name = "localFilename";
      this.localFilename.ReadOnly = true;
      this.localFilename.Size = new System.Drawing.Size(396, 21);
      this.localFilename.TabIndex = 14;
      // 
      // authoredOn
      // 
      this.authoredOn.FlatStyle = System.Windows.Forms.FlatStyle.System;
      this.authoredOn.Location = new System.Drawing.Point(120, 196);
      this.authoredOn.Name = "authoredOn";
      this.authoredOn.Size = new System.Drawing.Size(164, 23);
      this.authoredOn.TabIndex = 12;
      this.authoredOn.Click += new System.EventHandler(this.authoredOn_Clicked);
      // 
      // pings
      // 
      this.pings.Location = new System.Drawing.Point(120, 113);
      this.pings.Multiline = true;
      this.pings.Name = "pings";
      this.pings.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
      this.pings.Size = new System.Drawing.Size(396, 77);
      this.pings.TabIndex = 10;
      this.pings.Enter += new System.EventHandler(this.genericTextBox_GotFocus);
      this.pings.Leave += new System.EventHandler(this.genericTextBox_LostFocus);
      this.pings.KeyUp += new System.Windows.Forms.KeyEventHandler(this.genericTextBox_KeyUp);
      this.pings.MouseUp += new System.Windows.Forms.MouseEventHandler(this.genericTextBox_MouseUp);
      this.pings.TextChanged += new System.EventHandler(this.genericTextBox_TextChanged);
      // 
      // allowPings
      // 
      this.allowPings.AutoSize = true;
      this.allowPings.FlatStyle = System.Windows.Forms.FlatStyle.System;
      this.allowPings.Location = new System.Drawing.Point(120, 89);
      this.allowPings.Name = "allowPings";
      this.allowPings.Size = new System.Drawing.Size(85, 18);
      this.allowPings.TabIndex = 8;
      this.allowPings.Text = "Allo&w Pings";
      this.allowPings.CheckedChanged += new System.EventHandler(this.allowPings_CheckedChanged);
      // 
      // formatting
      // 
      this.formatting.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.formatting.FormattingEnabled = true;
      this.formatting.Items.AddRange(new object[] {
            "None"});
      this.formatting.Location = new System.Drawing.Point(120, 62);
      this.formatting.Name = "formatting";
      this.formatting.Size = new System.Drawing.Size(396, 21);
      this.formatting.TabIndex = 5;
      this.formatting.SelectedIndexChanged += new System.EventHandler(this.genericComboBox_SelectedIndexChanged);
      // 
      // comments
      // 
      this.comments.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.comments.FormattingEnabled = true;
      this.comments.Items.AddRange(new object[] {
            "None",
            "Open",
            "Closed"});
      this.comments.Location = new System.Drawing.Point(120, 32);
      this.comments.Name = "comments";
      this.comments.Size = new System.Drawing.Size(92, 21);
      this.comments.TabIndex = 3;
      this.comments.SelectedIndexChanged += new System.EventHandler(this.genericComboBox_SelectedIndexChanged);
      // 
      // postStatus
      // 
      this.postStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.postStatus.FormattingEnabled = true;
      this.postStatus.Items.AddRange(new object[] {
            "Draft",
            "Publish"});
      this.postStatus.Location = new System.Drawing.Point(120, 4);
      this.postStatus.Name = "postStatus";
      this.postStatus.Size = new System.Drawing.Size(65, 21);
      this.postStatus.TabIndex = 1;
      this.postStatus.SelectedIndexChanged += new System.EventHandler(this.genericComboBox_SelectedIndexChanged);
      // 
      // local
      // 
      this.local.AutoSize = true;
      this.local.FlatStyle = System.Windows.Forms.FlatStyle.System;
      this.local.Location = new System.Drawing.Point(8, 229);
      this.local.Name = "local";
      this.local.Size = new System.Drawing.Size(78, 13);
      this.local.TabIndex = 13;
      this.local.Text = "Local filename:";
      // 
      // label6
      // 
      this.label6.AutoSize = true;
      this.label6.FlatStyle = System.Windows.Forms.FlatStyle.System;
      this.label6.Location = new System.Drawing.Point(8, 201);
      this.label6.Name = "label6";
      this.label6.Size = new System.Drawing.Size(73, 13);
      this.label6.TabIndex = 11;
      this.label6.Text = "A&uthored On:";
      // 
      // pingsLabel
      // 
      this.pingsLabel.AutoSize = true;
      this.pingsLabel.FlatStyle = System.Windows.Forms.FlatStyle.System;
      this.pingsLabel.Location = new System.Drawing.Point(8, 116);
      this.pingsLabel.Name = "pingsLabel";
      this.pingsLabel.Size = new System.Drawing.Size(71, 13);
      this.pingsLabel.TabIndex = 9;
      this.pingsLabel.Text = "&URLs to Ping:";
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.FlatStyle = System.Windows.Forms.FlatStyle.System;
      this.label3.Location = new System.Drawing.Point(8, 65);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(88, 13);
      this.label3.TabIndex = 4;
      this.label3.Text = "Text Fo&rmatting:";
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.FlatStyle = System.Windows.Forms.FlatStyle.System;
      this.label2.Location = new System.Drawing.Point(8, 35);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(61, 13);
      this.label2.TabIndex = 2;
      this.label2.Text = "C&omments:";
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.FlatStyle = System.Windows.Forms.FlatStyle.System;
      this.label1.Location = new System.Drawing.Point(8, 7);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(66, 13);
      this.label1.TabIndex = 0;
      this.label1.Text = "&Post Status:";
      // 
      // previewPage
      // 
      this.previewPage.Controls.Add(this.panel1);
      this.previewPage.ImageIndex = 2;
      this.previewPage.Location = new System.Drawing.Point(0, 0);
      this.previewPage.Name = "previewPage";
      this.previewPage.Size = new System.Drawing.Size(683, 574);
      this.previewPage.TabIndex = 0;
      this.previewPage.Title = "Preview";
      this.previewPage.Visible = false;
      // 
      // panel1
      // 
      this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                  | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
      this.panel1.Controls.Add(this.webBrowser);
      this.panel1.Location = new System.Drawing.Point(10, 11);
      this.panel1.Name = "panel1";
      this.panel1.Size = new System.Drawing.Size(663, 553);
      this.panel1.TabIndex = 0;
      // 
      // webBrowser
      // 
      this.webBrowser.AllowWebBrowserDrop = false;
      this.webBrowser.Dock = System.Windows.Forms.DockStyle.Fill;
      this.webBrowser.IsWebBrowserContextMenuEnabled = false;
      this.webBrowser.Location = new System.Drawing.Point(0, 0);
      this.webBrowser.Name = "webBrowser";
      this.webBrowser.Size = new System.Drawing.Size(659, 549);
      this.webBrowser.TabIndex = 0;
      // 
      // DraftControl
      // 
      this.Controls.Add(this.modeTabs);
      this.Name = "DraftControl";
      this.Size = new System.Drawing.Size(683, 599);
      this.Load += new System.EventHandler(this.DraftControl_Load);
      this.modeTabs.ResumeLayout(false);
      this.mainPage.ResumeLayout(false);
      this.extended.ResumeLayout(false);
      this.extended.PerformLayout();
      this.body.ResumeLayout(false);
      this.body.PerformLayout();
      this.footer.ResumeLayout(false);
      this.footer.PerformLayout();
      this.header.ResumeLayout(false);
      this.header.PerformLayout();
      this.advancedPage.ResumeLayout(false);
      this.advancedPage.PerformLayout();
      this.previewPage.ResumeLayout(false);
      this.panel1.ResumeLayout(false);
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.ImageList imageList;
    internal Crownwood.Magic.Controls.TabControl modeTabs;
    internal Crownwood.Magic.Controls.TabPage mainPage;
    internal Crownwood.Magic.Controls.TabPage advancedPage;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label local;
    private System.Windows.Forms.Label label6;
    private System.Windows.Forms.Label pingsLabel;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Label beenPosted;
    internal System.Windows.Forms.ComboBox postStatus;
    internal System.Windows.Forms.ComboBox comments;
    internal System.Windows.Forms.ComboBox formatting;
    internal System.Windows.Forms.CheckBox allowPings;
    internal System.Windows.Forms.TextBox keywords;
    internal System.Windows.Forms.TextBox pings;
    internal System.Windows.Forms.Button authoredOn;
    internal System.Windows.Forms.TextBox localFilename;
    private System.Windows.Forms.Label label8;
    private System.Windows.Forms.Label label9;
    internal System.Windows.Forms.Button selectCategories;
    internal System.Windows.Forms.TextBox title;
    internal System.Windows.Forms.ComboBox category;
    internal System.Windows.Forms.LinkLabel minimizeHeader;
    internal System.Windows.Forms.LinkLabel minimizeFooter;
    internal System.Windows.Forms.TextBox excerpt;
    private System.Windows.Forms.Label label12;
    internal System.Windows.Forms.Panel header;
    internal System.Windows.Forms.Panel footer;
    private System.Windows.Forms.Panel extended;
    internal System.Windows.Forms.TextBox entryBody;
    private System.Windows.Forms.Label label10;
    internal System.Windows.Forms.TextBox extendedEntry;
    private System.Windows.Forms.Label label11;
    internal System.Windows.Forms.Panel body;
    internal System.Windows.Forms.Splitter splitter;
    private System.Windows.Forms.Panel panel1;
    internal Crownwood.Magic.Controls.TabPage previewPage;
    private System.Windows.Forms.WebBrowser webBrowser;
    private System.Windows.Forms.Label label4;

  }
}
