using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestExpoWebAPI.Model
{
    public class GeneralEvaluation
    {
            public long deviceID { get; set; }
            public int rating { get; set; }
            public string comment { get; set; }
            public int questionNumber { get; set; }
            public bool WillAttendAgain { get; set; }
       
    }
}