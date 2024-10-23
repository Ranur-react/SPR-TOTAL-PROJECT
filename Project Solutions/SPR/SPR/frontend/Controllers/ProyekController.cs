using api.Models;
using frontend.Base;
using frontend.Repository.Data;
using Microsoft.AspNetCore.Mvc;

namespace frontend.Controllers
{
    public class ProyekController : BaseController<Proyek, ProyekRepository, int>
    {
        private readonly ProyekRepository repository;

        public ProyekController(ProyekRepository repository) : base(repository)
        {
            this.repository = repository;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
