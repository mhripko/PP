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
    
    public partial class sp_getProjectInspectionsOverview_Result
    {
        public string ProjectInspectionStatus { get; set; }
        public Nullable<long> JSInspID { get; set; }
        public string PIIJSStatus { get; set; }
        public string PIIJSDisp { get; set; }
        public string QARStatus { get; set; }
        public Nullable<long> FInspID { get; set; }
        public string PIIFStatus { get; set; }
        public string PIIFDisp { get; set; }
        public Nullable<long> BRInspID { get; set; }
        public string PIIBRStatus { get; set; }
        public string PIIBRDisp { get; set; }
        public string PROJECTNAME { get; set; }
        public long PROJINSPINFOID { get; set; }
        public long PROJECTID { get; set; }
        public bool ASSETS_ACCEPTED { get; set; }
        public bool PLANS_APPROVED { get; set; }
        public Nullable<long> INSPWORKFLOW_NUM { get; set; }
        public long INSPWORKFLOW_STATUSID { get; set; }
        public string INSPWORKFLOW_CREATOR { get; set; }
        public Nullable<System.DateTime> INSPWORKFLOW_CREATE_DT { get; set; }
        public string INSPWORKFLOW_APPROVER { get; set; }
        public Nullable<System.DateTime> INSPWORKFLOW_APPROVED_DT { get; set; }
        public Nullable<long> PROJINSPSTATUS { get; set; }
        public long JOBSTART_STATUSID { get; set; }
        public Nullable<long> JOBSTART_DISPID { get; set; }
        public Nullable<System.DateTime> JOBSTART_DT { get; set; }
        public string JOBSTART_INSPECTOR { get; set; }
        public long QAREVIEW_STATUSID { get; set; }
        public Nullable<long> QAREVIEW_DISPID { get; set; }
        public Nullable<System.DateTime> QAREVIEW_DT { get; set; }
        public string QAREVIEW_ENGINEER { get; set; }
        public long FINALINSP_STATUSID { get; set; }
        public Nullable<long> FINALINSP_DISPID { get; set; }
        public Nullable<System.DateTime> FINALINSP_DT { get; set; }
        public string FINALINSP_INSPECTOR { get; set; }
        public long BONDRELINSP_STATUSID { get; set; }
        public Nullable<long> BONDRELINSP_DISPID { get; set; }
        public Nullable<System.DateTime> BONDRELINSP_DT { get; set; }
        public string BONDRELINSP_INSPECTOR { get; set; }
        public bool IS_ACTIVE { get; set; }
        public string ADDED_BY { get; set; }
        public System.DateTime ADDED_DT { get; set; }
        public string UPDATED_BY { get; set; }
        public System.DateTime UPDATED_DT { get; set; }
    }
}