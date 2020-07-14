using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using PubQuiz.Models.Attributes;

namespace PubQuiz.Models
{
    public class City:BaseModel
    {

        [CustomRequired]
        public string Name { get; set; }

        [CustomRequired]
        public string Zip { get; set; }


        public int CountryId { get; set; }
        public Country Country { get; set; }

        public ICollection<NoticeBoard> NoticeBoards { get; set; }


    }
}
