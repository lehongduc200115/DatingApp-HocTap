using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography.X509Certificates;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Threading.Tasks;
using DatingApp.API.Data;
using DatingApp.API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace DatingApp.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly DataContext2 _dbcontext;
        private readonly IConfiguration _configuration;

        public AuthController(DataContext2 dbcontext, IConfiguration configuration)
        {
            _dbcontext = dbcontext;
            _configuration = configuration;
        }


        [HttpPost("Register")]
        public IActionResult Register(string username, string password)
        {
            var usr = _dbcontext.User.FirstOrDefault<User>(x => x.Username == username);
            if (usr != null)
            {
                return BadRequest();
            }
            else
            {
                var newusr = new User { Username = username, Password = password };
                _dbcontext.User.Add(newusr);
                _dbcontext.SaveChanges();
                return Ok();
            }
        }

        [HttpPost("login")]
        public IActionResult Login(User user)
        {
            var usr = _dbcontext.User.FirstOrDefault<User>(x => x.Username == user.Username);
            if (usr == null)
            {
                return Unauthorized();
            }
            else
            {
                return new ObjectResult(CreateJWT(user.Username));
            }
        }

        public dynamic CreateJWT(string username)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.Name, username)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("AppSettings:Token").Value));

            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(0.5),
                SigningCredentials = cred
            };

            var tokenHandler = new JwtSecurityTokenHandler();

            var token = tokenHandler.CreateToken(tokenDescriptor);

            var result = new
            {
                token = tokenHandler.WriteToken(token)
            };
            return result;
        }

        //[AllowAnonymous]
        [HttpGet("GetHttpContext")]
        public IActionResult GetHttpContext()
        {
            var x = HttpContext;
            return Ok();
        }
    }
}
