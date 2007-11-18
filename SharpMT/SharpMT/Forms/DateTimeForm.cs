#region Using directives

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

#endregion

namespace SharpMT.Forms
{
  partial class DateTimeForm : Form
  {
    public DateTimeForm()
    {
      InitializeComponent();
    }

    private void label1_Click(object sender, EventArgs e)
    {
    
    }

    private void useServerTime_CheckedChanged(object sender, EventArgs e)
    {
      if (useServerTime.Checked == true)
      {
        datePicker.Enabled = false;
        timePicker.Enabled = false;
      }
      else
      {
        datePicker.Enabled = true;
        timePicker.Enabled = true;
      }
    }
  }
}