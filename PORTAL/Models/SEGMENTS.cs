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
    
    public partial class SEGMENTS
    {
        public long SEGMENTID { get; set; }
        public long PROJECTID { get; set; }
        public long UPMHID { get; set; }
        public long DNMHID { get; set; }
        public long SIZEID { get; set; }
        public long TYPEID { get; set; }
        public long INVNUM { get; set; }
        public string PAGES { get; set; }
        public bool IS_ACTIVE { get; set; }
        public Nullable<bool> ACCEPTED { get; set; }
        public string ACCEPTED_BY { get; set; }
        public Nullable<System.DateTime> ACCEPTED_DT { get; set; }
        public string ADDED_BY { get; set; }
        public System.DateTime ADDED_DT { get; set; }
        public string UPDATED_BY { get; set; }
        public System.DateTime UPDATED_DT { get; set; }
    
        public virtual LOOKUP LOOKUP { get; set; }
        public virtual LOOKUP LOOKUP1 { get; set; }
        public virtual PROJECTS PROJECTS { get; set; }
    }
}