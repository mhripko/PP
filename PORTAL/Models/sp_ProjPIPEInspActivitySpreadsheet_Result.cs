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
    
    public partial class sp_ProjPIPEInspActivitySpreadsheet_Result
    {
        public Nullable<long> itid { get; set; }
        public string Description { get; set; }
        public Nullable<long> @do { get; set; }
        public Nullable<long> atid { get; set; }
        public Nullable<bool> ooo { get; set; }
        public Nullable<long> ASSETID { get; set; }
        public string ASSETNAME { get; set; }
        public string UPMHNAME { get; set; }
        public string DNMHNAME { get; set; }
        public Nullable<long> INSPECTIONID { get; set; }
        public Nullable<bool> IS_NOT_REQ { get; set; }
        public Nullable<long> INSPECTIONSTATUSID { get; set; }
        public string inspStatus { get; set; }
        public Nullable<System.DateTime> COMPL_DATE { get; set; }
        public Nullable<long> DISPOSITIONID { get; set; }
        public string inspDisp { get; set; }
        public string INSPECTORNAME { get; set; }
    }
}