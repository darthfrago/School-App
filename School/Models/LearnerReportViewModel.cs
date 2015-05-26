using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace School.Models
{
    public class MarksReportViewModel
    {
        public string Subject { get; set; }
        public string Marks { get; set; }
        public string Description { get; set; }
    }

    public class ConcernsReportViewModel
    {
        public DateTime Date { get; set; }
        public string Teacher { get; set; }
        public string Message { get; set; }
    }

    public class LearnerReportViewModel
    {
        public string Learner { get; set; }
        public List<MarksReportViewModel> Marks { get; set; }
        public List<ConcernsReportViewModel> Concerns { get; set; }
    }
}