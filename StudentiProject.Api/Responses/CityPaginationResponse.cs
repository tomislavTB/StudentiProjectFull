using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using StudentiProject.Models.Attributes;
using StudentiProject.Models;

namespace StudentiProject.Responses
{
    public class CityResponse
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public string Zip { get; set; }

    }
}
