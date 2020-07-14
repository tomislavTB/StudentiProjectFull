using PubQuiz.Model.Users;

namespace PubQuiz.Responses
{
    public class LoginResponse : AppResponse
    {
        public string Token { get; set; }

        public AuthUser User { get; set; }
    }
}