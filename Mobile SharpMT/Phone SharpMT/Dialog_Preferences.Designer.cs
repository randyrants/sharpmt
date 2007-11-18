namespace Phone_SharpMT {
  partial class Dialog_Preferences {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;
    private System.Windows.Forms.MainMenu mainMenu1;

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
      this.mainMenu1 = new System.Windows.Forms.MainMenu();
      this.btnOK = new System.Windows.Forms.MenuItem();
      this.mnuMenu = new System.Windows.Forms.MenuItem();
      this.mniServer = new System.Windows.Forms.MenuItem();
      this.mniProxy = new System.Windows.Forms.MenuItem();
      this.mniDefaults = new System.Windows.Forms.MenuItem();
      this.mniImages = new System.Windows.Forms.MenuItem();
      this.menuItem3 = new System.Windows.Forms.MenuItem();
      this.btnCancel = new System.Windows.Forms.MenuItem();
      this.serverPanel = new System.Windows.Forms.Panel();
      this.ckbShowExit = new System.Windows.Forms.CheckBox();
      this.btnRefresh = new System.Windows.Forms.LinkLabel();
      this.cbBlogs = new System.Windows.Forms.ComboBox();
      this.ebPassword = new System.Windows.Forms.TextBox();
      this.lblPassword = new System.Windows.Forms.Label();
      this.ebUsername = new System.Windows.Forms.TextBox();
      this.lblUsername = new System.Windows.Forms.Label();
      this.ebCgi = new System.Windows.Forms.TextBox();
      this.lblCgi = new System.Windows.Forms.Label();
      this.ebHost = new System.Windows.Forms.TextBox();
      this.lblHost = new System.Windows.Forms.Label();
      this.defaultsPanel = new System.Windows.Forms.Panel();
      this.ckbServerTime = new System.Windows.Forms.CheckBox();
      this.ckbAllowPings = new System.Windows.Forms.CheckBox();
      this.cbFormatting = new System.Windows.Forms.ComboBox();
      this.label6 = new System.Windows.Forms.Label();
      this.cbComment = new System.Windows.Forms.ComboBox();
      this.label5 = new System.Windows.Forms.Label();
      this.cbStatus = new System.Windows.Forms.ComboBox();
      this.lblPostStatus = new System.Windows.Forms.Label();
      this.imagesPanel = new System.Windows.Forms.Panel();
      this.ebTarget = new System.Windows.Forms.TextBox();
      this.label8 = new System.Windows.Forms.Label();
      this.ebUpload = new System.Windows.Forms.TextBox();
      this.label7 = new System.Windows.Forms.Label();
      this.proxyPanel = new System.Windows.Forms.Panel();
      this.ckbProxyAuthentication = new System.Windows.Forms.CheckBox();
      this.ckbUseProxy = new System.Windows.Forms.CheckBox();
      this.ebProxyPassword = new System.Windows.Forms.TextBox();
      this.label4 = new System.Windows.Forms.Label();
      this.ebProxyPort = new System.Windows.Forms.TextBox();
      this.ebProxyUserName = new System.Windows.Forms.TextBox();
      this.label2 = new System.Windows.Forms.Label();
      this.label3 = new System.Windows.Forms.Label();
      this.ebProxyUrl = new System.Windows.Forms.TextBox();
      this.label1 = new System.Windows.Forms.Label();
      this.serverPanel.SuspendLayout();
      this.defaultsPanel.SuspendLayout();
      this.imagesPanel.SuspendLayout();
      this.proxyPanel.SuspendLayout();
      this.SuspendLayout();
      // 
      // mainMenu1
      // 
      this.mainMenu1.MenuItems.Add(this.btnOK);
      this.mainMenu1.MenuItems.Add(this.mnuMenu);
      // 
      // btnOK
      // 
      this.btnOK.Text = "Done";
      this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
      // 
      // mnuMenu
      // 
      this.mnuMenu.MenuItems.Add(this.mniServer);
      this.mnuMenu.MenuItems.Add(this.mniProxy);
      this.mnuMenu.MenuItems.Add(this.mniDefaults);
      this.mnuMenu.MenuItems.Add(this.mniImages);
      this.mnuMenu.MenuItems.Add(this.menuItem3);
      this.mnuMenu.MenuItems.Add(this.btnCancel);
      this.mnuMenu.Text = "Menu";
      // 
      // mniServer
      // 
      this.mniServer.Checked = true;
      this.mniServer.Text = "Server";
      this.mniServer.Click += new System.EventHandler(this.mniServer_Click);
      // 
      // mniProxy
      // 
      this.mniProxy.Text = "Proxy";
      this.mniProxy.Click += new System.EventHandler(this.mniProxy_Click);
      // 
      // mniDefaults
      // 
      this.mniDefaults.Text = "Defaults";
      this.mniDefaults.Click += new System.EventHandler(this.mniDefaults_Click);
      // 
      // mniImages
      // 
      this.mniImages.Text = "Images";
      this.mniImages.Click += new System.EventHandler(this.mniImages_Click);
      // 
      // menuItem3
      // 
      this.menuItem3.Text = "-";
      // 
      // btnCancel
      // 
      this.btnCancel.Text = "Cancel";
      this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
      // 
      // serverPanel
      // 
      this.serverPanel.AutoScroll = true;
      this.serverPanel.Controls.Add(this.ckbShowExit);
      this.serverPanel.Controls.Add(this.btnRefresh);
      this.serverPanel.Controls.Add(this.cbBlogs);
      this.serverPanel.Controls.Add(this.ebPassword);
      this.serverPanel.Controls.Add(this.lblPassword);
      this.serverPanel.Controls.Add(this.ebUsername);
      this.serverPanel.Controls.Add(this.lblUsername);
      this.serverPanel.Controls.Add(this.ebCgi);
      this.serverPanel.Controls.Add(this.lblCgi);
      this.serverPanel.Controls.Add(this.ebHost);
      this.serverPanel.Controls.Add(this.lblHost);
      this.serverPanel.Dock = System.Windows.Forms.DockStyle.Fill;
      this.serverPanel.Location = new System.Drawing.Point(0, 0);
      this.serverPanel.Name = "serverPanel";
      this.serverPanel.Size = new System.Drawing.Size(176, 180);
      // 
      // ckbShowExit
      // 
      this.ckbShowExit.Location = new System.Drawing.Point(61, 161);
      this.ckbShowExit.Name = "ckbShowExit";
      this.ckbShowExit.Size = new System.Drawing.Size(112, 15);
      this.ckbShowExit.TabIndex = 6;
      this.ckbShowExit.Text = "Show Exit";
      this.ckbShowExit.Visible = false;
      // 
      // btnRefresh
      // 
      this.btnRefresh.BackColor = System.Drawing.SystemColors.Control;
      this.btnRefresh.Location = new System.Drawing.Point(61, 140);
      this.btnRefresh.Name = "btnRefresh";
      this.btnRefresh.Size = new System.Drawing.Size(57, 18);
      this.btnRefresh.TabIndex = 5;
      this.btnRefresh.Text = "Refresh";
      this.btnRefresh.TextAlign = System.Drawing.ContentAlignment.TopCenter;
      this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
      // 
      // cbBlogs
      // 
      this.cbBlogs.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.cbBlogs.Items.Add("Click Refresh to update");
      this.cbBlogs.Location = new System.Drawing.Point(3, 115);
      this.cbBlogs.Name = "cbBlogs";
      this.cbBlogs.Size = new System.Drawing.Size(167, 22);
      this.cbBlogs.TabIndex = 4;
      this.cbBlogs.SelectedIndexChanged += new System.EventHandler(this.cbBlogs_SelectedIndexChanged);
      // 
      // ebPassword
      // 
      this.ebPassword.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.ebPassword.Location = new System.Drawing.Point(61, 87);
      this.ebPassword.Name = "ebPassword";
      this.ebPassword.PasswordChar = '*';
      this.ebPassword.Size = new System.Drawing.Size(109, 22);
      this.ebPassword.TabIndex = 3;
      this.ebPassword.GotFocus += new System.EventHandler(this.ebGeneric_GotFocus);
      this.ebPassword.TextChanged += new System.EventHandler(this.ebGeneric_TextChanged);
      // 
      // lblPassword
      // 
      this.lblPassword.Location = new System.Drawing.Point(3, 90);
      this.lblPassword.Name = "lblPassword";
      this.lblPassword.Size = new System.Drawing.Size(52, 15);
      this.lblPassword.Text = "Passwrd:";
      // 
      // ebUsername
      // 
      this.ebUsername.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.ebUsername.Location = new System.Drawing.Point(61, 59);
      this.ebUsername.Name = "ebUsername";
      this.ebUsername.Size = new System.Drawing.Size(109, 22);
      this.ebUsername.TabIndex = 2;
      this.ebUsername.GotFocus += new System.EventHandler(this.ebGeneric_GotFocus);
      this.ebUsername.TextChanged += new System.EventHandler(this.ebGeneric_TextChanged);
      // 
      // lblUsername
      // 
      this.lblUsername.Location = new System.Drawing.Point(3, 62);
      this.lblUsername.Name = "lblUsername";
      this.lblUsername.Size = new System.Drawing.Size(52, 15);
      this.lblUsername.Text = "User:";
      // 
      // ebCgi
      // 
      this.ebCgi.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.ebCgi.Location = new System.Drawing.Point(61, 31);
      this.ebCgi.Name = "ebCgi";
      this.ebCgi.Size = new System.Drawing.Size(109, 22);
      this.ebCgi.TabIndex = 1;
      this.ebCgi.Text = "/cgipath/mt-xmlrpc.cgi";
      this.ebCgi.GotFocus += new System.EventHandler(this.ebGeneric_GotFocus);
      this.ebCgi.TextChanged += new System.EventHandler(this.ebGeneric_TextChanged);
      // 
      // lblCgi
      // 
      this.lblCgi.Location = new System.Drawing.Point(3, 34);
      this.lblCgi.Name = "lblCgi";
      this.lblCgi.Size = new System.Drawing.Size(52, 15);
      this.lblCgi.Text = "CGI Path:";
      // 
      // ebHost
      // 
      this.ebHost.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.ebHost.Location = new System.Drawing.Point(61, 3);
      this.ebHost.Name = "ebHost";
      this.ebHost.Size = new System.Drawing.Size(109, 22);
      this.ebHost.TabIndex = 0;
      this.ebHost.Text = "www.hostname.com";
      this.ebHost.GotFocus += new System.EventHandler(this.ebGeneric_GotFocus);
      this.ebHost.TextChanged += new System.EventHandler(this.ebGeneric_TextChanged);
      // 
      // lblHost
      // 
      this.lblHost.Location = new System.Drawing.Point(3, 6);
      this.lblHost.Name = "lblHost";
      this.lblHost.Size = new System.Drawing.Size(34, 15);
      this.lblHost.Text = "Host:";
      // 
      // defaultsPanel
      // 
      this.defaultsPanel.AutoScroll = true;
      this.defaultsPanel.Controls.Add(this.ckbServerTime);
      this.defaultsPanel.Controls.Add(this.ckbAllowPings);
      this.defaultsPanel.Controls.Add(this.cbFormatting);
      this.defaultsPanel.Controls.Add(this.label6);
      this.defaultsPanel.Controls.Add(this.cbComment);
      this.defaultsPanel.Controls.Add(this.label5);
      this.defaultsPanel.Controls.Add(this.cbStatus);
      this.defaultsPanel.Controls.Add(this.lblPostStatus);
      this.defaultsPanel.Dock = System.Windows.Forms.DockStyle.Fill;
      this.defaultsPanel.Location = new System.Drawing.Point(0, 0);
      this.defaultsPanel.Name = "defaultsPanel";
      this.defaultsPanel.Size = new System.Drawing.Size(176, 180);
      this.defaultsPanel.Visible = false;
      // 
      // ckbServerTime
      // 
      this.ckbServerTime.Location = new System.Drawing.Point(3, 153);
      this.ckbServerTime.Name = "ckbServerTime";
      this.ckbServerTime.Size = new System.Drawing.Size(152, 15);
      this.ckbServerTime.TabIndex = 4;
      this.ckbServerTime.Text = "Use Server Time";
      // 
      // ckbAllowPings
      // 
      this.ckbAllowPings.Location = new System.Drawing.Point(3, 132);
      this.ckbAllowPings.Name = "ckbAllowPings";
      this.ckbAllowPings.Size = new System.Drawing.Size(152, 15);
      this.ckbAllowPings.TabIndex = 3;
      this.ckbAllowPings.Text = "Allow Pings";
      this.ckbAllowPings.CheckStateChanged += new System.EventHandler(this.ckbAllowPings_CheckStateChanged);
      // 
      // cbFormatting
      // 
      this.cbFormatting.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.cbFormatting.Items.Add("None");
      this.cbFormatting.Location = new System.Drawing.Point(3, 104);
      this.cbFormatting.Name = "cbFormatting";
      this.cbFormatting.Size = new System.Drawing.Size(170, 22);
      this.cbFormatting.TabIndex = 2;
      this.cbFormatting.SelectedIndexChanged += new System.EventHandler(this.cbBlogs_SelectedIndexChanged);
      // 
      // label6
      // 
      this.label6.Location = new System.Drawing.Point(3, 86);
      this.label6.Name = "label6";
      this.label6.Size = new System.Drawing.Size(112, 15);
      this.label6.Text = "Text Formatting:";
      // 
      // cbComment
      // 
      this.cbComment.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.cbComment.Items.Add("None");
      this.cbComment.Items.Add("Open");
      this.cbComment.Items.Add("Closed");
      this.cbComment.Location = new System.Drawing.Point(3, 61);
      this.cbComment.Name = "cbComment";
      this.cbComment.Size = new System.Drawing.Size(170, 22);
      this.cbComment.TabIndex = 1;
      this.cbComment.SelectedIndexChanged += new System.EventHandler(this.cbBlogs_SelectedIndexChanged);
      // 
      // label5
      // 
      this.label5.Location = new System.Drawing.Point(3, 43);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(70, 15);
      this.label5.Text = "Comments:";
      // 
      // cbStatus
      // 
      this.cbStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.cbStatus.Items.Add("Draft");
      this.cbStatus.Items.Add("Publish");
      this.cbStatus.Location = new System.Drawing.Point(3, 18);
      this.cbStatus.Name = "cbStatus";
      this.cbStatus.Size = new System.Drawing.Size(170, 22);
      this.cbStatus.TabIndex = 0;
      this.cbStatus.SelectedIndexChanged += new System.EventHandler(this.cbBlogs_SelectedIndexChanged);
      // 
      // lblPostStatus
      // 
      this.lblPostStatus.Location = new System.Drawing.Point(3, 0);
      this.lblPostStatus.Name = "lblPostStatus";
      this.lblPostStatus.Size = new System.Drawing.Size(70, 15);
      this.lblPostStatus.Text = "Post Status:";
      // 
      // imagesPanel
      // 
      this.imagesPanel.AutoScroll = true;
      this.imagesPanel.Controls.Add(this.ebTarget);
      this.imagesPanel.Controls.Add(this.label8);
      this.imagesPanel.Controls.Add(this.ebUpload);
      this.imagesPanel.Controls.Add(this.label7);
      this.imagesPanel.Dock = System.Windows.Forms.DockStyle.Fill;
      this.imagesPanel.Location = new System.Drawing.Point(0, 0);
      this.imagesPanel.Name = "imagesPanel";
      this.imagesPanel.Size = new System.Drawing.Size(176, 180);
      this.imagesPanel.Visible = false;
      // 
      // ebTarget
      // 
      this.ebTarget.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.ebTarget.Location = new System.Drawing.Point(3, 60);
      this.ebTarget.Name = "ebTarget";
      this.ebTarget.Size = new System.Drawing.Size(170, 22);
      this.ebTarget.TabIndex = 1;
      this.ebTarget.GotFocus += new System.EventHandler(this.ebGeneric_GotFocus);
      // 
      // label8
      // 
      this.label8.Location = new System.Drawing.Point(3, 42);
      this.label8.Name = "label8";
      this.label8.Size = new System.Drawing.Size(164, 15);
      this.label8.Text = "Target:     (for inserting links)";
      // 
      // ebUpload
      // 
      this.ebUpload.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.ebUpload.Location = new System.Drawing.Point(3, 18);
      this.ebUpload.Name = "ebUpload";
      this.ebUpload.Size = new System.Drawing.Size(170, 22);
      this.ebUpload.TabIndex = 0;
      this.ebUpload.GotFocus += new System.EventHandler(this.ebGeneric_GotFocus);
      // 
      // label7
      // 
      this.label7.Location = new System.Drawing.Point(3, 0);
      this.label7.Name = "label7";
      this.label7.Size = new System.Drawing.Size(124, 15);
      this.label7.Text = "Upload Image Path:";
      // 
      // proxyPanel
      // 
      this.proxyPanel.AutoScroll = true;
      this.proxyPanel.Controls.Add(this.ckbProxyAuthentication);
      this.proxyPanel.Controls.Add(this.ckbUseProxy);
      this.proxyPanel.Controls.Add(this.ebProxyPassword);
      this.proxyPanel.Controls.Add(this.label4);
      this.proxyPanel.Controls.Add(this.ebProxyPort);
      this.proxyPanel.Controls.Add(this.ebProxyUserName);
      this.proxyPanel.Controls.Add(this.label2);
      this.proxyPanel.Controls.Add(this.label3);
      this.proxyPanel.Controls.Add(this.ebProxyUrl);
      this.proxyPanel.Controls.Add(this.label1);
      this.proxyPanel.Dock = System.Windows.Forms.DockStyle.Fill;
      this.proxyPanel.Location = new System.Drawing.Point(0, 0);
      this.proxyPanel.Name = "proxyPanel";
      this.proxyPanel.Size = new System.Drawing.Size(176, 180);
      this.proxyPanel.Visible = false;
      // 
      // ckbProxyAuthentication
      // 
      this.ckbProxyAuthentication.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.ckbProxyAuthentication.Enabled = false;
      this.ckbProxyAuthentication.Location = new System.Drawing.Point(3, 83);
      this.ckbProxyAuthentication.Name = "ckbProxyAuthentication";
      this.ckbProxyAuthentication.Size = new System.Drawing.Size(170, 15);
      this.ckbProxyAuthentication.TabIndex = 8;
      this.ckbProxyAuthentication.Text = "Proxy requires authentication";
      this.ckbProxyAuthentication.CheckStateChanged += new System.EventHandler(this.ckbProxyAuthentication_CheckStateChanged);
      // 
      // ckbUseProxy
      // 
      this.ckbUseProxy.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.ckbUseProxy.Location = new System.Drawing.Point(3, 6);
      this.ckbUseProxy.Name = "ckbUseProxy";
      this.ckbUseProxy.Size = new System.Drawing.Size(182, 15);
      this.ckbUseProxy.TabIndex = 0;
      this.ckbUseProxy.Text = "Use a proxy for HTTP commands";
      this.ckbUseProxy.CheckStateChanged += new System.EventHandler(this.ckbUseProxy_CheckStateChanged);
      // 
      // ebProxyPassword
      // 
      this.ebProxyPassword.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.ebProxyPassword.Enabled = false;
      this.ebProxyPassword.Location = new System.Drawing.Point(61, 133);
      this.ebProxyPassword.Name = "ebProxyPassword";
      this.ebProxyPassword.Size = new System.Drawing.Size(112, 22);
      this.ebProxyPassword.TabIndex = 4;
      this.ebProxyPassword.GotFocus += new System.EventHandler(this.ebGeneric_GotFocus);
      this.ebProxyPassword.TextChanged += new System.EventHandler(this.ebGeneric_TextChanged);
      // 
      // label4
      // 
      this.label4.Location = new System.Drawing.Point(3, 136);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(52, 15);
      this.label4.Text = "Passwrd:";
      // 
      // ebProxyPort
      // 
      this.ebProxyPort.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.ebProxyPort.Enabled = false;
      this.ebProxyPort.Location = new System.Drawing.Point(61, 55);
      this.ebProxyPort.Name = "ebProxyPort";
      this.ebProxyPort.Size = new System.Drawing.Size(112, 22);
      this.ebProxyPort.TabIndex = 2;
      this.ebProxyPort.Text = "80";
      this.ebProxyPort.GotFocus += new System.EventHandler(this.ebGeneric_GotFocus);
      this.ebProxyPort.TextChanged += new System.EventHandler(this.ebGeneric_TextChanged);
      // 
      // ebProxyUserName
      // 
      this.ebProxyUserName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.ebProxyUserName.Enabled = false;
      this.ebProxyUserName.Location = new System.Drawing.Point(61, 105);
      this.ebProxyUserName.Name = "ebProxyUserName";
      this.ebProxyUserName.Size = new System.Drawing.Size(112, 22);
      this.ebProxyUserName.TabIndex = 3;
      this.ebProxyUserName.GotFocus += new System.EventHandler(this.ebGeneric_GotFocus);
      this.ebProxyUserName.TextChanged += new System.EventHandler(this.ebGeneric_TextChanged);
      // 
      // label2
      // 
      this.label2.Location = new System.Drawing.Point(3, 58);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(52, 15);
      this.label2.Text = "Port:";
      // 
      // label3
      // 
      this.label3.Location = new System.Drawing.Point(3, 108);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(52, 15);
      this.label3.Text = "User:";
      // 
      // ebProxyUrl
      // 
      this.ebProxyUrl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.ebProxyUrl.Enabled = false;
      this.ebProxyUrl.Location = new System.Drawing.Point(61, 27);
      this.ebProxyUrl.Name = "ebProxyUrl";
      this.ebProxyUrl.Size = new System.Drawing.Size(112, 22);
      this.ebProxyUrl.TabIndex = 1;
      this.ebProxyUrl.Text = "www.yourproxy.com";
      this.ebProxyUrl.GotFocus += new System.EventHandler(this.ebGeneric_GotFocus);
      this.ebProxyUrl.TextChanged += new System.EventHandler(this.ebGeneric_TextChanged);
      // 
      // label1
      // 
      this.label1.Location = new System.Drawing.Point(3, 30);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(52, 15);
      this.label1.Text = "URL:";
      // 
      // Dialog_Preferences
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
      this.AutoScroll = true;
      this.ClientSize = new System.Drawing.Size(176, 180);
      this.Controls.Add(this.proxyPanel);
      this.Controls.Add(this.imagesPanel);
      this.Controls.Add(this.defaultsPanel);
      this.Controls.Add(this.serverPanel);
      this.KeyPreview = true;
      this.Menu = this.mainMenu1;
      this.Name = "Dialog_Preferences";
      this.Text = "Options";
      this.Load += new System.EventHandler(this.Dialog_Preferences_Load);
      this.serverPanel.ResumeLayout(false);
      this.defaultsPanel.ResumeLayout(false);
      this.imagesPanel.ResumeLayout(false);
      this.proxyPanel.ResumeLayout(false);
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Panel serverPanel;
    private System.Windows.Forms.Label lblHost;
    public System.Windows.Forms.TextBox ebHost;
    public System.Windows.Forms.TextBox ebPassword;
    private System.Windows.Forms.Label lblPassword;
    public System.Windows.Forms.TextBox ebUsername;
    private System.Windows.Forms.Label lblUsername;
    public System.Windows.Forms.TextBox ebCgi;
    private System.Windows.Forms.Label lblCgi;
    private System.Windows.Forms.MenuItem btnOK;
    public System.Windows.Forms.CheckBox ckbShowExit;
    private System.Windows.Forms.LinkLabel btnRefresh;
    public System.Windows.Forms.ComboBox cbBlogs;
    private System.Windows.Forms.MenuItem mnuMenu;
    private System.Windows.Forms.MenuItem mniServer;
    private System.Windows.Forms.MenuItem mniProxy;
    private System.Windows.Forms.MenuItem mniDefaults;
    private System.Windows.Forms.MenuItem mniImages;
    private System.Windows.Forms.MenuItem menuItem3;
    private System.Windows.Forms.MenuItem btnCancel;
    private System.Windows.Forms.Panel defaultsPanel;
    public System.Windows.Forms.ComboBox cbStatus;
    private System.Windows.Forms.Label lblPostStatus;
    public System.Windows.Forms.ComboBox cbComment;
    private System.Windows.Forms.Label label5;
    public System.Windows.Forms.CheckBox ckbServerTime;
    public System.Windows.Forms.CheckBox ckbAllowPings;
    public System.Windows.Forms.ComboBox cbFormatting;
    private System.Windows.Forms.Label label6;
    private System.Windows.Forms.Panel imagesPanel;
    public System.Windows.Forms.TextBox ebTarget;
    private System.Windows.Forms.Label label8;
    public System.Windows.Forms.TextBox ebUpload;
    private System.Windows.Forms.Label label7;
    private System.Windows.Forms.Panel proxyPanel;
    internal System.Windows.Forms.CheckBox ckbProxyAuthentication;
    internal System.Windows.Forms.CheckBox ckbUseProxy;
    internal System.Windows.Forms.TextBox ebProxyPassword;
    private System.Windows.Forms.Label label4;
    internal System.Windows.Forms.TextBox ebProxyPort;
    internal System.Windows.Forms.TextBox ebProxyUserName;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Label label3;
    internal System.Windows.Forms.TextBox ebProxyUrl;
    private System.Windows.Forms.Label label1;
  }
}