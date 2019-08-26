using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using StudentiProject.Models.Attributes;

namespace StudentiProject.Models
{
    public class Executor : BaseModel
    {

        [CustomRequired]
        public string Description { get; set; }


        public int CourseId { get; set; }
        public Course Course { get; set; }


        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; }

    }
}