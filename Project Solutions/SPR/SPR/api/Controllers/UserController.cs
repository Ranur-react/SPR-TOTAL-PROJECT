using api.Base;
using api.Models;
using api.Repository.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : BaseController<User, UsersRepository, Guid>
    {
        private readonly UsersRepository _usersRepository;
        public IConfiguration Configuration { get; set; }

        public UserController(UsersRepository usersRepository, IConfiguration configuration) : base(usersRepository)
        {
            _usersRepository = usersRepository;
            Configuration = configuration;
        }
    }
}
