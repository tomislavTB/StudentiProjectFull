using Microsoft.AspNetCore.Identity;

namespace StudentiProject.Responses
{
    public class RegisterResponse : AppResponse
    {
        public string Token { get; set; }
        public AuthUserResponse User { get; set; }
    }
}