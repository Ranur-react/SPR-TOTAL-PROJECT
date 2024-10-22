using api.Base;
using api.Models;
using api.Repository.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApprovalSPRController : BaseController<ApprovalSPR, ApprovalSPRRepository, Guid>
    {
        private readonly ApprovalSPRRepository _approvalSPRRepository;
        public IConfiguration Configuration { get; set; }

        public ApprovalSPRController(ApprovalSPRRepository approvalSPRRepository, IConfiguration configuration) : base(approvalSPRRepository)
        {
            _approvalSPRRepository = approvalSPRRepository;
            Configuration = configuration;
        }
    }
}
