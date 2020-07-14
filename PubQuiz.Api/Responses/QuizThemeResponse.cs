using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using PubQuiz.Models.Attributes;

namespace PubQuiz.Responses
{
    public class QuizThemeResponse
    {

        public long Id { get; set; }
        public string Name { get; set; }

    }
}
