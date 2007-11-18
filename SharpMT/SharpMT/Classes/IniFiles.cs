#region Using directives

using System;
using System.Runtime.InteropServices;
using System.Text;

#endregion

namespace SharpMT.Classes
{
  public class IniFiles
  {
    // Declares a managed prototype for the unmanaged function.
    [DllImport("Kernel32.dll", CharSet = CharSet.Auto)]
    public static extern IntPtr GetPrivateProfileString(String strAppName, String strKeyName, String strDefault, [Out] StringBuilder strString, UInt32 dwSize, String strFileName);
  }
}
