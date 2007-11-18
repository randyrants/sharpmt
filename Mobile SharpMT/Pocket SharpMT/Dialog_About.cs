using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace Pocket_SharpMT
{
	/// <summary>
	/// Summary description for Dialog_About.
	/// </summary>
	public class Dialog_About : System.Windows.Forms.Form
	{
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.Label label6;
    private System.Windows.Forms.PictureBox pictureBox1;
    private System.Windows.Forms.MainMenu mainMenu1;
    private System.Windows.Forms.Panel pnlMain;
    private Label label4;
    private System.Windows.Forms.Label label7;
  
		public Dialog_About()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Dialog_About));
      this.label1 = new System.Windows.Forms.Label();
      this.label2 = new System.Windows.Forms.Label();
      this.label3 = new System.Windows.Forms.Label();
      this.label5 = new System.Windows.Forms.Label();
      this.label6 = new System.Windows.Forms.Label();
      this.label7 = new System.Windows.Forms.Label();
      this.pictureBox1 = new System.Windows.Forms.PictureBox();
      this.mainMenu1 = new System.Windows.Forms.MainMenu();
      this.pnlMain = new System.Windows.Forms.Panel();
      this.label4 = new System.Windows.Forms.Label();
      this.pnlMain.SuspendLayout();
      this.SuspendLayout();
      // 
      // label1
      // 
      this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.label1.Location = new System.Drawing.Point(2, 2);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(235, 17);
      this.label1.Text = "Pocket SharpMT ver. 4.0 (4.0.0.0)";
      // 
      // label2
      // 
      this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.label2.Location = new System.Drawing.Point(2, 17);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(235, 17);
      // 
      // label3
      // 
      this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.label3.Location = new System.Drawing.Point(2, 41);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(235, 17);
      this.label3.Text = "--- This software is on CodePlex ---";
      this.label3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
      // 
      // label5
      // 
      this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.label5.Location = new System.Drawing.Point(1, 110);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(235, 43);
      this.label5.Text = "Support information:  Please consult the FAQ for a number of troubleshooting  sol" +
          "utions.";
      // 
      // label6
      // 
      this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.label6.Location = new System.Drawing.Point(2, 160);
      this.label6.Name = "label6";
      this.label6.Size = new System.Drawing.Size(235, 28);
      this.label6.Text = "News:  http://www.randyrants.com/sharpmt/";
      // 
      // label7
      // 
      this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.label7.Location = new System.Drawing.Point(2, 195);
      this.label7.Name = "label7";
      this.label7.Size = new System.Drawing.Size(235, 28);
      this.label7.Text = "Blog:  http://www.randyrants.com/";
      // 
      // pictureBox1
      // 
      this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
      this.pictureBox1.Location = new System.Drawing.Point(204, 233);
      this.pictureBox1.Name = "pictureBox1";
      this.pictureBox1.Size = new System.Drawing.Size(32, 32);
      // 
      // pnlMain
      // 
      this.pnlMain.AutoScroll = true;
      this.pnlMain.Controls.Add(this.pictureBox1);
      this.pnlMain.Controls.Add(this.label5);
      this.pnlMain.Controls.Add(this.label1);
      this.pnlMain.Controls.Add(this.label6);
      this.pnlMain.Controls.Add(this.label2);
      this.pnlMain.Controls.Add(this.label3);
      this.pnlMain.Controls.Add(this.label4);
      this.pnlMain.Controls.Add(this.label7);
      this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
      this.pnlMain.Location = new System.Drawing.Point(0, 0);
      this.pnlMain.Name = "pnlMain";
      this.pnlMain.Size = new System.Drawing.Size(240, 268);
      // 
      // label4
      // 
      this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.label4.Location = new System.Drawing.Point(2, 65);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(235, 42);
      this.label4.Text = "For more information about this project, go to http://www.codeplex.com/sharpmt";
      // 
      // Dialog_About
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
      this.ClientSize = new System.Drawing.Size(240, 268);
      this.Controls.Add(this.pnlMain);
      this.Menu = this.mainMenu1;
      this.Name = "Dialog_About";
      this.Text = "About Pocket #MT";
      this.pnlMain.ResumeLayout(false);
      this.ResumeLayout(false);

    }
		#endregion
  }
}
