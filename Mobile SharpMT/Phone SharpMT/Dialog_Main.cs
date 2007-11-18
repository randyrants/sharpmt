using System;
using System.Drawing;
using System.Collections;
using System.Windows.Forms;
using SharpMTClasses;
using System.Xml;
using System.Net;
using System.IO;
using System.Threading;
using Microsoft.Win32;
using Pocket_SharpMT._Objects.code;
using SPFileDialog;
using Microsoft.WindowsMobile.Forms;

namespace Phone_SharpMT {
  public partial class Dialog_Main : Form {
    public enum BlogEngine : int { MovableType = 0, TypePad = 1, Generic = 2 };

    public static string m_strBloggerAppKey = "E1903FF629738304B95F476DB59A3236D812D9C625";
    public static string m_strUserAgent = "SharpMT/3.2.1";
    public static string m_strAppName = "Phone SharpMT";
    public static Dialog_Main m_ptrThis = null;
    public static string m_strDraftsHome = Environment.GetFolderPath(Environment.SpecialFolder.Personal) + @"\My Drafts";

    // SIP on the smartphone is the MainMemory/StorageCard switch
    public static bool m_bShowSIP = true;
    public static string m_strUseDefaultDateTime = "(Use Server Time)";
    public static BlogEngine m_nBlogMode = BlogEngine.MovableType;

    private string m_strRegKey;
    private string m_strBlogId, m_strUsername, m_strPassword, m_strHostname, m_strCgiPath;
    private ArrayList ma_objBlogs;
    private ArrayList ma_objCategories;
    private ArrayList ma_objTextFilters;
    private ArrayList ma_strSelectCat;
    private int m_nSelBlog;
    private CAdvSettings m_advDefaults;
    private string m_strUrlPrefix;
    private string m_strLocalFile, m_strRemoteFile;
    private string m_strBold, m_strItalics, m_strUnderline, m_strImage;
    private Control m_ctrlCurrent;
    private bool m_bLoading, m_bShowExit;
    private string m_strUploadPath;
    private bool m_bInsertImageUrl;
    private string m_strCustomOne, m_strCustomTwo;
    private bool m_bCloseCustomOne, m_bCloseCustomTwo;
    private string m_strDefaultTarget;

    // Proxy support
    private WebProxy m_netProxy = null;
    private bool m_bUseProxy, m_bProxyAuthentication;
    private string m_strProxyUrl, m_strProxyUserName, m_strProxyPassword;
    private int m_nProxyPort;

    public Dialog_Main() {
      // static pointer
      m_ptrThis = this;

      m_bLoading = true;

      InitializeComponent();

      m_ctrlCurrent = null;
      m_strRegKey = "Software\\RandyRants\\SharpMT";
      m_strBlogId = "-1";
      m_strUsername = "";
      m_strPassword = "";
      m_strHostname = "";
      m_strCgiPath = "";
      ma_objBlogs = new ArrayList();
      ma_objCategories = new ArrayList();
      ma_objTextFilters = new ArrayList();
      ma_strSelectCat = new ArrayList();
      m_nSelBlog = 0;
      m_advDefaults = new CAdvSettings();
      m_strUrlPrefix = "http://";
      m_strLocalFile = "";
      m_strRemoteFile = "";
      m_strBold = "b";
      m_strItalics = "i";
      m_strUnderline = "u";
      m_strUploadPath = "";
      m_bShowExit = true;
      m_strImage = "<img src=\"[IMAGELINK]\">";
      m_bInsertImageUrl = true;
      m_strCustomOne = "";
      m_strCustomTwo = "";
      m_bCloseCustomOne = m_bCloseCustomTwo = false;
      m_strDefaultTarget = "";
      m_bUseProxy = false;
      m_bProxyAuthentication = false;
      m_strProxyUrl = "";
      m_strProxyUserName = "";
      m_strProxyPassword = "";
      m_nProxyPort = 80;

    }

    /// <summary>
    /// The main entry point for the application.
    /// </summary>

    [MTAThread]
    static void Main() {
      Application.Run(new Dialog_Main());
    }

