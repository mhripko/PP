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
    
    public partial class spInsertContact_Result
    {
        public long CONTACTID { get; set; }
        public long CONTACTTYPEID { get; set; }
        public string INTERNALUSERNAME { get; set; }
        public string ContactName { get; set; }
        public string ContactPhone { get; set; }
        public string Extension { get; set; }
        public string EMail { get; set; }
        public Nullable<long> CompanyId { get; set; }
        public bool Is_ACTIVE { get; set; }
        public string ADDED_BY { get; set; }
        public System.DateTime ADDED_DT { get; set; }
        public string UPDATED_BY { get; set; }
        public System.DateTime UPDATED_DT { get; set; }
    }
}