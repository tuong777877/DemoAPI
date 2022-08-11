using DemoMyWebAPI.Models;
using DemoMyWebAPI.Repositories.Constracts;
using Microsoft.AspNetCore.Mvc;

namespace DemoMyWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : Controller
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerController(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        [Route("GetAll")]
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

        [Route("GetByIdCustomer")]
        [HttpGet]
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

        [Route("CreateAccount")]
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

        [Route("EditProfileAccount")]
        [HttpPut]
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

        [Route("DeleteAccount")]
        [HttpDelete]
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