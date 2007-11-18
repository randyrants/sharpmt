/*---------------------------------------------------------------------
   Copyright (C) Microsoft Corporation.  All rights reserved.

  This source code is intended only as a supplement to Microsoft
  Development Tools and/or on-line documentation.  See these other
  materials for detailed information regarding Microsoft code samples.

  THIS CODE AND INFORMATION ARE PROVIDED "AS IS" WITHOUT WARRANTY OF ANY
  KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
  IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
  PARTICULAR PURPOSE.
 ----------------------------------------------------------------------- *
 * File: Contact.cs
 *
 * Purpose: Managed representation of the IContact object.
 *
 * Notes:
 *
 */

using System;
using System.Runtime.InteropServices;

namespace Pocket_SharpMT {

  public class PO_Contact : PO_OutlookItem {
    internal PO_Contact(PocketOutlookControl poCtrl,
      ref IntPtr pIContact) : base (poCtrl, ref pIContact) {
    }

    public String BusinessFaxNumber {
      get {
        String zBusinessFaxNumber = null;
        IntPtr bz = new IntPtr(0);
        int hResult = do_get_BusinessFaxNumber(this.RawItemPtr, ref bz);
        try {
          PocketOutlook.CheckHRESULT(hResult);
          zBusinessFaxNumber = Marshal.PtrToStringUni(bz);
        }
        finally {
          PocketOutlook.SysFreeString(bz);
        }

        return zBusinessFaxNumber;
      }
      set {
        PocketOutlook.CheckHRESULT(do_put_BusinessFaxNumber(this.RawItemPtr, value));
      }
    } // BusinessFaxNumber

    public String CompanyName {
      get {
        String zCompanyName = null;
        IntPtr bz = new IntPtr(0);
        int hResult = do_get_CompanyName(this.RawItemPtr, ref bz);
        try {
          PocketOutlook.CheckHRESULT(hResult);
          zCompanyName = Marshal.PtrToStringUni(bz);
        }
        finally {
          PocketOutlook.SysFreeString(bz);
        }

        return zCompanyName;
      }
      set {
        PocketOutlook.CheckHRESULT(do_put_CompanyName(this.RawItemPtr, value));
      }
    } // CompanyName

    public String Department {
      get {
        String zDepartment = null;
        IntPtr bz = new IntPtr(0);
        int hResult = do_get_Department(this.RawItemPtr, ref bz);
        try {
          PocketOutlook.CheckHRESULT(hResult);
          zDepartment = Marshal.PtrToStringUni(bz);
        }
        finally {
          PocketOutlook.SysFreeString(bz);
        }

        return zDepartment;
      }
      set {
        PocketOutlook.CheckHRESULT(do_put_Department(this.RawItemPtr, value));
      }
    } // Department

    public String Email1Address {
      get {
        String zEmail1Address = null;
        IntPtr bz = new IntPtr(0);
        int hResult = do_get_Email1Address(this.RawItemPtr, ref bz);
        try {
          PocketOutlook.CheckHRESULT(hResult);
          zEmail1Address = Marshal.PtrToStringUni(bz);
        }
        finally {
          PocketOutlook.SysFreeString(bz);
        }

        return zEmail1Address;
      }
      set {
        PocketOutlook.CheckHRESULT(do_put_Email1Address(this.RawItemPtr, value));
      }
    } // Email1Address

    public String MobileTelephoneNumber {
      get {
        String zMobileTelephoneNumber = null;
        IntPtr bz = new IntPtr(0);
        int hResult = do_get_MobileTelephoneNumber(this.RawItemPtr, ref bz);
        try {
          PocketOutlook.CheckHRESULT(hResult);
          zMobileTelephoneNumber = Marshal.PtrToStringUni(bz);
        }
        finally {
          PocketOutlook.SysFreeString(bz);
        }

        return zMobileTelephoneNumber;
      }
      set {
        PocketOutlook.CheckHRESULT(do_put_MobileTelephoneNumber(this.RawItemPtr, value));
      }
    } // MobileTelephoneNumber

    public String OfficeLocation {
      get {
        String zOfficeLocation = null;
        IntPtr bz = new IntPtr(0);
        int hResult = do_get_OfficeLocation(this.RawItemPtr, ref bz);
        try {
          PocketOutlook.CheckHRESULT(hResult);
          zOfficeLocation = Marshal.PtrToStringUni(bz);
        }
        finally {
          PocketOutlook.SysFreeString(bz);
        }

        return zOfficeLocation;
      }
      set {
        PocketOutlook.CheckHRESULT(do_put_OfficeLocation(this.RawItemPtr, value));
      }
    } // OfficeLocation

    public String PagerNumber {
      get {
        String zPagerNumber = null;
        IntPtr bz = new IntPtr(0);
        int hResult = do_get_PagerNumber(this.RawItemPtr, ref bz);
        try {
          PocketOutlook.CheckHRESULT(hResult);
          zPagerNumber = Marshal.PtrToStringUni(bz);
        }
        finally {
          PocketOutlook.SysFreeString(bz);
        }

        return zPagerNumber;
      }
      set {
        PocketOutlook.CheckHRESULT(do_put_PagerNumber(this.RawItemPtr, value));
      }
    } // PagerNumber

    public String BusinessTelephoneNumber {
      get {
        String zBusinessTelephoneNumber = null;
        IntPtr bz = new IntPtr(0);
        int hResult = do_get_BusinessTelephoneNumber(this.RawItemPtr, ref bz);
        try {
          PocketOutlook.CheckHRESULT(hResult);
          zBusinessTelephoneNumber = Marshal.PtrToStringUni(bz);
        }
        finally {
          PocketOutlook.SysFreeString(bz);
        }

        return zBusinessTelephoneNumber;
      }
      set {
        PocketOutlook.CheckHRESULT(do_put_BusinessTelephoneNumber(this.RawItemPtr, value));
      }
    } // BusinessTelephoneNumber

    public String JobTitle {
      get {
        String zJobTitle = null;
        IntPtr bz = new IntPtr(0);
        int hResult = do_get_JobTitle(this.RawItemPtr, ref bz);
        try {
          PocketOutlook.CheckHRESULT(hResult);
          zJobTitle = Marshal.PtrToStringUni(bz);
        }
        finally {
          PocketOutlook.SysFreeString(bz);
        }

        return zJobTitle;
      }
      set {
        PocketOutlook.CheckHRESULT(do_put_JobTitle(this.RawItemPtr, value));
      }
    } // JobTitle

