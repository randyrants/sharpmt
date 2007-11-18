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
 * File: Item.class
 *
 * Purpose: Abstract superclass of the Pocket Outlook Items
 * (Appointments, Contacts, Tasks)
 *
 *
 * Notes: 
 *      This is a wrapper around an ItemCollection
 *
 */

using System;
using System.Runtime.InteropServices;

namespace Pocket_SharpMT {
  public abstract class PO_OutlookItem {
    private PocketOutlookControl m_poCtrl;
    private IntPtr m_pIItem;

    public enum ItemType {
      AppointmentItem = 1,
      ContactItem = 2,
      TaskItem = 3,
      CityItem = 102
    }

    protected PO_OutlookItem(PocketOutlookControl poCtrl, ref IntPtr pIItem) {
      m_poCtrl = poCtrl;
      m_pIItem = pIItem;
    }

    public PocketOutlookControl PocketOutlookControl {
      get {
        return m_poCtrl;
      }
    }

    /*
         * Access to this object's raw data.
         */
    protected IntPtr RawItemPtr {
      get {
        return m_pIItem;
      }
    }

    public void Save() {
      this.doSave();
    }
		
    public void Delete() {
      this.doDelete();
    }
        
    public PO_OutlookItem Copy() {
      return this.doCopy();
    }

    protected abstract void doSave();
    protected abstract void doDelete();
    protected abstract PO_OutlookItem doCopy();
  } 
}
