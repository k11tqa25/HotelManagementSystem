using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using WenKaiTsai.HotelManagementSystem.ApplicationCore.Models;
using WenKaiTsai.HotelManagementSystem.ApplicationCore.ServiceInterfaces;

namespace WenKaiTsai.HotelManagementSystem.HotelManagementSystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : Controller
    {
        private readonly IAdminService _adminService;
        private readonly IConfiguration _configuration;

        public AccountController(IAdminService adminService, IConfiguration configuration)
        {
            _adminService = adminService;
            _configuration = configuration;
        }


        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> RegisterAdmin([FromBody]AdminRegisterRequestModel model)
        {
            var createdUser = await _adminService.RegisterUserAsync(model);

            // 200 (Not bad practice)
            //return Ok(createdUser);

            // 201 and send the URL for newly created user also (api/account/user/{id})  (Better practice)
            return CreatedAtRoute(nameof(GetAdminById), new { id = createdUser.Id }, createdUser);
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> LoginUserAsync([FromBody] AdminLoginRequestModel model)
        {
            if (!ModelState.IsValid)
            {
                return Unauthorized();
            }

            // Cookie-based Authenticaiton
            var loggedInUser = await _adminService.LoginAsync(model);
            if (loggedInUser == null) return Unauthorized();

            // Token-based Authentication
            // Create JWT Token
            // Download library System.IdentityModel.Tokens.Jwt & Microsoft.IdentityModel.Tokens
            var jwtToken = CreateJWT(loggedInUser);
            return Ok(new { token = jwtToken });
        }


        [HttpGet]
        [Route("{id:int}", Name = nameof(GetAdminById))]
        public async Task<IActionResult> GetAdminById(int id)
        {
            var user = await _adminService.GetAdminByIdAsync(id);
            if (user == null) return NotFound($"No admin was found with id = {id}");
            return Ok(user);
        }


        private string CreateJWT(AdminLoginResponseModel model)
        {
            // We will use the token libraries to create token.
            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier, model.Id.ToString()),
                new Claim(ClaimTypes.Email, model.Email),
                new Claim(ClaimTypes.Name, model.Name)
            };
            var identityClaims = new ClaimsIdentity(claims);

            // Read the secret key from appsettings, make sure the secret key is unique and not guessable
            // In real world, we use something like Azure KeyVault to store any secrets of the application.
            var secretKey = _configuration["JwtSettings:SecretKey"];

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
            var expires = DateTime.UtcNow.AddDays(_configuration.GetValue<int>("JwtSettings:Expiration"));

            // Pick an hashing algorithm
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);

            // Create the token object that you will use to create the token that will include all the information such as credentials,
            // claims, expiration time...
            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = identityClaims,
                Expires = expires,
                SigningCredentials = credentials,
                Issuer = _configuration["JwtSettings:Issuer"],
                Audience = _configuration["JwtSettings:Audience"],
            };

            var tokenHandler = new JwtSecurityTokenHandler();

            var encodedJwt = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(encodedJwt);
        }
    }
}
