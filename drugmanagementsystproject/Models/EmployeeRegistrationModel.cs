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
        [Required(ErrorMessage ="please enter employee name")]
        [Display(Name ="Employee name")]
        [RegularExpression(@"[A-Za-z]{3,22}", ErrorMessage = "should contain minimum 3 letters")]
        public string employeename { get; set; }

        [Required(ErrorMessage = "DOB is Required")]
        [DataType(DataType.Date)]
       // [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/mm//yyyy}")]
        public DateTime dob { get; set; }

        [Required(ErrorMessage = "please enter phone number number")]
        [Display(Name ="phone number")]
        [RegularExpression(@"[0-9]{3,10}", ErrorMessage = "Not a Valid Number.")]
        public string phonenumber { get; set; }

        [Required(ErrorMessage = "email is required")]
        [Display(Name = "email id")]
        public string emailid { get; set; }

        [Required(ErrorMessage = "Please enter your gender")]
        //[RegularExpression(@"[male,female,MALE,FEMALE]", ErrorMessage = "should be male or female")]
        public string gender { get; set; }

        [Required(ErrorMessage = "please eneter your department"),MaxLength(20)]
        [RegularExpression(@"[A-Za-z]{1,32}", ErrorMessage = "please enter valid department")]
        public string department { get; set; }

        [Required(ErrorMessage = "please eneter your designation"), MaxLength(20)]
        [RegularExpression(@"[A-Za-z]{1,32}", ErrorMessage = "please enter valid designation")]
        public string designation { get; set; }

        [Required(ErrorMessage ="please enter username")]

        public string username { get; set; }

        [Required(ErrorMessage = "password is required")]
        [DataType(DataType.Password)]
        public string password { get; set; }

        [Required(ErrorMessage = "confirm password id required")]
        [Compare("password",ErrorMessage ="passwords are not matching")]
        [DataType(DataType.Password)]
        public string confirmpassword { get; set; }
        public bool delete { get; set; }
       
        public bool Employee { get; set; }
        public bool resetcode { get; set; }
    }

}