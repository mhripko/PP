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
    
    public partial class sp_getPlanOverviewDetails_Result
    {
        public string PROJECTNUMBER { get; set; }
        public string PROJECTNAME { get; set; }
        public string PlanStatus { get; set; }
        public long RevisionNumber { get; set; }
        public Nullable<long> NumSheets { get; set; }
        public string BookPage { get; set; }
        public string SheetNum { get; set; }
        public long SubmittalNumber { get; set; }
        public long SubmittalChildNumber { get; set; }
        public long PlanSubmittalID { get; set; }
        public string TrackingCode { get; set; }
        public string Media { get; set; }
        public long ActionID { get; set; }
        public long PCofCID { get; set; }
        public string AssignedTo { get; set; }
        public string CurrentLocation { get; set; }
    }
}
