using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;
using StudentiProject.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StudentiProject.Model.Users
{
    public class AuthUser : IdentityUser<int> 
    {
        [Required(ErrorMessage = "Morate unijeti ime gosta")]
        [MaxLength(100, ErrorMessage = "Ime gosta mora biti kraća od 100 znakova")]
        public string FirstName { get; set; }


        [Required(ErrorMessage = "Morate unijeti prezime gosta")]
        [MaxLength(100, ErrorMessage = "Preazme gosta mora biti kraća od 100 znakova")]
        public string LastName { get; set; }


        [RegularExpression(@"M|F", ErrorMessage = "Spol gosta se označava s jednim znakom: M ili F")]
        public string Gender { get; set; }
        public ICollection<Teacher> Teachers { get; set; }

         
    }
}