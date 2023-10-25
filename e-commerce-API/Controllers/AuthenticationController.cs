using e_commerce_API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using e_commerce_API.Models;
using e_commerce_API.Data;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;

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

            var claimsForToken = new List<Claim>();
            claimsForToken.Add(new Claim("sub", user.Id.ToString()));
            claimsForToken.Add(new Claim("given_name", user.Name));
            claimsForToken.Add(new Claim("family_name", user.LastName)); // cambiar mas adelante

            var jwtToken = new JwtSecurityToken(
            _configuration["Authentication:Issuer"],
            _configuration["Authentication:Audience"],
            claimsForToken,
            DateTime.UtcNow,
            DateTime.UtcNow.AddHours(1),
            credentials);

            var tokenToReturn = new JwtSecurityTokenHandler()
                .WriteToken(jwtToken);
                
            return Ok(tokenToReturn);
        }
    }
}
