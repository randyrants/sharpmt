using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace Pocket_SharpMT
{
	/// <summary>
	/// Summary description for Dialog_Categories.
	/// </summary>
	public class Dialog_Categories : System.Windows.Forms.Form
	{
    private System.Windows.Forms.ColumnHeader lvcDrafts;
    private System.Windows.Forms.Button btnCancel;
    public System.Windows.Forms.Label lblPrimary;
    private System.Windows.Forms.Label lblLabel;
    public System.Windows.Forms.ListView lvCategories;
    private System.Windows.Forms.MainMenu mainMenu1;
    private System.Windows.Forms.Button btnOK;
  
		public Dialog_Categories()
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
      this.lvCategories = new System.Windows.Forms.ListView();
      this.lvcDrafts = new System.Windows.Forms.ColumnHeader();
      this.btnCancel = new System.Windows.Forms.Button();
      this.btnOK = new System.Windows.Forms.Button();
      this.lblPrimary = new System.Windows.Forms.Label();
      this.lblLabel = new System.Windows.Forms.Label();
      this.mainMenu1 = new System.Windows.Forms.MainMenu();
      this.SuspendLayout();
      // 
      // lvCategories
      // 
      this.lvCategories.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                  | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.lvCategories.CheckBoxes = true;
      this.lvCategories.Columns.Add(this.lvcDrafts);
      this.lvCategories.FullRowSelect = true;
      this.lvCategories.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
      this.lvCategories.Location = new System.Drawing.Point(3, 22);
      this.lvCategories.Name = "lvCategories";
      this.lvCategories.Size = new System.Drawing.Size(234, 218);
      this.lvCategories.TabIndex = 0;
      this.lvCategories.View = System.Windows.Forms.View.Details;
      // 
      // lvcDrafts
      // 
      this.lvcDrafts.Text = "Categories";
      this.lvcDrafts.Width = 231;
      // 
      // btnCancel
      // 
      this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.btnCancel.Location = new System.Drawing.Point(165, 244);
      this.btnCancel.Name = "btnCancel";
      this.btnCancel.Size = new System.Drawing.Size(72, 20);
      this.btnCancel.TabIndex = 2;
      this.btnCancel.Text = "Cancel";
      // 
      // btnOK
      // 
      this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.btnOK.Location = new System.Drawing.Point(89, 244);
      this.btnOK.Name = "btnOK";
      this.btnOK.Size = new System.Drawing.Size(72, 20);
      this.btnOK.TabIndex = 1;
      this.btnOK.Text = "OK";
      // 
      // lblPrimary
      // 
      this.lblPrimary.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.lblPrimary.Location = new System.Drawing.Point(54, 2);
      this.lblPrimary.Name = "lblPrimary";
      this.lblPrimary.Size = new System.Drawing.Size(184, 14);
      // 
      // lblLabel
      // 
      this.lblLabel.Location = new System.Drawing.Point(3, 2);
      this.lblLabel.Name = "lblLabel";
      this.lblLabel.Size = new System.Drawing.Size(58, 14);
      this.lblLabel.Text = "Primary:";
      // 
      // Dialog_Categories
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
      this.ClientSize = new System.Drawing.Size(240, 268);
      this.Controls.Add(this.lblPrimary);
      this.Controls.Add(this.lblLabel);
      this.Controls.Add(this.lvCategories);
      this.Controls.Add(this.btnCancel);
      this.Controls.Add(this.btnOK);
      this.Menu = this.mainMenu1;
      this.Name = "Dialog_Categories";
      this.Text = "Select Categories";
      this.ResumeLayout(false);

    }
		#endregion

    protected override void OnResize(EventArgs e) {
      base.OnResize(e);

      this.lvCategories.Columns[0].Width = this.lvCategories.Width - 4;
    }
  }
}
