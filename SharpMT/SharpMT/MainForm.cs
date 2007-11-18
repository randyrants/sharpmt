#region Using directives

using System;
using System.Collections.Generic;
using System.Collections;
using System.Drawing;
using System.Windows.Forms;
using System.Net;
using System.IO;
using System.Threading;
using Crownwood.Magic.Common;
using Crownwood.Magic.Controls;
using Crownwood.Magic.Docking;
using Microsoft.Win32;
using SharpMT.Classes;
using SharpMT.Forms;
using RandyRants.SharpMTExtension;

#endregion

namespace SharpMT
{
  public enum BlogEngine : int { MovableType = 0, TypePad = 1, Generic = 2 };
  public partial class MainForm : Form
  {
    #region Constants
    public const string BloggerKey = "E1903FF629738304B95F476DB59A3236D812D9C625";
    public const string UserAgent = "SharpMT/3.2.0.0";
    public const string ApplicationName = "SharpMT";
    public const string UseDefaultDateTime = "(Use Server Time)"; 
    public const string RegistryKeyName = @"Software\RandyRants\SharpMT"; 
    public const int ToolBarButtons = 29; //# of buttons
    public const int IconCounts = 5; //# of icons
    public const int m_maxMRUDrafts = 8; 
    internal static FindForm m_findForm; 
    internal static SplashScreenForm m_splashScreen = null; 
    public static MainForm m_this = null; 
    public static string m_homeFolder = Application.ExecutablePath.Substring(0, Application.ExecutablePath.LastIndexOf(@"\") + 1);
    public static string m_dataFolder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\RandyRants.com\SharpMT\";
    public static string m_draftsFolder = Environment.GetFolderPath(Environment.SpecialFolder.Personal) + @"\My Drafts\";
    public static string m_magicConfigurationFile = m_dataFolder + "mgcState.xml";
    public static string m_applicationFolder = Application.ExecutablePath;
    public static string m_iBlogFile = m_dataFolder + "RSSFormat.txt";
    public static string m_spellicanConfigFile = m_dataFolder + "spellican.ini"; 
    public static BlogEngine m_blogMode = BlogEngine.MovableType; 
    public static char m_deadCharacter = Convert.ToChar(65279);
    #endregion

    #region Fields
    // Proxy support
    private WebProxy m_webProxy = null;

    // single instance stuff
    internal static System.Threading.Mutex m_mainMutex;
    private System.Threading.WaitHandle m_mainWaitHandle = null;
    private int m_notifiedKeyReturnValue;
    private string m_notifiedKeyName;

    // multi-draft
    private SharpMT.DraftControl m_currentDraft = null;
    internal string m_launchParameters = "";
    internal bool m_validFileAndBlog; 

    // Magic
    protected VisualStyle m_visualStyle; 
    protected DockingManager m_dockingManager;

    internal Size m_gutterSize; 
    internal string m_blogId; 
    internal string m_fontName; 
    internal float m_fontPointSize; 
    internal bool m_boldFont, m_italicFont; 

    private Rectangle m_windowsRectangle; 
    private string m_userName, m_password, m_hostName, m_cgiPath; 
    private int m_port;
    private bool m_useSsl;
    private string m_maxLinksToRefresh; 
    private int m_selectedBlogId; 
    private bool m_refreshAllPosts; 
    private int m_selectedUrlTab; 
    private bool m_tracing;
    public static TracingForm m_tracingForm = null; 
    internal AdvancedSettings m_defaultAdvancedSettings; 
    private bool m_minimizeToSysTray, m_insertImageUrl, m_ascendingSortForLinks, m_ascendingSortForUrlLinks;
    private string m_urlPrefix, m_localFileName, m_remoteFileName; 
    private string m_boldTag, m_italicsTag, m_underlineTag, m_imageTag; 
    private string m_musicTag, m_uploadPath, m_linkId; 
    private string m_imageLink, m_altImageTag; 
    private Control m_currentControl = null; 
    private int m_headerHeight, m_bodyHeight, m_footerHeight; 
    private int m_titleColumnWidth, m_idColumnWidth, m_currentSortedColumn; 
    private int m_urlLinksTitleWidth, m_urlLinksIdWidth, m_currentSortingUrlLinks; 
    private int m_topId = -1, m_rssField = 0; 
    private string m_target; 
    private bool m_proxy, m_proxyAuthentication; 
    private string m_proxyUrl, m_proxyUserName, m_proxyPassword; 
    private int m_proxyPort; 
    private int m_windowState; 

    internal List<CategoryItem> m_categoriesList, m_textFiltersList; 
    private List<BlogItem> m_blogList; 
    private List<string> m_mruDraftsList; 
    private List<CustomTag> m_customTagsList; 
    private List<PlugInItem> m_plugInsList; 
    private List<String> m_urlList;
    #endregion

    #region Panel Fields
    internal System.Windows.Forms.Panel linksPanel; //pnlLinks;
    private System.Windows.Forms.Splitter linksSplitter; //sptLinks;
    internal System.Windows.Forms.ListView linksListView; //lvLinks;
    private System.Windows.Forms.TextBox linksBody; //ebBody;
    internal System.Windows.Forms.ColumnHeader linksTitleColumn; //lvcLinks;
    internal System.Windows.Forms.ColumnHeader linksIdColumn; //lvcLinksID;
    #endregion

    public MainForm()
    {
      // static pointer
      m_this = this;

      // set up directories
      Directory.CreateDirectory(m_dataFolder);

      Thread t = new Thread(new ThreadStart(SplashScreenThread));
      t.Start();

      InitializeComponent();
      mainImageList.Images.AddStrip(new Bitmap(typeof(MainForm), "Images.mainImageList.bmp"));
      iconsImageList.Images.AddStrip(new Bitmap(typeof(MainForm), "Images.icons.bmp"));

      #region Panel Initialization
      // coding
      this.linksPanel = new System.Windows.Forms.Panel();
      this.linksSplitter = new System.Windows.Forms.Splitter();
      this.linksListView = new System.Windows.Forms.ListView();
      this.linksBody = new System.Windows.Forms.TextBox();
      this.linksTitleColumn = new System.Windows.Forms.ColumnHeader();
      this.linksIdColumn = new System.Windows.Forms.ColumnHeader();
      // 
      // linksPanel
      // 
      this.linksPanel.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                           this.linksSplitter,
                                                                           this.linksListView,
                                                                           this.linksBody});
      this.linksPanel.Dock = System.Windows.Forms.DockStyle.Fill;
      this.linksPanel.Name = "linksPanel";
      this.linksPanel.Size = new System.Drawing.Size(724, 540);
      this.linksPanel.TabIndex = 16;
      // 
      // linksSplitter
      // 
      this.linksSplitter.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.linksSplitter.Location = new System.Drawing.Point(0, 456);
      this.linksSplitter.Name = "sptLinks";
      this.linksSplitter.Size = new System.Drawing.Size(724, 4);
      this.linksSplitter.TabIndex = 17;
      this.linksSplitter.TabStop = false;
      // 
      // linksListView
      // 
      this.linksListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
                                                                              this.linksTitleColumn,
                                                                              this.linksIdColumn});
      this.linksListView.Dock = System.Windows.Forms.DockStyle.Fill;
      this.linksListView.FullRowSelect = true;
      this.linksListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Clickable;
      this.linksListView.HideSelection = false;
      this.linksListView.Name = "linksListView";
      this.linksListView.Size = new System.Drawing.Size(724, 460);
      this.linksListView.SmallImageList = this.iconsImageList;
      this.linksListView.TabIndex = 13;
      this.linksListView.View = System.Windows.Forms.View.Details;
      this.linksListView.SizeChanged += new System.EventHandler(this.linksListView_SizeChanged);
      this.linksListView.SelectedIndexChanged += new System.EventHandler(this.linksListView_SelectedIndexChanged);
      this.linksListView.DoubleClick += new System.EventHandler(this.linksListView_DoubleClick);
      this.linksListView.ColumnClick += new ColumnClickEventHandler(this.linksListView_ColumnClick);
      // 
      // linksBody
      // 
      this.linksBody.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.linksBody.Location = new System.Drawing.Point(0, 460);
      this.linksBody.Multiline = true;
      this.linksBody.Name = "linksBody";
      this.linksBody.ReadOnly = true;
      this.linksBody.ScrollBars = System.Windows.Forms.ScrollBars.Both;
      this.linksBody.Size = new System.Drawing.Size(724, 80);
      this.linksBody.TabIndex = 14;
      this.linksBody.Text = "";
      this.linksBody.LostFocus += new System.EventHandler(this.linksBody_LostFocus);
      this.linksBody.GotFocus += new System.EventHandler(this.linksBody_GotFocus);
      this.linksBody.DoubleClick += new System.EventHandler(this.linksBody_DoubleClick);
      // 
      // linksTitleColumn
      // 
      this.linksTitleColumn.Text = "Title";
      // 
      // lvcLinksID
      // 
      this.linksIdColumn.Text = "ID";
      #endregion

