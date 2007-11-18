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
  partial class AddTagForm : Form
  {
    public AddTagForm()
    {
      InitializeComponent();
    }

    protected override void OnClosing(CancelEventArgs e)
    {
      base.OnClosing(e);
      if (DialogResult == DialogResult.OK)
      {
        if (tagText.Text.Length == 0)
        {
          MessageBox.Show("Please enter some text to be used as a tag or click Cancel!", MainForm.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Stop);
          tagText.Focus();
          e.Cancel = true;
          return;
        }
      }
    } 
    
    private void enclose_CheckedChanged(object sender, EventArgs e)
    {
      UpdateCheckBoxText(tagText.Text);
    }

    private void tagText_TextChanged(object sender, EventArgs e)
    {
      UpdateCheckBoxText(tagText.Text);
    }
    
    private void UpdateCheckBoxText(string tag)
    {
      if (tag.Length == 0)
        tag = "tag";
      if (enclose.Checked)
      {
        String backTag = tag;
        if (tag.IndexOf(" ") > -1)
        {
          backTag = tag.Substring(0, tag.IndexOf(" "));
        }
        enclose.Text = string.Format("Enclosing tag: <{0}></{1}>", tag, backTag);
      }
      else
        enclose.Text = string.Format("Contained tag: <{0}>", tag);
    }
  }
}