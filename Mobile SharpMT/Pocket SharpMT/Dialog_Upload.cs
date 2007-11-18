using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using Pocket_SharpMT._Objects.code;

namespace Pocket_SharpMT
{
	/// <summary>
	/// Summary description for Dialog_Upload.
	/// </summary>
	public class Dialog_Upload : System.Windows.Forms.Form
	{
    public string m_strUploadPath;
    private Control m_ctrlCurrent; 

    public System.Windows.Forms.TextBox ebLocal;
    private System.Windows.Forms.Button btnBrowse;
    private System.Windows.Forms.Label lblRemote;
    public System.Windows.Forms.TextBox ebRemote;
    private System.Windows.Forms.Label label1;
    public System.Windows.Forms.Label urlLabel;
    private System.Windows.Forms.Button btnCancel;
    private System.Windows.Forms.Button btnOK;
    private System.Windows.Forms.MainMenu mainMenu1;
    private System.Windows.Forms.OpenFileDialog dlgOpen;
    private Microsoft.WindowsCE.Forms.InputPanel inputPanel;
    public System.Windows.Forms.CheckBox ckbInsert;
    public System.Windows.Forms.TextBox ebAltTag;
    public System.Windows.Forms.Label lblAltTag;
    private System.Windows.Forms.Panel pnlMain;
    private System.Windows.Forms.ContextMenu mnuContext;
    private System.Windows.Forms.MenuItem mniCutPopup;
    private System.Windows.Forms.MenuItem mniCopyPopup;
    private System.Windows.Forms.MenuItem mniPastePopup;
    private System.Windows.Forms.MenuItem mniDeletePopup;
    private System.Windows.Forms.Label lblLocal;
  
		public Dialog_Upload()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

      m_strUploadPath = "";
      m_ctrlCurrent = null;

