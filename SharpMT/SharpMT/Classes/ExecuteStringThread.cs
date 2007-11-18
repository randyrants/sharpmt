#region Using directives

using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using RandyRants.SharpMTExtension;

#endregion

namespace SharpMT
{
  class ExecuteStringThread
  {
    private ISharpMTExtension m_extension;
    private TextBox m_control;
    private MainForm m_form;

    private delegate void UpdateTheUIPlugIn(string returnValue, TextBox control, bool hasGUI, bool replaceSelectedText);

    public ExecuteStringThread(ISharpMTExtension extension, TextBox control, MainForm form)
    {
      m_extension = extension;
      m_control = control;
      m_form = form;
    }

    public void ThreadProc()
    {
      string returnValue = m_extension.ExecuteString();
      UpdateTheUIPlugIn updateTheUIPlugIn = new UpdateTheUIPlugIn(m_form.UpdateTheUIFromThePlugIn);
      m_form.Invoke(updateTheUIPlugIn, returnValue, m_control, m_extension.HasInputGUI, m_extension.ReplaceSelectedText);
    }
  }
}
