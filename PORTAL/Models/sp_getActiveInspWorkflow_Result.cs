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
    
    public partial class sp_getActiveInspWorkflow_Result
    {
        public string inspectiontype { get; set; }
        public string assetType { get; set; }
        public long INSPWORKFLOWSID { get; set; }
        public long INSPWORKFLOW_NUM { get; set; }
        public long INSPECTIONTYPEID { get; set; }
        public Nullable<long> TEMPLATE_NUM { get; set; }
        public bool REQUIRES_EVALUATION { get; set; }
        public bool MANDATORY { get; set; }
        public Nullable<bool> OPTIONAL { get; set; }
        public bool HOLDING_POINT { get; set; }
        public bool MULTIASSET { get; set; }
        public long ASSET_TYPE_ID { get; set; }
        public int DISPLAY_ORDER { get; set; }
        public bool IS_ACTIVE { get; set; }
        public string ADDED_BY { get; set; }
        public System.DateTime ADDED_DT { get; set; }
        public string UPDATED_BY { get; set; }
        public System.DateTime UPDATED_DT { get; set; }
    }
}