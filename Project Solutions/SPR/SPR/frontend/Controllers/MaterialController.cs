using api.Models;
using frontend.Base;
using frontend.Repository.Data;
using Microsoft.AspNetCore.Mvc;

namespace frontend.Controllers
{
    public class MaterialController : BaseController<Material, MaterialRepository, Guid>
    {
        private readonly MaterialRepository repository;

        public MaterialController(MaterialRepository repository): base(repository)
        {
            this.repository = repository;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
