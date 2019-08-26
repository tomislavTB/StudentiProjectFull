using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using StudentiProject.Models.Attributes;

namespace StudentiProject.Models
{
    public class Course : BaseModel
    {

        [CustomRequired]
        public string Name { get; set; }


        public string Description { get; set; }

        public int DivisionId { get; set; }
        public Division Division { get; set; }


        public ICollection<Executor> Executors { get; set; }
        public ICollection<Grade> Grades { get; set; }
    }
}
