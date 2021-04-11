using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using TodoWebApi.Models;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace TodoWebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuthController : Controller
    {
        private readonly TodoDbContext _context;
        private readonly IConfiguration _configuration;

        public AuthController(TodoDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public class UserViewModel
        {
            public string Name { get; set; }
            public string Password { get; set; }
        }
        private string EncryptPasswrod(string password)
        {
            //TODO: Agregar encriptacion a la tremendamente compleja logica de este metodo.
            return password;
        }

        [HttpPost]
        [Route("[action]")]
        public IActionResult Login([FromForm]UserViewModel model)
        {
            if (string.IsNullOrWhiteSpace(model.Password) || string.IsNullOrWhiteSpace(model.Name))
            {
                return BadRequest();
            }

            var encryptedPassword = EncryptPasswrod(model.Password);
            var user = _context.User.SingleOrDefault(e => e.Name == model.Name && e.Password == encryptedPassword.ToString());
            if (user == null)
            {
                return NotFound();
            }


            var secretKey = _configuration.GetValue<string>("SecretKey");
            var key = Encoding.ASCII.GetBytes(secretKey);

            var claims = new ClaimsIdentity(new[]
            {
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(ClaimTypes.Name, user.Name)
        });


            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = claims,
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var createdToken = tokenHandler.CreateToken(tokenDescriptor);

            return Ok(tokenHandler.WriteToken(createdToken));
        }
    }
}
