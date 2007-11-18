namespace SharpMT.Forms
{
  public partial class TracingForm
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TracingForm));
      this.log = new System.Windows.Forms.TextBox();
      this.SuspendLayout();
      // 
      // log
      // 
      this.log.Dock = System.Windows.Forms.DockStyle.Fill;
      this.log.Location = new System.Drawing.Point(0, 0);
      this.log.Multiline = true;
      this.log.Name = "log";
      this.log.ReadOnly = true;
      this.log.ScrollBars = System.Windows.Forms.ScrollBars.Both;
      this.log.Size = new System.Drawing.Size(632, 206);
      this.log.TabIndex = 0;
      // 
      // TracingForm
      // 
      this.ClientSize = new System.Drawing.Size(632, 206);
      this.Controls.Add(this.log);
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.Name = "TracingForm";
      this.Text = "Tracing Window";
      this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.TextBox log;
  }
}