    public String HomeTelephoneNumber {
      get {
        String zHomeTelephoneNumber = null;
        IntPtr bz = new IntPtr(0);
        int hResult = do_get_HomeTelephoneNumber(this.RawItemPtr, ref bz);
        try {
          PocketOutlook.CheckHRESULT(hResult);
          zHomeTelephoneNumber = Marshal.PtrToStringUni(bz);
        }
        finally {
          PocketOutlook.SysFreeString(bz);
        }

        return zHomeTelephoneNumber;
      }
      set {
        PocketOutlook.CheckHRESULT(do_put_HomeTelephoneNumber(this.RawItemPtr, value));
      }
    } // HomeTelephoneNumber

    public String Email2Address {
      get {
        String zEmail2Address = null;
        IntPtr bz = new IntPtr(0);
        int hResult = do_get_Email2Address(this.RawItemPtr, ref bz);
        try {
          PocketOutlook.CheckHRESULT(hResult);
          zEmail2Address = Marshal.PtrToStringUni(bz);
        }
        finally {
          PocketOutlook.SysFreeString(bz);
        }

        return zEmail2Address;
      }
      set {
        PocketOutlook.CheckHRESULT(do_put_Email2Address(this.RawItemPtr, value));
      }
    } // Email2Address

    public String Spouse {
      get {
        String zSpouse = null;
        IntPtr bz = new IntPtr(0);
        int hResult = do_get_Spouse(this.RawItemPtr, ref bz);
        try {
          PocketOutlook.CheckHRESULT(hResult);
          zSpouse = Marshal.PtrToStringUni(bz);
        }
        finally {
          PocketOutlook.SysFreeString(bz);
        }

        return zSpouse;
      }
      set {
        PocketOutlook.CheckHRESULT(do_put_Spouse(this.RawItemPtr, value));
      }
    } // Spouse

    public String Email3Address {
      get {
        String zEmail3Address = null;
        IntPtr bz = new IntPtr(0);
        int hResult = do_get_Email3Address(this.RawItemPtr, ref bz);
        try {
          PocketOutlook.CheckHRESULT(hResult);
          zEmail3Address = Marshal.PtrToStringUni(bz);
        }
        finally {
          PocketOutlook.SysFreeString(bz);
        }

        return zEmail3Address;
      }
      set {
        PocketOutlook.CheckHRESULT(do_put_Email3Address(this.RawItemPtr, value));
      }
    } // Email3Address

    public String Home2TelephoneNumber {
      get {
        String zHome2TelephoneNumber = null;
        IntPtr bz = new IntPtr(0);
        int hResult = do_get_Home2TelephoneNumber(this.RawItemPtr, ref bz);
        try {
          PocketOutlook.CheckHRESULT(hResult);
          zHome2TelephoneNumber = Marshal.PtrToStringUni(bz);
        }
        finally {
          PocketOutlook.SysFreeString(bz);
        }

        return zHome2TelephoneNumber;
      }
      set {
        PocketOutlook.CheckHRESULT(do_put_Home2TelephoneNumber(this.RawItemPtr, value));
      }
    } // Home2TelephoneNumber

    public String HomeFaxNumber {
      get {
        String zHomeFaxNumber = null;
        IntPtr bz = new IntPtr(0);
        int hResult = do_get_HomeFaxNumber(this.RawItemPtr, ref bz);
        try {
          PocketOutlook.CheckHRESULT(hResult);
          zHomeFaxNumber = Marshal.PtrToStringUni(bz);
        }
        finally {
          PocketOutlook.SysFreeString(bz);
        }

        return zHomeFaxNumber;
      }
      set {
        PocketOutlook.CheckHRESULT(do_put_HomeFaxNumber(this.RawItemPtr, value));
      }
    } // HomeFaxNumber

    public String CarTelephoneNumber {
      get {
        String zCarTelephoneNumber = null;
        IntPtr bz = new IntPtr(0);
        int hResult = do_get_CarTelephoneNumber(this.RawItemPtr, ref bz);
        try {
          PocketOutlook.CheckHRESULT(hResult);
          zCarTelephoneNumber = Marshal.PtrToStringUni(bz);
        }
        finally {
          PocketOutlook.SysFreeString(bz);
        }

        return zCarTelephoneNumber;
      }
      set {
        PocketOutlook.CheckHRESULT(do_put_CarTelephoneNumber(this.RawItemPtr, value));
      }
    } // CarTelephoneNumber

    public String AssistantName {
      get {
        String zAssistantName = null;
        IntPtr bz = new IntPtr(0);
        int hResult = do_get_AssistantName(this.RawItemPtr, ref bz);
        try {
          PocketOutlook.CheckHRESULT(hResult);
          zAssistantName = Marshal.PtrToStringUni(bz);
        }
        finally {
          PocketOutlook.SysFreeString(bz);
        }

        return zAssistantName;
      }
      set {
        PocketOutlook.CheckHRESULT(do_put_AssistantName(this.RawItemPtr, value));
      }
    } // AssistantName

    public String Children {
      get {
        String zChildren = null;
        IntPtr bz = new IntPtr(0);
        int hResult = do_get_Children(this.RawItemPtr, ref bz);
        try {
          PocketOutlook.CheckHRESULT(hResult);
          zChildren = Marshal.PtrToStringUni(bz);
        }
        finally {
          PocketOutlook.SysFreeString(bz);
        }

        return zChildren;
      }
      set {
        PocketOutlook.CheckHRESULT(do_put_Children(this.RawItemPtr, value));
      }
    } // Children

    public String Categories {
      get {
        String zCategories = null;
        IntPtr bz = new IntPtr(0);
        int hResult = do_get_Categories(this.RawItemPtr, ref bz);
        try {
          PocketOutlook.CheckHRESULT(hResult);
          zCategories = Marshal.PtrToStringUni(bz);
        }
        finally {
          PocketOutlook.SysFreeString(bz);
        }

        return zCategories;
      }
      set {
        PocketOutlook.CheckHRESULT(do_put_Categories(this.RawItemPtr, value));
      }
    } // Categories

