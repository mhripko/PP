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
    
    public partial class sp_getCorrections_Result
    {
        public Nullable<long> ProjId { get; set; }
        public string ProjNum { get; set; }
        public string ProjName { get; set; }
        public string ownerType { get; set; }
        public string commentType { get; set; }
        public long COMMENTID { get; set; }
        public long COMMENTTYPEID { get; set; }
        public long OWNERTYPEID { get; set; }
        public long RECORDID { get; set; }
        public bool CCWRDINTERNAL { get; set; }
        public string COMMENTS { get; set; }
        public bool IS_ACTIVE { get; set; }
        public string ADDED_BY { get; set; }
        public System.DateTime ADDED_DT { get; set; }
        public string UPDATED_BY { get; set; }
        public System.DateTime UPDATED_DT { get; set; }
    }
}
