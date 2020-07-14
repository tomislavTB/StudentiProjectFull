using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using PubQuiz.Models.Attributes;
using PubQuiz.Model.Users;

namespace PubQuiz.Models
{
    public class NoticeBoard : BaseModel
    {

        [CustomRequired]
        public string Name { get; set; }
        public DateTimeOffset DateWhen { get; set; }


        public int CityId { get; set; }
        public City City { get; set; }

        public int CoutryId { get; set; }
        public Country Country { get; set; }

        public int QuizThemeId { get; set; }
        public QuizTheme QuizTheme { get; set; }

        public int AuthUserId { get; set; }

        public ICollection<Champion> Champions { get; set; }

    }
}
