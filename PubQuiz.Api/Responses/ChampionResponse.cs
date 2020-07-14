using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using PubQuiz.Models.Attributes;
using PubQuiz.Models;
using PubQuiz.Model.Users;

namespace PubQuiz.Responses
{
    public class ChampionResponse
    {
        public long Id { get; set; }

        public int NoticeBoardId { get; set; }
        public NoticeBoard NoticeBoard { get; set; }


    }
}
