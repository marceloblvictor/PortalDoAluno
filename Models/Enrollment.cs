using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PortalDoAluno.Models
{
    public class Enrollment
    {
        public int ID { get; set; }

        public int StudentID { get; set; }

        public int CourseID { get; set; }

        [Range(0, 10)]
        public double? FirstExam { get; set; }

        [Range(0, 10)]
        public double? SecondExam { get; set; }

        [Range(0, 10)]
        public double? FinalExam { get; set; }

        public double? CalculateAverage() => FirstExam * 4.0 + SecondExam * 6.0;

        
    }
}
