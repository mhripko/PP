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
    
    public partial class spGetAllInspectionRequests_DONOTUSE_Result
    {
        public long INSPECTIONREQID { get; set; }
        public long REQUESTSTATUSID { get; set; }
        public long PROJECTID { get; set; }
        public System.DateTime REQUESTDATE { get; set; }
        public long CALLERID { get; set; }
        public long FIELDCONTACTID { get; set; }
        public long COMPANYID { get; set; }
        public System.DateTime FROM_DT { get; set; }
        public Nullable<System.DateTime> TO_DT { get; set; }
        public long WORK_SHIFT { get; set; }
        public Nullable<System.TimeSpan> OT_STARTTIME { get; set; }
        public bool IS_ACTIVE { get; set; }
        public string ADDED_BY { get; set; }
        public System.DateTime ADDED_DT { get; set; }
        public string UPDATED_BY { get; set; }
        public System.DateTime UPDATED_DT { get; set; }
    }
}
