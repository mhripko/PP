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
    
    public partial class SSMANHOLE
    {
        public int objectid { get; set; }
        public string mhno { get; set; }
        public string status { get; set; }
        public Nullable<System.DateTime> updatedate { get; set; }
        public Nullable<System.DateTime> constructiondate { get; set; }
        public Nullable<System.DateTime> finaldate { get; set; }
        public string source { get; set; }
        public Nullable<decimal> accessdiameter { get; set; }
        public string accesstype { get; set; }
        public Nullable<decimal> mhdiameter { get; set; }
    }
}
