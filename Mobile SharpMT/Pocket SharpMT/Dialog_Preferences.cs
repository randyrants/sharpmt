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

namespace Pocket_SharpMT
{
	/// <summary>
	/// Summary description for Dialog_Preferences.
	/// </summary>
  public class Dialog_Preferences : System.Windows.Forms.Form {
    public int m_nSelBlog;
    public ArrayList ma_objBlogs;
    public ArrayList ma_objTextFilters;
    public bool m_bMadeDirty;
    private Control m_ctrlCurrent;

    private System.Windows.Forms.TabControl tabOptions;
    private System.Windows.Forms.TabPage tbpOptions;
    private System.Windows.Forms.Label label2;
    public System.Windows.Forms.ComboBox cbComment;
    private System.Windows.Forms.Label lblPostStatus;
    public System.Windows.Forms.ComboBox cbStatus;
    private System.Windows.Forms.Label label1;
    public System.Windows.Forms.ComboBox cbFormatting;
    public System.Windows.Forms.CheckBox ckbAllowPings;
    private System.Windows.Forms.MainMenu mainMenu1;
    private System.Windows.Forms.Button btnDefault;
    public System.Windows.Forms.TextBox ebUnderline;
    public System.Windows.Forms.TextBox ebItalics;
    public System.Windows.Forms.TextBox ebBold;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.Label label6;
    public System.Windows.Forms.TextBox ebImage;
    private System.Windows.Forms.Label label7;
    public System.Windows.Forms.CheckBox ckbServerTime;
    private System.Windows.Forms.Panel panel3;
    private System.Windows.Forms.Label label8;
    public System.Windows.Forms.TextBox eb1;
    public System.Windows.Forms.CheckBox ckb1;
    private System.Windows.Forms.Label label9;
    public System.Windows.Forms.CheckBox ckb2;
    public System.Windows.Forms.TextBox eb2;
    private System.Windows.Forms.TabPage tbpProxy;
    internal System.Windows.Forms.TextBox ebProxyUrl;
    internal System.Windows.Forms.TextBox ebProxyPassword;
    private System.Windows.Forms.Label label12;
    private System.Windows.Forms.Label label13;
    private System.Windows.Forms.Label label14;
    private System.Windows.Forms.Label label15;
    internal System.Windows.Forms.TextBox ebProxyUserName;
    internal System.Windows.Forms.TextBox ebProxyPort;
    internal System.Windows.Forms.CheckBox ckbUseProxy;
    internal System.Windows.Forms.CheckBox ckbProxyAuthentication;
    private System.Windows.Forms.TabPage tbpTags;
    private System.Windows.Forms.TabPage tbpImage;
    public System.Windows.Forms.TextBox ebTarget;
    private System.Windows.Forms.Label label10;
    public System.Windows.Forms.TextBox ebUpload;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Label label11;
    private System.Windows.Forms.Panel panel4;
    private System.Windows.Forms.ContextMenu mnuContext;
    private System.Windows.Forms.MenuItem mniCutPopup;
    private System.Windows.Forms.MenuItem mniCopyPopup;
    private System.Windows.Forms.MenuItem mniPastePopup;
    private System.Windows.Forms.MenuItem mniDeletePopup;
    private TabPage tbpServer;
    private Label lblBlogs;
    private Label lblPassword;
    private Label lblHost;
    private Label lblUsername;
    private Label lblCgi;
    private Button btnRefresh;
    public ComboBox cbBlogs;
    public TextBox ebUsername;
    public TextBox ebPassword;
    public TextBox ebCgi;
    private Panel panel1;
    public CheckBox ckbShowExit;
    public TextBox ebHost;
    public CheckBox ckbBox;
    private Button btnCancel;
    private Button btnOK;
    private Microsoft.WindowsCE.Forms.InputPanel inputPanel;
  
    public Dialog_Preferences() {
      //
      // Required for Windows Form Designer support
      //
      InitializeComponent();

      m_ctrlCurrent = null;

      DialogResult = DialogResult.OK;
      btnOK.DialogResult = DialogResult.OK;
      btnCancel.DialogResult = DialogResult.Cancel;
    
      ma_objBlogs = new ArrayList();
      ma_objTextFilters = null;
      m_nSelBlog = 0;
      m_bMadeDirty = false;
    }

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    protected override void Dispose( bool disposing ) {
      base.Dispose( disposing );
    }

