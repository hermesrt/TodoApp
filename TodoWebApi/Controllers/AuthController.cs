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
using TodoWebApi.Helpers;
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
            public string Email { get; set; }
            public string Password { get; set; }
        }


        [HttpPost]
        [Route("[action]")]
        public IActionResult Login([FromBody] UserViewModel model)
        {
            if (string.IsNullOrWhiteSpace(model.Password) || string.IsNullOrWhiteSpace(model.Email))
            {
                return BadRequest();
            }

            var targetUser = _context.User.SingleOrDefault(e => e.Email == model.Email);
            if (targetUser == null)
            {
                return NotFound();
            }

            var hashedPass = SecurityHelper.HashPassword(model.Password, targetUser.Salt);
            if (hashedPass != targetUser.Password)
            {
                return Unauthorized();
            }

            var secretKey = _configuration.GetValue<string>("SecretKey");
            var key = Encoding.ASCII.GetBytes(secretKey);

            var claims = new ClaimsIdentity(new[]
            {
            new Claim("Id", targetUser.Id.ToString()),
            new Claim("Email", targetUser.Email)
        });


            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = claims,
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var createdToken = tokenHandler.CreateToken(tokenDescriptor);

            return Ok(new { token = tokenHandler.WriteToken(createdToken)});
        }

        [HttpPost]
        [Route("[action]")]
        public IActionResult SignUp([FromBody] UserViewModel model)
        {
            var salt = SecurityHelper.GenerateSalt();
            var hashedPasswod = SecurityHelper.HashPassword(model.Password, salt);
            _context.User.Add(new Models.User
            {
                Email = model.Email,
                Password = hashedPasswod,
                Salt = salt
            });
            _context.SaveChanges();
            return Ok();
        }
    }
}
