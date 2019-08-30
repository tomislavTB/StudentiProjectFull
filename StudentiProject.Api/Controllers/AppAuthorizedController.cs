using Microsoft.AspNetCore.Authorization;

namespace StudentiProject.Controllers
{
    [Authorize]
    public class AppAuthorizedController : AppController
    {
        
    }
}