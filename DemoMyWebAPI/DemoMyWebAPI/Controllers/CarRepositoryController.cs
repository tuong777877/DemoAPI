using DemoMyWebAPI.Model;
using DemoMyWebAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace DemoMyWebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CarRepositoryController : Controller
    {
        private readonly ICarRepository _carRepository;
        public CarRepositoryController(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(_carRepository.GetAll());
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpGet("{id}")]
        public IActionResult GetById(string id)
        {
            try
            {
                var car = _carRepository.GetById(id);
                if (car != null)
                {
                    return Ok(car);
                }
                return null;
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpPost]
        public IActionResult Create(CarModel model)
        {
            try
            {
                return Ok(_carRepository.Add(model));
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpPut("{id}")]
        public IActionResult Update(string id, CarVM carVM)
        {
            if (Guid.Parse(id) != carVM.Id)
            {
                return NotFound();
            }
            try
            {
                _carRepository.Update(carVM);
                return NoContent();
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            try
            {
                _carRepository.Delete(id);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
