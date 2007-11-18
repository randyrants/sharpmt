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
  partial class FindForm : Form
  {
    internal System.Windows.Forms.TextBox m_textBox;

    public FindForm()
    {
      InitializeComponent();
    }

    private void FindForm_KeyUp(object sender, KeyEventArgs e)
    {
      if (e.KeyData == Keys.Escape)
      {
        cancelButton.PerformClick();
      }
    }

    private void findButton_Click(object sender, EventArgs e)
    {
      string findText = findWhat.Text;
      string findIn = "";
      int position = 0, selection;

      if (findUp.Checked)
      {
        int caret = m_textBox.SelectionStart;
        findIn = m_textBox.Text.Substring(0, m_textBox.SelectionStart);
        if (!matchCase.Checked)
        {
          findIn = findIn.ToLower();
          findText = findText.ToLower();
        }
        position = findIn.LastIndexOf(findText);
        selection = position;
      }
      else
      {
        int caret = m_textBox.SelectionStart + m_textBox.SelectionLength;
        findIn = m_textBox.Text.Substring(m_textBox.SelectionStart + m_textBox.SelectionLength);
        if (!matchCase.Checked)
        {
          findIn = findIn.ToLower();
          findText = findText.ToLower();
        }
        position = findIn.IndexOf(findText);
        selection = caret + position;
      }
 
      // if not found
      if (position == -1)
      {
        MessageBox.Show("Finished searching", MainForm.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        findWhat.SelectAll();
        findWhat.Focus();
      }
      else
      { //if founnd
        m_textBox.HideSelection = true;
        m_textBox.SelectionStart = selection;
        m_textBox.SelectionLength = findText.Length;
        this.Owner.Focus();
      }
    }

    private void cancelButton_Click(object sender, EventArgs e)
    {
      this.Visible = false;
      Owner.Focus();
    }

    private void FindForm_Activated(object sender, EventArgs e)
    {
      this.Opacity = 1.00;
    }

    private void FindForm_Deactivate(object sender, EventArgs e)
    {
      this.Opacity = 0.85;
    }
  }
}