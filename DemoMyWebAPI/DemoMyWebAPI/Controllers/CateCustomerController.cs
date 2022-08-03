using DemoMyWebAPI.Data;
using DemoMyWebAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace DemoMyWebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CateCustomerController : Controller
    {
        private readonly CarStoreContext _context;
        public CateCustomerController(CarStoreContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var catecus = _context.CateCustomers.ToList();
            return Ok(catecus);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var catecus = _context.CateCustomers.SingleOrDefault(s => s.Id == id);
            try
            {
                if (catecus == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(catecus);
                }
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpPost]
        public IActionResult Create(CateCustomerModel model)
        {
            try
            {
                var catecus = new CateCustomer
                {
                    Name = model.Name,
                };
                _context.Add(catecus);
                _context.SaveChanges();
                return Ok(catecus);
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpPut("{id}")]
        public IActionResult Update(int id, CateCustomerModel model)
        {
            var catecus = _context.CateCustomers.SingleOrDefault(cc => cc.Id == id);
            try
            {
                if (catecus != null)
                {
                    catecus.Name = model.Name;
                    _context.SaveChanges();
                    return NoContent();
                }
                return NotFound();
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
                var catecus = _context.CateCars.SingleOrDefault(cc => cc.Id == id);
                if (catecus != null)
                {
                    _context.Remove(catecus);
                    _context.SaveChanges();
                    return Ok(catecus);
                }
                return NotFound();
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
