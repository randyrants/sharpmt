namespace SharpMT.Forms
{
  partial class AddPlugInForm
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
      this.label1 = new System.Windows.Forms.Label();
      this.location = new System.Windows.Forms.TextBox();
      this.browseDir = new System.Windows.Forms.Button();
      this.label2 = new System.Windows.Forms.Label();
      this.plugInName = new System.Windows.Forms.Label();
      this.label3 = new System.Windows.Forms.Label();
      this.description = new System.Windows.Forms.TextBox();
      this.version = new System.Windows.Forms.Label();
      this.label5 = new System.Windows.Forms.Label();
      this.formOpenDialog = new System.Windows.Forms.OpenFileDialog();
      this.SuspendLayout();
// 
// cancelButton
// 
      this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.cancelButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
      this.cancelButton.Location = new System.Drawing.Point(371, 177);
      this.cancelButton.Name = "cancelButton";
      this.cancelButton.TabIndex = 10;
      this.cancelButton.Text = "Cancel";
// 
// okButton
// 
      this.okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
      this.okButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
      this.okButton.Location = new System.Drawing.Point(289, 177);
      this.okButton.Name = "okButton";
      this.okButton.TabIndex = 9;
      this.okButton.Text = "OK";
// 
// label1
// 
      this.label1.AutoSize = true;
      this.label1.FlatStyle = System.Windows.Forms.FlatStyle.System;
      this.label1.Location = new System.Drawing.Point(10, 13);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(47, 13);
      this.label1.TabIndex = 0;
      this.label1.Text = "&Location:";
// 
// location
// 
      this.location.Location = new System.Drawing.Point(86, 10);
      this.location.Name = "location";
      this.location.Size = new System.Drawing.Size(274, 20);
      this.location.TabIndex = 1;
// 
// browseDir
// 
      this.browseDir.Location = new System.Drawing.Point(371, 8);
      this.browseDir.Name = "browseDir";
      this.browseDir.TabIndex = 2;
      this.browseDir.Text = "&Browse...";
      this.browseDir.Click += new System.EventHandler(this.browseDir_Click);
// 
// label2
// 
      this.label2.AutoSize = true;
      this.label2.FlatStyle = System.Windows.Forms.FlatStyle.System;
      this.label2.Location = new System.Drawing.Point(10, 40);
      this.label2.Margin = new System.Windows.Forms.Padding(3, 3, 1, 3);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(67, 13);
      this.label2.TabIndex = 3;
      this.label2.Text = "Plug-in name:";
// 
// plugInName
// 
      this.plugInName.FlatStyle = System.Windows.Forms.FlatStyle.System;
      this.plugInName.Location = new System.Drawing.Point(86, 40);
      this.plugInName.Margin = new System.Windows.Forms.Padding(1, 3, 3, 3);
      this.plugInName.Name = "plugInName";
      this.plugInName.Size = new System.Drawing.Size(274, 16);
      this.plugInName.TabIndex = 4;
// 
// label3
// 
      this.label3.AutoSize = true;
      this.label3.FlatStyle = System.Windows.Forms.FlatStyle.System;
      this.label3.Location = new System.Drawing.Point(10, 69);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(59, 13);
      this.label3.TabIndex = 5;
      this.label3.Text = "&Description:";
// 
// description
// 
      this.description.AutoSize = false;
      this.description.Location = new System.Drawing.Point(86, 66);
      this.description.Multiline = true;
      this.description.Name = "description";
      this.description.ReadOnly = true;
      this.description.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
      this.description.Size = new System.Drawing.Size(274, 100);
      this.description.TabIndex = 6;
// 
// version
// 
      this.version.FlatStyle = System.Windows.Forms.FlatStyle.System;
      this.version.Location = new System.Drawing.Point(86, 181);
      this.version.Margin = new System.Windows.Forms.Padding(1, 3, 3, 3);
      this.version.Name = "version";
      this.version.Size = new System.Drawing.Size(196, 16);
      this.version.TabIndex = 8;
// 
// label5
// 
      this.label5.AutoSize = true;
      this.label5.FlatStyle = System.Windows.Forms.FlatStyle.System;
      this.label5.Location = new System.Drawing.Point(10, 181);
      this.label5.Margin = new System.Windows.Forms.Padding(3, 3, 1, 3);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(41, 13);
      this.label5.TabIndex = 7;
      this.label5.Text = "Version:";
// 
// formOpenDialog
// 
      this.formOpenDialog.AddExtension = false;
      this.formOpenDialog.DefaultExt = "DLL";
      this.formOpenDialog.Filter = "SharpMT Extension Plug-Ins (*.dll)|*.dll|All Files (*.*)|*.*";
      this.formOpenDialog.Title = "Select a Plug-In";
// 
// AddPlugInForm
// 
      this.AcceptButton = this.okButton;
      this.AutoScaleDimensions = new System.Drawing.SizeF(5, 13);
      this.CancelButton = this.cancelButton;
      this.ClientSize = new System.Drawing.Size(458, 212);
      this.Controls.Add(this.version);
      this.Controls.Add(this.label5);
      this.Controls.Add(this.description);
      this.Controls.Add(this.label3);
      this.Controls.Add(this.plugInName);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.browseDir);
      this.Controls.Add(this.location);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.okButton);
      this.Controls.Add(this.cancelButton);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "AddPlugInForm";
      this.ShowInTaskbar = false;
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
      this.Text = "Add SharpMT Extension Plug-In";
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Button cancelButton;
    private System.Windows.Forms.Button okButton;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Button browseDir;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.TextBox description;
    private System.Windows.Forms.Label version;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.OpenFileDialog formOpenDialog;
    internal System.Windows.Forms.TextBox location;
    internal System.Windows.Forms.Label plugInName;
  }
}