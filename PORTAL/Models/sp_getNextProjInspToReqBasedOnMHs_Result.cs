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
    
    public partial class sp_getNextProjInspToReqBasedOnMHs_Result
    {
        public string inspType { get; set; }
        public Nullable<long> INSPECTIONTYPEID { get; set; }
        public Nullable<bool> HOLDING_POINT { get; set; }
        public Nullable<long> ASSET_TYPE_ID { get; set; }
        public string assetType { get; set; }
        public string assetName { get; set; }
        public Nullable<long> PROJINSPTEMPLATEID { get; set; }
        public Nullable<long> PROJECTID { get; set; }
        public Nullable<long> ASSETID { get; set; }
        public Nullable<bool> MANDATORY { get; set; }
        public Nullable<long> DISPLAY_ORDER { get; set; }
        public Nullable<bool> OK_TO_REQ { get; set; }
    }
}
