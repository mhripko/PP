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
    
    public partial class sp_getAllPlanCounts_Result
    {
        public string Reviewer { get; set; }
        public Nullable<int> PLANS_RECEIVED { get; set; }
        public Nullable<int> PLANS_READY_FOR_REVIEW { get; set; }
        public Nullable<int> PLANS_UNDER_REVIEW { get; set; }
        public Nullable<int> PLANS_REVIEW_COMPLETED { get; set; }
        public Nullable<int> PLANS_RECORDING { get; set; }
    }
}
