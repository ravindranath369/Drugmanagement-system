using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace drugmanagementsystproject.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage ="email is required")]
        public string email { get; set; }
        [Required(ErrorMessage ="password is required")]
        [DataType(DataType.Password)]
        public string password { get; set; }
    }
}