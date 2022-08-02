using DemoMyWebAPI.Models;
using DemoMyWebAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace DemoMyWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CateCar2Controller : Controller
    {
        private readonly ICateCarRepository _cateCarRepository;
        public CateCar2Controller(ICateCarRepository cateCarRepository)
        {
            _cateCarRepository = cateCarRepository;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(_cateCarRepository.GetAll());
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                var cateCar = _cateCarRepository.GetById(id);
                if (cateCar != null)
                {
                    return Ok(cateCar);
                }
                return NotFound();
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpPost]
        public IActionResult Create(CateCarModel model)
        {
            try
            {
                return Ok(_cateCarRepository.Add(model));
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpPut("{id}")]
        public IActionResult Update(int id, CateCarVM catecarVM)
        {
            if (id != catecarVM.Id)
            {
                return BadRequest();
            }
            try
            {
                _cateCarRepository.Update(catecarVM);
                return NoContent();
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _cateCarRepository.Delete(id);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
