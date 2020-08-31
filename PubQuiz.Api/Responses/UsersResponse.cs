using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using PubQuiz.Models.Attributes;
using PubQuiz.Models;
using PubQuiz.Model.Users;

namespace PubQuiz.Responses
{
    public class UserResponse
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }




    }
}
