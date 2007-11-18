using System;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace Pocket_SharpMT._Objects.code
{
	/// <summary>
	/// Summary description for EditMenuHelper.
	/// </summary>
  public class EditMenuHelper {
    public static IntPtr Cut() {
      try {
        IntPtr hWnd = GetFocus();
        return SendMessage(hWnd, WM_CUT, 0, 0);
      }
      catch {
        MessageBox.Show("Could not cut!");
        return new IntPtr(-1);
      }
    }

    public static IntPtr Copy() {
      try {
        IntPtr hWnd = GetFocus();
        return SendMessage(hWnd, WM_COPY, 0, 0);
      }
      catch {
        MessageBox.Show("Could not copy!");
        return new IntPtr(-1);
      }
    }
    
    public static IntPtr Paste() {
      try {
        IntPtr hWnd = GetFocus();
        return SendMessage(hWnd, WM_PASTE, 0, 0);
      }
      catch {
        MessageBox.Show("Could not paste!");
        return new IntPtr(-1);
      }
    }

    public static IntPtr Clear() {
      try {
        IntPtr hWnd = GetFocus();
        return SendMessage(hWnd, WM_CLEAR, 0, 0);
      }
      catch {
        MessageBox.Show("Could not delete!");
        return new IntPtr(-1);
      }
    }

    public static IntPtr Undo() {
      try {
        IntPtr hWnd = GetFocus();
        return SendMessage(hWnd, WM_UNDO, 0, 0);
      }
      catch {
        MessageBox.Show("Could not undo!");
        return new IntPtr(-1);
      }
    }

    public static bool CanUndo() {
      try {
        IntPtr hWnd = GetFocus();
        return SendMessage(hWnd, EM_CANUNDO, 0, 0) != IntPtr.Zero;
      }
      catch {
        MessageBox.Show("Could not check if undo possible!");
        return false;
      }
    }

    public static bool ClipboardHasText() {
      try {
        return IsClipboardFormatAvailable(CF_UNICODETEXT);
      }
      catch {
        MessageBox.Show("Could not check if clipboard has text!");
        return false;
      }
    }

    // API declarations
    private const uint WM_CUT = 0x300;
    private const uint WM_COPY = 0x301;
    private const uint WM_PASTE = 0x302;
    private const uint WM_CLEAR = 0x303;
    private const uint WM_UNDO = 0x304;
    private const uint EM_CANUNDO = 0xC6;
    private const uint CF_UNICODETEXT = 13;

    [DllImport("coredll.dll")]
    private static extern IntPtr SendMessage(IntPtr hWnd, uint wMsg, uint wParam, uint lParam);

    [DllImport("coredll.dll")]
    private static extern IntPtr GetFocus();

    [DllImport("Coredll.dll")]
    private static extern bool IsClipboardFormatAvailable(uint uFormat);
  }
}
