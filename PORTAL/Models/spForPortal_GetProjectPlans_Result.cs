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
    
    public partial class spForPortal_GetProjectPlans_Result
    {
        public long PROJECTID { get; set; }
        public string PROJECTNAME { get; set; }
        public string PROJECTNUMBER { get; set; }
        public long PlanSubmittalID { get; set; }
        public string Media { get; set; }
        public long PlanRevisionNumber { get; set; }
        public long SubmittalNumber { get; set; }
        public long SubmittalChildNumber { get; set; }
        public System.DateTime Received_DT { get; set; }
        public string PlanReviewStatus { get; set; }
        public string DISPOSITION { get; set; }
        public Nullable<System.DateTime> TargetDate { get; set; }
        public Nullable<bool> PDISACTIVE { get; set; }
        public string NW_PATH { get; set; }
        public string FILE_DESCRIPTION { get; set; }
        public Nullable<long> FILE_LENGTH { get; set; }
        public string FILE_LOCATION { get; set; }
        public string FILE_NAME { get; set; }
    }
}