    private void Dialog_Main_KeyDown(object sender, KeyEventArgs e) {
      if ((e.KeyCode == System.Windows.Forms.Keys.F1)) {
        // Soft Key 1
        // Not handled when menu is present.
      }
      if ((e.KeyCode == System.Windows.Forms.Keys.F2)) {
        // Soft Key 2
        // Not handled when menu is present.
      }
      if ((e.KeyCode == System.Windows.Forms.Keys.Up)) {
        // Up
      }
      if ((e.KeyCode == System.Windows.Forms.Keys.Down)) {
        // Down
      }
      if ((e.KeyCode == System.Windows.Forms.Keys.Left)) {
        // Left
      }
      if ((e.KeyCode == System.Windows.Forms.Keys.Right)) {
        // Right
      }
      if ((e.KeyCode == System.Windows.Forms.Keys.Enter)) {
        // Enter
      }
      if ((e.KeyCode == System.Windows.Forms.Keys.D1)) {
        // 1
      }
      if ((e.KeyCode == System.Windows.Forms.Keys.D2)) {
        // 2
      }
      if ((e.KeyCode == System.Windows.Forms.Keys.D3)) {
        // 3
      }
      if ((e.KeyCode == System.Windows.Forms.Keys.D4)) {
        // 4
      }
      if ((e.KeyCode == System.Windows.Forms.Keys.D5)) {
        // 5
      }
      if ((e.KeyCode == System.Windows.Forms.Keys.D6)) {
        // 6
      }
      if ((e.KeyCode == System.Windows.Forms.Keys.D7)) {
        // 7
      }
      if ((e.KeyCode == System.Windows.Forms.Keys.D8)) {
        // 8
      }
      if ((e.KeyCode == System.Windows.Forms.Keys.D9)) {
        // 9
      }
      if ((e.KeyCode == System.Windows.Forms.Keys.F8)) {
        // *
      }
      if ((e.KeyCode == System.Windows.Forms.Keys.D0)) {
        // 0
      }
      if ((e.KeyCode == System.Windows.Forms.Keys.F9)) {
        // #
      }

    }

