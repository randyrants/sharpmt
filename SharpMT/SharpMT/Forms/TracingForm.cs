#region Using directives

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

#endregion

namespace SharpMT.Forms
{
  public partial class TracingForm : Form
  {
    private const int CS_NOCLOSE = 0x200;

    internal TracingForm()
    {
      InitializeComponent();
    }

    public System.Windows.Forms.TextBox Log
    {
      get
      {
        return log;
      }

      set
      {
        log = value;
      }
    }

    protected override void OnClosing(CancelEventArgs e)
    {
      base.OnClosing(e);
      //      if (DialogResult == DialogResult.OK) {
      e.Cancel = true;
      //      }
    }

    protected override CreateParams CreateParams {
      // disable the close button on the system menu and caption bar
      get {
        CreateParams cp = base.CreateParams;
        cp.ClassStyle = cp.ClassStyle | CS_NOCLOSE;
        return cp;
      }
    } 
  }
}