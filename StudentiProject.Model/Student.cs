using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using StudentiProject.Models.Attributes;

namespace StudentiProject.Models
{
    public class Student : BaseModel
    {

        [CustomRequired]
        public string FirstName { get; set; }

        [CustomRequired]
        public string LastName { get; set; }


        public int CityId { get; set; }
        public City City { get; set; }
        public int  DivisionId { get; set; }
        public Division Division { get; set; }

        public ICollection<Grade> Grades { get; set; }
    }
}