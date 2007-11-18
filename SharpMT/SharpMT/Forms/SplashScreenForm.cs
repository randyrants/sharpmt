#region Using directives

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

#endregion

namespace SharpMT
{
  partial class SplashScreenForm : Form
  {
    // Delete required since it's opened on another thread
    private delegate void closeDelegate();
    public SplashScreenForm()
    {
      InitializeComponent();
    }

    public void CloseForm()
    {
      // delegate 
      closeDelegate closeForm = new closeDelegate(Close);
      this.Invoke(closeForm);
    }

  }
}