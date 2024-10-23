using api.Models;
using frontend.Repository.Data;
using Microsoft.AspNetCore.Mvc;

namespace frontend.Controllers
{
    public class SPRController : BaseController<SPR, SPRRepository, String>
    {
        private readonly SPRRepository repository;
        public IActionResult Index()
        {
            return View();
        }
    }
}
