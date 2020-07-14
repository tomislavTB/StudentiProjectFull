using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using PubQuiz.Models.Attributes;

namespace PubQuiz.Models
{
    public class QuizTheme : BaseModel
    {


        [CustomRequired]
        public string Name { get; set; }
        public ICollection<NoticeBoard> NoticeBoards { get; set; }


    }
}