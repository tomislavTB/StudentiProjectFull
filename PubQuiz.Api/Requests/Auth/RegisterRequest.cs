using System.ComponentModel.DataAnnotations;

namespace PubQuiz.Requests.Auth
{
    public class RegisterRequest : AppRequest
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string Password { get; set; }
    }
}