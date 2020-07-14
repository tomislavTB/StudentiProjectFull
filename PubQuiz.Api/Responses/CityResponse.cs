using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using PubQuiz.Models.Attributes;
using PubQuiz.Models;

namespace PubQuiz.Responses
{
    public class CityResponse
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public string Zip { get; set; }

    }
}
