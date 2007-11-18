using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Phone_SharpMT {
  public partial class Dialog_Categories : Form {
    public Dialog_Categories() {
      InitializeComponent();
    }

    protected override void OnResize(EventArgs e) {
      base.OnResize(e);

      this.lvCategories.Columns[0].Width = this.lvCategories.Width - 4;
    }

    private void btnOK_Click(object sender, EventArgs e) {
      this.DialogResult = DialogResult.OK;
      //Close();
    }

    private void btnCancel_Click(object sender, EventArgs e) {
      this.DialogResult = DialogResult.Cancel;
      //Close();
    }
  }
}