      #region Initialization
      m_gutterSize = new Size(8, 8);
      m_blogId = "-1";
      m_categoriesList = new List<CategoryItem>();
      m_textFiltersList = new List<CategoryItem>();

      m_userName = "";
      m_password = "";
      m_hostName = "";
      m_cgiPath = "";
      m_port = 80;
      m_useSsl = false;
      m_blogList = new List<BlogItem>();
      m_mruDraftsList = new List<string>();
      m_customTagsList = new List<CustomTag>();
      m_plugInsList = new List<PlugInItem>();
      m_urlList = new List<String>();
      m_selectedBlogId = 0;
      m_maxLinksToRefresh = "10";
      m_refreshAllPosts = false;
      m_selectedUrlTab = 0;
      m_findForm = null;
      m_fontName = "Microsoft Sans Serif";
      m_fontPointSize = 8.25f;
      m_boldFont = m_italicFont = false;
      m_tracing = false;
      m_defaultAdvancedSettings = new AdvancedSettings();
      m_urlPrefix = "http://";
      m_minimizeToSysTray = false;
      m_localFileName = "";
      m_remoteFileName = "";
      m_boldTag = "b";
      m_italicsTag = "i";
      m_underlineTag = "u";
      m_musicTag = "[ARTIST] - [SONG]";
      m_uploadPath = "";
      m_linkId = "";
      m_imageLink = "";
      m_altImageTag = "";
      m_imageTag = "<img src=\"[IMAGELINK]\">";
      m_insertImageUrl = true;
      m_headerHeight = 53;
      m_bodyHeight = 150;
      m_footerHeight = 90;
      m_titleColumnWidth = -1;
      m_idColumnWidth = 0;
      m_currentSortedColumn = 1;
      m_ascendingSortForLinks = false;
      m_urlLinksTitleWidth = 700;
      m_urlLinksIdWidth = 0;
      m_currentSortingUrlLinks = 1;
      m_ascendingSortForUrlLinks = false;
      m_target = "";
      m_proxy = false;
      m_proxyAuthentication = false;
      m_proxyUrl = "";
      m_proxyUserName = "";
      m_proxyPassword = "";
      m_proxyPort = 80;
      m_windowState = 0;
      #endregion

