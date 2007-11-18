using System;
using System.Runtime.InteropServices;

namespace Pocket_SharpMT {
  internal class PocketOutlook {
    public static void CheckHRESULT(int hResult) {
      if (Failed(hResult) != 0) {
        throw new Exception();
      }
    }

    [ DllImport("PocketOutlook.dll", EntryPoint="PocketOutlook_IsFailure") ]
    public extern static uint Failed(int hResult);

    [ DllImport("PocketOutlook.dll", EntryPoint="PocketOutlook_ReleaseCOMPtr") ]
    public extern static uint ReleaseCOMPtr(IntPtr p);

    [ DllImport("PocketOutlook.dll", EntryPoint="BSTR_SysFreeString") ]
    public extern static void SysFreeString(IntPtr p);
  }
}
