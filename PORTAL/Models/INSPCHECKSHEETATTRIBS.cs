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
    
    public partial class INSPCHECKSHEETATTRIBS
    {
        public long INSPCSATTRIBID { get; set; }
        public long INSPCSREQID { get; set; }
        public long ATTRIBUTEID { get; set; }
        public Nullable<long> DISPLAYORDER { get; set; }
        public bool IS_ACTIVE { get; set; }
        public string ADDED_BY { get; set; }
        public System.DateTime ADDED_DT { get; set; }
        public string UPDATED_BY { get; set; }
        public System.DateTime UPDATED_DT { get; set; }
    
        public virtual LOOKUP LOOKUP { get; set; }
        public virtual INSPCHECKSHEETTEMPLATE INSPCHECKSHEETTEMPLATE { get; set; }
    }
}
