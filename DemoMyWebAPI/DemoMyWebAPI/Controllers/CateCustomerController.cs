using DemoMyWebAPI.Models;
using DemoMyWebAPI.Repositories.Constracts;
using Microsoft.AspNetCore.Mvc;

namespace DemoMyWebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CateCustomerController : Controller
    {
        private readonly ICateCustomerRepository _cateCustomerRepository;

        public CateCustomerController(ICateCustomerRepository cateCustomerRepository)
        {
            _cateCustomerRepository = cateCustomerRepository;
        }

        [Route("GetAll")]
        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(_cateCustomerRepository.GetAll());
            }
            catch
            {
                return BadRequest();
            }
        }

        [Route("GetByIdCategoryCustomer")]
        [HttpGet]
        public IActionResult GetById(int id)
        {
            try
            {
                return Ok(_cateCustomerRepository.GetById(id));
            }
            catch
            {
                return BadRequest();
            }
        }

        [Route("CreateCategoryCustomer")]
        [HttpPost]
        public IActionResult Create(CateCustomerModel model)
        {
            try
            {
                return Ok(_cateCustomerRepository.Add(model));
            }
            catch
            {
                return BadRequest();
            }
        }

        [Route("EditProfileCategoryCustomer")]
        [HttpPut]
        public IActionResult Update(int id, CateCustomerVM model)
        {
            if (id != model.Id)
            {
                return BadRequest();
            }
            try
            {
                _cateCustomerRepository.Update(model);
                return NoContent();
            }
            catch
            {
                return BadRequest();
            }
        }

        [Route("DeletecategoryCustomer")]
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            try
            {
                _cateCustomerRepository.Delete(id);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}