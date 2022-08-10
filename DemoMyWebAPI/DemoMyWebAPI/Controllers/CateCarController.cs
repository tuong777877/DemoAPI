﻿using DemoMyWebAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace DemoMyWebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CateCarController : Controller
    {
        private readonly ICateCarRepository _cateCarRepository;

        public CateCarController(ICateCarRepository cateCarRepository)
        {
            _cateCarRepository = cateCarRepository;
        }

        [Route("GetAll")]
        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(_cateCarRepository.GetAll());
            }
            catch
            {
                return BadRequest();
            }
        }

        [Route("GetByIdCategoryCar")]
        [HttpGet]
        public IActionResult GetById(int id)
        {
            try
            {
                var cateCar = _cateCarRepository.GetById(id);
                if (cateCar != null)
                {
                    return Ok(cateCar);
                }
                return NotFound();
            }
            catch
            {
                return BadRequest();
            }
        }

        [Route("CreateCategoryCar")]
        [HttpPost]
        public IActionResult Create(CateCarModel model)
        {
            try
            {
                return Ok(_cateCarRepository.Add(model));
            }
            catch
            {
                return BadRequest();
            }
        }

        [Route("EditProfileCategoryCar")]
        [HttpPut]
        public IActionResult Update(int id, CateCarVM catecarVM)
        {
            if (id != catecarVM.Id)
            {
                return BadRequest();
            }
            try
            {
                _cateCarRepository.Update(catecarVM);
                return NoContent();
            }
            catch
            {
                return BadRequest();
            }
        }

        [Route("DeleteVategoryCar")]
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            try
            {
                _cateCarRepository.Delete(id);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}