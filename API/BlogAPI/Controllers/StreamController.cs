using Microsoft.AspNetCore.Mvc;

namespace BlogAPI.Controllers
{
    public class StreamController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
