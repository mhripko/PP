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
    using System.Collections.Generic;
    
    public partial class PROJINSPTEMPLATE
    {
        public long PROJINSPTEMPLATEID { get; set; }
        public long PROJECTID { get; set; }
        public long ASSETID { get; set; }
        public long INSPECTIONTYPEID { get; set; }
        public bool INSP_NOT_REQUIRED { get; set; }
        public bool MANDATORY { get; set; }
        public long DISPLAY_ORDER { get; set; }
        public bool OK_TO_REQ { get; set; }
        public bool HOLDING_POINT_ACTIVE { get; set; }
        public bool IS_ACTIVE { get; set; }
        public string ADDED_BY { get; set; }
        public System.DateTime ADDED_DT { get; set; }
        public string UPDATED_BY { get; set; }
        public System.DateTime UPDATED_DT { get; set; }
    
        public virtual LOOKUP LOOKUP { get; set; }
        public virtual PROJECTS PROJECTS { get; set; }
    }
}