    public String WebPage {
      get {
        String zWebPage = null;
        IntPtr bz = new IntPtr(0);
        int hResult = do_get_WebPage(this.RawItemPtr, ref bz);
        try {
          PocketOutlook.CheckHRESULT(hResult);
          zWebPage = Marshal.PtrToStringUni(bz);
        }
        finally {
          PocketOutlook.SysFreeString(bz);
        }

        return zWebPage;
      }
      set {
        PocketOutlook.CheckHRESULT(do_put_WebPage(this.RawItemPtr, value));
      }
    } // WebPage

    public String Business2TelephoneNumber {
      get {
        String zBusiness2TelephoneNumber = null;
        IntPtr bz = new IntPtr(0);
        int hResult = do_get_Business2TelephoneNumber(this.RawItemPtr, ref bz);
        try {
          PocketOutlook.CheckHRESULT(hResult);
          zBusiness2TelephoneNumber = Marshal.PtrToStringUni(bz);
        }
        finally {
          PocketOutlook.SysFreeString(bz);
        }

        return zBusiness2TelephoneNumber;
      }
      set {
        PocketOutlook.CheckHRESULT(do_put_Business2TelephoneNumber(this.RawItemPtr, value));
      }
    } // Business2TelephoneNumber

    public String RadioTelephoneNumber {
      get {
        String zRadioTelephoneNumber = null;
        IntPtr bz = new IntPtr(0);
        int hResult = do_get_RadioTelephoneNumber(this.RawItemPtr, ref bz);
        try {
          PocketOutlook.CheckHRESULT(hResult);
          zRadioTelephoneNumber = Marshal.PtrToStringUni(bz);
        }
        finally {
          PocketOutlook.SysFreeString(bz);
        }

        return zRadioTelephoneNumber;
      }
      set {
        PocketOutlook.CheckHRESULT(do_put_RadioTelephoneNumber(this.RawItemPtr, value));
      }
    } // RadioTelephoneNumber

    public String FileAs {
      get {
        String zFileAs = null;
        IntPtr bz = new IntPtr(0);
        int hResult = do_get_FileAs(this.RawItemPtr, ref bz);
        try {
          PocketOutlook.CheckHRESULT(hResult);
          zFileAs = Marshal.PtrToStringUni(bz);
        }
        finally {
          PocketOutlook.SysFreeString(bz);
        }

        return zFileAs;
      }
      set {
        PocketOutlook.CheckHRESULT(do_put_FileAs(this.RawItemPtr, value));
      }
    } // FileAs

    public String Title {
      get {
        String zTitle = null;
        IntPtr bz = new IntPtr(0);
        int hResult = do_get_Title(this.RawItemPtr, ref bz);
        try {
          PocketOutlook.CheckHRESULT(hResult);
          zTitle = Marshal.PtrToStringUni(bz);
        }
        finally {
          PocketOutlook.SysFreeString(bz);
        }

        return zTitle;
      }
      set {
        PocketOutlook.CheckHRESULT(do_put_Title(this.RawItemPtr, value));
      }
    } // Title

    public String FirstName {
      get {
        String zFirstName = null;
        IntPtr bz = new IntPtr(0);
        int hResult = do_get_FirstName(this.RawItemPtr, ref bz);
        try {
          PocketOutlook.CheckHRESULT(hResult);
          zFirstName = Marshal.PtrToStringUni(bz);
        }
        finally {
          PocketOutlook.SysFreeString(bz);
        }

        return zFirstName;
      }
      set {
        PocketOutlook.CheckHRESULT(do_put_FirstName(this.RawItemPtr, value));
      }
    } // FirstName

    public String MiddleName {
      get {
        String zMiddleName = null;
        IntPtr bz = new IntPtr(0);
        int hResult = do_get_MiddleName(this.RawItemPtr, ref bz);
        try {
          PocketOutlook.CheckHRESULT(hResult);
          zMiddleName = Marshal.PtrToStringUni(bz);
        }
        finally {
          PocketOutlook.SysFreeString(bz);
        }

        return zMiddleName;
      }
      set {
        PocketOutlook.CheckHRESULT(do_put_MiddleName(this.RawItemPtr, value));
      }
    } // MiddleName

    public String LastName {
      get {
        String zLastName = null;
        IntPtr bz = new IntPtr(0);
        int hResult = do_get_LastName(this.RawItemPtr, ref bz);
        try {
          PocketOutlook.CheckHRESULT(hResult);
          zLastName = Marshal.PtrToStringUni(bz);
        }
        finally {
          PocketOutlook.SysFreeString(bz);
        }

        return zLastName;
      }
      set {
        PocketOutlook.CheckHRESULT(do_put_LastName(this.RawItemPtr, value));
      }
    } // LastName

    public String Suffix {
      get {
        String zSuffix = null;
        IntPtr bz = new IntPtr(0);
        int hResult = do_get_Suffix(this.RawItemPtr, ref bz);
        try {
          PocketOutlook.CheckHRESULT(hResult);
          zSuffix = Marshal.PtrToStringUni(bz);
        }
        finally {
          PocketOutlook.SysFreeString(bz);
        }

        return zSuffix;
      }
      set {
        PocketOutlook.CheckHRESULT(do_put_Suffix(this.RawItemPtr, value));
      }
    } // Suffix

    public String HomeAddressStreet {
      get {
        String zHomeAddressStreet = null;
        IntPtr bz = new IntPtr(0);
        int hResult = do_get_HomeAddressStreet(this.RawItemPtr, ref bz);
        try {
          PocketOutlook.CheckHRESULT(hResult);
          zHomeAddressStreet = Marshal.PtrToStringUni(bz);
        }
        finally {
          PocketOutlook.SysFreeString(bz);
        }

        return zHomeAddressStreet;
      }
      set {
        PocketOutlook.CheckHRESULT(do_put_HomeAddressStreet(this.RawItemPtr, value));
      }
    } // HomeAddressStreet

    public String HomeAddressCity {
      get {
        String zHomeAddressCity = null;
        IntPtr bz = new IntPtr(0);
        int hResult = do_get_HomeAddressCity(this.RawItemPtr, ref bz);
        try {
          PocketOutlook.CheckHRESULT(hResult);
          zHomeAddressCity = Marshal.PtrToStringUni(bz);
        }
        finally {
          PocketOutlook.SysFreeString(bz);
        }

        return zHomeAddressCity;
      }
      set {
        PocketOutlook.CheckHRESULT(do_put_HomeAddressCity(this.RawItemPtr, value));
      }
    } // HomeAddressCity

