﻿#region Using directives

using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

#endregion

namespace SharpMT
{
  public class ListViewItemStringComparer : System.Collections.IComparer
  {
    private int nCol = 0;
    private bool bAscending = true;
		public ListViewItemStringComparer() {
      nCol = 0;
		}

    public ListViewItemStringComparer(bool b) {
      nCol = 0;
      bAscending = b;
    }

    public int Compare(object x, object y) {
      if (bAscending)
        return String.Compare(((ListViewItem)x).SubItems[nCol].Text, ((ListViewItem)y).SubItems[nCol].Text);
      else
        return String.Compare(((ListViewItem)y).SubItems[nCol].Text, ((ListViewItem)x).SubItems[nCol].Text);
    }
	}

  public class ListViewItemIntComparer : System.Collections.IComparer
  {
    private int nCol = 1;
    private bool bAscending = true;
    public ListViewItemIntComparer() {
      nCol = 1;
    }

    public ListViewItemIntComparer(bool b) {
      nCol = 1;
      bAscending = b;
    }

    public int Compare(object x, object y) {
      int nX = Convert.ToInt32(((ListViewItem)x).SubItems[nCol].Text);
      int nY = Convert.ToInt32(((ListViewItem)y).SubItems[nCol].Text);
      if (bAscending)
        return (nX.CompareTo(nY));
      else
        return (nY.CompareTo(nX));
    }
  }
}
