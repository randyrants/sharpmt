namespace SharpMT.Forms
{
  partial class UploadForm
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
      this.localFileName = new System.Windows.Forms.TextBox();
      this.browse = new System.Windows.Forms.Button();
      this.label2 = new System.Windows.Forms.Label();
      this.remoteFileName = new System.Windows.Forms.TextBox();
      this.label3 = new System.Windows.Forms.Label();
      this.urlLink = new System.Windows.Forms.LinkLabel();
      this.insertTag = new System.Windows.Forms.CheckBox();
      this.altLabel = new System.Windows.Forms.Label();
      this.altAttribute = new System.Windows.Forms.TextBox();
      this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
      this.SuspendLayout();
// 
// cancelButton
// 
      this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.cancelButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
      this.cancelButton.Location = new System.Drawing.Point(380, 208);
      this.cancelButton.Margin = new System.Windows.Forms.Padding(3, 1, 3, 3);
      this.cancelButton.Name = "cancelButton";
      this.cancelButton.TabIndex = 11;
      this.cancelButton.Text = "Cancel";
// 
// okButton
// 
      this.okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
      this.okButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
      this.okButton.Location = new System.Drawing.Point(298, 208);
      this.okButton.Margin = new System.Windows.Forms.Padding(3, 1, 3, 3);
      this.okButton.Name = "okButton";
      this.okButton.TabIndex = 10;
      this.okButton.Text = "OK";
// 
// label1
// 
      this.label1.AutoSize = true;
      this.label1.FlatStyle = System.Windows.Forms.FlatStyle.System;
      this.label1.Location = new System.Drawing.Point(13, 13);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(129, 13);
      this.label1.TabIndex = 0;
      this.label1.Text = "&Select an image to upload:";
// 
// localFileName
// 
      this.localFileName.Location = new System.Drawing.Point(27, 34);
      this.localFileName.Name = "localFileName";
      this.localFileName.ReadOnly = true;
      this.localFileName.Size = new System.Drawing.Size(346, 20);
      this.localFileName.TabIndex = 1;
      this.localFileName.TabStop = false;
// 
// browse
// 
      this.browse.FlatStyle = System.Windows.Forms.FlatStyle.System;
      this.browse.Location = new System.Drawing.Point(380, 32);
      this.browse.Name = "browse";
      this.browse.TabIndex = 2;
      this.browse.Text = "&Browse...";
      this.browse.Click += new System.EventHandler(this.browse_Click);
// 
// label2
// 
      this.label2.AutoSize = true;
      this.label2.FlatStyle = System.Windows.Forms.FlatStyle.System;
      this.label2.Location = new System.Drawing.Point(13, 61);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(219, 13);
      this.label2.TabIndex = 3;
      this.label2.Text = "&Enter the path and name of the remote image:";
// 
// remoteFileName
// 
      this.remoteFileName.Location = new System.Drawing.Point(27, 82);
      this.remoteFileName.Name = "remoteFileName";
      this.remoteFileName.Size = new System.Drawing.Size(428, 20);
      this.remoteFileName.TabIndex = 4;
// 
// label3
// 
      this.label3.AutoSize = true;
      this.label3.FlatStyle = System.Windows.Forms.FlatStyle.System;
      this.label3.Location = new System.Drawing.Point(13, 109);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(232, 13);
      this.label3.TabIndex = 5;
      this.label3.Text = "The remote path will be relative to the Blog URL:";
// 
// urlLink
// 
      this.urlLink.Links.Add(new System.Windows.Forms.LinkLabel.Link(0, 0));
      this.urlLink.Location = new System.Drawing.Point(27, 129);
      this.urlLink.Name = "urlLink";
      this.urlLink.Size = new System.Drawing.Size(428, 16);
      this.urlLink.TabIndex = 6;
      this.urlLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.urlLink_LinkClicked);
// 
// insertTag
// 
      this.insertTag.AutoSize = true;
      this.insertTag.FlatStyle = System.Windows.Forms.FlatStyle.System;
      this.insertTag.Location = new System.Drawing.Point(13, 153);
      this.insertTag.Name = "insertTag";
      this.insertTag.Size = new System.Drawing.Size(200, 18);
      this.insertTag.TabIndex = 7;
      this.insertTag.Text = "&Insert IMG tag with this link as SRC";
// 
// altLabel
// 
      this.altLabel.AutoSize = true;
      this.altLabel.FlatStyle = System.Windows.Forms.FlatStyle.System;
      this.altLabel.Location = new System.Drawing.Point(27, 179);
      this.altLabel.Name = "altLabel";
      this.altLabel.Size = new System.Drawing.Size(67, 13);
      this.altLabel.TabIndex = 8;
      this.altLabel.Text = "&ATL attribute:";
// 
// altAttribute
// 
      this.altAttribute.Location = new System.Drawing.Point(101, 176);
      this.altAttribute.Name = "altAttribute";
      this.altAttribute.Size = new System.Drawing.Size(354, 20);
      this.altAttribute.TabIndex = 9;
// 
// openFileDialog
// 
      this.openFileDialog.Filter = "Image Files (*.bmp; *.gif; *.png; *.jpg; *.jpeg)|*.BMP;*.GIF;*.PNG;*.JPG;*.JPEG|A" +
          "ll files (*.*)|*.*";
      this.openFileDialog.Title = "Select a file to upload";
// 
// UploadForm
// 
      this.AutoScaleDimensions = new System.Drawing.SizeF(5, 13);
      this.ClientSize = new System.Drawing.Size(467, 244);
      this.Controls.Add(this.altAttribute);
      this.Controls.Add(this.altLabel);
      this.Controls.Add(this.insertTag);
      this.Controls.Add(this.urlLink);
      this.Controls.Add(this.label3);
      this.Controls.Add(this.remoteFileName);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.browse);
      this.Controls.Add(this.localFileName);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.cancelButton);
      this.Controls.Add(this.okButton);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "UploadForm";
      this.ShowInTaskbar = false;
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
      this.Text = "Upload Image";
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Button cancelButton;
    private System.Windows.Forms.Button okButton;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Button browse;
    private System.Windows.Forms.Label label2;
    internal System.Windows.Forms.TextBox localFileName;
    internal System.Windows.Forms.TextBox remoteFileName;
    private System.Windows.Forms.Label label3;
    internal System.Windows.Forms.LinkLabel urlLink;
    internal System.Windows.Forms.CheckBox insertTag;
    internal System.Windows.Forms.TextBox altAttribute;
    private System.Windows.Forms.OpenFileDialog openFileDialog;
    internal System.Windows.Forms.Label altLabel;
  }
}