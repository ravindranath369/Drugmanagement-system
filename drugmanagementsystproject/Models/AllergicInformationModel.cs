using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace drugmanagementsystproject.Models
{
    public class AllergicInformationModel
    {
        public string allergyid { get; set; }
        public string allergyname { get; set; }
        public bool isdrugundertrails { get; set; }
        public bool anyallergyreaction { get; set; }
        public string differentsighnsandsympht { get; set; }
        public string antialergicmedicine { get; set; }

        [Key]
        public int Aid { get; set; }
        public int id { get; set; }

    }
}