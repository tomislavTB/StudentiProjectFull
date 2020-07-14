using Microsoft.AspNetCore.Authorization;

namespace PubQuiz.Controllers
{
    [Authorize]
    public class AppAuthorizedController : AppController
    {
        
    }
}