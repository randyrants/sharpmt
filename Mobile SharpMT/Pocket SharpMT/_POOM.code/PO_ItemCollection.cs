/*---------------------------------------------------------------------
   Copyright (C) Microsoft Corporation.  All rights reserved.

  This source code is intended only as a supplement to Microsoft
  Development Tools and/or on-line documentation.  See these other
  materials for detailed information regarding Microsoft code samples.

  THIS CODE AND INFORMATION ARE PROVIDED "AS IS" WITHOUT WARRANTY OF ANY
  KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
  IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
  PARTICULAR PURPOSE.
 -----------------------------------------------------------------------
 * File: PO_ItemCollection.class
 *
 * Purpose: Managed reperesentation of the IPOutlookItemCollection
 *
 *
 * Notes:
 *
 */

using System;
using System.Runtime.InteropServices;

namespace Pocket_SharpMT{

  public class PO_ItemCollection {
    private PocketOutlookControl m_poCtrl;
    private IntPtr m_pIPOutlookItemCollection;
    private int m_tItemType;

    internal PO_ItemCollection(PocketOutlookControl poCtrl, int tItemType, ref IntPtr pIPOutlookItemCollection) {
      m_pIPOutlookItemCollection = pIPOutlookItemCollection;
      m_tItemType = tItemType;
      m_poCtrl = poCtrl;
    }

    public int Count {
      get {
        int nCount = 0;
        PocketOutlook.CheckHRESULT(do_get_Count(m_pIPOutlookItemCollection, ref nCount));
        return nCount;
      }
    }

    public bool IncludeRecurrences {
      get {
        int bIncludeRecurrences = 0;
        PocketOutlook.CheckHRESULT(do_get_IncludeRecurrences(m_pIPOutlookItemCollection, ref bIncludeRecurrences));
        return bIncludeRecurrences == 0 ? false : true;
      }
      set {
        PocketOutlook.CheckHRESULT(do_put_IncludeRecurrences(m_pIPOutlookItemCollection, value ? 1 : 0));
      }
    }
        
    public PocketOutlookControl PocketOutlookControl {
      get {
        return m_poCtrl;
      }
    }

    public PO_OutlookItem Add() {
      IntPtr pItem = new IntPtr(0);
      int hResult = do_Add(m_pIPOutlookItemCollection, ref pItem);
      try {
        PocketOutlook.CheckHRESULT(hResult);
      }
      catch (Exception) {
        PocketOutlook.ReleaseCOMPtr(pItem);
        throw;
      }

      return this.CreateItem(pItem);
    }

    public PO_OutlookItem Item(int iIndex) {
      IntPtr pItem = new IntPtr(0);
      int hResult = do_Item(m_pIPOutlookItemCollection, iIndex, ref pItem);
      try {
        PocketOutlook.CheckHRESULT(hResult);
      }
      catch (Exception) {
        PocketOutlook.ReleaseCOMPtr(pItem);
        throw;
      }

      return this.CreateItem(pItem);
    }

    public void Remove(int iIndex) {
      PocketOutlook.CheckHRESULT(do_Remove(m_pIPOutlookItemCollection, iIndex));
    }

    public void Sort(string zProperty, bool bDescending) {
      PocketOutlook.CheckHRESULT(do_Sort(m_pIPOutlookItemCollection, zProperty, bDescending ? 1 : 0));
    }

    public PO_OutlookItem Find(string zRestriction) {
      IntPtr pItem = new IntPtr(0);
      int hResult = do_Find(m_pIPOutlookItemCollection, zRestriction, ref pItem);

      try {
        PocketOutlook.CheckHRESULT(hResult);
      }
      catch (Exception) {
        PocketOutlook.ReleaseCOMPtr(pItem);
        throw;
      }

      return this.CreateItem(pItem);
    }

