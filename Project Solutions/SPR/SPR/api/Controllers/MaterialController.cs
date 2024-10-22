using api.Base;
using api.Models;
using api.Repository.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MaterialController : BaseController<Material, MaterialRepository, Guid>
    {
        private readonly MaterialRepository materialRepository;
        public IConfiguration _Configuration;

        public MaterialController(MaterialRepository materialRepository, IConfiguration configuration) : base(materialRepository)
        {
            this.materialRepository = materialRepository;
            _Configuration = configuration;
        }
    }
}
