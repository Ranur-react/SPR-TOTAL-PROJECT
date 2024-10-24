using api.Base;
using api.Models;
using api.Models.ViewModel;
using api.Repository.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using NuGet.Protocol.Core.Types;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SPRController : BaseController<SPR, SPRRepository, String>
    {
        private readonly SPRRepository sPRRepository;
        public IConfiguration _Configuration;

        public SPRController(SPRRepository sPRRepository, IConfiguration configuration) : base(sPRRepository)
        {
            this.sPRRepository = sPRRepository;
            _Configuration = configuration;
        }
        [HttpPost]
        public override ActionResult<SPR> Post(SPR entity)
        {
            try
            {
                var result = sPRRepository.CreateSPR(entity);
                switch (result)
                {
                    case 1:
                        return Ok(new { status = StatusCodes.Status201Created, result, message = $"Data Berhasil Tersimpan ke [{ControllerContext.ActionDescriptor.ControllerName}]" });
                    //return Ok(result);
                    case 2:
                        return Ok(new { status = StatusCodes.Status201Created, result, message = $"Data Berhasil Tersimpan ke [{ControllerContext.ActionDescriptor.ControllerName}] dan kedalam Table" });
                    case 3:
                        return Ok(new { status = StatusCodes.Status200OK, result, message = $"Data sudah ada [{ControllerContext.ActionDescriptor.ControllerName}]" });
                    default:
                        return BadRequest(new { status = StatusCodes.Status400BadRequest, result, message = $" Data gagal Ditambahkan , ada kekeliruan dalam data yang dikirimkan, hubungi adminstrator [{ControllerContext.ActionDescriptor.ControllerName}]" });
                }
            }
            catch (Exception e)
            {
                return BadRequest(new { status = StatusCodes.Status417ExpectationFailed, errors = e.Message });
            }
        }
        [Route("GetSPRByProject/{key}")]
        [HttpGet]
        public ActionResult<ICollection<SPR>> GetSPRByProject(int key)
        {

            try
            {
                var result = sPRRepository.GetSPRByProject(key);
                if (result != null)
                {
                    return Ok(result);
                }
                else
                {
                    return Ok(result);
                }
            }
            catch (Exception e)
            {
                return BadRequest(new { status = StatusCodes.Status417ExpectationFailed, errorMessage = e.Message });

            }
        }
        [Route("CreateSPR")]
        [HttpPost]
        public ActionResult<SPR> CreateSPR(SPRContentDetilView entity)
        {
            try
            {
                var result = sPRRepository.CreateSPRWithDetails(entity);
                switch (result)
                {
                    case 1:
                        return Ok(new RequestForm
                        { 
                            code = StatusCodes.Status201Created, 
                            status="Created",
                            data=result, 
                            message = $"Data Berhasil Tersimpan ke [{ControllerContext.ActionDescriptor.ControllerName}]" 
                        });
                    default:
                        return BadRequest(new RequestForm { 
                            code = StatusCodes.Status400BadRequest, 
                            status="Bad Request",
                            data = result, 
                            message = $" Data gagal Ditambahkan , ada kekeliruan dalam data yang dikirimkan, hubungi adminstrator [{ControllerContext.ActionDescriptor.ControllerName}]" });
                }
            }
            catch (Exception e)
            {
                return BadRequest(new RequestForm { 
                    code = StatusCodes.Status417ExpectationFailed, 
                    status="Error",
                    message= e.Message,
                    data=e,
                });
            }
        }
    }
}
