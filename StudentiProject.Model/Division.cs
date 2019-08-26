using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using StudentiProject.Models.Attributes;

namespace StudentiProject.Models
{
    public class Division : BaseModel
    {

        [CustomRequired]
        public string Name { get; set; }


        public int  CollegeId { get; set; }
        public College College { get; set; }

    }
}