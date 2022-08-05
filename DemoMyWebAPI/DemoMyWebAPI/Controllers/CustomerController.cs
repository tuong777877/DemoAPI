using DemoMyWebAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DemoMyWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : Controller
    {
        private readonly CarStoreContext _context;

        public CustomerController(CarStoreContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_context.Customers.ToList());
        }
        [HttpGet("{id}")]
        public IActionResult GetById(string id)
        {
            var cus = _context.Customers.SingleOrDefault(c => c.Id == Guid.Parse(id));
            try
            {
                if (cus == null)
                {
                    return NotFound();
                }
                return Ok(cus);
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpPost]
        public IActionResult Create(CustomerModel model)
        {
            try
            {
                var cus = new Customer
                {
                    Id = Guid.NewGuid(),
                    Name = model.Name,
                    Email = model.Email,
                    Username = model.Username,
                    Password = model.Password,
                    IdCate = model.IdCate,
                    PhoneNumber = model.PhoneNumber,
                    Address = model.Address,
                };
                _context.Add(cus);
                _context.SaveChanges();
                return Ok(cus);
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpPut("{id}")]
        public IActionResult Edit(string id, CustomerModel model)
        {
            var cus = _context.Customers.SingleOrDefault(c => c.Id == Guid.Parse(id));
            try
            {
                if (cus == null)
                {
                    return NotFound();
                }
                else
                {
                    cus.Name = model.Name;
                    cus.Email = model.Email;
                    cus.Username = model.Username;
                    cus.Password = model.Password;
                    cus.IdCate = model.IdCate;
                    cus.Address = model.Address;
                    cus.PhoneNumber = model.PhoneNumber;
                    _context.SaveChanges();
                    return Ok(cus);
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
            var cus = _context.Customers.SingleOrDefault(c => c.Id == Guid.Parse(id));
            try
            {
                if (cus == null)
                {
                    return NotFound();
                }
                else
                {
                    _context.Remove(cus);
                    _context.SaveChanges();
                    return Ok(cus);
                }
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
