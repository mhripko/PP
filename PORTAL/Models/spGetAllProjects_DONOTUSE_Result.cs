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
    
    public partial class spGetAllProjects_DONOTUSE_Result
    {
        public long PROJECTID { get; set; }
        public bool IS_VALID { get; set; }
        public Nullable<long> PROJYEAR { get; set; }
        public Nullable<long> PROJNUMSEQ { get; set; }
        public string PROJECTNUMBER { get; set; }
        public string PROJECTNAME { get; set; }
        public string FKA { get; set; }
        public long PROJECTSTATUSID { get; set; }
        public Nullable<long> PREV_PROJECTSTATUSID { get; set; }
        public Nullable<long> PROJECTTYPEID { get; set; }
        public Nullable<long> PROJECTCLASSID { get; set; }
        public bool PLANSREQUIRED { get; set; }
        public string NSCROSSSTREETS { get; set; }
        public string EWCROSSSTREETS { get; set; }
        public bool COUNTYPERMITREQ { get; set; }
        public bool COUNTYPERMITAPPROVED { get; set; }
        public bool ILA { get; set; }
        public Nullable<System.DateTime> ILA_APPROVAL_DT { get; set; }
        public bool JOBSTART { get; set; }
        public Nullable<System.DateTime> JOBSTARTDATE { get; set; }
        public Nullable<System.DateTime> BOND_DT { get; set; }
        public Nullable<bool> NA_BOND { get; set; }
        public string BOND_BY { get; set; }
        public Nullable<System.DateTime> ASBUILT_DT { get; set; }
        public Nullable<bool> NA_RECORD { get; set; }
        public string RECORD_BY { get; set; }
        public string FINAL_INSPECTOR { get; set; }
        public Nullable<System.DateTime> FINAL_DT { get; set; }
        public string BOND_REL_INSPECTOR { get; set; }
        public Nullable<System.DateTime> BOND_REL_DT { get; set; }
        public bool OVERSIZE { get; set; }
        public Nullable<decimal> OVERSIZECOST { get; set; }
        public Nullable<System.DateTime> OVERSIZEBOARDAPPROVALDATE { get; set; }
        public string REFUND_NUMBER { get; set; }
        public Nullable<System.DateTime> REFUND_DT { get; set; }
        public string LIFTSTATIONNUM { get; set; }
        public bool MHADJUST { get; set; }
        public string DEVELOPERPROJNUM { get; set; }
        public string PROCTOR { get; set; }
        public bool IS_ACTIVE { get; set; }
        public string ADDED_BY { get; set; }
        public System.DateTime ADDED_DT { get; set; }
        public string UPDATED_BY { get; set; }
        public System.DateTime UPDATED_DT { get; set; }
    }
}
