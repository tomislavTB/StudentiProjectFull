using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;
using PubQuiz.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PubQuiz.Model.Users
{
    public class AuthUser : IdentityUser<int> 
    {
        [Required(ErrorMessage = "Morate unijeti ime")]
        [MaxLength(100, ErrorMessage = "Ime mora biti kraća od 100 znakova")]
        public string FirstName { get; set; }


        [Required(ErrorMessage = "Morate unijeti prezime")]
        [MaxLength(100, ErrorMessage = "Preazme mora biti kraća od 100 znakova")]
        public string LastName { get; set; }


        [RegularExpression(@"M|F", ErrorMessage = "Spol se označava s jednim znakom: M ili F")]
        public string Gender { get; set; }

    }
}