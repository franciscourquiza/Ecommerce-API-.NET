using e_commerce_API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using e_commerce_API.Models;
using e_commerce_API.Data;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace e_commerce_API.Controllers

{
    [Route("api/[auth]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IUserService _userService;

        public AuthenticationController(IConfiguration configuration, IUserService userService) 
        {
            _configuration = configuration;
            _userService = userService;
        }

        [HttpPost("Login")]
        public ActionResult<string> Login(AuthenticationRequestBody authenticationRequestBody)
        {
            var user = _userService.ValidateUser(authenticationRequestBody);
            if (user == null) 
            {
                return Unauthorized();
            }
            var securityPassword = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_configuration["Authentication:SecretForKey"]));
            var credentials = new SigningCredentials(securityPassword, SecurityAlgorithms.HmacSha256);

        }
    }
