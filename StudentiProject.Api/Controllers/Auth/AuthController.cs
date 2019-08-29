using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using StudentiProject.Model.Users;
using StudentiProject.Requests.Auth;
using StudentiProject.Responses;
using StudentiProject.Services.Contracts;

namespace StudentiProject.Controllers.Auth
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : AppController
    {
        private readonly SignInManager<AuthUser> _signInManager;
        private readonly UserManager<AuthUser> _userManager;
        private readonly IConfiguration _configuration;
        public AuthController(
            UserManager<AuthUser> userManager,
            SignInManager<AuthUser> signInManager,
            IConfiguration configuration
            )
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
        }
        [HttpPost("login")]
        public async Task<RegisterResponse> Login([FromBody] LoginRequest model)
        {
            var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, false, false);
            if (result.Succeeded)
            {
                var appUser = _userManager.Users.SingleOrDefault(r => r.Email == model.Email);
                return new RegisterResponse
                {
                    User = new AuthUserResponse
                    {
                        Id = appUser.Id,
                        Email = appUser.Email
                    },
                    Token = GenerateJwtToken(appUser.Email, appUser).ToString()
                };
            }
            throw new ApplicationException("INVALID_LOGIN_ATTEMPT");
        }
        [HttpPost("register")]
        public async Task<object> Register([FromBody] RegisterRequest model)
        {
            var user = new AuthUser
            {
                UserName = model.Email,
                Email = model.Email,
                FirstName = model.FirstName,
                LastName = model.LastName
            };
            var result = await _userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                await _signInManager.SignInAsync(user, false);
                
                return new RegisterResponse
                {
                    User = new AuthUserResponse
                    {
                        Id = user.Id,
                        Email = user.Email
                    },
                    Token = GenerateJwtToken(user.Email, user).ToString()
                };
            }
            throw new ApplicationException("UNKNOWN_ERROR");
        }
        [Authorize]
        [HttpGet]
        public object Protected()
        {
            return "Protected area";
        }
        private object GenerateJwtToken(string email, AuthUser user)
        {
            var claims = new List<Claim>
           {
               new Claim(JwtRegisteredClaimNames.Sub, email),
               new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
               // new Claim(ClaimTypes.NameIdentifier, user.Id)
           };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtKey"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expires = DateTime.Now.AddDays(Convert.ToDouble(_configuration["JwtExpireDays"]));
            var token = new JwtSecurityToken(
                _configuration["JwtIssuer"],
                _configuration["JwtIssuer"],
                claims,
                expires: expires,
                signingCredentials: creds
            );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}