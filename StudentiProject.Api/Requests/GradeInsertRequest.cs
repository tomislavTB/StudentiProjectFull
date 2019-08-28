using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StudentiProject.Requests
{
    public class GradeInsertRequest
    {
        [Required]
        [RegularExpression(@"^[1-5]{1}$")]
        public int Evaluation { get; set; }

        [Required]
        public int CourseId { get; set; }

        [Required]
        public int StudentId { get; set; }

    }
}
