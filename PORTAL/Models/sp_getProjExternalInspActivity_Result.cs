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
    
    public partial class sp_getProjExternalInspActivity_Result
    {
        public long ASSET_TYPE_ID { get; set; }
        public long ASSETID { get; set; }
        public bool INSPISACT { get; set; }
        public long INSPECTIONID { get; set; }
        public string inspType { get; set; }
        public long INSPECTIONTYPEID { get; set; }
        public string InspStatus { get; set; }
        public long INSPECTIONSTATUSID { get; set; }
        public string Disp { get; set; }
        public long DISPOSITIONID { get; set; }
        public Nullable<System.DateTime> COMPL_DATE { get; set; }
        public string EVALUATED_BY { get; set; }
        public Nullable<System.DateTime> EVALUATE_START_DT { get; set; }
        public Nullable<System.DateTime> EVALUATE_END_DT { get; set; }
        public string INSPECTORNAME { get; set; }
        public string assetName { get; set; }
        public string UPMHNAME { get; set; }
        public string DNMHNAME { get; set; }
        public bool IS_MULTI_ASSET_INSP { get; set; }
        public string SubAssetName { get; set; }
        public long INSPECTIONREQID { get; set; }
        public System.DateTime REQUESTDATE { get; set; }
    }
}
