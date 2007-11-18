namespace SharpMT.Forms
{
  partial class EntryBodyForm
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EntryBodyForm));
      this.okButton = new System.Windows.Forms.Button();
      this.story = new System.Windows.Forms.TextBox();
      this.SuspendLayout();
// 
// okButton
// 
      this.okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
      this.okButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
      this.okButton.Location = new System.Drawing.Point(413, 342);
      this.okButton.Margin = new System.Windows.Forms.Padding(3, 1, 3, 3);
      this.okButton.Name = "okButton";
      this.okButton.TabIndex = 1;
      this.okButton.Text = "OK";
// 
// story
// 
      this.story.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                  | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.story.AutoSize = false;
      this.story.Location = new System.Drawing.Point(13, 13);
      this.story.Multiline = true;
      this.story.Name = "story";
      this.story.ReadOnly = true;
      this.story.ScrollBars = System.Windows.Forms.ScrollBars.Both;
      this.story.Size = new System.Drawing.Size(475, 314);
      this.story.TabIndex = 0;
// 
// EntryBodyForm
// 
      this.AcceptButton = this.okButton;
      this.AutoScaleDimensions = new System.Drawing.SizeF(5, 13);
      this.ClientSize = new System.Drawing.Size(500, 377);
      this.Controls.Add(this.story);
      this.Controls.Add(this.okButton);
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.MinimizeBox = false;
      this.Name = "EntryBodyForm";
      this.ShowInTaskbar = false;
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
      this.Text = "Blog Link Story";
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Button okButton;
    internal System.Windows.Forms.TextBox story;
  }
}