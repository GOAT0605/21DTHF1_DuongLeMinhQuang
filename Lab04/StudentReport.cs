using Lab04.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab04
{
    public class StudentReport
    {
        public string StudentID { get; set; }

        public string Name { get; set; }

        public double AverageScore { get; set; }
        public string FacultyName { get; set; }

    }
}