    public String HomeAddressState {
      get {
        String zHomeAddressState = null;
        IntPtr bz = new IntPtr(0);
        int hResult = do_get_HomeAddressState(this.RawItemPtr, ref bz);
        try {
          PocketOutlook.CheckHRESULT(hResult);
          zHomeAddressState = Marshal.PtrToStringUni(bz);
        }
        finally {
          PocketOutlook.SysFreeString(bz);
        }

        return zHomeAddressState;
      }
      set {
        PocketOutlook.CheckHRESULT(do_put_HomeAddressState(this.RawItemPtr, value));
      }
    } // HomeAddressState

    public String HomeAddressPostalCode {
      get {
        String zHomeAddressPostalCode = null;
        IntPtr bz = new IntPtr(0);
        int hResult = do_get_HomeAddressPostalCode(this.RawItemPtr, ref bz);
        try {
          PocketOutlook.CheckHRESULT(hResult);
          zHomeAddressPostalCode = Marshal.PtrToStringUni(bz);
        }
        finally {
          PocketOutlook.SysFreeString(bz);
        }

        return zHomeAddressPostalCode;
      }
      set {
        PocketOutlook.CheckHRESULT(do_put_HomeAddressPostalCode(this.RawItemPtr, value));
      }
    } // HomeAddressPostalCode

    public String HomeAddressCountry {
      get {
        String zHomeAddressCountry = null;
        IntPtr bz = new IntPtr(0);
        int hResult = do_get_HomeAddressCountry(this.RawItemPtr, ref bz);
        try {
          PocketOutlook.CheckHRESULT(hResult);
          zHomeAddressCountry = Marshal.PtrToStringUni(bz);
        }
        finally {
          PocketOutlook.SysFreeString(bz);
        }

        return zHomeAddressCountry;
      }
      set {
        PocketOutlook.CheckHRESULT(do_put_HomeAddressCountry(this.RawItemPtr, value));
      }
    } // HomeAddressCountry

    public String OtherAddressStreet {
      get {
        String zOtherAddressStreet = null;
        IntPtr bz = new IntPtr(0);
        int hResult = do_get_OtherAddressStreet(this.RawItemPtr, ref bz);
        try {
          PocketOutlook.CheckHRESULT(hResult);
          zOtherAddressStreet = Marshal.PtrToStringUni(bz);
        }
        finally {
          PocketOutlook.SysFreeString(bz);
        }

        return zOtherAddressStreet;
      }
      set {
        PocketOutlook.CheckHRESULT(do_put_OtherAddressStreet(this.RawItemPtr, value));
      }
    } // OtherAddressStreet

    public String OtherAddressCity {
      get {
        String zOtherAddressCity = null;
        IntPtr bz = new IntPtr(0);
        int hResult = do_get_OtherAddressCity(this.RawItemPtr, ref bz);
        try {
          PocketOutlook.CheckHRESULT(hResult);
          zOtherAddressCity = Marshal.PtrToStringUni(bz);
        }
        finally {
          PocketOutlook.SysFreeString(bz);
        }

        return zOtherAddressCity;
      }
      set {
        PocketOutlook.CheckHRESULT(do_put_OtherAddressCity(this.RawItemPtr, value));
      }
    } // OtherAddressCity

    public String OtherAddressState {
      get {
        String zOtherAddressState = null;
        IntPtr bz = new IntPtr(0);
        int hResult = do_get_OtherAddressState(this.RawItemPtr, ref bz);
        try {
          PocketOutlook.CheckHRESULT(hResult);
          zOtherAddressState = Marshal.PtrToStringUni(bz);
        }
        finally {
          PocketOutlook.SysFreeString(bz);
        }

        return zOtherAddressState;
      }
      set {
        PocketOutlook.CheckHRESULT(do_put_OtherAddressState(this.RawItemPtr, value));
      }
    } // OtherAddressState

    public String OtherAddressPostalCode {
      get {
        String zOtherAddressPostalCode = null;
        IntPtr bz = new IntPtr(0);
        int hResult = do_get_OtherAddressPostalCode(this.RawItemPtr, ref bz);
        try {
          PocketOutlook.CheckHRESULT(hResult);
          zOtherAddressPostalCode = Marshal.PtrToStringUni(bz);
        }
        finally {
          PocketOutlook.SysFreeString(bz);
        }

        return zOtherAddressPostalCode;
      }
      set {
        PocketOutlook.CheckHRESULT(do_put_OtherAddressPostalCode(this.RawItemPtr, value));
      }
    } // OtherAddressPostalCode

    public String OtherAddressCountry {
      get {
        String zOtherAddressCountry = null;
        IntPtr bz = new IntPtr(0);
        int hResult = do_get_OtherAddressCountry(this.RawItemPtr, ref bz);
        try {
          PocketOutlook.CheckHRESULT(hResult);
          zOtherAddressCountry = Marshal.PtrToStringUni(bz);
        }
        finally {
          PocketOutlook.SysFreeString(bz);
        }

        return zOtherAddressCountry;
      }
      set {
        PocketOutlook.CheckHRESULT(do_put_OtherAddressCountry(this.RawItemPtr, value));
      }
    } // OtherAddressCountry

    public String BusinessAddressStreet {
      get {
        String zBusinessAddressStreet = null;
        IntPtr bz = new IntPtr(0);
        int hResult = do_get_BusinessAddressStreet(this.RawItemPtr, ref bz);
        try {
          PocketOutlook.CheckHRESULT(hResult);
          zBusinessAddressStreet = Marshal.PtrToStringUni(bz);
        }
        finally {
          PocketOutlook.SysFreeString(bz);
        }

        return zBusinessAddressStreet;
      }
      set {
        PocketOutlook.CheckHRESULT(do_put_BusinessAddressStreet(this.RawItemPtr, value));
      }
    } // BusinessAddressStreet

    public String BusinessAddressCity {
      get {
        String zBusinessAddressCity = null;
        IntPtr bz = new IntPtr(0);
        int hResult = do_get_BusinessAddressCity(this.RawItemPtr, ref bz);
        try {
          PocketOutlook.CheckHRESULT(hResult);
          zBusinessAddressCity = Marshal.PtrToStringUni(bz);
        }
        finally {
          PocketOutlook.SysFreeString(bz);
        }

        return zBusinessAddressCity;
      }
      set {
        PocketOutlook.CheckHRESULT(do_put_BusinessAddressCity(this.RawItemPtr, value));
      }
    } // BusinessAddressCity

