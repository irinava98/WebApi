using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebApplication2.Services;

namespace WebApplication2.Controllers
{


    [ApiController]
    [Route("[controller]")]
    public class GenericController<T>: ControllerBase where T: class 
    {
        private readonly IGenericService<T> service;

        public GenericController(IGenericService<T> service)
        {
            this.service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await service.GetAll());

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await service.GetById(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post(T item)
        {
            if (item == null)
            {
                return BadRequest();
            }
            await service.Add(item);
            return Ok();
        }


        [HttpPut]
        public async Task<IActionResult> Put(T item)
        {
            if (item == null)
            {
                return NotFound();
            }
            await service.Update(item);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {

            await service.DeleteById(id);
            return NoContent();
        }
    }
}
