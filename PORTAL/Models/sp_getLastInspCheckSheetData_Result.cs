//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PORTAL.Models
{
    using System;
    
    public partial class sp_getLastInspCheckSheetData_Result
    {
        public Nullable<long> TEMPLATE_NUM { get; set; }
        public Nullable<long> DESCR_ORDER { get; set; }
        public string DESCRIPTION { get; set; }
        public Nullable<bool> DISPLAY_TO_LEFT { get; set; }
        public Nullable<bool> MULTICHOICE_REQ { get; set; }
        public string reqResult { get; set; }
        public Nullable<long> COMMENTID { get; set; }
        public Nullable<long> RECORDID { get; set; }
        public string COMMENTS { get; set; }
        public long INSPECTIONID { get; set; }
        public bool IS_ACTIVE { get; set; }
    }
}
