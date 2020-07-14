using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using PubQuiz.Models.Attributes;
using PubQuiz.Model.Users;

namespace PubQuiz.Models
{
    public class Champion : BaseModel
    {

        public int NoticeBoardId { get; set; }
        public NoticeBoard NoticeBoard { get; set; }

        public int AuthUserId { get; set; }

    }
}
