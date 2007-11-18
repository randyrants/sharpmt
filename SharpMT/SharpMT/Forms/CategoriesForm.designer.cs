namespace SharpMT.Forms
{
  partial class CategoriesForm
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

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      this.cancelButton = new System.Windows.Forms.Button();
      this.okButton = new System.Windows.Forms.Button();
      this.categories = new System.Windows.Forms.CheckedListBox();
      this.label1 = new System.Windows.Forms.Label();
      this.primaryCategory = new System.Windows.Forms.Label();
      this.SuspendLayout();
// 
// cancelButton
// 
      this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.cancelButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
      this.cancelButton.Location = new System.Drawing.Point(205, 234);
      this.cancelButton.Margin = new System.Windows.Forms.Padding(3, 1, 3, 3);
      this.cancelButton.Name = "cancelButton";
      this.cancelButton.TabIndex = 4;
      this.cancelButton.Text = "Cancel";
// 
// okButton
// 
      this.okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
      this.okButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
      this.okButton.Location = new System.Drawing.Point(123, 234);
      this.okButton.Margin = new System.Windows.Forms.Padding(3, 1, 3, 3);
      this.okButton.Name = "okButton";
      this.okButton.TabIndex = 3;
      this.okButton.Text = "OK";
// 
// categories
// 
      this.categories.CheckOnClick = true;
      this.categories.FormattingEnabled = true;
      this.categories.Location = new System.Drawing.Point(13, 33);
      this.categories.Name = "categories";
      this.categories.ScrollAlwaysVisible = true;
      this.categories.Size = new System.Drawing.Size(267, 191);
      this.categories.TabIndex = 2;
// 
// label1
// 
      this.label1.AutoSize = true;
      this.label1.FlatStyle = System.Windows.Forms.FlatStyle.System;
      this.label1.Location = new System.Drawing.Point(13, 13);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(40, 13);
      this.label1.TabIndex = 0;
      this.label1.Text = "Primary:";
      this.label1.Click += new System.EventHandler(this.label1_Click);
// 
// primaryCategory
// 
      this.primaryCategory.FlatStyle = System.Windows.Forms.FlatStyle.System;
      this.primaryCategory.Location = new System.Drawing.Point(60, 13);
      this.primaryCategory.Name = "primaryCategory";
      this.primaryCategory.Size = new System.Drawing.Size(220, 13);
      this.primaryCategory.TabIndex = 1;
      this.primaryCategory.Click += new System.EventHandler(this.label1_Click);
// 
// CategoriesForm
// 
      this.AcceptButton = this.okButton;
      this.AutoScaleDimensions = new System.Drawing.SizeF(5, 13);
      this.CancelButton = this.cancelButton;
      this.ClientSize = new System.Drawing.Size(292, 269);
      this.Controls.Add(this.primaryCategory);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.categories);
      this.Controls.Add(this.cancelButton);
      this.Controls.Add(this.okButton);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "CategoriesForm";
      this.ShowInTaskbar = false;
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
      this.Text = "Select Categories";
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Button cancelButton;
    private System.Windows.Forms.Button okButton;
    private System.Windows.Forms.Label label1;
    internal System.Windows.Forms.Label primaryCategory;
    internal System.Windows.Forms.CheckedListBox categories;
  }
}