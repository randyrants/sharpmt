using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Phone_SharpMT {
  public partial class Dialog_About : Form {
    public Dialog_About() {
      InitializeComponent();
    }

    private void Dialog_About_KeyDown(object sender, KeyEventArgs e) {
      if ((e.KeyCode == System.Windows.Forms.Keys.F1)) {
        // Soft Key 1
        // Not handled when menu is present.
      }
      if ((e.KeyCode == System.Windows.Forms.Keys.F2)) {
        // Soft Key 2
        // Not handled when menu is present.
      }
      if ((e.KeyCode == System.Windows.Forms.Keys.Up)) {
        // Up
      }
      if ((e.KeyCode == System.Windows.Forms.Keys.Down)) {
        // Down
      }
      if ((e.KeyCode == System.Windows.Forms.Keys.Left)) {
        // Left
      }
      if ((e.KeyCode == System.Windows.Forms.Keys.Right)) {
        // Right
      }
      if ((e.KeyCode == System.Windows.Forms.Keys.Enter)) {
        // Enter
      }
      if ((e.KeyCode == System.Windows.Forms.Keys.D1)) {
        // 1
      }
      if ((e.KeyCode == System.Windows.Forms.Keys.D2)) {
        // 2
      }
      if ((e.KeyCode == System.Windows.Forms.Keys.D3)) {
        // 3
      }
      if ((e.KeyCode == System.Windows.Forms.Keys.D4)) {
        // 4
      }
      if ((e.KeyCode == System.Windows.Forms.Keys.D5)) {
        // 5
      }
      if ((e.KeyCode == System.Windows.Forms.Keys.D6)) {
        // 6
      }
      if ((e.KeyCode == System.Windows.Forms.Keys.D7)) {
        // 7
      }
      if ((e.KeyCode == System.Windows.Forms.Keys.D8)) {
        // 8
      }
      if ((e.KeyCode == System.Windows.Forms.Keys.D9)) {
        // 9
      }
      if ((e.KeyCode == System.Windows.Forms.Keys.F8)) {
        // *
      }
      if ((e.KeyCode == System.Windows.Forms.Keys.D0)) {
        // 0
      }
      if ((e.KeyCode == System.Windows.Forms.Keys.F9)) {
        // #
      }

    }

    private void mniDone_Click(object sender, EventArgs e) {
      this.Close();
    }
  }
}