    public String BusinessAddressState {
      get {
        String zBusinessAddressState = null;
        IntPtr bz = new IntPtr(0);
        int hResult = do_get_BusinessAddressState(this.RawItemPtr, ref bz);
        try {
          PocketOutlook.CheckHRESULT(hResult);
          zBusinessAddressState = Marshal.PtrToStringUni(bz);
        }
        finally {
          PocketOutlook.SysFreeString(bz);
        }

        return zBusinessAddressState;
      }
      set {
        PocketOutlook.CheckHRESULT(do_put_BusinessAddressState(this.RawItemPtr, value));
      }
    } // BusinessAddressState

    public String BusinessAddressPostalCode {
      get {
        String zBusinessAddressPostalCode = null;
        IntPtr bz = new IntPtr(0);
        int hResult = do_get_BusinessAddressPostalCode(this.RawItemPtr, ref bz);
        try {
          PocketOutlook.CheckHRESULT(hResult);
          zBusinessAddressPostalCode = Marshal.PtrToStringUni(bz);
        }
        finally {
          PocketOutlook.SysFreeString(bz);
        }

        return zBusinessAddressPostalCode;
      }
      set {
        PocketOutlook.CheckHRESULT(do_put_BusinessAddressPostalCode(this.RawItemPtr, value));
      }
    } // BusinessAddressPostalCode

    public String BusinessAddressCountry {
      get {
        String zBusinessAddressCountry = null;
        IntPtr bz = new IntPtr(0);
        int hResult = do_get_BusinessAddressCountry(this.RawItemPtr, ref bz);
        try {
          PocketOutlook.CheckHRESULT(hResult);
          zBusinessAddressCountry = Marshal.PtrToStringUni(bz);
        }
        finally {
          PocketOutlook.SysFreeString(bz);
        }

        return zBusinessAddressCountry;
      }
      set {
        PocketOutlook.CheckHRESULT(do_put_BusinessAddressCountry(this.RawItemPtr, value));
      }
    } // BusinessAddressCountry

    public String Body {
      get {
        String zBody = null;
        IntPtr bz = new IntPtr(0);
        int hResult = do_get_Body(this.RawItemPtr, ref bz);
        try {
          PocketOutlook.CheckHRESULT(hResult);
          zBody = Marshal.PtrToStringUni(bz);
        }
        finally {
          PocketOutlook.SysFreeString(bz);
        }

        return zBody;
      }
      set {
        PocketOutlook.CheckHRESULT(do_put_Body(this.RawItemPtr, value));
      }
    } // Body

    public int Oid {
      get {
        int nOid = 0;
        PocketOutlook.CheckHRESULT(do_get_Oid(this.RawItemPtr, ref nOid));
        return nOid;
      }
    }

    protected override void doSave() {
      int hResult = do_Save(this.RawItemPtr);
      // this will throw an exception if the save fails
      PocketOutlook.CheckHRESULT(hResult);
    }

    protected override void doDelete() {
      int hResult = do_Delete(this.RawItemPtr);
      // this will throw an exception if the delete fails
      PocketOutlook.CheckHRESULT(hResult);
    }

    protected override PO_OutlookItem doCopy() {
      throw new NotSupportedException();
    }

    [ DllImport("PocketOutlook.dll", EntryPoint="IContact_get_Birthday") ]
    private static extern int do_get_Birthday(IntPtr self);

    [ DllImport("PocketOutlook.dll", EntryPoint="IContact_get_Anniversary") ]
    private static extern int do_get_Anniversary(IntPtr self);

    [ DllImport("PocketOutlook.dll", EntryPoint="IContact_get_BusinessFaxNumber") ]
    private static extern int do_get_BusinessFaxNumber(IntPtr self,
      ref IntPtr rbz);

    [ DllImport("PocketOutlook.dll", EntryPoint="IContact_get_CompanyName") ]
    private static extern int do_get_CompanyName(IntPtr self,
      ref IntPtr rbz);

    [ DllImport("PocketOutlook.dll", EntryPoint="IContact_get_Department") ]
    private static extern int do_get_Department(IntPtr self,
      ref IntPtr rbz);

    [ DllImport("PocketOutlook.dll", EntryPoint="IContact_get_Email1Address") ]
    private static extern int do_get_Email1Address(IntPtr self,
      ref IntPtr rbz);

    [ DllImport("PocketOutlook.dll", EntryPoint="IContact_get_MobileTelephoneNumber") ]
    private static extern int do_get_MobileTelephoneNumber(IntPtr self,
      ref IntPtr rbz);

    [ DllImport("PocketOutlook.dll", EntryPoint="IContact_get_OfficeLocation") ]
    private static extern int do_get_OfficeLocation(IntPtr self,
      ref IntPtr rbz);

    [ DllImport("PocketOutlook.dll", EntryPoint="IContact_get_PagerNumber") ]
    private static extern int do_get_PagerNumber(IntPtr self,
      ref IntPtr rbz);

    [ DllImport("PocketOutlook.dll", EntryPoint="IContact_get_BusinessTelephoneNumber") ]
    private static extern int do_get_BusinessTelephoneNumber(IntPtr self,
      ref IntPtr rbz);

    [ DllImport("PocketOutlook.dll", EntryPoint="IContact_get_JobTitle") ]
    private static extern int do_get_JobTitle(IntPtr self, ref IntPtr rbz);

    [ DllImport("PocketOutlook.dll", EntryPoint="IContact_get_HomeTelephoneNumber") ]
    private static extern int do_get_HomeTelephoneNumber(IntPtr self,
      ref IntPtr rbz);

    [ DllImport("PocketOutlook.dll", EntryPoint="IContact_get_Email2Address") ]
    private static extern int do_get_Email2Address(IntPtr self, 
      ref IntPtr rbz);

    [ DllImport("PocketOutlook.dll", EntryPoint="IContact_get_Spouse") ]
    private static extern int do_get_Spouse(IntPtr self,
      ref IntPtr rbz);