    public PO_OutlookItem FindNext() {
      IntPtr pItem = new IntPtr(0);
      int hResult = do_FindNext(m_pIPOutlookItemCollection, ref pItem);
            
      try {
        PocketOutlook.CheckHRESULT(hResult);
      }
      catch (Exception) {
        PocketOutlook.ReleaseCOMPtr(pItem);
        throw;
      }

      return this.CreateItem(pItem);
    }

    public PO_ItemCollection Restrict(String zRestriction) {
      IntPtr pItemCollection = new IntPtr(0);
      int hResult = do_Restrict(m_pIPOutlookItemCollection, zRestriction,
        ref pItemCollection);

      try {
        PocketOutlook.CheckHRESULT(hResult);
      }
      catch {
        PocketOutlook.ReleaseCOMPtr(pItemCollection);
      }

      return new PO_ItemCollection(m_poCtrl, m_tItemType, ref pItemCollection);
    }

    /*
         * A private function for creating an item of the proper type.
         */
    private PO_OutlookItem CreateItem(IntPtr pItem) {
      PO_OutlookItem item = null;
      PO_OutlookItem.ItemType itemType = (PO_OutlookItem.ItemType) m_tItemType;
      switch (itemType) {
        case PO_OutlookItem.ItemType.AppointmentItem:
//          item = new Appointment(m_poCtrl, ref pItem);
          break;
        case PO_OutlookItem.ItemType.ContactItem:
          item = new PO_Contact(m_poCtrl, ref pItem);
          break;
        case PO_OutlookItem.ItemType.TaskItem:
//          item = new Task(m_poCtrl, ref pItem);
          break;
        case PO_OutlookItem.ItemType.CityItem:
//          item = new City(m_poCtrl, ref pItem);
          break;
        default:
          throw new InvalidProgramException();
      }

      return item;
    } // CreateItem

    [ DllImport("PocketOutlook.dll", EntryPoint="IPOutlookItemCollection_get_Count") ]
    private static extern int do_get_Count(IntPtr self,
      ref int rnCount);
        
    [ DllImport("PocketOutlook.dll", EntryPoint="IPOutlookItemCollection_get_IncludeRecurrences") ]
    private static extern int do_get_IncludeRecurrences(IntPtr self,
      ref int rbIncludeRecurrences);

    [ DllImport("PocketOutlook.dll", EntryPoint="IPOutlookItemCollection_put_IncludeRecurrences") ]
    private static extern int do_put_IncludeRecurrences(IntPtr self,
      int bIncludeRecurrences);

    [ DllImport("PocketOutlook.dll", EntryPoint="IPOutlookItemCollection_Add") ]
    private static extern int do_Add(IntPtr self, ref IntPtr rpItem);

    [ DllImport("PocketOutlook.dll", EntryPoint="IPOutlookItemCollection_Item") ]
    private static extern int do_Item(IntPtr self, int iIndex,
      ref IntPtr rpItem);

    [ DllImport("PocketOutlook.dll", EntryPoint="IPOutlookItemCollection_Remove") ]
    private static extern int do_Remove(IntPtr self, int iIndex);

    [ DllImport("PocketOutlook.dll", EntryPoint="IPOutlookItemCollection_Sort") ]
    private static extern int do_Sort(IntPtr self, String zProperty, int bDescending);
        

    [ DllImport("PocketOutlook.dll", EntryPoint="IPOutlookItemCollection_Find") ]
    private static extern int do_Find(IntPtr self, String zRestriction, ref IntPtr rpItem);

    [ DllImport("PocketOutlook.dll", EntryPoint="IPOutlookItemCollection_FindNext") ]
    private static extern int do_FindNext(IntPtr self, ref IntPtr rpItem);

    [ DllImport("PocketOutlook.dll", EntryPoint="IPOutlookItemCollection_Restrict") ]
    private static extern int do_Restrict(IntPtr self, String zRestriction, ref IntPtr rpItemCollection);
  } 
} 