      #region Panel Setup
      // Magic
      m_visualStyle = VisualStyle.IDE;

      // Reduce the amount of flicker that occurs when windows are redocked within
      // the container. As this prevents unsightly backcolors being drawn in the
      // WM_ERASEBACKGROUND that seems to occur.
      SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
      SetStyle(ControlStyles.AllPaintingInWmPaint, true);

      // Create the object that manages the docking state
      m_dockingManager = new DockingManager(this, m_visualStyle);
      m_dockingManager.InnerControl = formPanel;// formPanel;
      m_dockingManager.OuterControl = statusStrip;// statusStrip;
      m_dockingManager.ContextMenu += new DockingManager.ContextMenuHandler(m_dockingManager_ContextMenu);
      // Create Content 
      Content linksContent = m_dockingManager.Contents.Add(linksPanel, "Blog Links", mainImageList, 0);
      linksContent.CaptionBar = true;
      linksContent.CloseButton = false;
      linksContent.Control.BackColor = SystemColors.MenuBar;//SystemColors.Control;
      linksContent.Control.ForeColor = SystemColors.MenuText;//SystemColors.ControlText;
      m_dockingManager.AddContentWithState(linksContent, State.DockRight);
      m_dockingManager.ToggleContentAutoHide(linksContent);

      // Load configuration
      try
      {
        m_dockingManager.LoadConfigFromFile(m_magicConfigurationFile);
      }
      catch
      {
      }
      #endregion
    }

    private void MainForm_Load(object sender, EventArgs e)
    {
      this.Visible = false;

      this.draftTabs.Appearance = Crownwood.Magic.Controls.TabControl.VisualAppearance.MultiDocument;
      this.draftTabs.SelectionChanged += new System.EventHandler(this.draftTabs_SelectionChanged);
      this.draftTabs.ClosePressed += new System.EventHandler(this.draftTabs_ClosePressed);
      this.draftTabs.ShowArrows = false;

      // Menu Initializations (now mostly in the UI)
      this.linksListView.ContextMenuStrip = this.linksContextMenuStrip;
      this.Text = ApplicationName;

      LoadRegistrySettings();

      SetupProxyInformation();

      // save current directory
      RegistryKey regKey = Registry.CurrentUser.CreateSubKey(RegistryKeyName);
      regKey.SetValue("InstallDirectory", Application.ExecutablePath);
      regKey.Close();

      // set up the data locker
      m_notifiedKeyName = RegistryKeyName + @"\DataLocker";
      regKey = Registry.CurrentUser.CreateSubKey(m_notifiedKeyName);
      regKey.Close();

      //create wait handle
      m_mainWaitHandle = new System.Threading.AutoResetEvent(false);

      //open key
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

      if (m_selectedBlogId > -1)
      {
        if (m_blogList.Count > 0)
        {
          BlogItem blogItem = m_blogList[m_selectedBlogId];
          statusStripPanelBlog.Text = string.Format("{0} ({1})", blogItem.Name, blogItem.ID);
        }
      }

      // set initial menu and toolbars
      viewBlogLinksToolStripMenuItem.Checked = m_dockingManager.Contents["Blog Links"].Visible;//pnlLinks.Visible;

      if (linksListView.Items.Count > 0)
      {
        linksListView.Items[0].Selected = true;
      }
      UpdateConnectionMenuToolbar();

      // reset post b/c it's a new form
      postToServerToolStripButton.Enabled = false;
      postToServerToolStripMenuItem.Enabled = false;
      postAllOpenDraftsToolStripMenuItem.Enabled = false;

      // override for sizing issue
      // Begin:SPELLCHECK_REM
      //axSpellicanCtrl1.Uninitialize();
      //axSpellicanCtrl1.Initialize(m_spellicanConfigFile);
      //axSpellicanCtrl1.Visible = true;
      // End:SPELLCHECK_REM

      this.Visible = true;
      ProcessTheOpenCommand();

      // size up the Links
      if (m_titleColumnWidth < 0)
      {
        linksTitleColumn.Width = linksListView.Width - 4 - (linksListView.Scrollable ? 17 : 0);
        m_titleColumnWidth = linksTitleColumn.Width;
      }
      else
        linksTitleColumn.Width = m_titleColumnWidth;
      linksIdColumn.Width = m_idColumnWidth;

      if (m_currentSortedColumn == 0)
        this.linksListView.ListViewItemSorter = new ListViewItemStringComparer(m_ascendingSortForLinks);
      else
        this.linksListView.ListViewItemSorter = (IComparer)new ListViewItemIntComparer(m_ascendingSortForLinks);

      linksListView.Sort();

      // Update the menu for the custom tags
      if (this.m_customTagsList.Count == 0)
      {
        m_customTagsList.Add(new CustomTag("strike", true));
        m_customTagsList.Add(new CustomTag("br", false));
        m_customTagsList.Add(new CustomTag("hr", false));
      }

      UpdateCustomTags();

      UpdatePlugIns();

      if (m_splashScreen != null)
      {
        this.Activate();
        m_splashScreen.CloseForm();
        m_splashScreen = null;
      }

      if (m_tracing)
      {
        m_tracingForm = new TracingForm();
        m_tracingForm.Show();
      }

      //ResizeStatusBarPanel();

      if (m_currentDraft != null)
      {
        m_currentDraft.title.Focus();
      }
    }

    private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
    {
      m_mainWaitHandle.Close();
      NativeCode.RegCloseKey(m_notifiedKeyReturnValue);

      int tabIndex = draftTabs.TabPages.Count - 1;
      while (tabIndex > -1)
      {
        draftTabs.SelectedIndex = tabIndex;
        m_currentDraft = (DraftControl)draftTabs.TabPages[tabIndex].Controls[0];

        m_headerHeight = m_currentDraft.header.Height;
        m_bodyHeight = m_currentDraft.body.Height;
        m_footerHeight = m_currentDraft.footer.Height;

        if (m_currentDraft.CloseDraft())
        {
          draftTabs.TabPages.RemoveAt(tabIndex);
        }
        else
        {
          e.Cancel = true;
          return;
        }
        tabIndex--;
      }

      SaveRegistrySettings();

      SaveDataFiles();

      if (m_tracingForm != null)
      {
        m_tracingForm.Close();
      }
    }

    #region Overrides
    protected override void OnMove(EventArgs e)
    {
      base.OnMove(e);

      if (WindowState == FormWindowState.Normal)
      {
        if (mainNotifyIcon.Visible == false)
          m_windowsRectangle = DesktopBounds;
        else
          mainNotifyIcon.Visible = false;
        m_windowState = (int)FormWindowState.Normal;
      }
      else if (WindowState == FormWindowState.Minimized)
      {
        if (m_minimizeToSysTray)
        {
          if (this.Visible == true)
          {
            mainNotifyIcon.Visible = true;
            this.Visible = false;
            if (m_tracingForm != null)
              m_tracingForm.Visible = false;
          }
        }
      }
      else if (WindowState == FormWindowState.Maximized)
      {
        if (mainNotifyIcon.Visible == true)
          mainNotifyIcon.Visible = false;
        m_windowState = (int)FormWindowState.Maximized;
      }
    }

    protected override void OnResize(EventArgs e)
    {
      base.OnResize(e);

      if (WindowState == FormWindowState.Normal)
      {
        if (mainNotifyIcon.Visible == false)
          m_windowsRectangle = DesktopBounds;
        else
          mainNotifyIcon.Visible = false;
        m_windowState = (int)FormWindowState.Normal;
        //ResizeStatusBarPanel();
      }
      else if (WindowState == FormWindowState.Minimized)
      {
        if (m_minimizeToSysTray)
        {
          if (this.Visible == true)
          {
            mainNotifyIcon.Visible = true;
            this.Visible = false;
            if (m_tracingForm != null)
              m_tracingForm.Visible = false;
          }
        }
      }
      else if (WindowState == FormWindowState.Maximized)
      {
        if (mainNotifyIcon.Visible == true)
          mainNotifyIcon.Visible = false;
        m_windowState = (int)FormWindowState.Maximized;
        //ResizeStatusBarPanel();
      }
    }
    #endregion
  }
}