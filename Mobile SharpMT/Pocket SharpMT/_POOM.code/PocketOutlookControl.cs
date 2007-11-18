using System;
using System.Runtime.InteropServices;
using System.Diagnostics;

namespace Pocket_SharpMT {


  public class PocketOutlookControl {
    // the pointer to the unmanaged COM object
    private IntPtr m_pIPOutlookControl;

    /*
        * Do NOT call CoInitializeEx in managed code. The execution engine
        * takes care of this already.
        */

    public PocketOutlookControl() {
      m_pIPOutlookControl = new IntPtr(0);
      int hResult = UnmanagedConstructor(ref m_pIPOutlookControl);

      PocketOutlook.CheckHRESULT(hResult);
    }

    public void Dispose() {
      //
      // Since m_pIPOutlookControl is an unmanaged object, it must be
      // destroyed by hand.
      //
      if (m_pIPOutlookControl != IntPtr.Zero)
        PocketOutlook.ReleaseCOMPtr(m_pIPOutlookControl);
    }

    ~PocketOutlookControl() {
      this.Dispose();
    }

    /*
         * Property methods.
         *
         */

    public String Version {
      /*
             * Notes:
             *
             *    Native POOM property methods for "string"-like 
             *    properties (Such as IPOutlookApp::get_Version(...)) 
             *    all use BSTRs. BSTRs have a slightly unusual layout;
             *    however, all that matters here is that the actual
             *    pointer returned points to the beginning of a null
             *    terminated unicode string. So we can safely use
             *    System.Runtime.InteropServices.Marshal.PtrToStringUni(IntPtr)
             *    to extract the string.
             *
             *    [ Look up "BSTR" in the MSDN index for more information ]
             *
             */
      get {
        IntPtr bz = new IntPtr(0);
        int hResult = do_get_Version(m_pIPOutlookControl, ref bz);

        String zVersion = null;
        try {
          PocketOutlook.CheckHRESULT(hResult);
          zVersion = Marshal.PtrToStringUni(bz);
        }
        finally {
          /*
                     * Each call to the native accessor allocates a new
                     * BSTR, so it must be freed each time.
                     */
          PocketOutlook.SysFreeString(bz);
        }
        return zVersion;
      }
    } // Version


    /*
         * In native C++, the type of CurrentCityIndex is a 4-byte
         * "long". In managed C#, that's just an "int"
         */

    public bool OutlookCompatible {
      get {
        bool bCompatible = false;
        int hResult = do_get_OutlookCompatible(m_pIPOutlookControl,
          ref bCompatible);
                
        PocketOutlook.CheckHRESULT(hResult);

        return bCompatible;
      }
    } // OutlookCompatible


    public void Logon() {
      this.Logon(0);
    }

    public void Logon(int hWindowHandle) {
      PocketOutlook.CheckHRESULT(do_Logon(m_pIPOutlookControl,
        hWindowHandle));
    }

    public void Logoff() {
      PocketOutlook.CheckHRESULT(do_Logoff(m_pIPOutlookControl));
    }

    public PO_Folder GetDefaultFolder(int tFolder) {
      IntPtr pIFolder = new IntPtr(0);
      int hResult = do_GetDefaultFolder(m_pIPOutlookControl,
        tFolder,
        ref pIFolder);
      try {
        PocketOutlook.CheckHRESULT(hResult);
      }
      catch (Exception) {
        PocketOutlook.ReleaseCOMPtr(pIFolder);
        throw;
      }

      return new PO_Folder(this, pIFolder);
    }


    public void GetItemFromOid(long oid) {
      throw new NotSupportedException();
    }

    //
    // Imported functions
    //

    // Notes: 
    //
    // o The C# type "int" is equivalent to the C++ type
    //   "long"! Both types are 32 bit integers. If you mismatch
    //   types, you may assert inside the Execution Engine.
    // 
    // o A "IntPtr" appears in C++ as an intptr_t, which can be
    //   safely treated as any type of pointer (e.g. an
    //   IPOutlookApp*).
    //
    // o A "ref IntPtr" appears in C++ as a "intptr_t*", which can be
    //   safely treated as any type of double pointer (e.g. an
    //   IPOutlookApp**).
    // 
    // o A "String" appears as an "LPCTSTR", aka "const wchar_t*". See
    //   PocketOutlook.hpp for more.

    [ DllImport("PocketOutlook.dll", EntryPoint="IPOutlookApp_SetupCOM") ]
    private static extern int do_SetupCOM();

    [ DllImport("PocketOutlook.dll", EntryPoint="IPOutlookApp_Create") ]
    private static extern int UnmanagedConstructor(ref IntPtr rpApp);

    [ DllImport("PocketOutlook.dll", EntryPoint="IPOutlookApp_Logon") ]
    private static extern int do_Logon(IntPtr self, int hWindowHandle);

    [ DllImport("PocketOutlook.dll", EntryPoint="IPOutlookApp_Logoff") ]
    private static extern int do_Logoff(IntPtr self);

    [ DllImport("PocketOutlook.dll", EntryPoint="IPOutlookApp_get_Version") ]
    private static extern int do_get_Version(IntPtr self,
      ref IntPtr rbzVersion);

    [ DllImport("PocketOutlook.dll", EntryPoint="IPOutlookApp_GetDefaultFolder") ]
    private static extern int do_GetDefaultFolder(IntPtr self,
      int tFolder,
      ref IntPtr rpFolder);

    [ DllImport("PocketOutlook.dll", EntryPoint="IPOutlookApp_GetItemFromOid") ]
    private static extern int do_GetItemFromOid(IntPtr self,
      int Oid,
      ref IntPtr rpItem);

    [ DllImport("PocketOutlook.dll", EntryPoint="IPOutlookApp_get_OutlookCompatible") ]
    private static extern int do_get_OutlookCompatible(IntPtr self,
      ref bool rbCompatible);

    [ DllImport("PocketOutlook.dll", EntryPoint="IPOutlookApp_GetTimeZoneFromIndex") ]
    private static extern int do_GetTimeZoneFromIndex(IntPtr self,
      int cTimeZone,
      ref IntPtr rpTimeZone);

    [ DllImport("PocketOutlook.dll", EntryPoint="IPOutlookApp_GetTimeZoneInformationFromIndex") ]
    private static extern int do_GetTimeZoneInformationFromIndex(IntPtr self);

    [ DllImport("PocketOutlook.dll", EntryPoint="IPOutlookApp_SysFreeString") ]
    private static extern int do_SysFreeString(IntPtr self, IntPtr bz);

    [ DllImport("PocketOutlook.dll", EntryPoint="IPOutlookApp_VariantTimeToSystemTime") ]
    private static extern int do_VariantTimeToSystemTime(IntPtr self);

    [ DllImport("PocketOutlook.dll", EntryPoint="IPOutlookApp_SystemTimeToVariantTime") ]
    private static extern int do_SystemTimeToVariantTime(IntPtr self);


  } // class PocketOutlookControl
} // namespace PocketOutlook
