using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace drugmanagementsystproject.Models
{
    public class DrugTrailHistoryModel
    {
        [Key]
        public int id { get; set; }
        [Required(ErrorMessage = "please enter id")]
        [Display(Name ="drug trail history id")]
        public string drugtrailhistid { get; set; }
        [Required(ErrorMessage = "please enter drugname")]
        [Display(Name = "drug trail history id")]
        public string drugname { get; set; }
        [Required(ErrorMessage = "please enter number of partispants")]
        [Display(Name ="Number of partispants")]
        public int numberofpartispants { get; set; }
        [Required(ErrorMessage = "please enter number of people with side efffects")]
        [Display(Name ="Number of people with side effects")]
        public int numberofpeoplewithsideeffects { get; set; }

        [Required(ErrorMessage = "please enter number of people with no effects")]
        [Display(Name ="Number of people with no effects")]
        public int numberofpeoplewithNoeffects { get; set; }
        [Required(ErrorMessage = "please enter sucess rate")]
        [Display(Name ="Sucess rate of trail")]
        public int sucesspercentageoftrails { get; set; }
        [Required(ErrorMessage ="please enetercomments")]
        public string comments { get; set; }
        [Required(ErrorMessage ="please enter final result")]
        [Display(Name ="What is the final result of drug")]
        [RegularExpression(@"[A-Za-z]{1,32}", ErrorMessage = "result should be in the text format")]
        public string finalresultofdrug { get; set; }
    }
}