      DialogResult = DialogResult.OK;
      btnOK.DialogResult = DialogResult.OK;
      btnCancel.DialogResult = DialogResult.Cancel;
    }

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
      this.lblLocal = new System.Windows.Forms.Label();
      this.ebLocal = new System.Windows.Forms.TextBox();
      this.mnuContext = new System.Windows.Forms.ContextMenu();
      this.mniCutPopup = new System.Windows.Forms.MenuItem();
      this.mniCopyPopup = new System.Windows.Forms.MenuItem();
      this.mniPastePopup = new System.Windows.Forms.MenuItem();
      this.mniDeletePopup = new System.Windows.Forms.MenuItem();
      this.btnBrowse = new System.Windows.Forms.Button();
      this.lblRemote = new System.Windows.Forms.Label();
      this.ebRemote = new System.Windows.Forms.TextBox();
      this.label1 = new System.Windows.Forms.Label();
      this.urlLabel = new System.Windows.Forms.Label();
      this.btnCancel = new System.Windows.Forms.Button();
      this.btnOK = new System.Windows.Forms.Button();
      this.mainMenu1 = new System.Windows.Forms.MainMenu();
      this.dlgOpen = new System.Windows.Forms.OpenFileDialog();
      this.inputPanel = new Microsoft.WindowsCE.Forms.InputPanel();
      this.ckbInsert = new System.Windows.Forms.CheckBox();
      this.ebAltTag = new System.Windows.Forms.TextBox();
      this.lblAltTag = new System.Windows.Forms.Label();
      this.pnlMain = new System.Windows.Forms.Panel();
      this.pnlMain.SuspendLayout();
      this.SuspendLayout();
      // 
      // lblLocal
      // 
      this.lblLocal.Location = new System.Drawing.Point(3, 2);
      this.lblLocal.Name = "lblLocal";
      this.lblLocal.Size = new System.Drawing.Size(162, 14);
      this.lblLocal.Text = "Select an image to upload:";
      // 
      // ebLocal
      // 
      this.ebLocal.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.ebLocal.ContextMenu = this.mnuContext;
      this.ebLocal.Location = new System.Drawing.Point(3, 21);
      this.ebLocal.Name = "ebLocal";
      this.ebLocal.ReadOnly = true;
      this.ebLocal.Size = new System.Drawing.Size(234, 21);
      this.ebLocal.TabIndex = 0;
      this.ebLocal.GotFocus += new System.EventHandler(this.ebGeneric_GotFocus);
      this.ebLocal.KeyUp += new System.Windows.Forms.KeyEventHandler(this.ebGeneric_KeyUp);
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
      this.mniCutPopup.Enabled = false;
      this.mniCutPopup.Text = "Cut";
      this.mniCutPopup.Click += new System.EventHandler(this.mniCutPopup_Click);
      // 
      // mniCopyPopup
      // 
      this.mniCopyPopup.Enabled = false;
      this.mniCopyPopup.Text = "Copy";
      this.mniCopyPopup.Click += new System.EventHandler(this.mniCopyPopup_Click);
      // 
      // mniPastePopup
      // 
      this.mniPastePopup.Enabled = false;
      this.mniPastePopup.Text = "Paste";
      this.mniPastePopup.Click += new System.EventHandler(this.mniPastePopup_Click);
      // 
      // mniDeletePopup
      // 
      this.mniDeletePopup.Enabled = false;
      this.mniDeletePopup.Text = "Delete";
      this.mniDeletePopup.Click += new System.EventHandler(this.mniDeletePopup_Click);
      // 
      // btnBrowse
      // 
      this.btnBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.btnBrowse.Location = new System.Drawing.Point(165, 48);
      this.btnBrowse.Name = "btnBrowse";
      this.btnBrowse.Size = new System.Drawing.Size(72, 20);
      this.btnBrowse.TabIndex = 1;
      this.btnBrowse.Text = "Browse...";
      this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
      this.btnBrowse.GotFocus += new System.EventHandler(this.objGeneric_GotFocus);
      // 
      // lblRemote
      // 
      this.lblRemote.Location = new System.Drawing.Point(3, 76);
      this.lblRemote.Name = "lblRemote";
      this.lblRemote.Size = new System.Drawing.Size(235, 14);
      this.lblRemote.Text = "The path and name of the remote image:";
      // 
      // ebRemote
      // 
      this.ebRemote.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.ebRemote.ContextMenu = this.mnuContext;
      this.ebRemote.Location = new System.Drawing.Point(3, 95);
      this.ebRemote.Name = "ebRemote";
      this.ebRemote.Size = new System.Drawing.Size(234, 21);
      this.ebRemote.TabIndex = 2;
      this.ebRemote.GotFocus += new System.EventHandler(this.ebGeneric_GotFocus);
      this.ebRemote.KeyUp += new System.Windows.Forms.KeyEventHandler(this.ebGeneric_KeyUp);
      // 
      // label1
      // 
      this.label1.Location = new System.Drawing.Point(4, 124);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(225, 14);
      this.label1.Text = "Remote path, relative to the Blog URL:";
      // 
      // urlLabel
      // 
      this.urlLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.urlLabel.Location = new System.Drawing.Point(4, 143);
      this.urlLabel.Name = "urlLabel";
      this.urlLabel.Size = new System.Drawing.Size(233, 33);
      // 
      // btnCancel
      // 
      this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.btnCancel.Location = new System.Drawing.Point(165, 244);
      this.btnCancel.Name = "btnCancel";
      this.btnCancel.Size = new System.Drawing.Size(72, 20);
      this.btnCancel.TabIndex = 6;
      this.btnCancel.Text = "Cancel";
      // 
      // btnOK
      // 
      this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.btnOK.Location = new System.Drawing.Point(89, 244);
      this.btnOK.Name = "btnOK";
      this.btnOK.Size = new System.Drawing.Size(72, 20);
      this.btnOK.TabIndex = 5;
      this.btnOK.Text = "OK";
      // 
      // dlgOpen
      // 
      this.dlgOpen.Filter = "Image Files (*.bmp; *.gif; *.png; *.jpg; *.jpeg)|*.BMP;*.GIF;*.PNG;*.JPG;*.JPEG|A" +
          "ll files (*.*)|*.*";
      // 
      // ckbInsert
      // 
      this.ckbInsert.Location = new System.Drawing.Point(4, 178);
      this.ckbInsert.Name = "ckbInsert";
      this.ckbInsert.Size = new System.Drawing.Size(225, 20);
      this.ckbInsert.TabIndex = 3;
      this.ckbInsert.Text = "Insert IMG tag with this link as SRC";
      // 
      // ebAltTag
      // 
      this.ebAltTag.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.ebAltTag.ContextMenu = this.mnuContext;
      this.ebAltTag.Location = new System.Drawing.Point(91, 202);
      this.ebAltTag.Name = "ebAltTag";
      this.ebAltTag.Size = new System.Drawing.Size(146, 21);
      this.ebAltTag.TabIndex = 4;
      this.ebAltTag.GotFocus += new System.EventHandler(this.ebGeneric_GotFocus);
      this.ebAltTag.KeyUp += new System.Windows.Forms.KeyEventHandler(this.ebGeneric_KeyUp);
      // 
      // lblAltTag
      // 
      this.lblAltTag.Location = new System.Drawing.Point(4, 206);
      this.lblAltTag.Name = "lblAltTag";
      this.lblAltTag.Size = new System.Drawing.Size(82, 14);
      this.lblAltTag.Text = "ALT Attribute:";
      // 
      // pnlMain
      // 
      this.pnlMain.AutoScroll = true;
      this.pnlMain.Controls.Add(this.ckbInsert);
      this.pnlMain.Controls.Add(this.ebLocal);
      this.pnlMain.Controls.Add(this.btnBrowse);
      this.pnlMain.Controls.Add(this.label1);
      this.pnlMain.Controls.Add(this.ebAltTag);
      this.pnlMain.Controls.Add(this.lblRemote);
      this.pnlMain.Controls.Add(this.ebRemote);
      this.pnlMain.Controls.Add(this.lblAltTag);
      this.pnlMain.Controls.Add(this.urlLabel);
      this.pnlMain.Controls.Add(this.lblLocal);
      this.pnlMain.Controls.Add(this.btnCancel);
      this.pnlMain.Controls.Add(this.btnOK);
      this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
      this.pnlMain.Location = new System.Drawing.Point(0, 0);
      this.pnlMain.Name = "pnlMain";
      this.pnlMain.Size = new System.Drawing.Size(240, 268);
      // 
      // Dialog_Upload
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
      this.ClientSize = new System.Drawing.Size(240, 268);
      this.Controls.Add(this.pnlMain);
      this.Menu = this.mainMenu1;
      this.Name = "Dialog_Upload";
      this.Text = "Upload Image";
      this.pnlMain.ResumeLayout(false);
      this.ResumeLayout(false);

    }
		#endregion
    protected override void OnClosing(CancelEventArgs e) {
      base.OnClosing(e);
      if (DialogResult == DialogResult.OK) {
        if (ebLocal.Text.Length == 0) {
          e.Cancel = true;
          MessageBox.Show("Please select an image to upload!", Dialog_Main.m_strAppName, MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1);
          btnBrowse.Focus();
          return;
        }
        if (ebRemote.Text.Length == 0) {
          e.Cancel = true;
          MessageBox.Show("Please enter a remote name for this image!", Dialog_Main.m_strAppName, MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1);
          ebRemote.Focus();
        }

      }      
    }

    private void btnBrowse_Click(object sender, System.EventArgs e) {
      if (dlgOpen.ShowDialog() == DialogResult.OK) {
        ebLocal.Text = dlgOpen.FileName;
        if (ebRemote.Text.Length == 0) {
          ebRemote.Text = dlgOpen.FileName.Substring(dlgOpen.FileName.LastIndexOf("\\") + 1);
          ebRemote.Focus();
          ebRemote.SelectionStart = ebRemote.Text.Length;
          ebRemote.SelectionLength = 0;
        }
        else if (ebRemote.Text == m_strUploadPath) {
          ebRemote.Text += dlgOpen.FileName.Substring(dlgOpen.FileName.LastIndexOf("\\") + 1);
          ebRemote.Focus();
          ebRemote.SelectionStart = ebRemote.Text.Length;
          ebRemote.SelectionLength = 0;
        }
      }
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
          mniCopyPopup.Enabled = true;
          if (activeTextBox.ReadOnly) {
            mniCutPopup.Enabled = false;
            mniDeletePopup.Enabled = false;
          }
          else {
            mniCutPopup.Enabled = true;
            mniDeletePopup.Enabled = true;
          }
        }
        else {
          mniCutPopup.Enabled = false;
          mniCopyPopup.Enabled = false;
          mniDeletePopup.Enabled = false;
        }
        if (EditMenuHelper.ClipboardHasText()) {
          if (activeTextBox.ReadOnly) {
            mniPastePopup.Enabled = false;
          }
          else {
            mniPastePopup.Enabled = true;
          }
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
