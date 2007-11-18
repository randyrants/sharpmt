using System;
using System.Runtime.InteropServices;

namespace SPFileDialog {
  [StructLayout(LayoutKind.Sequential)]
  public struct FILETIME {
    public uint dwLowDateTime;
    public uint dwHighDateTime;
  };
  
  [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
  public struct WIN32_FIND_DATA {
    public int dwFileAttributes;
    public FILETIME ftCreationTime;
    public FILETIME ftLastAccessTime;
    public FILETIME ftLastWriteTime;
    public uint nFileSizeHigh;
    public uint nFileSizeLow;
    public uint dwOID;
    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
    public string cFileName;
  }

  public class NativeClass {
    [DllImport("note_prj.dll")]
    public static extern IntPtr FindFirstFlashCard(out WIN32_FIND_DATA lpFindData);

    [DllImport("coredll.dll")]
    public static extern bool FindClose(IntPtr hHandle);
  }
}
