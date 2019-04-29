using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PORTAL.Models
{
    /// <summary>
    /// RegisterViewModel is called to help the Register page visualization.
    /// </summary>
    public class POCRequestViewModel
    {
        [Required]
        [Display(Name = "Description")]
        public string PROJECTDESC { get; set; }

        [Required]
        [StringLength(14, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 11)]
        [Display(Name = "Parcel Number")]
        public string ParcelNumber { get; set; }

        [Required]
        [Display(Name = "ERU")]
        public double ERU { get; set; }

        [Required]
        [Display(Name = "QAVG")]
        public double QAVG { get; set; }
        

    }

    public class ProjectRequestViewModel
    {
        [Required]
        [Display(Name = "Name")]
        public string ProjectName { get; set; }

        [Required]
        [StringLength(14, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 11)]
        [Display(Name = "Parcel Number")]
        public string ParcelNumber { get; set; }

        [Required]
        [Display(Name = "ACCELA")]
        public string ACCELA { get; set; }

        [Required]
        [Display(Name = "NS Cross Streets")]
        public string NSCROSSSTREETS { get; set; }

        [Required]
        [Display(Name = "EW Cross Streets")]
        public string EWCROSSSTREETS { get; set; }

        [Required]
        [Display(Name = "Developer")]
        public string DEVELOPER { get; set; }

        [Required]
        [Display(Name = "Dev Proj Number")]
        public double DEVELOPERPROJECTNUMBER { get; set; }

        [Required]
        [Display(Name = "Engineering Firm")]
        public string ENGINEERINGFIRM { get; set; }

        [Required]
        [Display(Name = "Contractor")]
        public string CONTRACTOR { get; set; }
    }

    public class PlanReviewRequestViewModel
    {
        [Required]
        [Display(Name = "Project Number")]
        public string ProjectNumber { get; set; }

        [Required]
        [Display(Name = "Project Name")]
        public string ProjectName { get; set; }

        [Required]
        [Display(Name = "PDF File")]
        public string PDFFILE { get; set; }
    }

}