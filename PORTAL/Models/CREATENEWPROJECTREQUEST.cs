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
    
    public partial class CREATENEWPROJECTREQUEST
    {
        public long CREATENEWPROJECTID { get; set; }
        public string PROJECTNAME { get; set; }
        public string ParcelNumber { get; set; }
        public string ACCELA { get; set; }
        public string NSCROSSSTREETS { get; set; }
        public string EWCROSSSTREETS { get; set; }
        public string DEVELOPER { get; set; }
        public Nullable<long> DEVELOPERPROJECTNUMBER { get; set; }
        public string ENGINEERINGFIRM { get; set; }
        public string CONTRACTOR { get; set; }
        public string PDFFILE { get; set; }
        public string REQUEST_BY { get; set; }
        public System.DateTime REQUEST_DT { get; set; }
        public string STATUS { get; set; }
    }
}
