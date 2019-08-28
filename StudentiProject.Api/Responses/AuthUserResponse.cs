using Microsoft.AspNetCore.Identity;

namespace StudentiProject.Responses
{
    public class AuthUserResponse
    {
        public long Id { get; set; }
        public string Email { get; set; }
    }
}