using DemoMyWebAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace DemoMyWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly CarStoreContext _context;
        private readonly AppSettings _appSettings;

        public UserController(CarStoreContext context, IOptionsMonitor<AppSettings> optionsMonitor)
        {
            _context = context;
            _appSettings = optionsMonitor.CurrentValue;
        }

        [Route("Login")]
        [HttpPost]
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
            var token = GenerateToke(user);
            return Ok(new
            {
                Success = true,
                Message = "Authentication success",
                Data = token,
            });
        }

        private TokenModel GenerateToke(Customer customer)
        {
            var jwtTokenHandler = new JwtSecurityTokenHandler();
            var secretKey = Encoding.UTF8.GetBytes(_appSettings.SecretKey);
            var tokenDescription = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(JwtRegisteredClaimNames.Name, customer.Name),
                    new Claim(JwtRegisteredClaimNames.Email, customer.Email),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim("UserName", customer.Username),
                    new Claim("Id", customer.Id.ToString()),
                }),
                //thoi gian het token
                Expires = DateTime.UtcNow.AddSeconds(20),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(secretKey), SecurityAlgorithms.HmacSha256Signature),
            };
            var token = jwtTokenHandler.CreateToken(tokenDescription);
            var accessToken = jwtTokenHandler.WriteToken(token);
            var refreshToken = GenerateRefreshToken();

            //Luu vao Database
            var refreshTokenEntity = new RefreshToken
            {
                Id = Guid.NewGuid(),
                JwtId = token.Id,
                Token = refreshToken,
                IsUsed = false,
                IsRevoked = false,
                CusId = customer.Id,
            };
            _context.Add(refreshTokenEntity);
            _context.SaveChanges();

            return new TokenModel
            {
                AccessToken = accessToken,
                RefreshToken = refreshToken,
            };
        }

        private string GenerateRefreshToken()
        {
            var random = new byte[32];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(random);
                return Convert.ToBase64String(random);
            }
        }

        [Route("RenewToken")]
        [HttpPost]
        public IActionResult RenewToken(TokenModel model)
        {
            var jwtTokenHandler = new JwtSecurityTokenHandler();
            var secretKeyByte = Encoding.UTF8.GetBytes(_appSettings.SecretKey);
            var param = new TokenValidationParameters
            {
                // tu cap token
                ValidateIssuer = false,
                ValidateAudience = false,

                //ky vao token
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(secretKeyByte),

                ClockSkew = TimeSpan.Zero,

                //khong cho kiem tra expire token
                ValidateLifetime = false,
            };
            try
            {
                //Check AccessToken valid format
                var tokenInVerification = jwtTokenHandler.ValidateToken(model.AccessToken, param, out var validatedToken);

                //Check thuat toan algorithm
                if (validatedToken is JwtSecurityToken jwtSecurityToken)
                {
                    var result = jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256);
                    if (!result)
                    {
                        return Ok(new
                        {
                            Success = false,
                            Message = "Invalid Token"
                        });
                    }
                    return Ok(new
                    {
                        Success = true,
                    });
                }

                //Check AccessToken Expire
                var utcExpireDate = long.Parse(tokenInVerification.Claims.FirstOrDefault(x => x.Type == JwtRegisteredClaimNames.Exp).Value);

                var expireDate = ConvertUnixTimeToDateTime(utcExpireDate);
                if (expireDate > DateTime.UtcNow)
                {
                    return Ok(new
                    {
                        Success = false,
                        Message = "Access token has not yet expired"
                    });
                }

                //Check RefreshToken exist in DB
                var storeToken = _context.refreshTokens.FirstOrDefault(rf => rf.Token == model.RefreshToken);
                if (storeToken == null)
                {
                    return Ok(new
                    {
                        Success = false,
                        Message = "Access token does not exist"
                    });
                }

                //Check RefreshToken is used or revoked ?
                if (storeToken.IsUsed)
                {
                    return Ok(new
                    {
                        Success = false,
                        Message = "Access token has been used"
                    });
                }
                if (storeToken.IsRevoked)
                {
                    return Ok(new
                    {
                        Success = false,
                        Message = "Access token has been revoked"
                    });
                }

                //Check AccessToken id == Jwt in RefreshToken
                var jti = tokenInVerification.Claims.FirstOrDefault(x => x.Type == JwtRegisteredClaimNames.Jti).Value;
                if (storeToken.JwtId != jti)
                {
                    return Ok(new
                    {
                        Success = false,
                        Message = "Token is wrong"
                    });
                }

                //Update Token
                storeToken.IsUsed = true;
                storeToken.IsRevoked = true;
                _context.Update(storeToken);
                _context.SaveChanges();

                //Create New Token
                var user = _context.Customers.SingleOrDefault(cus => cus.Id == storeToken.CusId);
                var token = GenerateToke(user);
                return Ok(new
                {
                    Success = true,
                    Message = "RenewToken success",
                    Data = token,
                });
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        private DateTime ConvertUnixTimeToDateTime(long utcExpireDate)
        {
            var dateTimeInterval = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            dateTimeInterval.AddSeconds(utcExpireDate).ToUniversalTime();

            return dateTimeInterval;
        }
    }
}