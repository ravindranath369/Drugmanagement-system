using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace drugmanagementsystproject.Models
{
    public class DrugTrailHistoryModel
    {
        public int id { get; set; }
        public string drugtrailhistid { get; set; }
        public string drugname { get; set; }
        public int numberofpartispants { get; set; }
        public int numberofpeoplewithsideeffects { get; set; }
        public int numberofpeoplewithNoeffects { get; set; }
        public int sucesspercentageoftrails { get; set; }
        public string comments { get; set; }
        public string finalresultofdrug { get; set; }
    }
}