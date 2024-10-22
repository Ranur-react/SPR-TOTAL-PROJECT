using api.Base;
using api.Models;
using api.Repository.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogSPRController : BaseController<LogSPR, LogSPRRepository, Guid>
    {
        private readonly LogSPRRepository logSPRRepository;
        public IConfiguration Configuration { get; set; }

        public LogSPRController(LogSPRRepository logSPRRepository, IConfiguration configuration) : base(logSPRRepository)
        {
            this.logSPRRepository = logSPRRepository;
            Configuration = configuration;
        }
    }
}
