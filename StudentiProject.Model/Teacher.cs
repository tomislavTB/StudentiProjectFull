using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using StudentiProject.Models.Attributes;

namespace StudentiProject.Models
{
    public class Teacher : BaseModel
    {

        [CustomRequired]
        public string FirstName { get; set; }

        [CustomRequired]
        public string LastName { get; set; }

        [CustomRequired]
        public string Address { get; set; }

        
        public int CityId { get; set; }
        public City City { get; set; }


        public ICollection<Executor> Executors { get; set; }
    }
}