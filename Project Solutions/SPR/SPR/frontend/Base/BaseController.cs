using frontend.Repository.Interface;
using Microsoft.AspNetCore.Mvc;

namespace frontend.Base
{
    public class BaseController<TEntity, TRepository, TId> : Controller
       where TEntity : class
       where TRepository : IRepository<TEntity, TId>
    {
        private readonly TRepository repository;

        public BaseController(TRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public async Task<JsonResult> GetAll()
        {
            var result = await repository.Get();
            return Json(result);
        }
        [HttpGet]
        public async Task<JsonResult> Get(TId id)
        {
            var result = await repository.Get(id);
            return Json(result);
        }

        [HttpPost]
        public ActionResult<TEntity> Post(TEntity entity)
        {
            var result = repository.Post(entity);
            try
            {
                return Json(result);

            }
            catch (Exception e)
            {

                return Json(new { Message = e.Message });
            }   
        }

        [HttpPut]
        public JsonResult Put(TEntity entity)
        {
            var result = repository.Put(entity);
            try
            {
                return Json(result);

            }
            catch (Exception e)
            {

                return Json(new { Message = e.Message });
            }

        }

        [HttpDelete]
        public JsonResult Delete(TId id)
        {
            var result = repository.Delete(id);
            try
            {
                return Json(result);

            }
            catch (Exception e)
            {

                return Json(new { Message = e.Message });
            }
        }
    }
}

