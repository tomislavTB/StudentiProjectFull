using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using StudentiProject.Models.Attributes;

namespace StudentiProject.Models
{
    public class Country : BaseModel
    {

        [CustomRequired]
        public string Name { get; set; }

    }
}