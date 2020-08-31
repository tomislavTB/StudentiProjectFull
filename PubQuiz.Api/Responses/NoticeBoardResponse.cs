using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using PubQuiz.Models.Attributes;
using PubQuiz.Models;
using PubQuiz.Model.Users;

namespace PubQuiz.Responses
{
    public class NoticeBoardResponse
    {
        public long Id { get; set; }

        public string Name { get; set; }
        public int CityId { get; set; }
        public City City { get; set; }

        public int CountryId { get; set; }
        public Country Country { get; set; }

        public int QuizThemeId { get; set; }
        public QuizTheme QuizTheme { get; set; }

        public int AuthUserId { get; set; }
        public AuthUser AuthUser { get; set; }
        public DateTimeOffset DateWhen { get; set; }
    }
}
