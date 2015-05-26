using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace School.Models
{
    public class LearnersViewModel
    {
        public int LearnerID { get; set; }
        public int ClassID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public bool Presence { get; set; }
    }

    public class LearnerMarksViewModel
    {
        public int LearnerID { get; set; }
        public int ClassID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Mark { get; set; }
    }

    public class LearnerListViewModel
    {
        public List<LearnersViewModel> Learners { get; set; }
    }
}