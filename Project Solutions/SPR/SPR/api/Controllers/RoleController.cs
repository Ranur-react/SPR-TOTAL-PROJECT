using api.Base;
using api.Models;
using api.Repository.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : BaseController<Role, RoleRepository, int>
    {
        private readonly RoleRepository roleRepository;
        public IConfiguration Configuration { get; set; }

        public RoleController(RoleRepository roleRepository, IConfiguration configuration) : base(roleRepository)
        {
            this.roleRepository = roleRepository;
            this.Configuration = configuration;
        }
    }
}
