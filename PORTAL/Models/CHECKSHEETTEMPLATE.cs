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
    
    public partial class CHECKSHEETTEMPLATE
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CHECKSHEETTEMPLATE()
        {
            this.CHECKSHEET = new HashSet<CHECKSHEET>();
        }
    
        public long CHECKSHEETTEMPLATEID { get; set; }
        public long TEMPLATE_NUM { get; set; }
        public bool IS_CATEGORY { get; set; }
        public bool IS_OPTIONAL { get; set; }
        public long CATEGORY { get; set; }
        public string DESCRIPTION { get; set; }
        public long DESCR_ORDER { get; set; }
        public bool IS_ACTIVE { get; set; }
        public string ADDED_BY { get; set; }
        public System.DateTime ADDED_DT { get; set; }
        public string UPDATED_BY { get; set; }
        public System.DateTime UPDATED_DT { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CHECKSHEET> CHECKSHEET { get; set; }
    }
}