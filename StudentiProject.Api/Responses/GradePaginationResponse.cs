using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using StudentiProject.Models.Attributes;

namespace StudentiProject.Responses
{
    public class GradeResponse
    {

        public long Id { get; set; }
        public string ExamTime { get; set; }

        public int Evaluation { get; set; }


    }
}