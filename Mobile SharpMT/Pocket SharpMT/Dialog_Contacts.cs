using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace Pocket_SharpMT
{
	/// <summary>
	/// Summary description for Dialog_Contacts.
	/// </summary>
	public class Dialog_Contacts : System.Windows.Forms.Form
	{
    private PO_ItemCollection poicContactsCollection;
    public string m_strName;
    public string m_strUrl;

    public System.Windows.Forms.ListView lvContacts;
    private System.Windows.Forms.ColumnHeader lvcContacts;
    private System.Windows.Forms.MainMenu mainMenu1;
    private System.Windows.Forms.Button btnCancel;
    private System.Windows.Forms.Button btnOK;
    public System.Windows.Forms.CheckBox ckbLink;
    public System.Windows.Forms.RadioButton rbbEmail;
    private System.Windows.Forms.RadioButton rbbUrl;

    // Used to get contacts list using GetDefaultFolder method
    private const int folderContactsConst = 10;

		public Dialog_Contacts()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

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
      this.lvContacts = new System.Windows.Forms.ListView();
      this.lvcContacts = new System.Windows.Forms.ColumnHeader();
      this.mainMenu1 = new System.Windows.Forms.MainMenu();
      this.btnCancel = new System.Windows.Forms.Button();
      this.btnOK = new System.Windows.Forms.Button();
      this.ckbLink = new System.Windows.Forms.CheckBox();
      this.rbbEmail = new System.Windows.Forms.RadioButton();
      this.rbbUrl = new System.Windows.Forms.RadioButton();
      this.SuspendLayout();
      // 
      // lvContacts
      // 
      this.lvContacts.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                  | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.lvContacts.Columns.Add(this.lvcContacts);
      this.lvContacts.FullRowSelect = true;
      this.lvContacts.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
      this.lvContacts.Location = new System.Drawing.Point(3, 3);
      this.lvContacts.Name = "lvContacts";
      this.lvContacts.Size = new System.Drawing.Size(234, 210);
      this.lvContacts.TabIndex = 0;
      this.lvContacts.View = System.Windows.Forms.View.Details;
      // 
      // lvcContacts
      // 
      this.lvcContacts.Text = "Contacts";
      this.lvcContacts.Width = 232;
      // 
      // btnCancel
      // 
      this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.btnCancel.Location = new System.Drawing.Point(165, 244);
      this.btnCancel.Name = "btnCancel";
      this.btnCancel.Size = new System.Drawing.Size(72, 20);
      this.btnCancel.TabIndex = 5;
      this.btnCancel.Text = "Cancel";
      // 
      // btnOK
      // 
      this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.btnOK.Location = new System.Drawing.Point(89, 244);
      this.btnOK.Name = "btnOK";
      this.btnOK.Size = new System.Drawing.Size(72, 20);
      this.btnOK.TabIndex = 4;
      this.btnOK.Text = "OK";
      // 
      // ckbLink
      // 
      this.ckbLink.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.ckbLink.Location = new System.Drawing.Point(3, 219);
      this.ckbLink.Name = "ckbLink";
      this.ckbLink.Size = new System.Drawing.Size(93, 20);
      this.ckbLink.TabIndex = 1;
      this.ckbLink.Text = "Add link to:";
      this.ckbLink.CheckStateChanged += new System.EventHandler(this.ckbLink_CheckStateChanged);
      // 
      // rbbEmail
      // 
      this.rbbEmail.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.rbbEmail.Checked = true;
      this.rbbEmail.Enabled = false;
      this.rbbEmail.Location = new System.Drawing.Point(96, 219);
      this.rbbEmail.Name = "rbbEmail";
      this.rbbEmail.Size = new System.Drawing.Size(72, 20);
      this.rbbEmail.TabIndex = 2;
      this.rbbEmail.Text = "E-mail";
      // 
      // rbbUrl
      // 
      this.rbbUrl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.rbbUrl.Enabled = false;
      this.rbbUrl.Location = new System.Drawing.Point(167, 219);
      this.rbbUrl.Name = "rbbUrl";
      this.rbbUrl.Size = new System.Drawing.Size(70, 20);
      this.rbbUrl.TabIndex = 3;
      this.rbbUrl.Text = "URL";
      // 
      // Dialog_Contacts
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
      this.ClientSize = new System.Drawing.Size(240, 268);
      this.Controls.Add(this.rbbUrl);
      this.Controls.Add(this.rbbEmail);
      this.Controls.Add(this.ckbLink);
      this.Controls.Add(this.btnCancel);
      this.Controls.Add(this.btnOK);
      this.Controls.Add(this.lvContacts);
      this.Menu = this.mainMenu1;
      this.Name = "Dialog_Contacts";
      this.Text = "Insert Contact";
      this.Load += new System.EventHandler(this.Dialog_Contacts_Load);
      this.ResumeLayout(false);

    }
		#endregion

    protected override void OnClosing(CancelEventArgs e) {
      base.OnClosing(e);
      if (DialogResult == DialogResult.OK) {
        int nPos = -1;
        // do stuffs here
        ListView.SelectedIndexCollection lvSel = lvContacts.SelectedIndices;
        if (lvSel.Count <= 0) {
          e.Cancel = true;
          MessageBox.Show("Please select a Contact to insert!", Dialog_Main.m_strAppName, MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1);
          lvContacts.Focus();
          return;
        }
        else {
          nPos = lvSel[0];
        }

        PO_Contact pa;
        pa = (PO_Contact) poicContactsCollection.Item(nPos + 1);      // Starting with first item, item 'zero' does not exist
        m_strName = pa.FileAs;
        if (ckbLink.Checked) {
          if (rbbEmail.Checked) {
            m_strUrl = pa.Email1Address;
          }
          else { //URL
            m_strUrl = pa.WebPage;
          }
        }
        else {
          m_strUrl = "";
        }
      }      
    }

    private void Dialog_Contacts_Load(object sender, System.EventArgs e) {
      try {
        // The Application object is the only object which can be viewed
        // by external libraries. Other PocketOutlook objects are created
        // by calling various methods on the Application object.
        PocketOutlookControl poCtrl = new PocketOutlookControl();
              
        // Log the user onto a Pocket Outlook session 
        poCtrl.Logon();

        // get contacts info
        poicContactsCollection = poCtrl.GetDefaultFolder(folderContactsConst).Items;

        PO_Contact pa;
        for (int i = 0; i < poicContactsCollection.Count; i++) {
          pa = (PO_Contact) poicContactsCollection.Item(i + 1);      // Starting with first item, item 'zero' does not exist
                      
          // Add contact information to the list view
          ListViewItem lvI = new ListViewItem(pa.FileAs);
          lvI.ImageIndex = 2;

          this.lvContacts.Items.Add(lvI);
        }
        // log the user out
        poCtrl.Logoff();
      }
      catch (Exception exception) {
        MessageBox.Show(exception.ToString());
        MessageBox.Show("Cannot find PocketOutlook.dll!  Please re-install Pocket SharpMT.");
      }
    }

    private void ckbLink_CheckStateChanged(object sender, System.EventArgs e) {
      rbbEmail.Enabled = ckbLink.Checked;
      rbbUrl.Enabled = ckbLink.Checked;
    }

    protected override void OnResize(EventArgs e) {
      base.OnResize(e);

      this.lvContacts.Columns[0].Width = this.lvContacts.Width - 4;
    }
  }
}