    #region Windows Form Designer generated code
    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent() {
      this.tabOptions = new System.Windows.Forms.TabControl();
      this.tbpServer = new System.Windows.Forms.TabPage();
      this.lblBlogs = new System.Windows.Forms.Label();
      this.lblPassword = new System.Windows.Forms.Label();
      this.lblHost = new System.Windows.Forms.Label();
      this.lblUsername = new System.Windows.Forms.Label();
      this.lblCgi = new System.Windows.Forms.Label();
      this.btnRefresh = new System.Windows.Forms.Button();
      this.cbBlogs = new System.Windows.Forms.ComboBox();
      this.ebUsername = new System.Windows.Forms.TextBox();
      this.mnuContext = new System.Windows.Forms.ContextMenu();
      this.mniCutPopup = new System.Windows.Forms.MenuItem();
      this.mniCopyPopup = new System.Windows.Forms.MenuItem();
      this.mniPastePopup = new System.Windows.Forms.MenuItem();
      this.mniDeletePopup = new System.Windows.Forms.MenuItem();
      this.ebPassword = new System.Windows.Forms.TextBox();
      this.ebCgi = new System.Windows.Forms.TextBox();
      this.panel1 = new System.Windows.Forms.Panel();
      this.ckbShowExit = new System.Windows.Forms.CheckBox();
      this.ebHost = new System.Windows.Forms.TextBox();
      this.ckbBox = new System.Windows.Forms.CheckBox();
      this.tbpProxy = new System.Windows.Forms.TabPage();
      this.panel4 = new System.Windows.Forms.Panel();
      this.ckbProxyAuthentication = new System.Windows.Forms.CheckBox();
      this.ckbUseProxy = new System.Windows.Forms.CheckBox();
      this.ebProxyPort = new System.Windows.Forms.TextBox();
      this.ebProxyUrl = new System.Windows.Forms.TextBox();
      this.ebProxyUserName = new System.Windows.Forms.TextBox();
      this.ebProxyPassword = new System.Windows.Forms.TextBox();
      this.label15 = new System.Windows.Forms.Label();
      this.label12 = new System.Windows.Forms.Label();
      this.label14 = new System.Windows.Forms.Label();
      this.label13 = new System.Windows.Forms.Label();
      this.tbpOptions = new System.Windows.Forms.TabPage();
      this.cbFormatting = new System.Windows.Forms.ComboBox();
      this.cbStatus = new System.Windows.Forms.ComboBox();
      this.lblPostStatus = new System.Windows.Forms.Label();
      this.label2 = new System.Windows.Forms.Label();
      this.cbComment = new System.Windows.Forms.ComboBox();
      this.label1 = new System.Windows.Forms.Label();
      this.ckbServerTime = new System.Windows.Forms.CheckBox();
      this.ckbAllowPings = new System.Windows.Forms.CheckBox();
      this.tbpImage = new System.Windows.Forms.TabPage();
      this.ebTarget = new System.Windows.Forms.TextBox();
      this.label10 = new System.Windows.Forms.Label();
      this.label3 = new System.Windows.Forms.Label();
      this.ebUpload = new System.Windows.Forms.TextBox();
      this.label11 = new System.Windows.Forms.Label();
      this.tbpTags = new System.Windows.Forms.TabPage();
      this.btnDefault = new System.Windows.Forms.Button();
      this.ckb2 = new System.Windows.Forms.CheckBox();
      this.label6 = new System.Windows.Forms.Label();
      this.eb2 = new System.Windows.Forms.TextBox();
      this.label5 = new System.Windows.Forms.Label();
      this.label9 = new System.Windows.Forms.Label();
      this.label4 = new System.Windows.Forms.Label();
      this.ckb1 = new System.Windows.Forms.CheckBox();
      this.ebBold = new System.Windows.Forms.TextBox();
      this.eb1 = new System.Windows.Forms.TextBox();
      this.ebItalics = new System.Windows.Forms.TextBox();
      this.label8 = new System.Windows.Forms.Label();
      this.ebUnderline = new System.Windows.Forms.TextBox();
      this.panel3 = new System.Windows.Forms.Panel();
      this.label7 = new System.Windows.Forms.Label();
      this.ebImage = new System.Windows.Forms.TextBox();
      this.mainMenu1 = new System.Windows.Forms.MainMenu();
      this.inputPanel = new Microsoft.WindowsCE.Forms.InputPanel();
      this.btnCancel = new System.Windows.Forms.Button();
      this.btnOK = new System.Windows.Forms.Button();
      this.tabOptions.SuspendLayout();
      this.tbpServer.SuspendLayout();
      this.tbpProxy.SuspendLayout();
      this.tbpOptions.SuspendLayout();
      this.tbpImage.SuspendLayout();
      this.tbpTags.SuspendLayout();
      this.SuspendLayout();
      // 
      // tabOptions
      // 
      this.tabOptions.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                  | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.tabOptions.Controls.Add(this.tbpServer);
      this.tabOptions.Controls.Add(this.tbpProxy);
      this.tabOptions.Controls.Add(this.tbpOptions);
      this.tabOptions.Controls.Add(this.tbpImage);
      this.tabOptions.Controls.Add(this.tbpTags);
      this.tabOptions.Dock = System.Windows.Forms.DockStyle.None;
      this.tabOptions.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular);
      this.tabOptions.Location = new System.Drawing.Point(0, 0);
      this.tabOptions.Name = "tabOptions";
      this.tabOptions.SelectedIndex = 0;
      this.tabOptions.Size = new System.Drawing.Size(251, 244);
      this.tabOptions.TabIndex = 0;
      // 
      // tbpServer
      // 
      this.tbpServer.AutoScroll = true;
      this.tbpServer.Controls.Add(this.lblBlogs);
      this.tbpServer.Controls.Add(this.lblPassword);
      this.tbpServer.Controls.Add(this.lblHost);
      this.tbpServer.Controls.Add(this.lblUsername);
      this.tbpServer.Controls.Add(this.lblCgi);
      this.tbpServer.Controls.Add(this.btnRefresh);
      this.tbpServer.Controls.Add(this.cbBlogs);
      this.tbpServer.Controls.Add(this.ebUsername);
      this.tbpServer.Controls.Add(this.ebPassword);
      this.tbpServer.Controls.Add(this.ebCgi);
      this.tbpServer.Controls.Add(this.panel1);
      this.tbpServer.Controls.Add(this.ckbShowExit);
      this.tbpServer.Controls.Add(this.ebHost);
      this.tbpServer.Controls.Add(this.ckbBox);
      this.tbpServer.Location = new System.Drawing.Point(0, 0);
      this.tbpServer.Name = "tbpServer";
      this.tbpServer.Size = new System.Drawing.Size(251, 219);
      this.tbpServer.Text = "Server";
      // 
      // lblBlogs
      // 
      this.lblBlogs.Location = new System.Drawing.Point(3, 136);
      this.lblBlogs.Name = "lblBlogs";
      this.lblBlogs.Size = new System.Drawing.Size(55, 15);
      this.lblBlogs.Text = "Blog List:";
      // 
      // lblPassword
      // 
      this.lblPassword.Location = new System.Drawing.Point(3, 106);
      this.lblPassword.Name = "lblPassword";
      this.lblPassword.Size = new System.Drawing.Size(60, 15);
      this.lblPassword.Text = "Password:";
      // 
      // lblHost
      // 
      this.lblHost.Location = new System.Drawing.Point(3, 7);
      this.lblHost.Name = "lblHost";
      this.lblHost.Size = new System.Drawing.Size(76, 15);
      this.lblHost.Text = "Web Server:";
      // 
      // lblUsername
      // 
      this.lblUsername.Location = new System.Drawing.Point(3, 77);
      this.lblUsername.Name = "lblUsername";
      this.lblUsername.Size = new System.Drawing.Size(69, 15);
      this.lblUsername.Text = "User Name:";
      // 
      // lblCgi
      // 
      this.lblCgi.Location = new System.Drawing.Point(3, 34);
      this.lblCgi.Name = "lblCgi";
      this.lblCgi.Size = new System.Drawing.Size(83, 15);
      this.lblCgi.Text = "CGI-BIN Path:";
      // 
      // btnRefresh
      // 
      this.btnRefresh.Location = new System.Drawing.Point(88, 161);
      this.btnRefresh.Name = "btnRefresh";
      this.btnRefresh.Size = new System.Drawing.Size(72, 20);
      this.btnRefresh.TabIndex = 5;
      this.btnRefresh.Text = "Refresh";
      this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
      this.btnRefresh.GotFocus += new System.EventHandler(this.objGeneric_GotFocus);
      // 
      // cbBlogs
      // 
      this.cbBlogs.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.cbBlogs.Items.Add("Tap Refresh to update");
      this.cbBlogs.Location = new System.Drawing.Point(88, 132);
      this.cbBlogs.Name = "cbBlogs";
      this.cbBlogs.Size = new System.Drawing.Size(161, 22);
      this.cbBlogs.TabIndex = 4;
      this.cbBlogs.SelectedIndexChanged += new System.EventHandler(this.cbBlogs_SelectedIndexChanged);
      this.cbBlogs.GotFocus += new System.EventHandler(this.objGeneric_GotFocus);
      // 
      // ebUsername
      // 
      this.ebUsername.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.ebUsername.ContextMenu = this.mnuContext;
      this.ebUsername.Location = new System.Drawing.Point(88, 73);
      this.ebUsername.Name = "ebUsername";
      this.ebUsername.Size = new System.Drawing.Size(161, 21);
      this.ebUsername.TabIndex = 2;
      this.ebUsername.GotFocus += new System.EventHandler(this.ebGeneric_GotFocus);
      this.ebUsername.KeyUp += new System.Windows.Forms.KeyEventHandler(this.ebGeneric_KeyUp);
      this.ebUsername.TextChanged += new System.EventHandler(this.ebGeneric_TextChanged);
      // 
      // mnuContext
      // 
      this.mnuContext.MenuItems.Add(this.mniCutPopup);
      this.mnuContext.MenuItems.Add(this.mniCopyPopup);
      this.mnuContext.MenuItems.Add(this.mniPastePopup);
      this.mnuContext.MenuItems.Add(this.mniDeletePopup);
      this.mnuContext.Popup += new System.EventHandler(this.mnuContext_Popup);
      // 
      // mniCutPopup
      // 
      this.mniCutPopup.Text = "Cut";
      this.mniCutPopup.Click += new System.EventHandler(this.mniCutPopup_Click);
      // 
      // mniCopyPopup
      // 
      this.mniCopyPopup.Text = "Copy";
      this.mniCopyPopup.Click += new System.EventHandler(this.mniCopyPopup_Click);
      // 
      // mniPastePopup
      // 
      this.mniPastePopup.Text = "Paste";
      this.mniPastePopup.Click += new System.EventHandler(this.mniPastePopup_Click);
      // 
      // mniDeletePopup
      // 
      this.mniDeletePopup.Text = "Delete";
      this.mniDeletePopup.Click += new System.EventHandler(this.mniDeletePopup_Click);
      // 
      // ebPassword
      // 
      this.ebPassword.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.ebPassword.ContextMenu = this.mnuContext;
      this.ebPassword.Location = new System.Drawing.Point(88, 102);
      this.ebPassword.Name = "ebPassword";
      this.ebPassword.PasswordChar = '*';
      this.ebPassword.Size = new System.Drawing.Size(161, 21);
      this.ebPassword.TabIndex = 3;
      this.ebPassword.GotFocus += new System.EventHandler(this.ebGeneric_GotFocus);
      this.ebPassword.KeyUp += new System.Windows.Forms.KeyEventHandler(this.ebGeneric_KeyUp);
      this.ebPassword.TextChanged += new System.EventHandler(this.ebGeneric_TextChanged);
      // 
      // ebCgi
      // 
      this.ebCgi.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.ebCgi.ContextMenu = this.mnuContext;
      this.ebCgi.Location = new System.Drawing.Point(88, 30);
      this.ebCgi.Name = "ebCgi";
      this.ebCgi.Size = new System.Drawing.Size(161, 21);
      this.ebCgi.TabIndex = 1;
      this.ebCgi.Text = "/cgipath/mt-xmlrpc.cgi";
      this.ebCgi.GotFocus += new System.EventHandler(this.ebGeneric_GotFocus);
      this.ebCgi.KeyUp += new System.Windows.Forms.KeyEventHandler(this.ebGeneric_KeyUp);
      this.ebCgi.TextChanged += new System.EventHandler(this.ebGeneric_TextChanged);
      // 
      // panel1
      // 
      this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.panel1.BackColor = System.Drawing.Color.Black;
      this.panel1.Location = new System.Drawing.Point(6, 61);
      this.panel1.Name = "panel1";
      this.panel1.Size = new System.Drawing.Size(241, 3);
      // 
      // ckbShowExit
      // 
      this.ckbShowExit.Location = new System.Drawing.Point(3, 188);
      this.ckbShowExit.Name = "ckbShowExit";
      this.ckbShowExit.Size = new System.Drawing.Size(83, 20);
      this.ckbShowExit.TabIndex = 6;
      this.ckbShowExit.TabStop = false;
      this.ckbShowExit.Text = "Show Exit";
      this.ckbShowExit.Visible = false;
      this.ckbShowExit.GotFocus += new System.EventHandler(this.objGeneric_GotFocus);
      // 
      // ebHost
      // 
      this.ebHost.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.ebHost.ContextMenu = this.mnuContext;
      this.ebHost.Location = new System.Drawing.Point(88, 3);
      this.ebHost.Name = "ebHost";
      this.ebHost.Size = new System.Drawing.Size(161, 21);
      this.ebHost.TabIndex = 0;
      this.ebHost.Text = "www.hostname.com";
      this.ebHost.GotFocus += new System.EventHandler(this.ebGeneric_GotFocus);
      this.ebHost.KeyUp += new System.Windows.Forms.KeyEventHandler(this.ebGeneric_KeyUp);
      this.ebHost.TextChanged += new System.EventHandler(this.ebGeneric_TextChanged);
      // 
      // ckbBox
      // 
      this.ckbBox.Location = new System.Drawing.Point(88, 188);
      this.ckbBox.Name = "ckbBox";
      this.ckbBox.Size = new System.Drawing.Size(116, 20);
      this.ckbBox.TabIndex = 7;
      this.ckbBox.Text = "Auto-show SIP";
      this.ckbBox.GotFocus += new System.EventHandler(this.objGeneric_GotFocus);
      // 
      // tbpProxy
      // 
      this.tbpProxy.AutoScroll = true;
      this.tbpProxy.Controls.Add(this.panel4);
      this.tbpProxy.Controls.Add(this.ckbProxyAuthentication);
      this.tbpProxy.Controls.Add(this.ckbUseProxy);
      this.tbpProxy.Controls.Add(this.ebProxyPort);
      this.tbpProxy.Controls.Add(this.ebProxyUrl);
      this.tbpProxy.Controls.Add(this.ebProxyUserName);
      this.tbpProxy.Controls.Add(this.ebProxyPassword);
      this.tbpProxy.Controls.Add(this.label15);
      this.tbpProxy.Controls.Add(this.label12);
      this.tbpProxy.Controls.Add(this.label14);
      this.tbpProxy.Controls.Add(this.label13);
      this.tbpProxy.Location = new System.Drawing.Point(0, 0);
      this.tbpProxy.Name = "tbpProxy";
      this.tbpProxy.Size = new System.Drawing.Size(243, 217);
      this.tbpProxy.Text = "Proxy";
      // 
      // panel4
      // 
      this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.panel4.BackColor = System.Drawing.Color.Black;
      this.panel4.Location = new System.Drawing.Point(5, 84);
      this.panel4.Name = "panel4";
      this.panel4.Size = new System.Drawing.Size(235, 3);
      // 
      // ckbProxyAuthentication
      // 
      this.ckbProxyAuthentication.Enabled = false;
      this.ckbProxyAuthentication.Location = new System.Drawing.Point(3, 92);
      this.ckbProxyAuthentication.Name = "ckbProxyAuthentication";
      this.ckbProxyAuthentication.Size = new System.Drawing.Size(212, 20);
      this.ckbProxyAuthentication.TabIndex = 3;
      this.ckbProxyAuthentication.Text = "My Proxy requires authentication";
      this.ckbProxyAuthentication.GotFocus += new System.EventHandler(this.objGeneric_GotFocus);
      this.ckbProxyAuthentication.CheckStateChanged += new System.EventHandler(this.ckbProxyAuthentication_CheckStateChanged);
      // 
      // ckbUseProxy
      // 
      this.ckbUseProxy.Location = new System.Drawing.Point(3, 3);
      this.ckbUseProxy.Name = "ckbUseProxy";
      this.ckbUseProxy.Size = new System.Drawing.Size(212, 20);
      this.ckbUseProxy.TabIndex = 0;
      this.ckbUseProxy.Text = "Use a proxy for HTTP commands";
      this.ckbUseProxy.GotFocus += new System.EventHandler(this.objGeneric_GotFocus);
      this.ckbUseProxy.CheckStateChanged += new System.EventHandler(this.ckbUseProxy_CheckStateChanged);
      // 
      // ebProxyPort
      // 
      this.ebProxyPort.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.ebProxyPort.ContextMenu = this.mnuContext;
      this.ebProxyPort.Enabled = false;
      this.ebProxyPort.Location = new System.Drawing.Point(89, 53);
      this.ebProxyPort.Name = "ebProxyPort";
      this.ebProxyPort.Size = new System.Drawing.Size(151, 21);
      this.ebProxyPort.TabIndex = 2;
      this.ebProxyPort.Text = "80";
      this.ebProxyPort.GotFocus += new System.EventHandler(this.ebGeneric_GotFocus);
      this.ebProxyPort.KeyUp += new System.Windows.Forms.KeyEventHandler(this.ebGeneric_KeyUp);
      this.ebProxyPort.TextChanged += new System.EventHandler(this.ebGeneric_TextChanged);
      // 
      // ebProxyUrl
      // 
      this.ebProxyUrl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.ebProxyUrl.ContextMenu = this.mnuContext;
      this.ebProxyUrl.Enabled = false;
      this.ebProxyUrl.Location = new System.Drawing.Point(89, 26);
      this.ebProxyUrl.Name = "ebProxyUrl";
      this.ebProxyUrl.Size = new System.Drawing.Size(151, 21);
      this.ebProxyUrl.TabIndex = 1;
      this.ebProxyUrl.Text = "www.yourproxy.com";
      this.ebProxyUrl.GotFocus += new System.EventHandler(this.ebGeneric_GotFocus);
      this.ebProxyUrl.KeyUp += new System.Windows.Forms.KeyEventHandler(this.ebGeneric_KeyUp);
      this.ebProxyUrl.TextChanged += new System.EventHandler(this.ebGeneric_TextChanged);
      // 
      // ebProxyUserName
      // 
      this.ebProxyUserName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.ebProxyUserName.ContextMenu = this.mnuContext;
      this.ebProxyUserName.Enabled = false;
      this.ebProxyUserName.Location = new System.Drawing.Point(89, 118);
      this.ebProxyUserName.Name = "ebProxyUserName";
      this.ebProxyUserName.Size = new System.Drawing.Size(151, 21);
      this.ebProxyUserName.TabIndex = 4;
      this.ebProxyUserName.GotFocus += new System.EventHandler(this.ebGeneric_GotFocus);
      this.ebProxyUserName.KeyUp += new System.Windows.Forms.KeyEventHandler(this.ebGeneric_KeyUp);
      this.ebProxyUserName.TextChanged += new System.EventHandler(this.ebGeneric_TextChanged);
      // 
      // ebProxyPassword
      // 
      this.ebProxyPassword.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.ebProxyPassword.ContextMenu = this.mnuContext;
      this.ebProxyPassword.Enabled = false;
      this.ebProxyPassword.Location = new System.Drawing.Point(89, 147);
      this.ebProxyPassword.Name = "ebProxyPassword";
      this.ebProxyPassword.PasswordChar = '*';
      this.ebProxyPassword.Size = new System.Drawing.Size(151, 21);
      this.ebProxyPassword.TabIndex = 5;
      this.ebProxyPassword.GotFocus += new System.EventHandler(this.ebGeneric_GotFocus);
      this.ebProxyPassword.KeyUp += new System.Windows.Forms.KeyEventHandler(this.ebGeneric_KeyUp);
      this.ebProxyPassword.TextChanged += new System.EventHandler(this.ebGeneric_TextChanged);
      // 
      // label15
      // 
      this.label15.Location = new System.Drawing.Point(3, 122);
      this.label15.Name = "label15";
      this.label15.Size = new System.Drawing.Size(69, 15);
      this.label15.Text = "User Name:";
      // 
      // label12
      // 
      this.label12.Location = new System.Drawing.Point(3, 57);
      this.label12.Name = "label12";
      this.label12.Size = new System.Drawing.Size(83, 15);
      this.label12.Text = "Proxy Port:";
      // 
      // label14
      // 
      this.label14.Location = new System.Drawing.Point(3, 151);
      this.label14.Name = "label14";
      this.label14.Size = new System.Drawing.Size(60, 15);
      this.label14.Text = "Password:";
      // 
      // label13
      // 
      this.label13.Location = new System.Drawing.Point(3, 30);
      this.label13.Name = "label13";
      this.label13.Size = new System.Drawing.Size(76, 15);
      this.label13.Text = "Proxy URL:";
      // 
      // tbpOptions
      // 
      this.tbpOptions.Controls.Add(this.cbFormatting);
      this.tbpOptions.Controls.Add(this.cbStatus);
      this.tbpOptions.Controls.Add(this.lblPostStatus);
      this.tbpOptions.Controls.Add(this.label2);
      this.tbpOptions.Controls.Add(this.cbComment);
      this.tbpOptions.Controls.Add(this.label1);
      this.tbpOptions.Controls.Add(this.ckbServerTime);
      this.tbpOptions.Controls.Add(this.ckbAllowPings);
      this.tbpOptions.Location = new System.Drawing.Point(0, 0);
      this.tbpOptions.Name = "tbpOptions";
      this.tbpOptions.Size = new System.Drawing.Size(243, 217);
      this.tbpOptions.Text = "Defaults";
      // 
      // cbFormatting
      // 
      this.cbFormatting.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.cbFormatting.Items.Add("None");
      this.cbFormatting.Location = new System.Drawing.Point(100, 61);
      this.cbFormatting.Name = "cbFormatting";
      this.cbFormatting.Size = new System.Drawing.Size(137, 22);
      this.cbFormatting.TabIndex = 2;
      this.cbFormatting.SelectedIndexChanged += new System.EventHandler(this.cbBlogs_SelectedIndexChanged);
      this.cbFormatting.GotFocus += new System.EventHandler(this.objGeneric_GotFocus);
      // 
      // cbStatus
      // 
      this.cbStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.cbStatus.Items.Add("Draft");
      this.cbStatus.Items.Add("Publish");
      this.cbStatus.Location = new System.Drawing.Point(100, 2);
      this.cbStatus.Name = "cbStatus";
      this.cbStatus.Size = new System.Drawing.Size(65, 22);
      this.cbStatus.TabIndex = 0;
      this.cbStatus.SelectedIndexChanged += new System.EventHandler(this.cbBlogs_SelectedIndexChanged);
      this.cbStatus.GotFocus += new System.EventHandler(this.objGeneric_GotFocus);
      // 
      // lblPostStatus
      // 
      this.lblPostStatus.Location = new System.Drawing.Point(3, 4);
      this.lblPostStatus.Name = "lblPostStatus";
      this.lblPostStatus.Size = new System.Drawing.Size(75, 14);
      this.lblPostStatus.Text = "Post Status:";
      // 
      // label2
      // 
      this.label2.Location = new System.Drawing.Point(3, 34);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(69, 14);
      this.label2.Text = "Comments:";
      // 
      // cbComment
      // 
      this.cbComment.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.cbComment.Items.Add("None");
      this.cbComment.Items.Add("Open");
      this.cbComment.Items.Add("Closed");
      this.cbComment.Location = new System.Drawing.Point(100, 31);
      this.cbComment.Name = "cbComment";
      this.cbComment.Size = new System.Drawing.Size(109, 22);
      this.cbComment.TabIndex = 1;
      this.cbComment.SelectedIndexChanged += new System.EventHandler(this.cbBlogs_SelectedIndexChanged);
      this.cbComment.GotFocus += new System.EventHandler(this.objGeneric_GotFocus);
      // 
      // label1
      // 
      this.label1.Location = new System.Drawing.Point(2, 64);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(98, 14);
      this.label1.Text = "Text Formatting:";
      // 
      // ckbServerTime
      // 
      this.ckbServerTime.Location = new System.Drawing.Point(99, 89);
      this.ckbServerTime.Name = "ckbServerTime";
      this.ckbServerTime.Size = new System.Drawing.Size(127, 20);
      this.ckbServerTime.TabIndex = 4;
      this.ckbServerTime.Text = "Use Server Time";
      this.ckbServerTime.GotFocus += new System.EventHandler(this.objGeneric_GotFocus);
      this.ckbServerTime.CheckStateChanged += new System.EventHandler(this.ckbAllowPings_CheckStateChanged);
      // 
      // ckbAllowPings
      // 
      this.ckbAllowPings.Location = new System.Drawing.Point(4, 89);
      this.ckbAllowPings.Name = "ckbAllowPings";
      this.ckbAllowPings.Size = new System.Drawing.Size(91, 20);
      this.ckbAllowPings.TabIndex = 3;
      this.ckbAllowPings.Text = "Allow Pings";
      this.ckbAllowPings.GotFocus += new System.EventHandler(this.objGeneric_GotFocus);
      this.ckbAllowPings.CheckStateChanged += new System.EventHandler(this.ckbAllowPings_CheckStateChanged);
      // 
      // tbpImage
      // 
      this.tbpImage.Controls.Add(this.ebTarget);
      this.tbpImage.Controls.Add(this.label10);
      this.tbpImage.Controls.Add(this.label3);
      this.tbpImage.Controls.Add(this.ebUpload);
      this.tbpImage.Controls.Add(this.label11);
      this.tbpImage.Location = new System.Drawing.Point(0, 0);
      this.tbpImage.Name = "tbpImage";
      this.tbpImage.Size = new System.Drawing.Size(243, 217);
      this.tbpImage.Text = "Images";
      // 
      // ebTarget
      // 
      this.ebTarget.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.ebTarget.ContextMenu = this.mnuContext;
      this.ebTarget.Location = new System.Drawing.Point(3, 72);
      this.ebTarget.Name = "ebTarget";
      this.ebTarget.Size = new System.Drawing.Size(237, 21);
      this.ebTarget.TabIndex = 1;
      this.ebTarget.GotFocus += new System.EventHandler(this.ebGeneric_GotFocus);
      this.ebTarget.KeyUp += new System.Windows.Forms.KeyEventHandler(this.ebGeneric_KeyUp);
      // 
      // label10
      // 
      this.label10.Location = new System.Drawing.Point(2, 53);
      this.label10.Name = "label10";
      this.label10.Size = new System.Drawing.Size(100, 14);
      this.label10.Text = "Target:";
      // 
      // label3
      // 
      this.label3.Location = new System.Drawing.Point(2, 4);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(130, 14);
      this.label3.Text = "Upload Image Path:";
      // 
      // ebUpload
      // 
      this.ebUpload.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.ebUpload.ContextMenu = this.mnuContext;
      this.ebUpload.Location = new System.Drawing.Point(3, 25);
      this.ebUpload.Name = "ebUpload";
      this.ebUpload.Size = new System.Drawing.Size(237, 21);
      this.ebUpload.TabIndex = 0;
      this.ebUpload.GotFocus += new System.EventHandler(this.ebGeneric_GotFocus);
      this.ebUpload.KeyUp += new System.Windows.Forms.KeyEventHandler(this.ebGeneric_KeyUp);
      // 
      // label11
      // 
      this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.label11.Location = new System.Drawing.Point(112, 53);
      this.label11.Name = "label11";
      this.label11.Size = new System.Drawing.Size(110, 14);
      this.label11.Text = "(for inserting links)";
      this.label11.TextAlign = System.Drawing.ContentAlignment.TopRight;
      // 
      // tbpTags
      // 
      this.tbpTags.AutoScroll = true;
      this.tbpTags.Controls.Add(this.btnDefault);
      this.tbpTags.Controls.Add(this.ckb2);
      this.tbpTags.Controls.Add(this.label6);
      this.tbpTags.Controls.Add(this.eb2);
      this.tbpTags.Controls.Add(this.label5);
      this.tbpTags.Controls.Add(this.label9);
      this.tbpTags.Controls.Add(this.label4);
      this.tbpTags.Controls.Add(this.ckb1);
      this.tbpTags.Controls.Add(this.ebBold);
      this.tbpTags.Controls.Add(this.eb1);
      this.tbpTags.Controls.Add(this.ebItalics);
      this.tbpTags.Controls.Add(this.label8);
      this.tbpTags.Controls.Add(this.ebUnderline);
      this.tbpTags.Controls.Add(this.panel3);
      this.tbpTags.Controls.Add(this.label7);
      this.tbpTags.Controls.Add(this.ebImage);
      this.tbpTags.Location = new System.Drawing.Point(0, 0);
      this.tbpTags.Name = "tbpTags";
      this.tbpTags.Size = new System.Drawing.Size(243, 217);
      this.tbpTags.Text = "Tags";
      // 
      // btnDefault
      // 
      this.btnDefault.Location = new System.Drawing.Point(124, 31);
      this.btnDefault.Name = "btnDefault";
      this.btnDefault.Size = new System.Drawing.Size(100, 22);
      this.btnDefault.TabIndex = 3;
      this.btnDefault.Text = "Reset Tags";
      this.btnDefault.Click += new System.EventHandler(this.btnDefault_Click);
      this.btnDefault.GotFocus += new System.EventHandler(this.objGeneric_GotFocus);
      // 
      // ckb2
      // 
      this.ckb2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.ckb2.Location = new System.Drawing.Point(18, 179);
      this.ckb2.Name = "ckb2";
      this.ckb2.Size = new System.Drawing.Size(200, 20);
      this.ckb2.TabIndex = 8;
      this.ckb2.Text = "Containted tag: <tag>";
      this.ckb2.GotFocus += new System.EventHandler(this.objGeneric_GotFocus);
      this.ckb2.CheckStateChanged += new System.EventHandler(this.ckb2_CheckStateChanged);
      // 
      // label6
      // 
      this.label6.Location = new System.Drawing.Point(2, 7);
      this.label6.Name = "label6";
      this.label6.Size = new System.Drawing.Size(59, 14);
      this.label6.Text = "Bold:";
      // 
      // eb2
      // 
      this.eb2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.eb2.ContextMenu = this.mnuContext;
      this.eb2.Location = new System.Drawing.Point(107, 151);
      this.eb2.Name = "eb2";
      this.eb2.Size = new System.Drawing.Size(129, 21);
      this.eb2.TabIndex = 7;
      this.eb2.GotFocus += new System.EventHandler(this.ebGeneric_GotFocus);
      this.eb2.KeyUp += new System.Windows.Forms.KeyEventHandler(this.ebGeneric_KeyUp);
      this.eb2.TextChanged += new System.EventHandler(this.eb2_TextChanged);
      // 
      // label5
      // 
      this.label5.Location = new System.Drawing.Point(124, 7);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(56, 14);
      this.label5.Text = "Italics:";
      // 
      // label9
      // 
      this.label9.Location = new System.Drawing.Point(2, 155);
      this.label9.Name = "label9";
      this.label9.Size = new System.Drawing.Size(85, 14);
      this.label9.Text = "Custom tag 2:";
      // 
      // label4
      // 
      this.label4.Location = new System.Drawing.Point(2, 35);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(61, 14);
      this.label4.Text = "Underline:";
      // 
      // ckb1
      // 
      this.ckb1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.ckb1.Location = new System.Drawing.Point(18, 126);
      this.ckb1.Name = "ckb1";
      this.ckb1.Size = new System.Drawing.Size(208, 20);
      this.ckb1.TabIndex = 6;
      this.ckb1.Text = "Containted tag: <tag>";
      this.ckb1.GotFocus += new System.EventHandler(this.objGeneric_GotFocus);
      this.ckb1.CheckStateChanged += new System.EventHandler(this.ckb1_CheckStateChanged);
      // 
      // ebBold
      // 
      this.ebBold.ContextMenu = this.mnuContext;
      this.ebBold.Location = new System.Drawing.Point(68, 3);
      this.ebBold.Name = "ebBold";
      this.ebBold.Size = new System.Drawing.Size(44, 21);
      this.ebBold.TabIndex = 0;
      this.ebBold.GotFocus += new System.EventHandler(this.ebGeneric_GotFocus);
      this.ebBold.KeyUp += new System.Windows.Forms.KeyEventHandler(this.ebGeneric_KeyUp);
      // 
      // eb1
      // 
      this.eb1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.eb1.ContextMenu = this.mnuContext;
      this.eb1.Location = new System.Drawing.Point(107, 98);
      this.eb1.Name = "eb1";
      this.eb1.Size = new System.Drawing.Size(129, 21);
      this.eb1.TabIndex = 5;
      this.eb1.GotFocus += new System.EventHandler(this.ebGeneric_GotFocus);
      this.eb1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.ebGeneric_KeyUp);
      this.eb1.TextChanged += new System.EventHandler(this.eb1_TextChanged);
      // 
      // ebItalics
      // 
      this.ebItalics.ContextMenu = this.mnuContext;
      this.ebItalics.Location = new System.Drawing.Point(180, 3);
      this.ebItalics.Name = "ebItalics";
      this.ebItalics.Size = new System.Drawing.Size(44, 21);
      this.ebItalics.TabIndex = 1;
      this.ebItalics.GotFocus += new System.EventHandler(this.ebGeneric_GotFocus);
      this.ebItalics.KeyUp += new System.Windows.Forms.KeyEventHandler(this.ebGeneric_KeyUp);
      // 
      // label8
      // 
      this.label8.Location = new System.Drawing.Point(2, 102);
      this.label8.Name = "label8";
      this.label8.Size = new System.Drawing.Size(85, 14);
      this.label8.Text = "Custom tag 1:";
      // 
      // ebUnderline
      // 
      this.ebUnderline.ContextMenu = this.mnuContext;
      this.ebUnderline.Location = new System.Drawing.Point(68, 31);
      this.ebUnderline.Name = "ebUnderline";
      this.ebUnderline.Size = new System.Drawing.Size(44, 21);
      this.ebUnderline.TabIndex = 2;
      this.ebUnderline.GotFocus += new System.EventHandler(this.ebGeneric_GotFocus);
      this.ebUnderline.KeyUp += new System.Windows.Forms.KeyEventHandler(this.ebGeneric_KeyUp);
      // 
      // panel3
      // 
      this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.panel3.BackColor = System.Drawing.Color.Black;
      this.panel3.Location = new System.Drawing.Point(4, 88);
      this.panel3.Name = "panel3";
      this.panel3.Size = new System.Drawing.Size(235, 3);
      // 
      // label7
      // 
      this.label7.Location = new System.Drawing.Point(2, 63);
      this.label7.Name = "label7";
      this.label7.Size = new System.Drawing.Size(66, 14);
      this.label7.Text = "Image:";
      // 
      // ebImage
      // 
      this.ebImage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.ebImage.ContextMenu = this.mnuContext;
      this.ebImage.Location = new System.Drawing.Point(68, 59);
      this.ebImage.Name = "ebImage";
      this.ebImage.Size = new System.Drawing.Size(168, 21);
      this.ebImage.TabIndex = 4;
      this.ebImage.GotFocus += new System.EventHandler(this.ebGeneric_GotFocus);
      this.ebImage.KeyUp += new System.Windows.Forms.KeyEventHandler(this.ebGeneric_KeyUp);
      // 
      // btnCancel
      // 
      this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.btnCancel.Location = new System.Drawing.Point(176, 247);
      this.btnCancel.Name = "btnCancel";
      this.btnCancel.Size = new System.Drawing.Size(72, 20);
      this.btnCancel.TabIndex = 8;
      this.btnCancel.Text = "Cancel";
      // 
      // btnOK
      // 
      this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.btnOK.Location = new System.Drawing.Point(100, 247);
      this.btnOK.Name = "btnOK";
      this.btnOK.Size = new System.Drawing.Size(72, 20);
      this.btnOK.TabIndex = 7;
      this.btnOK.Text = "OK";
      // 
      // Dialog_Preferences
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
      this.ClientSize = new System.Drawing.Size(251, 270);
      this.Controls.Add(this.btnCancel);
      this.Controls.Add(this.btnOK);
      this.Controls.Add(this.tabOptions);
      this.Menu = this.mainMenu1;
      this.Name = "Dialog_Preferences";
      this.Text = "Options";
      this.Load += new System.EventHandler(this.Dialog_Preferences_Load);
      this.tabOptions.ResumeLayout(false);
      this.tbpServer.ResumeLayout(false);
      this.tbpProxy.ResumeLayout(false);
      this.tbpOptions.ResumeLayout(false);
      this.tbpImage.ResumeLayout(false);
      this.tbpTags.ResumeLayout(false);
      this.ResumeLayout(false);

    }
    #endregion

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

    private void Dialog_Preferences_Load(object sender, System.EventArgs e) {
      if (ma_objBlogs.Count > 0) {
        // Pop through the Array and update the list
        cbBlogs.Items.Clear();
        for (int i=0; i< ma_objBlogs.Count; i++) {
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
        if (cbBlogs.Text == "Tap Refresh to update") {
          if (MessageBox.Show("You haven't connected to your Blog yet by tapping the Refresh button - do you want to now?", Dialog_Main.m_strAppName, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes) {
            refreshClick();
            e.Cancel = true;
          }
        }
      }
    }

    private void btnRefresh_Click(object sender, System.EventArgs e) {
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
          Uri uriProxy = new Uri(string.Format("http://{0}:{1}",  ebProxyUrl.Text, ebProxyPort.Text));

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
          switch(strValueName) {
            case "blogid": // blogID
              objBI.strId = strElement;
              break;
            case "blogName": // blogName
              objBI.strName = strElement;
              break;
            case "url": // url
              objBI.strUrl= strElement;
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
      for (nField=0; nField < ma_objBlogs.Count; nField++) {
        objBI = (CBlogItem)ma_objBlogs[nField];
        cbBlogs.Items.Add(string.Format("{0} ({1})", objBI.strName, objBI.strId));
      }
      if (nPos >= ma_objBlogs.Count) {
        nPos = 0;
      }
      cbBlogs.SelectedIndex = nPos;
      Cursor.Current = Cursors.Default;
    }

    private void ebGeneric_TextChanged(object sender, System.EventArgs e) {
      this.m_bMadeDirty = true;    
    }

    private void cbBlogs_SelectedIndexChanged(object sender, System.EventArgs e) {
      this.m_bMadeDirty = true;
    }

    private void ebGeneric_GotFocus(object sender, System.EventArgs e) {
      if (Dialog_Main.m_bShowSIP == true) {
        inputPanel.Enabled = true;
      }
      m_ctrlCurrent = (Control)sender;
    }

    private void objGeneric_GotFocus(object sender, System.EventArgs e) {
      if (Dialog_Main.m_bShowSIP == true) {
        inputPanel.Enabled = false;
      }
    }

    private void ckbAllowPings_CheckStateChanged(object sender, System.EventArgs e) {
      this.m_bMadeDirty = true;
    }

    private void btnDefault_Click(object sender, System.EventArgs e) {
      ebBold.Text = "b";
      ebItalics.Text = "i";
      ebUnderline.Text = "u";
      ebImage.Text = "<img src=\"[IMAGELINK]\">";
    }

    private void UpdateLabel(CheckBox ckb, String strTag) {
      if (ckb.Checked) {
        String strBackTag = strTag;
        if (strTag.IndexOf(" ") > -1) {
          strBackTag = strTag.Substring(0, strTag.IndexOf(" "));
        }
        ckb.Text = string.Format("Enclosing tag: <{0}></{1}>", strTag, strBackTag);
      }
      else
        ckb.Text = string.Format("Containted tag: <{0}>", strTag);
    }

    private void eb1_TextChanged(object sender, System.EventArgs e) {
      UpdateLabel(ckb1, eb1.Text);
    }

    private void eb2_TextChanged(object sender, System.EventArgs e) {
      UpdateLabel(ckb2, eb2.Text);
    }

    private void ckb1_CheckStateChanged(object sender, System.EventArgs e) {
      UpdateLabel(ckb1, eb1.Text);
    }

    private void ckb2_CheckStateChanged(object sender, System.EventArgs e) {
      UpdateLabel(ckb2, eb2.Text);
    }

    private void ckbUseProxy_CheckStateChanged(object sender, System.EventArgs e) {
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

    private void ckbProxyAuthentication_CheckStateChanged(object sender, System.EventArgs e) {
      if (ckbUseProxy.Checked) {
        ebProxyUserName.Enabled = ckbProxyAuthentication.Checked;
        ebProxyPassword.Enabled = ckbProxyAuthentication.Checked;
      }
      else {
        ebProxyUserName.Enabled = false;
        ebProxyPassword.Enabled = false;
      }
    }

    private void ebGeneric_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e) {
      // trap for control keys
      if (e.Control) {
        switch(e.KeyCode) {
          case Keys.C:
            if (mniCopyPopup.Enabled)
              EditMenuHelper.Copy();
            break;
          case Keys.X:
            if (mniCutPopup.Enabled)
              EditMenuHelper.Cut();
            break;
          case Keys.V:
            if (mniPastePopup.Enabled)
              EditMenuHelper.Paste();
            break;
        }
      }
    }

    private void mnuContext_Popup(object sender, System.EventArgs e) {
      // Find control with focus
      if (m_ctrlCurrent == null) {
        return;
      }

      TextBox activeTextBox = ((TextBox)m_ctrlCurrent);
    
      if (activeTextBox != null) {
        if (activeTextBox.SelectionLength > 0) {
          mniCutPopup.Enabled = true;
          mniCopyPopup.Enabled = true;
          mniDeletePopup.Enabled = true;
        }
        else {
          mniCutPopup.Enabled = false;
          mniCopyPopup.Enabled = false;
          mniDeletePopup.Enabled = false;
        }
        if (EditMenuHelper.ClipboardHasText()) {
          mniPastePopup.Enabled = true;
        }
        else {
          mniPastePopup.Enabled = false;
        }
      }
      else {
        mniCutPopup.Enabled = false;
        mniCopyPopup.Enabled = false;
        mniDeletePopup.Enabled = false;
        mniPastePopup.Enabled = false;
      }    
    }
    private void mniCutPopup_Click(object sender, System.EventArgs e) {
      EditMenuHelper.Cut();
    }

    private void mniCopyPopup_Click(object sender, System.EventArgs e) {
      EditMenuHelper.Copy();
    }

    private void mniPastePopup_Click(object sender, System.EventArgs e) {
      EditMenuHelper.Paste();
    }

    private void mniDeletePopup_Click(object sender, System.EventArgs e) {
      EditMenuHelper.Clear();
    }
  }
}
