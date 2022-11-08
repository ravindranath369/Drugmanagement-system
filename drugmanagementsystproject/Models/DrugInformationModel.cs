using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace drugmanagementsystproject.Models
{
    public class DrugInformationModel
    {
        [Key]
        public int id { get; set; }

        [Required(ErrorMessage ="please enter drugid")]
        [Display(Name ="drug id")]
        public string drugid { get; set; }

        [Required(ErrorMessage ="please enter drugname")]
        [Display(Name ="drug short name")]
        public string drugshortname { get; set; }
        [Required(ErrorMessage ="please enter drugname")]
        [Display(Name ="drug long name")]
        public string druglongname { get; set; }
        [Required(ErrorMessage = "please enter allergies may cause on usage")]
        [Display(Name ="allergies may cause on usage")]
        [RegularExpression(@"[A-Za-z]{1,32}", ErrorMessage = "please enter valid data")]
        public string allergiesmaycauseonusage { get; set; }
    }
}