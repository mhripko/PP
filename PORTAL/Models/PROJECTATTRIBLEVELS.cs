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
    
    public partial class PROJECTATTRIBLEVELS
    {
        public long PROJATTRIBLEVELID { get; set; }
        public long LEVELID { get; set; }
        public long ATTRIBUTEID { get; set; }
        public bool IS_ACTIVE { get; set; }
        public Nullable<long> PARENTID { get; set; }
        public string ADDED_BY { get; set; }
        public System.DateTime ADDED_DT { get; set; }
        public string UPDATED_BY { get; set; }
        public System.DateTime UPDATED_DT { get; set; }
    
        public virtual LOOKUP LOOKUP { get; set; }
        public virtual LOOKUP LOOKUP1 { get; set; }
    }
}
