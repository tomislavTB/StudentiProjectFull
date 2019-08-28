using System.ComponentModel.DataAnnotations;

namespace StudentiProject.Requests.Auth
{
    public class RegisterRequest : AppRequest
    {
        [Required]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "PASSWORD_MIN_LENGTH", MinimumLength = 6)]
        public string Password { get; set; }
    }
}