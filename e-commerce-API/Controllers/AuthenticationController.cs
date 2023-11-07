using e_commerce_API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using e_commerce_API.Models;
using e_commerce_API.Data;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using e_commerce_API.Data.Entities;

namespace e_commerce_API.Controllers

{
    [Route("api/[controller]")]
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

        [HttpPost]
        public IActionResult Login([FromBody] AuthenticationRequestBody authenticationRequestBody)
        {
            Tuple<bool, User?> validationResponse = _userService.ValidateUser(authenticationRequestBody.Email, authenticationRequestBody.Password);
            if (!validationResponse.Item1 && validationResponse.Item2 == null) 
            {
                return NotFound("Email no existente");
            }
            else if (!validationResponse.Item1 && validationResponse.Item2 != null)
                return Unauthorized("Contraseña incorrecta");

            var securityPassword = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_configuration["Authentication:SecretForKey"]));
            var credentials = new SigningCredentials(securityPassword, SecurityAlgorithms.HmacSha256);

            var claimsForToken = new List<Claim>();
            claimsForToken.Add(new Claim("sub", validationResponse.Item2.Email));
            claimsForToken.Add(new Claim("given_name", validationResponse.Item2.Name));
            claimsForToken.Add(new Claim("role", validationResponse.Item2.UserType)); // cambiar mas adelante

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
