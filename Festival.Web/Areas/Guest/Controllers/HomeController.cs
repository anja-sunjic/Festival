using Microsoft.AspNetCore.Mvc;

namespace Festival.Web.Areas.Guest.Controllers
{
    [Area("Guest")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