    protected override void OnClosing(System.ComponentModel.CancelEventArgs e) {
      string strTitle = lblFileTitle.Text;//this.Text;
      strTitle = strTitle.Replace(m_strAppName + ": ", "");
      if (strTitle.IndexOf("*") > -1)
        strTitle = strTitle.Replace("*", "");
      strTitle += " has changed.\r\n\r\nDo you want to save these changes?\r\n\r\nTo cancel press Yes and then Cancel.";
      if (mniSave.Enabled == true) {
        DialogResult dlgRes = MessageBox.Show(strTitle, m_strAppName, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
        switch (dlgRes) {
          case DialogResult.Cancel:
          case DialogResult.No:
            break;
          case DialogResult.Yes:
          case DialogResult.OK:
            saveClicked();
            if (mniSave.Enabled) {
              e.Cancel = true;
              return;
            }
            break;
        }
      }
      SaveRegistrySettings();
      //SaveDataFiles();
    }

    private void mniCategories_Click(object sender, EventArgs e) {
      UpdateCategories();
    }

    private void mniTextFilters_Click(object sender, EventArgs e) {
      UpdateTextFilters();
    }

    private void mniUpload_Click(object sender, EventArgs e) {
      // reset the insert link no matter
      String strImageLink = "", strAltTag = "";
      Control ctrl = m_ctrlCurrent;

      // Get the Image names (local and remote)
      Dialog_Upload dlg = new Dialog_Upload();
      dlg.urlLabel.Text = ((CBlogItem)ma_objBlogs[m_nSelBlog]).strUrl;
      dlg.ebRemote.Text = m_strUploadPath;
      dlg.m_strUploadPath = m_strUploadPath;
      if (dlg.urlLabel.Text.Length <= 0) {
        dlg.urlLabel.Text = "Pocket SharpMT couldn't find a URL for this Blog!";
      }

      if (m_bInsertImageUrl)
        dlg.ckbInsert.Checked = true;

      if (ctrl == null) {
        dlg.ckbInsert.Enabled = false;
        dlg.lblAltTag.Enabled = false;
        dlg.ebAltTag.Enabled = false;
      }

      if (dlg.ShowDialog() == DialogResult.Cancel) {
        return;
      }

      m_bInsertImageUrl = dlg.ckbInsert.Checked;
      if (m_bInsertImageUrl) {
        strImageLink = dlg.urlLabel.Text + dlg.ebRemote.Text;
        strAltTag = dlg.ebAltTag.Text;
      }

      // Update the UI if true!
      setCursors(true);
      prepProgress(true);

      m_strLocalFile = dlg.ebLocal.Text;
      m_strRemoteFile = dlg.ebRemote.Text;

      UploadFileThreadProc();

      if (strImageLink.Length > 0) {
        string str = m_strImage;
        str = str.Replace("[IMAGELINK]", strImageLink);
        str = str.Replace("[ALTTAG]", strAltTag);
        if (ctrl != null) {
          ctrl.Focus();
          ((TextBox)ctrl).SelectedText = str;
        }
      }
    }

    private void Dialog_Main_Load(object sender, EventArgs e) {
      lblFileTitle.Text = "(untitled)";
      m_bLoading = true;

      LoadRegistrySettings();

      // make directories
      try {
        if (!System.IO.Directory.Exists(m_strDraftsHome)) {
          System.IO.Directory.CreateDirectory(m_strDraftsHome);
          if (!System.IO.Directory.Exists(m_strDraftsHome)) {
            m_strDraftsHome = Environment.GetFolderPath(Environment.SpecialFolder.Personal) + @"\My Drafts";
            System.IO.Directory.CreateDirectory(m_strDraftsHome);
          }
        }
      }
      catch {
        m_strDraftsHome = Environment.GetFolderPath(Environment.SpecialFolder.Personal) + @"\My Drafts";
        System.IO.Directory.CreateDirectory(m_strDraftsHome);
      }

      SetupProxyInformation();

      updateConnectionMenuToolbar();

      // now that everything else is clear, do this last one to rest the toolbar/menu
      mniSave.Enabled = false;
      tbbSave.Enabled = false;
      // reset post b/c it's a new form
      mniPost.Enabled = false;

      this.dtDate.Enabled = (ckbServer.Checked ? false : true);
      this.dtTime.Enabled = (ckbServer.Checked ? false : true);

      if (m_bShowExit) {
        this.mniExit = new System.Windows.Forms.MenuItem();
        this.mniExit.Text = "Exit";
        this.mniExit.Click += new System.EventHandler(this.mniExit_Click);
        this.mnuTools.MenuItems.Add(this.mniExit);
      }
      else
        this.mniExit = null;

      m_bLoading = false;
      
      ebTitle.Focus();
    }

    private void Dialog_Main_Closing(object sender, System.ComponentModel.CancelEventArgs e) {
      string strTitle = lblFileTitle.Text; //this.Text;
      //strTitle = strTitle.Replace(m_strAppName + ": ", "");
      if (strTitle.IndexOf("*") > -1)
        strTitle = strTitle.Replace("*", "");
      strTitle += " has changed.\r\n\r\nDo you want to save these changes?\r\n\r\nTo cancel press Yes and then Cancel.";
      if (mniSave.Enabled == true) {
        DialogResult dlgRes = MessageBox.Show(strTitle, m_strAppName, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
        switch (dlgRes) {
          case DialogResult.Cancel:
          case DialogResult.No:
            break;
          case DialogResult.Yes:
          case DialogResult.OK:
            saveClicked();
            if (mniSave.Enabled) {
              e.Cancel = true;
              return;
            }
            break;
        }
      }
      SaveRegistrySettings();
      //SaveDataFiles();
    }

    private void mniAbout_Click(object sender, EventArgs e) {
      Dialog_About dlg = new Dialog_About();
      dlg.ShowDialog();
      dlg.Dispose();
    }

    private void mniSave_Click(object sender, EventArgs e) {
      saveClicked();
    }

    private void ebGeneric_GotFocus(object sender, System.EventArgs e) {
      updateTextBoxMenuToolbar(false, true, (Control)sender);
    }

    private void ebGeneric_LostFocus(object sender, System.EventArgs e) {
      updateTextBoxMenuToolbar(false, false);
    }

    private void ebGeneric_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e) {
      if (((TextBox)sender).SelectionLength > 0) {
        updateTextBoxMenuToolbar(true, true, (Control)sender);
      }
      else {
        updateTextBoxMenuToolbar(false, true, (Control)sender);
      }
    }

    private void ebGeneric_TextChanged(object sender, EventArgs e) {
      if (((TextBox)sender).Text.Length > 0) {
        if (!mniSave.Enabled)
          makeDirty();
        mniSave.Enabled = true;
        tbbSave.Enabled = true;
        if (m_strBlogId == "-1") {
          mniPost.Enabled = false;
        }
        else {
          mniPost.Enabled = true;
        }
      }

      if (((TextBox)sender).SelectionLength > 0) {
        updateTextBoxMenuToolbar(true, true, (Control)sender);
      }
      else {
        updateTextBoxMenuToolbar(false, true, (Control)sender);
      }
    }

    private void cbGeneric_SelectedIndexChanged(object sender, System.EventArgs e) {
      makeDirty();
    }

    private void ckbAllowPings_CheckedChanged(object sender, System.EventArgs e) {
      makeDirty();
    }

    private void saveClicked() {
      // check to see if there's a filename already!
      if (lblLocalName.Text == "") {
        Cursor.Current = Cursors.WaitCursor;
        SPSaveFileDialog dlgSave = new SPSaveFileDialog();
        dlgSave.Path = m_strDraftsHome;
        dlgSave.FileName = makeFileNameSave(ebTitle.Text) + ".smt";
        if (dlgSave.ShowDialog() == DialogResult.OK) {
          lblLocalName.Text = dlgSave.FileName;
        }
        else {
          return;
        }
      }

      // DON'T reset post b/c there's still data in the form
      mniSave.Enabled = false;
      tbbSave.Enabled = false;

      saveFile(lblLocalName.Text);

      //SaveDataFiles();
      string strFileName = lblLocalName.Text;
      strFileName = strFileName.Substring(strFileName.LastIndexOf("\\") + 1);
      lblFileTitle.Text = strFileName;
    }

    private void mniOpen_Click(object sender, EventArgs e) {
      Cursor.Current = Cursors.WaitCursor;
      SPOpenFileDialog dlgOpen = new SPOpenFileDialog();
      dlgOpen.Path = m_strDraftsHome;
      if (dlgOpen.ShowDialog() == DialogResult.OK) {
        if (dlgOpen.MakeHome)
          m_strDraftsHome = dlgOpen.Path;

        // check save first
        if (dirtyCheck() == false)
          return;

        m_bLoading = true;
        openFile(dlgOpen.FileName);
        m_bLoading = false;
      }
    }

    private void mniNew_Click(object sender, EventArgs e) {
      newClicked();
    }

    private void mniOptions_Click(object sender, EventArgs e) {
      optionsClicked();
    }
    
    private void mniExit_Click(object sender, System.EventArgs e) {
      string strTitle = lblFileTitle.Text;//this.Text;
      //strTitle = strTitle.Replace(m_strAppName + ": ", "");
      if (strTitle.IndexOf("*") > -1)
        strTitle = strTitle.Replace("*", "");
      strTitle += " has changed.\r\n\r\nDo you want to save these changes?\r\n\r\nTo prevent closing press Yes and then Cancel.";
      if (mniSave.Enabled == true) {
        DialogResult dlgRes = MessageBox.Show(strTitle, m_strAppName, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
        switch (dlgRes) {
          case DialogResult.Cancel:
          case DialogResult.No:
            break;
          case DialogResult.Yes:
          case DialogResult.OK:
            saveClicked();
            if (mniSave.Enabled)
              return;
            break;
        }
      }
      mniSave.Enabled = false;
      this.Close();
      Application.Exit();
    }

    private void mniPost_Click(object sender, EventArgs e) {
      // Save the post
      saveClicked();

      setCursors(true);
      prepProgress(true);

      UpdatePostThreadProc();
      //      Thread t = new Thread(new ThreadStart(UpdatePostThread));
      //      t.Start();

      ebTitle.Focus();
    }

    private void btnCategories_Click(object sender, EventArgs e) {
      if (cbCategories.SelectedIndex == 0) {
        MessageBox.Show("Please select a primary category before continuing!", m_strAppName, MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1);
        cbCategories.Focus();
        return;
      }
      string strPrimary = cbCategories.Text;
      ArrayList a_strId = new ArrayList();
      Dialog_Categories dlg = new Dialog_Categories();
      for (int i = 0; i < ma_objCategories.Count; i++) {
        string strName = ((CCatItem)ma_objCategories[i]).strName;
        if (strName == strPrimary)
          dlg.lblPrimary.Text = strPrimary;
        else {
          ListViewItem lvI = new ListViewItem(strName);
          dlg.lvCategories.Items.Add(lvI);
          a_strId.Add(((CCatItem)ma_objCategories[i]).strId);
        }
      }

      for (int i = 0; i < ma_strSelectCat.Count; i++) {
        // check the selected items
        for (int n = 0; n < a_strId.Count; n++) {
          if (ma_strSelectCat[i] == a_strId[n]) {
            dlg.lvCategories.Items[n].Checked = true;
            break;
          }
        }
      }
      if (dlg.ShowDialog() == DialogResult.OK) {
        makeDirty();
        ma_strSelectCat.Clear();
        for (int i = 0; i < dlg.lvCategories.Items.Count; i++) {
          if (dlg.lvCategories.Items[i].Checked == true) {
            string strName = dlg.lvCategories.Items[i].Text;
            for (int n = 0; n < ma_objCategories.Count; n++) {
              if (strName == (((CCatItem)ma_objCategories[n]).strName)) {
                ma_strSelectCat.Add((((CCatItem)ma_objCategories[n]).strId));
                break;
              }
            }
          }
        }
      }
    }

    private void ckbServer_CheckStateChanged(object sender, EventArgs e) {
      if ((dtDate == null) || (dtTime == null))
        return;

      if (ckbServer.Checked == true) {
        dtDate.Enabled = false;
        dtTime.Enabled = false;
      }
      else {
        dtDate.Enabled = true;
        dtTime.Enabled = true;
      }
      makeDirty();
    }

    private void mniContact_Click(object sender, EventArgs e) {
      if (m_ctrlCurrent == null) {
        return;
      }
      Control ctrl = m_ctrlCurrent;

      ChooseContactDialog dlgOpen = new ChooseContactDialog();
      dlgOpen.ChoosePropertyText = "Web page";
      if (dlgOpen.ShowDialog() == DialogResult.OK) {
        m_ctrlCurrent = ctrl;
        ((TextBox)m_ctrlCurrent).SelectedText = dlgOpen.SelectedContactName;
        m_ctrlCurrent.Focus();
      }

      // Old code from POOM
      //if (m_ctrlCurrent == null) {
      //  return;
      //}
      //Control ctrl = m_ctrlCurrent;

      //string strText = ((TextBox)m_ctrlCurrent).SelectedText;

      //Dialog_Contacts dlg = new Dialog_Contacts();
      //if (dlg.ShowDialog() == DialogResult.OK) {
      //  string str = "";
      //  if (dlg.ckbLink.Checked) {
      //    if (dlg.linkTo.SelectedIndex == 0)
      //      str = string.Format("<a href=\"mailto:{0}\">{1}</a>", dlg.m_strUrl, dlg.m_strName);
      //    else
      //      str = string.Format("<a href=\"{0}\">{1}</a>", dlg.m_strUrl, dlg.m_strName);
      //  }
      //  else {
      //    str = dlg.m_strName;
      //  }
      //  m_ctrlCurrent = ctrl;
      //  ((TextBox)m_ctrlCurrent).SelectedText = str;
      //  m_ctrlCurrent.Focus();
      //}
    }

    private void ckbServerPosted_CheckStateChanged(object sender, EventArgs e) {
      // Overrides for the loading of the application
      if (lblFileTitle.Text != m_strAppName)
        makeDirty();
    }

    private bool dirtyCheck() {
      string strTitle = lblFileTitle.Text;//this.Text;
      //strTitle = strTitle.Replace(m_strAppName + ": ", "");
      if (strTitle.IndexOf("*") > -1)
        strTitle = strTitle.Replace("*", "");
      strTitle += " has changed.\r\n\r\nDo you want to save these changes?\r\n\r\nTo cancel press Yes and then Cancel.";
      if (mniSave.Enabled) {
        DialogResult dlgRes = MessageBox.Show(strTitle, m_strAppName, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
        switch (dlgRes) {
          case DialogResult.Cancel:
          case DialogResult.No:
            return true;
          case DialogResult.Yes:
          case DialogResult.OK:
            saveClicked();
            if (mniSave.Enabled)
              return false;
            break;
        }
      }
      return true;
    }
  }
}