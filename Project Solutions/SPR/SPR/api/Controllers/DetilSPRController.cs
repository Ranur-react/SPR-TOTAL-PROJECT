using api.Base;
using api.Models;
using api.Repository.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DetilSPRController : BaseController<DetilSPR, DetilSPRRepository, Guid>
    {
        private readonly DetilSPRRepository repository; 
        public IConfiguration Configuration { get; set; }

        public DetilSPRController(DetilSPRRepository repository, IConfiguration configuration) : base(repository)
        {
            this.repository = repository;
            Configuration = configuration;
        }
    }
}
