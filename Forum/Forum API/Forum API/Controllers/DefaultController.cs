using Microsoft.AspNetCore.Mvc;

namespace Forum_API.Controllers
{
    public class DefaultController : Controller
    {
        public ILogger<DefaultController> logger;

        public DefaultController(ILogger<DefaultController> _logger)
        {
            logger = _logger;
        }
    }
}
