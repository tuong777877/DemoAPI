using DemoMyWebAPI.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DemoMyWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        public static List<Car> cars = new List<Car>();
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(cars);
        }
        [HttpPost]
        public IActionResult Create(Car car)
        {
            var Ncar = new Car
            {
                Id = Guid.NewGuid(),
                Name = car.Name,
                Price = car.Price,
                Status = car.Status,
                DateRelease = car.DateRelease,
                Descirption = car.Descirption,
            };
            cars.Add(Ncar);
            return Ok();
        }
        [HttpGet("{id}")]
        public IActionResult GetById(string id)
        {
            try
            {
                var Ncar = cars.SingleOrDefault(a => a.Id == Guid.Parse(id));
                if (Ncar == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(cars);
                }
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpPut("{id}")]
        public IActionResult Edit(string id, Car car)
        {
            var Ncar = cars.SingleOrDefault(a => a.Id == Guid.Parse(id));
            try
            {
                if (Ncar == null)
                {
                    return NotFound();
                }
                else
                {
                    if (id != Ncar.Id.ToString())
                    {
                        return BadRequest();
                    }
                    else
                    {
                        Ncar.Name = car.Name;
                        Ncar.Price = car.Price;
                        Ncar.Status = car.Status;
                        Ncar.Descirption = car.Descirption;
                        Ncar.DateRelease = car.DateRelease;
                        return Ok();
                    }
                }
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            var Ncar = cars.SingleOrDefault(a => a.Id == Guid.Parse(id));
            try
            {
                if (Ncar == null)
                {
                    return NotFound();
                }
                else
                {
                    cars.Remove(Ncar);
                    return Ok();
                }
            }
            catch
            {
                return BadRequest();
            }
            
        }
    }
}
