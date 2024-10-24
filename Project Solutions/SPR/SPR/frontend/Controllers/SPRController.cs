using api.Models;
using api.Models.ViewModel;
using frontend.Base;
using frontend.Repository.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

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
        [HttpPost]
        public async Task<Object> CreateSPR([FromBody]  SPRContentDetilView entity) {

            try
            {
                RequestForm result = await repository.CreateSPR(entity);
                switch (result.code) {
                    case 200:
                        return Ok(result);
                    case 201:
                        return Ok(result);
                    case 0:
                        return BadRequest(new RequestForm
                        {
                            code = StatusCodes.Status400BadRequest,
                            message ="mohon sertakan data di body api",
                            data = result,
                        });
                    default:
                        return BadRequest(result);

                }
            }
            catch (Exception e)
            {

                return BadRequest(new RequestForm {
                    code=StatusCodes.Status400BadRequest,
                    message = e.Message,
                    data=e,
                });
            }
        }
        [HttpGet]
        public async Task<Object> GetSPRByProject(int proyekId) {
            try
            {
                var result = await repository.GetSPRByProject(proyekId);
                return Ok(result);

            }
            catch (Exception e)
            {

                return BadRequest(new { Message = e.Message });
            }
        }
    }
}
