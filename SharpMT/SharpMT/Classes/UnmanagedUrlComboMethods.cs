using System;
using System.Runtime.InteropServices;

namespace CP.Windows.Forms
{
  [StructLayout(LayoutKind.Sequential)]
  internal struct Rect
  {
    public int left;
    public int top;
    public int right;
    public int bottom;
  }

  [StructLayout(LayoutKind.Sequential)]
  internal struct ComboBoxInfo : IDisposable
  {
    public int cbSize;
    public Rect rcItem;
    public Rect rcButton;
    public IntPtr stateButton;
    public IntPtr hwndCombo;
    public IntPtr hwndEdit;
    public IntPtr hwndList;
    #region IDisposable Members

    public void Dispose()
    {
    }

    #endregion
  }

  internal class UnManagedMethods
  {
    [DllImport("User32.dll")]
    internal static extern bool GetComboBoxInfo(IntPtr hwndCombo, ref ComboBoxInfo info);

    [DllImport("Shlwapi.dll")]
    internal static extern void SHAutoComplete(IntPtr hwnd, IntPtr flags);

    [DllImport("User32.dll")]
    internal static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
  }
}
