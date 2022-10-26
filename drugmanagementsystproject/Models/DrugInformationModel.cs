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
        [Required]
        public string drugid { get; set; }

        [Required]
        public string drugshortname { get; set; }

        public string druglongname { get; set; }
        public string allergiesmaycauseonusage { get; set; }
    }
}