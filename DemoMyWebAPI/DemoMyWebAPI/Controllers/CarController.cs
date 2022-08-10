using DemoMyWebAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace DemoMyWebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CarController : Controller
    {
        private readonly ICarRepository _carRepository;

        public CarController(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }

        [Route("GetAll")]
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

        [Route("GetByIdCustomer")]
        [HttpGet]
        public IActionResult GetById(string id)
        {
            try
            {
                var car = _carRepository.GetById(id);
                if (car != null)
                {
                    return Ok(car);
                }
                return NotFound();
            }
            catch
            {
                return BadRequest();
            }
        }

        [Route("CreateNewCar")]
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

        [Route("EditProfileCar")]
        [HttpPut]
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

        [Route("DeleteCar")]
        [HttpDelete]
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