    [ DllImport("PocketOutlook.dll", EntryPoint="IContact_get_Email3Address") ]
    private static extern int do_get_Email3Address(IntPtr self,
      ref IntPtr rbz);

    [ DllImport("PocketOutlook.dll", EntryPoint="IContact_get_Home2TelephoneNumber") ]
    private static extern int do_get_Home2TelephoneNumber(IntPtr self,
      ref IntPtr rbz);

    [ DllImport("PocketOutlook.dll", EntryPoint="IContact_get_HomeFaxNumber") ]
    private static extern int do_get_HomeFaxNumber(IntPtr self,
      ref IntPtr rbz);

    [ DllImport("PocketOutlook.dll", EntryPoint="IContact_get_CarTelephoneNumber") ]
    private static extern int do_get_CarTelephoneNumber(IntPtr self,
      ref IntPtr rbz);

    [ DllImport("PocketOutlook.dll", EntryPoint="IContact_get_AssistantName") ]
    private static extern int do_get_AssistantName(IntPtr self,
      ref IntPtr rbz);

    [ DllImport("PocketOutlook.dll", EntryPoint="IContact_get_AssistantTelephoneNumber") ]
    private static extern int do_get_AssistantTelephoneNumber(IntPtr self,
      ref IntPtr rbz);

    [ DllImport("PocketOutlook.dll", EntryPoint="IContact_get_Children") ]
    private static extern int do_get_Children(IntPtr self,
      ref IntPtr rbz);

    [ DllImport("PocketOutlook.dll", EntryPoint="IContact_get_Categories") ]
    private static extern int do_get_Categories(IntPtr self,
      ref IntPtr rbz);

    [ DllImport("PocketOutlook.dll", EntryPoint="IContact_get_WebPage") ]
    private static extern int do_get_WebPage(IntPtr self,
      ref IntPtr rbz);

    [ DllImport("PocketOutlook.dll", EntryPoint="IContact_get_Business2TelephoneNumber") ]
    private static extern int do_get_Business2TelephoneNumber(IntPtr self,
      ref IntPtr rbz);

    [ DllImport("PocketOutlook.dll", EntryPoint="IContact_get_Title") ]
    private static extern int do_get_Title(IntPtr self,
      ref IntPtr rbz);

    [ DllImport("PocketOutlook.dll", EntryPoint="IContact_get_FirstName") ]
    private static extern int do_get_FirstName(IntPtr self,
      ref IntPtr rbz);

    [ DllImport("PocketOutlook.dll", EntryPoint="IContact_get_MiddleName") ]
    private static extern int do_get_MiddleName(IntPtr self,
      ref IntPtr rbz);

    [ DllImport("PocketOutlook.dll", EntryPoint="IContact_get_LastName") ]
    private static extern int do_get_LastName(IntPtr self,
      ref IntPtr rbz);

    [ DllImport("PocketOutlook.dll", EntryPoint="IContact_get_Suffix") ]
    private static extern int do_get_Suffix(IntPtr self,
      ref IntPtr rbz);

    [ DllImport("PocketOutlook.dll", EntryPoint="IContact_get_HomeAddressStreet") ]
    private static extern int do_get_HomeAddressStreet(IntPtr self,
      ref IntPtr rbz);

    [ DllImport("PocketOutlook.dll", EntryPoint="IContact_get_HomeAddressCity") ]
    private static extern int do_get_HomeAddressCity(IntPtr self,
      ref IntPtr rbz);

    [ DllImport("PocketOutlook.dll", EntryPoint="IContact_get_HomeAddressState") ]
    private static extern int do_get_HomeAddressState(IntPtr self,
      ref IntPtr rbz);

    [ DllImport("PocketOutlook.dll", EntryPoint="IContact_get_HomeAddressPostalCode") ]
    private static extern int do_get_HomeAddressPostalCode(IntPtr self,
      ref IntPtr rbz);

    [ DllImport("PocketOutlook.dll", EntryPoint="IContact_get_HomeAddressCountry") ]
    private static extern int do_get_HomeAddressCountry(IntPtr self,
      ref IntPtr rbz);

    [ DllImport("PocketOutlook.dll", EntryPoint="IContact_get_OtherAddressStreet") ]
    private static extern int do_get_OtherAddressStreet(IntPtr self,
      ref IntPtr rbz);

    [ DllImport("PocketOutlook.dll", EntryPoint="IContact_get_OtherAddressCity") ]
    private static extern int do_get_OtherAddressCity(IntPtr self,
      ref IntPtr rbz);

    [ DllImport("PocketOutlook.dll", EntryPoint="IContact_get_OtherAddressState") ]
    private static extern int do_get_OtherAddressState(IntPtr self,
      ref IntPtr rbz);

    [ DllImport("PocketOutlook.dll", EntryPoint="IContact_get_OtherAddressPostalCode") ]
    private static extern int do_get_OtherAddressPostalCode(IntPtr self,
      ref IntPtr rbz);

    [ DllImport("PocketOutlook.dll", EntryPoint="IContact_get_OtherAddressCountry") ]
    private static extern int do_get_OtherAddressCountry(IntPtr self,
      ref IntPtr rbz);

    [ DllImport("PocketOutlook.dll", EntryPoint="IContact_get_BusinessAddressStreet") ]
    private static extern int do_get_BusinessAddressStreet(IntPtr self,
      ref IntPtr rbz);

    [ DllImport("PocketOutlook.dll", EntryPoint="IContact_get_BusinessAddressCity") ]
    private static extern int do_get_BusinessAddressCity(IntPtr self,
      ref IntPtr rbz);

    [ DllImport("PocketOutlook.dll", EntryPoint="IContact_get_BusinessAddressState") ]
    private static extern int do_get_BusinessAddressState(IntPtr self,
      ref IntPtr rbz);

    [ DllImport("PocketOutlook.dll", EntryPoint="IContact_get_BusinessAddressPostalCode") ]
    private static extern int do_get_BusinessAddressPostalCode(IntPtr self,
      ref IntPtr rbz);

    [ DllImport("PocketOutlook.dll", EntryPoint="IContact_get_BusinessAddressCountry") ]
    private static extern int do_get_BusinessAddressCountry(IntPtr self,
      ref IntPtr rbz);

    [ DllImport("PocketOutlook.dll", EntryPoint="IContact_get_RadioTelephoneNumber") ]
    private static extern int do_get_RadioTelephoneNumber(IntPtr self,
      ref IntPtr rbz);

