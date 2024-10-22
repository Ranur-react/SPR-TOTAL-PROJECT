using Microsoft.AspNetCore.Mvc;

namespace frontend.Controllers
{
    public class SPRController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
