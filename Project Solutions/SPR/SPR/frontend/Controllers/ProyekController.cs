using Microsoft.AspNetCore.Mvc;

namespace frontend.Controllers
{
    public class ProyekController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