    [ DllImport("PocketOutlook.dll", EntryPoint="IContact_get_FileAs") ]
    private static extern int do_get_FileAs(IntPtr self,
      ref IntPtr rbz);

    [ DllImport("PocketOutlook.dll", EntryPoint="IContact_get_Body") ]
    private static extern int do_get_Body(IntPtr self,
      ref IntPtr rbz);

    [ DllImport("PocketOutlook.dll", EntryPoint="IContact_get_YomiCompanyName") ]
    private static extern int do_get_YomiCompanyName(IntPtr self,
      ref IntPtr rbz);

    [ DllImport("PocketOutlook.dll", EntryPoint="IContact_get_YomiFirstName") ]
    private static extern int do_get_YomiFirstName(IntPtr self,
      ref IntPtr rbz);

    [ DllImport("PocketOutlook.dll", EntryPoint="IContact_get_YomiLastName") ]
    private static extern int do_get_YomiLastName(IntPtr self,
      ref IntPtr rbz);

    [ DllImport("PocketOutlook.dll", EntryPoint="IContact_put_Birthday") ]
    private static extern int do_put_Birthday(IntPtr self,
      String zBirthday);

    [ DllImport("PocketOutlook.dll", EntryPoint="IContact_put_Anniversary") ]
    private static extern int do_put_Anniversary(IntPtr self,
      String zAnniversary);

    [ DllImport("PocketOutlook.dll", EntryPoint="IContact_put_BusinessFaxNumber") ]
    private static extern int do_put_BusinessFaxNumber(IntPtr self,
      String
      zBusinessFaxNumber);

    [ DllImport("PocketOutlook.dll", EntryPoint="IContact_put_CompanyName") ]
    private static extern int do_put_CompanyName(IntPtr self,
      String zCompanyName);

    [ DllImport("PocketOutlook.dll", EntryPoint="IContact_put_Department") ]
    private static extern int do_put_Department(IntPtr self,
      String zDepartment);

    [ DllImport("PocketOutlook.dll", EntryPoint="IContact_put_Email1Address") ]
    private static extern int do_put_Email1Address(IntPtr self,
      String zEmail1Address);

    [ DllImport("PocketOutlook.dll", EntryPoint="IContact_put_MobileTelephoneNumber") ]
    private static extern int do_put_MobileTelephoneNumber(IntPtr self,
      String
      zMobileTelephoneNumber);

    [ DllImport("PocketOutlook.dll", EntryPoint="IContact_put_OfficeLocation") ]
    private static extern int do_put_OfficeLocation(IntPtr self,
      String
      zOfficeLocation);

    [ DllImport("PocketOutlook.dll", EntryPoint="IContact_put_PagerNumber") ]
    private static extern int do_put_PagerNumber(IntPtr self,
      String zPagerNumber);

    [ DllImport("PocketOutlook.dll", EntryPoint="IContact_put_BusinessTelephoneNumber") ]
    private static extern int do_put_BusinessTelephoneNumber(IntPtr
      self,
      String
      zBusinessTelephoneNumber);

    [ DllImport("PocketOutlook.dll", EntryPoint="IContact_put_JobTitle") ]
    private static extern int do_put_JobTitle(IntPtr self,
      String zJobTitle);

    [ DllImport("PocketOutlook.dll", EntryPoint="IContact_put_HomeTelephoneNumber") ]
    private static extern int do_put_HomeTelephoneNumber(IntPtr self,
      String
      zHomeTelephoneNumber);

    [ DllImport("PocketOutlook.dll", EntryPoint="IContact_put_Email2Address") ]
    private static extern int do_put_Email2Address(IntPtr self,
      String zEmail2Address);

    [ DllImport("PocketOutlook.dll", EntryPoint="IContact_put_Spouse") ]
    private static extern int do_put_Spouse(IntPtr self,
      String zSpouse);

    [ DllImport("PocketOutlook.dll", EntryPoint="IContact_put_Email3Address") ]
    private static extern int do_put_Email3Address(IntPtr self,
      String zEmail3Address);

    [ DllImport("PocketOutlook.dll", EntryPoint="IContact_put_Home2TelephoneNumber") ]
    private static extern int do_put_Home2TelephoneNumber(IntPtr self,
      String zHome2TelephoneNumber);

    [ DllImport("PocketOutlook.dll", EntryPoint="IContact_put_HomeFaxNumber") ]
    private static extern int do_put_HomeFaxNumber(IntPtr self,
      String zHomeFaxNumber);

    [ DllImport("PocketOutlook.dll", EntryPoint="IContact_put_CarTelephoneNumber") ]
    private static extern int do_put_CarTelephoneNumber(IntPtr self,
      String zCarTelephoneNumber);

    [ DllImport("PocketOutlook.dll", EntryPoint="IContact_put_AssistantName") ]
    private static extern int do_put_AssistantName(IntPtr self,
      String zAssistantName);

    [ DllImport("PocketOutlook.dll", EntryPoint="IContact_put_AssistantTelephoneNumber") ]
    private static extern int do_put_AssistantTelephoneNumber(IntPtr self,
      String zAssistantTelephoneNumber);

    [ DllImport("PocketOutlook.dll", EntryPoint="IContact_put_Children") ]
    private static extern int do_put_Children(IntPtr self,
      String zChildren);

    [ DllImport("PocketOutlook.dll", EntryPoint="IContact_put_Categories") ]
    private static extern int do_put_Categories(IntPtr self,
      String zCategories);

    [ DllImport("PocketOutlook.dll", EntryPoint="IContact_put_WebPage") ]
    private static extern int do_put_WebPage(IntPtr self,
      String zWebPage);

    [ DllImport("PocketOutlook.dll", EntryPoint="IContact_put_Business2TelephoneNumber") ]
    private static extern int do_put_Business2TelephoneNumber(IntPtr self,
      String zBusiness2TelephoneNumber);

    [ DllImport("PocketOutlook.dll", EntryPoint="IContact_put_Title") ]
    private static extern int do_put_Title(IntPtr self,
      String zTitle);

    [ DllImport("PocketOutlook.dll", EntryPoint="IContact_put_FirstName") ]
    private static extern int do_put_FirstName(IntPtr self,
      String zFirstName);

