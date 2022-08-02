using DemoMyWebAPI.Data;
using DemoMyWebAPI.Model;
using DemoMyWebAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DemoMyWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : Controller
    {
        private readonly CarStoreContext _context;
        public CarController(CarStoreContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var ListCateCar = _context.Cars.ToList();
            return Ok(ListCateCar);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(string id)
        {
            try
            {
                var ListCar = _context.Cars.SingleOrDefault(a => a.Id == Guid.Parse(id));
                if (ListCar == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(ListCar);
                }
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
                var car = new Car
                {
                    Id = model.Id = Guid.NewGuid(),
                    Name = model.Name,
                    Price = model.Price,
                    Descirption=model.Descirption,
                    Status = model.Status,
                    IdCate = model.IdCate,
                    catecar=model.catecar,
                };
                _context.Add(car);
                _context.SaveChanges();
                return Ok(car);
            }
            catch
            {

                return BadRequest();
            }
        }
        [HttpPut]
        public IActionResult UpdateById(string id, CarModel model)
        {
            var car = _context.Cars.SingleOrDefault(a => a.Id == Guid.Parse(id));
            if (car == null)
            {
                return NotFound();
            }
            else
            {
                car.Id = model.Id;
                car.Name = model.Name;
                car.Price = model.Price;
                car.Descirption = model.Descirption;
                car.Status = model.Status;
                car.IdCate = model.IdCate;
                car.catecar = model.catecar;
                _context.SaveChanges();
                return NoContent();
            }
        }
        [HttpDelete]
        public IActionResult Delete(string id)
        {
            var car = _context.Cars.SingleOrDefault(a => a.Id == Guid.Parse(id));
            try
            {
                if (car == null)
                {
                    return NotFound();
                }
                else
                {
                    _context.Remove(car);
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
