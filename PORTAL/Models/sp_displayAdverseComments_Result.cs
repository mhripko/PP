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
    
    public partial class sp_displayAdverseComments_Result
    {
        public string ASSETNAME { get; set; }
        public Nullable<long> PROJINSPASSETID { get; set; }
        public Nullable<long> ASSETTYPEID { get; set; }
        public string COMMENTS { get; set; }
        public string ownerType { get; set; }
        public string commentType { get; set; }
        public long COMMENTTYPEID { get; set; }
        public string inspType { get; set; }
        public string StatusType { get; set; }
        public string disposition { get; set; }
        public string ADDED_BY { get; set; }
        public System.DateTime ADDED_DT { get; set; }
    }
}
