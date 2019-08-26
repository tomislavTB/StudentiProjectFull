using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using StudentiProject.Models.Attributes;

namespace StudentiProject.Responses
{
    public class CountryResponse
    {
        public long Id { get; set; }
        public string Name { get; set; }


    }
}