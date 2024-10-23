using api.Models;
using frontend.Base;
using frontend.Repository.Data;
using Microsoft.AspNetCore.Mvc;

namespace frontend.Controllers
{
    public class SPRController : BaseController<SPR, SPRRepository, String>
    {
        private readonly SPRRepository repository;

        public SPRController(SPRRepository sPRRepository) : base(sPRRepository) 
        { 
        this.repository= sPRRepository;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
