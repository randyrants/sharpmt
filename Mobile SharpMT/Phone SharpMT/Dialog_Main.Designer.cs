namespace Phone_SharpMT {
  partial class Dialog_Main {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;
    private System.Windows.Forms.MainMenu mnuMain;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing) {
      if (disposing && (components != null)) {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent() {
      this.mnuMain = new System.Windows.Forms.MainMenu();
      this.tbbSave = new System.Windows.Forms.MenuItem();
      this.mnuTools = new System.Windows.Forms.MenuItem();
      this.menuItem4 = new System.Windows.Forms.MenuItem();
      this.mniNew = new System.Windows.Forms.MenuItem();
      this.mniOpen = new System.Windows.Forms.MenuItem();
      this.menuItem6 = new System.Windows.Forms.MenuItem();
      this.mniSave = new System.Windows.Forms.MenuItem();
      this.mniPost = new System.Windows.Forms.MenuItem();
      this.menuItem1 = new System.Windows.Forms.MenuItem();
      this.mniCategories = new System.Windows.Forms.MenuItem();
      this.mniTextFilters = new System.Windows.Forms.MenuItem();
      this.mniUpload = new System.Windows.Forms.MenuItem();
      this.mniContact = new System.Windows.Forms.MenuItem();
      this.mniOptions = new System.Windows.Forms.MenuItem();
      this.mniAbout = new System.Windows.Forms.MenuItem();
      this.ebTitle = new System.Windows.Forms.TextBox();
      this.lblTitle = new System.Windows.Forms.Label();
      this.lblEntry = new System.Windows.Forms.Label();
      this.ebEntry = new System.Windows.Forms.TextBox();
      this.cbCategories = new System.Windows.Forms.ComboBox();
      this.btnCategories = new System.Windows.Forms.LinkLabel();
      this.lblExtended = new System.Windows.Forms.Label();
      this.ebExtended = new System.Windows.Forms.TextBox();
      this.ebExcerpt = new System.Windows.Forms.TextBox();
      this.lblExcerpt = new System.Windows.Forms.Label();
      this.lblFileTitle = new System.Windows.Forms.Label();
      this.ebKeywords = new System.Windows.Forms.TextBox();
      this.lblKey = new System.Windows.Forms.Label();
      this.ebPings = new System.Windows.Forms.TextBox();
      this.lblUrls = new System.Windows.Forms.Label();
      this.lblPostStatus = new System.Windows.Forms.Label();
      this.cbStatus = new System.Windows.Forms.ComboBox();
      this.cbComment = new System.Windows.Forms.ComboBox();
      this.lblComments = new System.Windows.Forms.Label();
      this.cbFormatting = new System.Windows.Forms.ComboBox();
      this.lblText = new System.Windows.Forms.Label();
      this.lblDate = new System.Windows.Forms.Label();
      this.dtDate = new System.Windows.Forms.DateTimePicker();
      this.dtTime = new System.Windows.Forms.DateTimePicker();
      this.lblTime = new System.Windows.Forms.Label();
      this.ckbServer = new System.Windows.Forms.CheckBox();
      this.ckbServerPosted = new System.Windows.Forms.CheckBox();
      this.ckbAllowPings = new System.Windows.Forms.CheckBox();
      this.lblLocalName = new System.Windows.Forms.Label();
      this.SuspendLayout();
      // 
      // mnuMain
      // 
      this.mnuMain.MenuItems.Add(this.tbbSave);
      this.mnuMain.MenuItems.Add(this.mnuTools);
      // 
      // tbbSave
      // 
      this.tbbSave.Text = "Save";
      this.tbbSave.Click += new System.EventHandler(this.mniSave_Click);
      // 
      // mnuTools
      // 
      this.mnuTools.MenuItems.Add(this.menuItem4);
      this.mnuTools.MenuItems.Add(this.menuItem1);
      this.mnuTools.MenuItems.Add(this.mniPost);
      this.mnuTools.MenuItems.Add(this.mniContact);
      this.mnuTools.MenuItems.Add(this.mniOptions);
      this.mnuTools.MenuItems.Add(this.mniAbout);
      this.mnuTools.Text = "Tools";
      // 
      // menuItem4
      // 
      this.menuItem4.MenuItems.Add(this.mniNew);
      this.menuItem4.MenuItems.Add(this.mniOpen);
      this.menuItem4.MenuItems.Add(this.menuItem6);
      this.menuItem4.MenuItems.Add(this.mniSave);
      this.menuItem4.Text = "Drafts";
      // 
      // mniNew
      // 
      this.mniNew.Text = "New Draft";
      this.mniNew.Click += new System.EventHandler(this.mniNew_Click);
      // 
      // mniOpen
      // 
      this.mniOpen.Text = "Open Draft...";
      this.mniOpen.Click += new System.EventHandler(this.mniOpen_Click);
      // 
      // menuItem6
      // 
      this.menuItem6.Text = "-";
      // 
      // mniSave
      // 
      this.mniSave.Text = "Save Draft";
      this.mniSave.Click += new System.EventHandler(this.mniSave_Click);
      // 
      // mniPost
      // 
      this.mniPost.Text = "Post to Server";
      this.mniPost.Click += new System.EventHandler(this.mniPost_Click);
      // 
      // menuItem1
      // 
      this.menuItem1.MenuItems.Add(this.mniCategories);
      this.menuItem1.MenuItems.Add(this.mniTextFilters);
      this.menuItem1.MenuItems.Add(this.mniUpload);
      this.menuItem1.Text = "Server";
      // 
      // mniCategories
      // 
      this.mniCategories.Text = "Update Categories";
      this.mniCategories.Click += new System.EventHandler(this.mniCategories_Click);
      // 
      // mniTextFilters
      // 
      this.mniTextFilters.Text = "Update Text Filters";
      this.mniTextFilters.Click += new System.EventHandler(this.mniTextFilters_Click);
      // 
      // mniUpload
      // 
      this.mniUpload.Text = "Upload Media...";
      this.mniUpload.Click += new System.EventHandler(this.mniUpload_Click);
      // 
      // mniContact
      // 
      this.mniContact.Text = "Insert Contact...";
      this.mniContact.Click += new System.EventHandler(this.mniContact_Click);
      // 
      // mniOptions
      // 
      this.mniOptions.Text = "Options...";
      this.mniOptions.Click += new System.EventHandler(this.mniOptions_Click);
      // 
      // mniAbout
      // 
      this.mniAbout.Text = "About...";
      this.mniAbout.Click += new System.EventHandler(this.mniAbout_Click);
      // 
      // ebTitle
      // 
      this.ebTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.ebTitle.Location = new System.Drawing.Point(44, 3);
      this.ebTitle.Name = "ebTitle";
      this.ebTitle.Size = new System.Drawing.Size(122, 22);
      this.ebTitle.TabIndex = 0;
      this.ebTitle.LostFocus += new System.EventHandler(this.ebGeneric_LostFocus);
      this.ebTitle.GotFocus += new System.EventHandler(this.ebGeneric_GotFocus);
      this.ebTitle.KeyUp += new System.Windows.Forms.KeyEventHandler(this.ebGeneric_KeyUp);
      this.ebTitle.TextChanged += new System.EventHandler(this.ebGeneric_TextChanged);
      // 
      // lblTitle
      // 
      this.lblTitle.Location = new System.Drawing.Point(3, 5);
      this.lblTitle.Name = "lblTitle";
      this.lblTitle.Size = new System.Drawing.Size(35, 14);
      this.lblTitle.Text = "Title:";
      // 
      // lblEntry
      // 
      this.lblEntry.Location = new System.Drawing.Point(3, 56);
      this.lblEntry.Name = "lblEntry";
      this.lblEntry.Size = new System.Drawing.Size(109, 14);
      this.lblEntry.Text = "Entry Body:";
      // 
      // ebEntry
      // 
      this.ebEntry.AcceptsReturn = true;
      this.ebEntry.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.ebEntry.Location = new System.Drawing.Point(3, 73);
      this.ebEntry.Multiline = true;
      this.ebEntry.Name = "ebEntry";
      this.ebEntry.Size = new System.Drawing.Size(163, 42);
      this.ebEntry.TabIndex = 3;
      this.ebEntry.LostFocus += new System.EventHandler(this.ebGeneric_LostFocus);
      this.ebEntry.GotFocus += new System.EventHandler(this.ebGeneric_GotFocus);
      this.ebEntry.KeyUp += new System.Windows.Forms.KeyEventHandler(this.ebGeneric_KeyUp);
      this.ebEntry.TextChanged += new System.EventHandler(this.ebGeneric_TextChanged);
      // 
      // cbCategories
      // 
      this.cbCategories.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.cbCategories.Items.Add("(none)");
      this.cbCategories.Location = new System.Drawing.Point(3, 31);
      this.cbCategories.Name = "cbCategories";
      this.cbCategories.Size = new System.Drawing.Size(139, 22);
      this.cbCategories.TabIndex = 1;
      this.cbCategories.SelectedIndexChanged += new System.EventHandler(this.cbGeneric_SelectedIndexChanged);
      // 
      // btnCategories
      // 
      this.btnCategories.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.btnCategories.BackColor = System.Drawing.SystemColors.Control;
      this.btnCategories.Location = new System.Drawing.Point(148, 31);
      this.btnCategories.Name = "btnCategories";
      this.btnCategories.Size = new System.Drawing.Size(18, 22);
      this.btnCategories.TabIndex = 2;
      this.btnCategories.Text = "...";
      this.btnCategories.TextAlign = System.Drawing.ContentAlignment.TopCenter;
      this.btnCategories.Click += new System.EventHandler(this.btnCategories_Click);
      // 
      // lblExtended
      // 
      this.lblExtended.Location = new System.Drawing.Point(3, 118);
      this.lblExtended.Name = "lblExtended";
      this.lblExtended.Size = new System.Drawing.Size(109, 15);
      this.lblExtended.Text = "Extended Entry:";
      // 
      // ebExtended
      // 
      this.ebExtended.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.ebExtended.Location = new System.Drawing.Point(3, 135);
      this.ebExtended.Multiline = true;
      this.ebExtended.Name = "ebExtended";
      this.ebExtended.Size = new System.Drawing.Size(163, 42);
      this.ebExtended.TabIndex = 4;
      this.ebExtended.LostFocus += new System.EventHandler(this.ebGeneric_LostFocus);
      this.ebExtended.GotFocus += new System.EventHandler(this.ebGeneric_GotFocus);
      this.ebExtended.KeyUp += new System.Windows.Forms.KeyEventHandler(this.ebGeneric_KeyUp);
      this.ebExtended.TextChanged += new System.EventHandler(this.ebGeneric_TextChanged);
      // 
      // ebExcerpt
      // 
      this.ebExcerpt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.ebExcerpt.Location = new System.Drawing.Point(3, 198);
      this.ebExcerpt.Multiline = true;
      this.ebExcerpt.Name = "ebExcerpt";
      this.ebExcerpt.Size = new System.Drawing.Size(163, 42);
      this.ebExcerpt.TabIndex = 5;
      this.ebExcerpt.LostFocus += new System.EventHandler(this.ebGeneric_LostFocus);
      this.ebExcerpt.GotFocus += new System.EventHandler(this.ebGeneric_GotFocus);
      this.ebExcerpt.KeyUp += new System.Windows.Forms.KeyEventHandler(this.ebGeneric_KeyUp);
      this.ebExcerpt.TextChanged += new System.EventHandler(this.ebGeneric_TextChanged);
      // 
      // lblExcerpt
      // 
      this.lblExcerpt.Location = new System.Drawing.Point(3, 180);
      this.lblExcerpt.Name = "lblExcerpt";
      this.lblExcerpt.Size = new System.Drawing.Size(109, 15);
      this.lblExcerpt.Text = "Excerpt:";
      // 
      // lblFileTitle
      // 
      this.lblFileTitle.Location = new System.Drawing.Point(85, 56);
      this.lblFileTitle.Name = "lblFileTitle";
      this.lblFileTitle.Size = new System.Drawing.Size(59, 22);
      this.lblFileTitle.Text = "Pocket SharpMT";
      this.lblFileTitle.Visible = false;
      // 
      // ebKeywords
      // 
      this.ebKeywords.AcceptsReturn = true;
      this.ebKeywords.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.ebKeywords.Location = new System.Drawing.Point(3, 261);
      this.ebKeywords.Name = "ebKeywords";
      this.ebKeywords.Size = new System.Drawing.Size(163, 22);
      this.ebKeywords.TabIndex = 6;
      this.ebKeywords.LostFocus += new System.EventHandler(this.ebGeneric_LostFocus);
      this.ebKeywords.GotFocus += new System.EventHandler(this.ebGeneric_GotFocus);
      this.ebKeywords.KeyUp += new System.Windows.Forms.KeyEventHandler(this.ebGeneric_KeyUp);
      this.ebKeywords.TextChanged += new System.EventHandler(this.ebGeneric_TextChanged);
      // 
      // lblKey
      // 
      this.lblKey.Location = new System.Drawing.Point(3, 243);
      this.lblKey.Name = "lblKey";
      this.lblKey.Size = new System.Drawing.Size(109, 15);
      this.lblKey.Text = "Keywords:";
      // 
      // ebPings
      // 
      this.ebPings.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.ebPings.Location = new System.Drawing.Point(3, 304);
      this.ebPings.Multiline = true;
      this.ebPings.Name = "ebPings";
      this.ebPings.Size = new System.Drawing.Size(163, 42);
      this.ebPings.TabIndex = 7;
      this.ebPings.LostFocus += new System.EventHandler(this.ebGeneric_LostFocus);
      this.ebPings.GotFocus += new System.EventHandler(this.ebGeneric_GotFocus);
      this.ebPings.KeyUp += new System.Windows.Forms.KeyEventHandler(this.ebGeneric_KeyUp);
      this.ebPings.TextChanged += new System.EventHandler(this.ebGeneric_TextChanged);
      // 
      // lblUrls
      // 
      this.lblUrls.Location = new System.Drawing.Point(3, 286);
      this.lblUrls.Name = "lblUrls";
      this.lblUrls.Size = new System.Drawing.Size(109, 15);
      this.lblUrls.Text = "URLs to Ping:";
      // 
      // lblPostStatus
      // 
      this.lblPostStatus.Location = new System.Drawing.Point(3, 383);
      this.lblPostStatus.Name = "lblPostStatus";
      this.lblPostStatus.Size = new System.Drawing.Size(69, 15);
      this.lblPostStatus.Text = "Post Status:";
      // 
      // cbStatus
      // 
      this.cbStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.cbStatus.Items.Add("Draft");
      this.cbStatus.Items.Add("Publish");
      this.cbStatus.Location = new System.Drawing.Point(78, 380);
      this.cbStatus.Name = "cbStatus";
      this.cbStatus.Size = new System.Drawing.Size(88, 22);
      this.cbStatus.TabIndex = 9;
      this.cbStatus.SelectedIndexChanged += new System.EventHandler(this.cbGeneric_SelectedIndexChanged);
      // 
      // cbComment
      // 
      this.cbComment.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.cbComment.Items.Add("None");
      this.cbComment.Items.Add("Open");
      this.cbComment.Items.Add("Closed");
      this.cbComment.Location = new System.Drawing.Point(78, 408);
      this.cbComment.Name = "cbComment";
      this.cbComment.Size = new System.Drawing.Size(88, 22);
      this.cbComment.TabIndex = 10;
      this.cbComment.SelectedIndexChanged += new System.EventHandler(this.cbGeneric_SelectedIndexChanged);
      // 
      // lblComments
      // 
      this.lblComments.Location = new System.Drawing.Point(3, 412);
      this.lblComments.Name = "lblComments";
      this.lblComments.Size = new System.Drawing.Size(69, 15);
      this.lblComments.Text = "Comments:";
      // 
      // cbFormatting
      // 
      this.cbFormatting.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.cbFormatting.Items.Add("None");
      this.cbFormatting.Location = new System.Drawing.Point(3, 451);
      this.cbFormatting.Name = "cbFormatting";
      this.cbFormatting.Size = new System.Drawing.Size(163, 22);
      this.cbFormatting.TabIndex = 11;
      this.cbFormatting.SelectedIndexChanged += new System.EventHandler(this.cbGeneric_SelectedIndexChanged);
      // 
      // lblText
      // 
      this.lblText.Location = new System.Drawing.Point(3, 433);
      this.lblText.Name = "lblText";
      this.lblText.Size = new System.Drawing.Size(126, 15);
      this.lblText.Text = "Text Formatting:";
      // 
      // lblDate
      // 
      this.lblDate.Location = new System.Drawing.Point(3, 510);
      this.lblDate.Name = "lblDate";
      this.lblDate.Size = new System.Drawing.Size(69, 15);
      this.lblDate.Text = "Date:";
      // 
      // dtDate
      // 
      this.dtDate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.dtDate.CustomFormat = "MMM\'/\'dd\'/\'yyyy";
      this.dtDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
      this.dtDate.Location = new System.Drawing.Point(78, 507);
      this.dtDate.Name = "dtDate";
      this.dtDate.Size = new System.Drawing.Size(88, 23);
      this.dtDate.TabIndex = 13;
      // 
      // dtTime
      // 
      this.dtTime.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.dtTime.CustomFormat = "hh:mm:ss tt";
      this.dtTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
      this.dtTime.Location = new System.Drawing.Point(78, 536);
      this.dtTime.Name = "dtTime";
      this.dtTime.Size = new System.Drawing.Size(88, 23);
      this.dtTime.TabIndex = 14;
      // 
      // lblTime
      // 
      this.lblTime.Location = new System.Drawing.Point(3, 539);
      this.lblTime.Name = "lblTime";
      this.lblTime.Size = new System.Drawing.Size(69, 15);
      this.lblTime.Text = "Time:";
      // 
      // ckbServer
      // 
      this.ckbServer.Checked = true;
      this.ckbServer.CheckState = System.Windows.Forms.CheckState.Checked;
      this.ckbServer.Location = new System.Drawing.Point(3, 479);
      this.ckbServer.Name = "ckbServer";
      this.ckbServer.Size = new System.Drawing.Size(152, 22);
      this.ckbServer.TabIndex = 12;
      this.ckbServer.Text = "Use Server Time";
      this.ckbServer.CheckStateChanged += new System.EventHandler(this.ckbServer_CheckStateChanged);
      // 
      // ckbServerPosted
      // 
      this.ckbServerPosted.Location = new System.Drawing.Point(3, 565);
      this.ckbServerPosted.Name = "ckbServerPosted";
      this.ckbServerPosted.Size = new System.Drawing.Size(152, 22);
      this.ckbServerPosted.TabIndex = 15;
      this.ckbServerPosted.Text = "posted to server";
      this.ckbServerPosted.CheckStateChanged += new System.EventHandler(this.ckbServerPosted_CheckStateChanged);
      // 
      // ckbAllowPings
      // 
      this.ckbAllowPings.Checked = true;
      this.ckbAllowPings.CheckState = System.Windows.Forms.CheckState.Checked;
      this.ckbAllowPings.Location = new System.Drawing.Point(3, 352);
      this.ckbAllowPings.Name = "ckbAllowPings";
      this.ckbAllowPings.Size = new System.Drawing.Size(152, 22);
      this.ckbAllowPings.TabIndex = 8;
      this.ckbAllowPings.Text = "Allow Pings";
      this.ckbAllowPings.CheckStateChanged += new System.EventHandler(this.ckbAllowPings_CheckedChanged);
      // 
      // lblLocalName
      // 
      this.lblLocalName.Location = new System.Drawing.Point(85, 110);
      this.lblLocalName.Name = "lblLocalName";
      this.lblLocalName.Size = new System.Drawing.Size(59, 22);
      this.lblLocalName.Visible = false;
      // 
      // Dialog_Main
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
      this.AutoScroll = true;
      this.ClientSize = new System.Drawing.Size(169, 180);
      this.Controls.Add(this.ckbAllowPings);
      this.Controls.Add(this.ckbServerPosted);
      this.Controls.Add(this.ckbServer);
      this.Controls.Add(this.dtTime);
      this.Controls.Add(this.lblTime);
      this.Controls.Add(this.dtDate);
      this.Controls.Add(this.lblDate);
      this.Controls.Add(this.cbFormatting);
      this.Controls.Add(this.lblText);
      this.Controls.Add(this.cbComment);
      this.Controls.Add(this.lblComments);
      this.Controls.Add(this.cbStatus);
      this.Controls.Add(this.lblPostStatus);
      this.Controls.Add(this.ebPings);
      this.Controls.Add(this.lblUrls);
      this.Controls.Add(this.ebKeywords);
      this.Controls.Add(this.lblKey);
      this.Controls.Add(this.lblLocalName);
      this.Controls.Add(this.lblFileTitle);
      this.Controls.Add(this.ebExcerpt);
      this.Controls.Add(this.lblExcerpt);
      this.Controls.Add(this.ebExtended);
      this.Controls.Add(this.lblExtended);
      this.Controls.Add(this.btnCategories);
      this.Controls.Add(this.cbCategories);
      this.Controls.Add(this.ebEntry);
      this.Controls.Add(this.lblEntry);
      this.Controls.Add(this.lblTitle);
      this.Controls.Add(this.ebTitle);
      this.KeyPreview = true;
      this.Menu = this.mnuMain;
      this.Name = "Dialog_Main";
      this.Text = "Phone SharpMT";
      this.Closing += new System.ComponentModel.CancelEventHandler(this.Dialog_Main_Closing);
      this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Dialog_Main_KeyDown);
      this.Load += new System.EventHandler(this.Dialog_Main_Load);
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.MenuItem mniExit;

    private System.Windows.Forms.TextBox ebTitle;
    private System.Windows.Forms.Label lblTitle;
    private System.Windows.Forms.Label lblEntry;
    private System.Windows.Forms.TextBox ebEntry;
    private System.Windows.Forms.ComboBox cbCategories;
    private System.Windows.Forms.LinkLabel btnCategories;
    private System.Windows.Forms.Label lblExtended;
    private System.Windows.Forms.TextBox ebExtended;
    private System.Windows.Forms.TextBox ebExcerpt;
    private System.Windows.Forms.Label lblExcerpt;
    private System.Windows.Forms.Label lblFileTitle;
    private System.Windows.Forms.TextBox ebKeywords;
    private System.Windows.Forms.Label lblKey;
    private System.Windows.Forms.TextBox ebPings;
    private System.Windows.Forms.Label lblUrls;
    private System.Windows.Forms.Label lblPostStatus;
    private System.Windows.Forms.ComboBox cbStatus;
    private System.Windows.Forms.ComboBox cbComment;
    private System.Windows.Forms.Label lblComments;
    private System.Windows.Forms.ComboBox cbFormatting;
    private System.Windows.Forms.Label lblText;
    private System.Windows.Forms.Label lblDate;
    private System.Windows.Forms.DateTimePicker dtDate;
    private System.Windows.Forms.DateTimePicker dtTime;
    private System.Windows.Forms.Label lblTime;
    private System.Windows.Forms.CheckBox ckbServer;
    private System.Windows.Forms.MenuItem tbbSave;
    private System.Windows.Forms.MenuItem mniAbout;
    private System.Windows.Forms.MenuItem mnuTools;
    private System.Windows.Forms.MenuItem mniPost;
    private System.Windows.Forms.MenuItem mniCategories;
    private System.Windows.Forms.MenuItem mniTextFilters;
    private System.Windows.Forms.MenuItem mniUpload;
    private System.Windows.Forms.MenuItem mniContact;
    private System.Windows.Forms.MenuItem mniOptions;
    private System.Windows.Forms.CheckBox ckbServerPosted;
    private System.Windows.Forms.CheckBox ckbAllowPings;
    private System.Windows.Forms.Label lblLocalName;
    private System.Windows.Forms.MenuItem menuItem4;
    private System.Windows.Forms.MenuItem mniNew;
    private System.Windows.Forms.MenuItem mniOpen;
    private System.Windows.Forms.MenuItem menuItem6;
    private System.Windows.Forms.MenuItem mniSave;
    private System.Windows.Forms.MenuItem menuItem1;
  }
}

