using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PORTAL.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class PartnerCompanyViewModel
    {
        [Editable(false)]
        public long COMPANYID { get; set; }

        [Required]
        [Display(Name = "Company Name")]
        public string COMPANYNAME { get; set; }
        [Display(Name = "Company Type")]
        public long COMPANYTYPEID { get; set; }
        [Display(Name = "Address")]
        public string ADDRESS { get; set; }
        [Display(Name = "Address2")]
        public string ADDRESS2 { get; set; }
        [Display(Name = "City")]
        public string CITY { get; set; }
        [Display(Name = "State")]
        public string STATE { get; set; }
        
        public Nullable<long> ZIP { get; set; }
        public Nullable<long> ZIP2 { get; set; }
        [Display(Name = "Phone")]
        public string TELEPHONE { get; set; }
        [Display(Name = "Extension")]
        public string EXTENSION { get; set; }
        public string FAX { get; set; }
        [Display(Name = "EMail")]
        public string EMAIL { get; set; }
        public bool IS_ACTIVE { get; set; }
        public string ADDED_BY { get; set; }
        public System.DateTime ADDED_DT { get; set; }
        public string UPDATED_BY { get; set; }
        public System.DateTime UPDATED_DT { get; set; }
        public string CONTACTNAME { get; set; }
        public Nullable<bool> IS_BPPORTALADMIN { get; set; }
    }

    /// <summary>
    /// ContactUserViewModel is the model used when Editing a linked Contact -to- Asp.Net.User account or when creating a
    /// new Contact and User record(s) for Pipes Portal Access.
    /// </summary>
    public class ContactUserViewModel
    {
        public long CONTACTID { get; set; }
        public long CONTACTTYPEID { get; set; }
        public string INTERNALUSERNAME { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        public string CONTACTNAME { get; set; }
        public string CONTACTPHONE { get; set; }
        public string EXTENSION { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string EMAIL { get; set; }
        public Nullable<long> COMPANYID { get; set; }
        public bool IS_ACTIVE { get; set; }
        public string ADDED_BY { get; set; }
        public System.DateTime ADDED_DT { get; set; }
        public string UPDATED_BY { get; set; }
        public System.DateTime UPDATED_DT { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PROJCONTACTS> PROJCONTACTS { get; set; }
    }

}