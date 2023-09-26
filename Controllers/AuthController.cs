using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Sample.Models;

namespace Sample.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public AuthController(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        [HttpPost]
        public IActionResult Authenticate([FromBody] Credential credential)
        {
            if (credential.UserName == "admin" && credential.Password == "password")
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, credential.UserName),
                    new Claim(ClaimTypes.Email, "admin@sailssoftware.com"),
                    new Claim("Department","HR"),
                    new Claim ("Admin","True"),
                    new Claim("Manager","True")
                };
                var expiresAt = DateTime.UtcNow.AddMinutes(20);
                return Ok(new
                {
                    access_token = CreateToken(claims, expiresAt),
                    expires_at = expiresAt,
                });
            }
            ModelState.AddModelError("Unauthorized", "You don't have access");
            return Unauthorized(ModelState);
        }


        private string CreateToken(IEnumerable<Claim> claims, DateTime expiresAt)
        {
            var secretkey = Encoding.ASCII.GetBytes(_configuration.GetValue<string>("SecretKey") ?? "");
            var jwt = new JwtSecurityToken(
                claims: claims,

                notBefore: DateTime.UtcNow,
                expires: expiresAt,
                signingCredentials: new SigningCredentials(
                    new SymmetricSecurityKey(secretkey),
                    SecurityAlgorithms.HmacSha256)
         );
            return new JwtSecurityTokenHandler().WriteToken(jwt);
        }




    }
}
