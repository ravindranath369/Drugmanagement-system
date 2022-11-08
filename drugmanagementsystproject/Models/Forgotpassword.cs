using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace drugmanagementsystproject.Models
{
    public class Forgotpassword
    {
        [Required(ErrorMessage ="please enter your password")]
        [Display(Name ="Email id")]
        public string Emailid { get; set; }
    }
}