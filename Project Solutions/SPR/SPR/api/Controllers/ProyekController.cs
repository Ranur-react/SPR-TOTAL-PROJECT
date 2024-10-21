using api.Base;
using api.Models;
using api.Repository.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProyekController : BaseController<Proyek, ProyekRepository, int>
    {
        private readonly ProyekRepository proyekRepository;
        public IConfiguration _Configuration;

        public ProyekController(ProyekRepository proyekRepository, IConfiguration configuration) : base(proyekRepository)
        {
            this.proyekRepository = proyekRepository;
           this._Configuration = configuration;
        }
    }
}
