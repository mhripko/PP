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
    
    public partial class spGetAllCompanies_Result
    {
        public string COMPANYTYPE { get; set; }
        public long COMPANYID { get; set; }
        public string COMPANYNAME { get; set; }
        public long COMPANYTYPEID { get; set; }
        public string ADDRESS { get; set; }
        public string ADDRESS2 { get; set; }
        public string CITY { get; set; }
        public string STATE { get; set; }
        public Nullable<long> ZIP { get; set; }
        public Nullable<long> ZIP2 { get; set; }
        public string TELEPHONE { get; set; }
        public string EXTENSION { get; set; }
        public string FAX { get; set; }
        public string EMAIL { get; set; }
        public bool IS_ACTIVE { get; set; }
        public string ADDED_BY { get; set; }
        public System.DateTime ADDED_DT { get; set; }
        public string UPDATED_BY { get; set; }
        public System.DateTime UPDATED_DT { get; set; }
        public string CONTACTNAME { get; set; }
    }
}