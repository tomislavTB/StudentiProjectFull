using StudentiProject.Model.Users;

namespace StudentiProject.Responses
{
    public class LoginResponse : AppResponse
    {
        public string Token { get; set; }

        public AuthUser User { get; set; }
    }
}