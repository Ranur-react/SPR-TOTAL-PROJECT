using api.Repository.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace api.Base
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController<Entity, Repository, Key> : ControllerBase
        where Entity : class
        where Repository : IRepository<Entity, Key>
    {
        private readonly Repository repository;

        public BaseController(Repository repository)
        {
            this.repository = repository;
        }
        [HttpGet]
        public virtual ActionResult<Entity> Get()
        {

            try
            {
                var result = repository.Get();
                if (result.Count() > 0)
                {
                    // return Ok(new  { status = StatusCodes.Status200OK, result, message = $" {result.Count()} Data Berhasil Didapatkan" });
                    return Ok(result);
                }
                else
                {
                    return Ok(result);

                    // return BadRequest(new { status = StatusCodes.Status204NoContent, result, message = $"tidak ada indikasi data ditemukan di [{ControllerContext.ActionDescriptor.ControllerName}] silahkan tambah data" });
                }
            }
            catch (Exception e)
            {
                return BadRequest(new { status = StatusCodes.Status417ExpectationFailed, errorMessage = e.Message });

            }
        }
        [HttpGet("{Key}")]
        public ActionResult<Entity> Get(Key key)
        {
            try
            {
                var result = repository.Get(key);
                if (result != null)
                {
                    return Ok(result);
                    // return Ok(new { status = StatusCodes.Status200OK, result, message = $" Data Berhasil Didapatkan dengan parameter {key}" });
                }
                else
                {
                    return Ok(result);
                    //return BadRequest(new { status = StatusCodes.Status204NoContent, result, message = $"tidak ada indikasi data ditemukan di [{ControllerContext.ActionDescriptor.ControllerName}] dengan paramter {key}" });
                }
            }
            catch (Exception e)
            {
                return BadRequest(new { status = StatusCodes.Status417ExpectationFailed, errorMessage = e.Message });

            }
        }
        [HttpPost]
        public virtual ActionResult<Entity> Post(Entity entity)
        {
            Console.WriteLine($"Received entity: {JsonSerializer.Serialize(entity)}");

            try
            {
                Console.WriteLine("Entity Received: " + entity);
                var result = repository.Insert(entity);
                switch (result)
                {
                    case 1:
                        return Ok(result);
                    // return Ok(new { status = StatusCodes.Status201Created, result, message = $"Data Berhasil Tersimpan ke [{ControllerContext.ActionDescriptor.ControllerName}]" });
                    default:
                        return Ok(result);
                        //return BadRequest(new { status = StatusCodes.Status400BadRequest, result, message = $" Data gagal Ditambahkan Sudah ada di dalam database [{ControllerContext.ActionDescriptor.ControllerName}]" });
                }
            }
            catch (Exception e)
            {
                return BadRequest(new { status = StatusCodes.Status417ExpectationFailed, errors = e.Message });
            }
        }
        [HttpPut]
        public virtual ActionResult<Entity> Put(Entity entity)
        {
            try
            {
                var result = repository.Update(entity);
                switch (result)
                {
                    case 1:
                        return Ok(result);

                    // return Ok(new { status = StatusCodes.Status200OK, result, message = $"Data Berhasil Diubah dan Tersimpan ke [{ControllerContext.ActionDescriptor.ControllerName}]" });
                    default:
                        return Ok(result);
                        // return BadRequest(new { status = StatusCodes.Status400BadRequest, result, message = $" Data gagal diubah di[{ControllerContext.ActionDescriptor.ControllerName}]" });
                }
            }
            catch (Exception e)
            {
                return BadRequest(new { status = StatusCodes.Status417ExpectationFailed, errors = e.Message });
            }

        }
        [HttpDelete("{key}")]
        public ActionResult<Entity> Delete(Key key)
        {
            try
            {
                var result = repository.Delete(key);
                switch (result)
                {
                    case 1:
                        return Ok(result);
                    //return Ok(new { status = StatusCodes.Status200OK, result, message = "Data Berhasil Dihapus" });
                    default:
                        return Ok(result);
                        //return BadRequest(new { status = StatusCodes.Status400BadRequest, result, message = $" Data {key} Tidak ditemukan  atau sudah dihapus di[{ControllerContext.ActionDescriptor.ControllerName}]" });
                }
            }
            catch (Exception e)
            {
                return BadRequest(new { status = StatusCodes.Status417ExpectationFailed, errors = e.Message });
            }

        }
    }
}
