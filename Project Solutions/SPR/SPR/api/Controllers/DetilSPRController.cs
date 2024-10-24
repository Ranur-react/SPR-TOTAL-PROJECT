using api.Base;
using api.Models;
using api.Models.ViewModel;
using api.Repository.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;


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
        [Route("GetBySPR/{key}")]
        [HttpGet]
        public ActionResult<ICollection<DetilSPRView>> GetBySPR(String key)
        {

            try
            {
                IEnumerable<DetilSPRView> result = repository.GetBySPR(key);
                if (result.Count()>0)
                {
                    //return Ok(result);
                    return Ok(new RequestForm
                    {
                        code = StatusCodes.Status200OK,
                        status = "Success",
                        data = result,
                        message = $"Data Berhasil didapatkan dari [{ControllerContext.ActionDescriptor.ControllerName}]"
                    });
                }
                else
                {
                    //return Ok(result);
                    return Ok(new RequestForm
                    {
                        code = StatusCodes.Status204NoContent,
                        status = "Empty",
                        data = result,
                        message = $"Tidak ada data [{ControllerContext.ActionDescriptor.ControllerName}]"
                    });
                }
            }
            catch (Exception e)
            {
                return BadRequest(new RequestForm
                {
                    code = StatusCodes.Status417ExpectationFailed,
                    status = "Error",
                    message = e.Message,
                    data = e,
                });

            }
        }
    }
}
