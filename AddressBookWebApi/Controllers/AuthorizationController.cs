using AddressBook.Domain.Implementation;
using AddressBook.Domain.Interfaces;
using AddressBook.Model.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace AddressBookWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorizationController : Controller
    {
        private IAuthorizationServices _service;
       
        private readonly IConfiguration _configuration;
        

        public AuthorizationController(IConfiguration configuration, IAuthorizationServices service) { 
            _service = service;
            _configuration = configuration;
        }

        [HttpPost("register")]
        public async void Register(UserRegister LoginInfo)
        {
            _service.RegisterUser(LoginInfo);
        }

        [HttpPost("login")]
        public async Task<ActionResult<string>> Login(UserLoginDto user)
        {
            if(!_service.IsRegistered(user)) {
                return BadRequest("Not valid Credentials");
            }

            string token = CreateToken(user);
            return Ok(token);
        }

        private string CreateToken(UserLoginDto user)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.Role, _service.GetUserRole(user))
            };

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(
                _configuration.GetSection("AppSettings:Token").Value));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: creds);

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }
    }
}
