using api.Models;
using api.Models.ViewModel;
using frontend.Base;
using frontend.Repository.Data;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Core.Types;

namespace frontend.Controllers
{
    public class DetilSPRController : BaseController<DetilSPR, DetilSPRRepository, Guid>
    {
        private readonly DetilSPRRepository _repository;

        public DetilSPRController(DetilSPRRepository repository) : base(repository)
        {
            _repository = repository;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public async Task<Object> GetBySPR(String SPRKode)
        {
            try
            {
                var result = await _repository.GetBySPR(SPRKode);
                return Ok(result);

            }
            catch (Exception e)
            {

                return BadRequest(new RequestForm
                {
                    code = StatusCodes.Status400BadRequest,
                    message = e.Message,
                    data = e,
                });
            }
        }
    }
}
