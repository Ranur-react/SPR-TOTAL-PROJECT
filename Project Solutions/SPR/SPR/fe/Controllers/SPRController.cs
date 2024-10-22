using Microsoft.AspNetCore.Mvc;

namespace fe.Controllers
{
    public class SPRController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
