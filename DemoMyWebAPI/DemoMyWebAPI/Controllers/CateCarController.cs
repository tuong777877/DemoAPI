using DemoMyWebAPI.Data;
using DemoMyWebAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DemoMyWebAPI.Controllers
{
    public class CateCarController : Controller
    {
        private readonly CarStoreContext _context;
        public CateCarController(CarStoreContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var ListCateCar = _context.CateCars.ToList();
            return Ok(ListCateCar);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                var ListCateCar = _context.CateCars.SingleOrDefault(a => a.Id == id);
                if (ListCateCar == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(ListCateCar);
                }
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
                var catecar = new CateCar
                {
                    Name = model.Name,
                };
                _context.Add(catecar);
                _context.SaveChanges();
                return Ok(catecar);
            }
            catch
            {

                return BadRequest();
            }
            
        }
        [HttpPut]
        public IActionResult UpdateById(int id, CateCarModel model)
        {
            var catecar = _context.CateCars.SingleOrDefault(a => a.Id == id);
            if(catecar == null)
            {
                return NotFound();
            }
            else
            {
                catecar.Name = model.Name;
                _context.SaveChanges();
                return NoContent();
            }
        }
    }
}
