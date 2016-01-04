using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestExpoWebAPI.Model
{
    public class Evaluation
    {
            public long deviceID { get; set; }
            public int rating { get; set; }
            public string comment { get; set; }
            public int speakerId { get; set; }
            public int presentationId { get; set; }
       
    }
}