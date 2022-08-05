using DemoMyWebAPI.Models;
using DemoMyWebAPI.Repositories.Constracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DemoMyWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerRepositoryController : Controller
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerRepositoryController(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(_customerRepository.GetAll());
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
                var customer = _customerRepository.GetById(id);
                if (customer != null)
                {
                    return Ok(customer);
                }
                return NotFound();
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
                return Ok(_customerRepository.Create(model));
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpPut("{id}")]
        public IActionResult edit(string id, CustomerVM cusVM)
        {
            if (Guid.Parse(id) != cusVM.Id)
            {
                return NotFound();
            }
            try
            {
                _customerRepository.Update(cusVM);
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
                _customerRepository.Delete(id);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
