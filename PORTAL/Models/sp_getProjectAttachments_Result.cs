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
    
    public partial class sp_getProjectAttachments_Result
    {
        public Nullable<long> Row { get; set; }
        public long UPLOADEDDOCID { get; set; }
        public string FILE_DESCRIPTION { get; set; }
        public string FILE_LOCATION { get; set; }
        public string FILE_NAME { get; set; }
        public string NW_PATH { get; set; }
        public long ATTACHMENTID { get; set; }
        public long ownertypeid { get; set; }
        public long recordid { get; set; }
        public string Asset { get; set; }
        public string OwnerName { get; set; }
        public string OwnerTypeValue { get; set; }
        public string OwnerTypeDesc { get; set; }
        public string ADDED_BY { get; set; }
        public System.DateTime ADDED_DT { get; set; }
        public string UPDATED_BY { get; set; }
        public System.DateTime UPDATED_DT { get; set; }
    }
}