using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace drugmanagementsystproject.Models
{
    public class IndivisualTrailsInfoModel
    {
        [Required(ErrorMessage = "please enter indivisualid")]
        [Display(Name ="individual id")]
        public string indivisualid { get; set; }
        [Required(ErrorMessage = "please enter indivisual name")]
        [Display(Name = "individual name")]
        [RegularExpression(@"[a-zA-Z]{3,20}", ErrorMessage = "name should contain minimum of 3 letters")]
        public string indivisualname { get; set; }
        [Required(ErrorMessage = "please enter individual adress")]
        [Display(Name = "individual adress")]
        public string indivisualadress { get; set; }
        [Required(ErrorMessage = "please enter phone number")]
        [Display(Name = "phone number")]
        [RegularExpression(@"[0-9]{1,10}",ErrorMessage ="phone number should be in digits format")]
        public string phonennumber { get; set; }
        [Required(ErrorMessage = "please enter emergency contact")]
        [Display(Name = "emergency contact number")]
        [RegularExpression(@"[0-9]{1,10}", ErrorMessage = "phone number should be in digits format")]
        public string emergencycontactnumber { get; set; }
        public int id { get; set; }
        [Required(ErrorMessage ="Please enter email id")]
        public string Emailid { get; set; }
        [Required(ErrorMessage ="please enter password")]
        [DataType(DataType.Password)]
        public string password { get; set; }
    }
}
