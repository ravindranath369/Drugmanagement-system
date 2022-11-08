using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace drugmanagementsystproject.Models
{
    public class AllergicInformationModel
    {
        [Required(ErrorMessage ="please enter allergy id")]
        [Display(Name ="allergy id")]
        public string allergyid { get; set; }

        [Required(ErrorMessage = "please Enter allergyname")]
        [Display(Name = "allergy name")]
        public string allergyname { get; set; }
       
        [Required]
        [Display(Name = "Is drug under trails")]
        public bool isdrugundertrails { get; set; }

        [Required]
        [Display(Name = "Is there any allergic reaction")]
        public bool anyallergyreaction { get; set; }

        [Required(ErrorMessage ="please enter signns and symphtoms")]
        [Display(Name ="sighns & symphtoms on usage")]
        [RegularExpression(@"[A-Za-z]{3,22}", ErrorMessage = "Not a Valid")]
        public string differentsighnsandsympht { get; set; }

        [Required(ErrorMessage = "enter the anti allergy medicine")]
        [Display(Name ="Anti allergy medicine")]
        public string antialergicmedicine { get; set; }

        public int Aid { get; set; }
    }
}