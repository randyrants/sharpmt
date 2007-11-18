#region Using directives

using System;
using System.Runtime.InteropServices;

#endregion

namespace SharpMT.Classes
{
  internal class NativeCode
  {
    public const int READ_CONTROL = 0x20000;
    public const int STANDARD_RIGHTS_READ = (READ_CONTROL);
    public const int KEY_QUERY_VALUE = 0x1;
    public const int KEY_ENUMERATE_SUB_KEYS = 0x8;
    public const int KEY_NOTIFY = 0x10;
    public const int SYNCHRONIZE = 0x100000;
    public const int KEY_READ = ((STANDARD_RIGHTS_READ | KEY_QUERY_VALUE | KEY_ENUMERATE_SUB_KEYS | KEY_NOTIFY)
      & (~SYNCHRONIZE));

    public const int REG_NOTIFY_CHANGE_NAME = 0x1;                      // Create or delete (child);
    public const int REG_NOTIFY_CHANGE_ATTRIBUTES = 0x2;
    public const int REG_NOTIFY_CHANGE_LAST_SET = 0x4;
    public const int REG_NOTIFY_CHANGE_SECURITY = 0x8;

    [DllImport("advapi32.dll")]
    public static extern int RegNotifyChangeKeyValue(int hKey, int bWatchSubtree, int
      dwNotifyFilter, int hEvent, int fAsynchronus);
    [DllImport("advapi32.dll")]
    public static extern int RegCloseKey(int hKey);
    [DllImport("advapi32.dll")]
    public static extern int RegOpenKeyEx(int hKey, string lpSubKey, int ulOptions,
      int samDesired, out int phkResult);
  }
}
