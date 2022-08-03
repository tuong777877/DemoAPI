using DemoMyWebAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.IdentityModel.Tokens.Jwt;

namespace DemoMyWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly CarStoreContext _context;
        private readonly AppSettings _appSettings;

        public UserController(CarStoreContext context,IOptionsMonitor<AppSettings> optionsMonitor)
        {
            _context = context;
            _appSettings = optionsMonitor.CurrentValue;
        }
        [HttpPost("Login")]
        public IActionResult Validate(LoginModel model)
        {
            var user = _context.Customers.SingleOrDefault(p => p.Username == model.Username && p.Password == model.Password);
            if (user == null)
            {
                return Ok(new
                {
                    Success = false,
                    Message = "Invalid username/password"
                });
            }
            return Ok(new
            {
                Success = true,
                Message = "Authentication success",
            });
        }
        private string GenerateToke(Customer customer)
        {
            var jwtTokenHandler = new JwtSecurityTokenHandler();
            return null;
        }
    }
}
