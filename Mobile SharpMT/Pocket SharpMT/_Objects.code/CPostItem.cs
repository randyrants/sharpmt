using System;

namespace SharpMTClasses {
  /// <summary>
  /// Summary description for CPostItem.
  /// </summary>
  public class CPostItem {
    public string strTitle;
    public string strEntry;
    public string strExtended;
    public string strExcerpt;
    public System.Collections.ArrayList a_strCategory;
    public string strPostStatus;
    public string strTextFormatting;
    public string strAllowComments;
    public string strAllowPings;
    public string strKeyword;
    public string strPings;
    public bool bPosted;
    public string strDateTime;
    
    public CPostItem() {
      strTitle = "";
      strEntry = "";
      strExtended = "";
      strExcerpt = "";
      a_strCategory = new System.Collections.ArrayList();
      strPostStatus = "";
      strTextFormatting = "";
      strAllowComments = "";
      strAllowPings = "";
      strKeyword = "";
      strPings = "";
      bPosted = false;
      strDateTime = "";
    }

    public void EncodeHTML() {
      strTitle = ConvertHack(strTitle);
      strEntry = ConvertHack(strEntry);
      strExtended = ConvertHack(strExtended);
      strExcerpt = ConvertHack(strExcerpt);
      strKeyword = ConvertHack(strKeyword);
    }

    private string ConvertHack(string strIn) {
      int chEncoded;
      string strOut = ""; 
      foreach (char c in strIn) {
        chEncoded = c;
        if (!((chEncoded >= 160) && (chEncoded < 256))) {  // if in 'ascii' range - *THINK* this works....
          switch (chEncoded) {
            case 8211:
            case 8212:
            case 8213:
            case 8216:
            case 8217:
            case 8220:
            case 8221:
              // convert to entity format ?
              strOut += string.Format("&#{0};", chEncoded);
              break;
            default:
              // if in 'ascii' range - *THINK* this works....
              strOut += c; // leave as-is
              break;
          }
        } 
        else { // convert to entity format ?
          strOut += string.Format("&#{0};", chEncoded);
        }
      }
      return strOut;
    }
  }
}
