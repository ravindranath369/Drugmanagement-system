using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace drugmanagementsystproject.Models
{
    public class DrugTrailInfoModel
    {
        public string trailid { get; set; }
        public DateTime trailstartdate { get; set; }
        public DateTime trailenddate { get; set; }
        public string test1result { get; set; }
        public string test2result { get; set; }
        public string finalresult { get; set; }
        public string purposeoftrail { get; set; }
        public int id { get; set; }

        //[key]
        public int dtinfoid { get; set; }
    }
}