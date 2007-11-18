namespace Phone_SharpMT {
  partial class Dialog_About {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;
    private System.Windows.Forms.MainMenu mainMenu1;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing) {
      if (disposing && (components != null)) {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent() {
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Dialog_About));
      this.mainMenu1 = new System.Windows.Forms.MainMenu();
      this.mniDone = new System.Windows.Forms.MenuItem();
      this.label1 = new System.Windows.Forms.Label();
      this.textBox1 = new System.Windows.Forms.TextBox();
      this.SuspendLayout();
      // 
      // mainMenu1
      // 
      this.mainMenu1.MenuItems.Add(this.mniDone);
      // 
      // mniDone
      // 
      this.mniDone.Text = "Done";
      this.mniDone.Click += new System.EventHandler(this.mniDone_Click);
      // 
      // label1
      // 
      this.label1.Dock = System.Windows.Forms.DockStyle.Top;
      this.label1.Location = new System.Drawing.Point(0, 0);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(176, 15);
      this.label1.Text = "Phone SharpMT 4.0 (4.0.0.0)";
      // 
      // textBox1
      // 
      this.textBox1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.textBox1.Location = new System.Drawing.Point(0, 15);
      this.textBox1.Multiline = true;
      this.textBox1.Name = "textBox1";
      this.textBox1.ReadOnly = true;
      this.textBox1.Size = new System.Drawing.Size(176, 165);
      this.textBox1.TabIndex = 6;
      this.textBox1.Text = resources.GetString("textBox1.Text");
      // 
      // Dialog_About
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
      this.AutoScroll = true;
      this.ClientSize = new System.Drawing.Size(176, 180);
      this.Controls.Add(this.textBox1);
      this.Controls.Add(this.label1);
      this.KeyPreview = true;
      this.Menu = this.mainMenu1;
      this.Name = "Dialog_About";
      this.Text = "Phone SharpMT";
      this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Dialog_About_KeyDown);
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.MenuItem mniDone;
    private System.Windows.Forms.TextBox textBox1;
  }
}