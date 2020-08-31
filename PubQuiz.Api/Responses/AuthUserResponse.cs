using Microsoft.AspNetCore.Identity;

namespace PubQuiz.Responses
{
    public class AuthUserResponse
    {
        public long Id { get; set; }
        public string Email { get; set; }
        public bool Admin { get; set; }
    }
}