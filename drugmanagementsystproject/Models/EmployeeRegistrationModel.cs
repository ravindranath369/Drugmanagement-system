using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace drugmanagementsystproject.Models
{
    public class EmployeeRegistrationModel
    {
        [Key]
        public int employeeid { get; set; }
        [Required]
        public string employeename { get; set; }

        [Required(ErrorMessage = "DOB is Required")]
        [DataType(DataType.Date)]
        public DateTime dob { get; set; }

        [Required(ErrorMessage = "please enter valid number")]
        [RegularExpression(@"[0-9]{10}", ErrorMessage = "Not a Valid Number.")]
        public string phonenumber { get; set; }

        [Required(ErrorMessage = "email is required")]
        public string emailid { get; set; }
        public string gender { get; set; }

        [Required(ErrorMessage = "please eneter your department"),MaxLength(20)]
        [RegularExpression(@"[A-Za-z]{1,32}", ErrorMessage = "Not a Valid Department")]
        public string department { get; set; }

        [Required(ErrorMessage = "please eneter your designation"), MaxLength(20)]
        [RegularExpression(@"[A-Za-z]{1,32}", ErrorMessage = "Not a Valid designation")]
        public string designation { get; set; }

        public string username { get; set; }

        [Required(ErrorMessage = "password is required")]
        [RegularExpression(@"[A-Za-z]{8}", ErrorMessage = "Not a Valid Number.")]
        public string password { get; set; }

        [Required(ErrorMessage = "please insert password")]
        //[RegularExpression(@"[0-9]{1}[a-z]{8}", ErrorMessage = "Not a Valid Number.")]
        [RegularExpression(@"[A-Za-z]{8}", ErrorMessage = "Not a Valid Number.")]
        public string confirmpassword { get; set; }
        public bool delete { get; set; }
    }

}