    [ DllImport("PocketOutlook.dll", EntryPoint="IContact_put_MiddleName") ]
    private static extern int do_put_MiddleName(IntPtr self,
      String zMiddleName);

    [ DllImport("PocketOutlook.dll", EntryPoint="IContact_put_LastName") ]
    private static extern int do_put_LastName(IntPtr self,
      String zLastName);

    [ DllImport("PocketOutlook.dll", EntryPoint="IContact_put_Suffix") ]
    private static extern int do_put_Suffix(IntPtr self,
      String zSuffix);

    [ DllImport("PocketOutlook.dll", EntryPoint="IContact_put_HomeAddressStreet") ]
    private static extern int do_put_HomeAddressStreet(IntPtr self,
      String zHomeAddressStreet);

    [ DllImport("PocketOutlook.dll", EntryPoint="IContact_put_HomeAddressCity") ]
    private static extern int do_put_HomeAddressCity(IntPtr self,
      String zHomeAddressCity);

    [ DllImport("PocketOutlook.dll", EntryPoint="IContact_put_HomeAddressState") ]
    private static extern int do_put_HomeAddressState(IntPtr self,
      String zHomeAddressState);

    [ DllImport("PocketOutlook.dll", EntryPoint="IContact_put_HomeAddressPostalCode") ]
    private static extern int do_put_HomeAddressPostalCode(IntPtr self,
      String zHomeAddressPostalCode);

    [ DllImport("PocketOutlook.dll", EntryPoint="IContact_put_HomeAddressCountry") ]
    private static extern int do_put_HomeAddressCountry(IntPtr self,
      String zHomeAddressCountry);

    [ DllImport("PocketOutlook.dll", EntryPoint="IContact_put_OtherAddressStreet") ]
    private static extern int do_put_OtherAddressStreet(IntPtr self,
      String zOtherAddressStreet);

    [ DllImport("PocketOutlook.dll", EntryPoint="IContact_put_OtherAddressCity") ]
    private static extern int do_put_OtherAddressCity(IntPtr self,
      String zOtherAddressCity);

    [ DllImport("PocketOutlook.dll", EntryPoint="IContact_put_OtherAddressState") ]
    private static extern int do_put_OtherAddressState(IntPtr self,
      String zOtherAddressState);

    [ DllImport("PocketOutlook.dll", EntryPoint="IContact_put_OtherAddressPostalCode") ]
    private static extern int do_put_OtherAddressPostalCode(IntPtr self,
      String zOtherAddressPostalCode);

    [ DllImport("PocketOutlook.dll", EntryPoint="IContact_put_OtherAddressCountry") ]
    private static extern int do_put_OtherAddressCountry(IntPtr self,
      String zOtherAddressCountry);

    [ DllImport("PocketOutlook.dll", EntryPoint="IContact_put_BusinessAddressStreet") ]
    private static extern int do_put_BusinessAddressStreet(IntPtr self,
      String zBusinessAddressStreet);

    [ DllImport("PocketOutlook.dll", EntryPoint="IContact_put_BusinessAddressCity") ]
    private static extern int do_put_BusinessAddressCity(IntPtr self,
      String zBusinessAddressCity);

    [ DllImport("PocketOutlook.dll", EntryPoint="IContact_put_BusinessAddressState") ]
    private static extern int do_put_BusinessAddressState(IntPtr self,
      String zBusinessAddressState);

    [ DllImport("PocketOutlook.dll", EntryPoint="IContact_put_BusinessAddressPostalCode") ]
    private static extern int do_put_BusinessAddressPostalCode(IntPtr self,
      String zBusinessAddressPostalCode);

    [ DllImport("PocketOutlook.dll", EntryPoint="IContact_put_BusinessAddressCountry") ]
    private static extern int do_put_BusinessAddressCountry(IntPtr self,
      String zBusinessAddressCountry);

    [ DllImport("PocketOutlook.dll", EntryPoint="IContact_put_RadioTelephoneNumber") ]
    private static extern int do_put_RadioTelephoneNumber(IntPtr self,
      String zRadioTelephoneNumber);

    [ DllImport("PocketOutlook.dll", EntryPoint="IContact_put_FileAs") ]
    private static extern int do_put_FileAs(IntPtr self,
      String zFileAs);

    [ DllImport("PocketOutlook.dll", EntryPoint="IContact_put_Body") ]
    private static extern int do_put_Body(IntPtr self,
      String zBody);

    [ DllImport("PocketOutlook.dll", EntryPoint="IContact_put_YomiCompanyName") ]
    private static extern int do_put_YomiCompanyName(IntPtr self,
      String zYomiCompanyName);

    [ DllImport("PocketOutlook.dll", EntryPoint="IContact_put_YomiFirstName") ]
    private static extern int do_put_YomiFirstName(IntPtr self,
      String zYomiFirstName);

    [ DllImport("PocketOutlook.dll", EntryPoint="IContact_put_YomiLastName") ]
    private static extern int do_put_YomiLastName(IntPtr self,
      String zYomiLastName);

    [ DllImport("PocketOutlook.dll", EntryPoint="IContact_Save") ]
    private static extern int do_Save(IntPtr self);

    [ DllImport("PocketOutlook.dll", EntryPoint="IContact_Delete") ]
    private static extern int do_Delete(IntPtr self);

    [ DllImport("PocketOutlook.dll", EntryPoint="IContact_Copy") ]
    private static extern int do_Copy(IntPtr self,
      ref IntPtr rpIContact);

    [ DllImport("PocketOutlook.dll", EntryPoint="IContact_Display") ]
    private static extern int do_Display(IntPtr self);

    [ DllImport("PocketOutlook.dll", EntryPoint="IContact_get_Oid") ]
    private static extern int do_get_Oid(IntPtr self,
      ref int rnOid);

    [ DllImport("PocketOutlook.dll", EntryPoint="IContact_put_BodyInk") ]
    private static extern int do_put_BodyInk(IntPtr self);

    [ DllImport("PocketOutlook.dll", EntryPoint="IContact_get_BodyInk") ]
    private static extern int do_get_BodyInk(IntPtr self);

    [ DllImport("PocketOutlook.dll", EntryPoint="IContact_get_Application") ]
    private static extern int do_get_Application(IntPtr self);

  } // class Contact

} // namespace PocketOutlook
