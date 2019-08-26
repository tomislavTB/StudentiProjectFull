using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using StudentiProject.Models.Attributes;

namespace StudentiProject.Models
{
    public class City:BaseModel
    {

        [CustomRequired]
        public string Name { get; set; }

        [CustomRequired]
        public string Zip { get; set; }


        public int CountryId { get; set; }
        public Country Country { get; set; }

    }
}
