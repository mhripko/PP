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
    
    public partial class sp_getProjInspByType_Result
    {
        public string COMMENTS { get; set; }
        public long INSPECTIONID { get; set; }
        public bool IS_OOOINSP { get; set; }
        public long INSPECTIONSTATUSID { get; set; }
        public long INSPECTIONREQID { get; set; }
        public long INSPECTORID { get; set; }
        public long INSPECTIONTYPEID { get; set; }
        public long ASSETID { get; set; }
        public Nullable<System.DateTime> SCHED_DATE { get; set; }
        public Nullable<System.DateTime> COMPL_DATE { get; set; }
        public long DISPOSITIONID { get; set; }
        public bool IS_NOT_REQ { get; set; }
        public string EVALUATED_BY { get; set; }
        public Nullable<System.DateTime> EVALUATE_START_DT { get; set; }
        public Nullable<System.DateTime> EVALUATE_END_DT { get; set; }
        public Nullable<System.DateTime> EMAIL_SENT { get; set; }
        public Nullable<long> EMAILID { get; set; }
        public bool IS_ACTIVE { get; set; }
        public string ADDED_BY { get; set; }
        public System.DateTime ADDED_DT { get; set; }
        public string UPDATED_BY { get; set; }
        public System.DateTime UPDATED_DT { get; set; }
        public string InspectionStatus { get; set; }
        public string InspectionType { get; set; }
        public string Disposition { get; set; }
        public string INSPECTORNAME { get; set; }
        public string asset { get; set; }
        public Nullable<bool> IS_MULTI { get; set; }
        public string subasset { get; set; }
        public long projectid { get; set; }
        public string projectnumber { get; set; }
        public string projectname { get; set; }
    }
}
