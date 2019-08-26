using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using StudentiProject.Models.Attributes;

namespace StudentiProject.Models
{
    public class Grade : BaseModel
    {


        [CustomRequired]
        public string ExamTime { get; set; }

        [CustomRequired]
        public int Evaluation { get; set; }


        public int CourseId { get; set; }
        public Course Course { get; set; }


        public int StudentId { get; set; }
        public Student Student { get; set; }

    }
}