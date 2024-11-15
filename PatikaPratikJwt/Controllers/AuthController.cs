using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;

using Microsoft.AspNetCore.Mvc;

using PatikaPratikJwt.Dtos;
using PatikaPratikJwt.Jwt;
using PatikaPratikJwt.Models;
using PatikaPratikJwt.Services;
using System.IdentityModel.Tokens.Jwt;

namespace PatikaPratikJwt.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;


        public AuthController(IUserService userService)
        {
            _userService = userService;

        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterRequest request)
        {
            var addUserDto = new AddUserDto
            {
                Email = request.Email,
                Password = request.Password,
            };

            var result = await _userService.AddUser(addUserDto);

            if (result.IsSucceed)
                return Ok();
            else
                return BadRequest();

        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequest request)
        {




            var result = await _userService.LoginUser(new LoginUserDto
            {
                Email = request.Email,
                Password = request.Password
            });

            if (!result.IsSucceed) BadRequest(result.Message);

            var user = result.Data;

            var configuration = HttpContext.RequestServices.GetRequiredService<IConfiguration>();

            var token = JwtHelper.GenerateJwtToken(new JwtDto
            {
                Id = user.Id,
                Email = user.Email,
                UserType = user.UserType,
                SecretKey = configuration["Jwt:SecretKey"]!,
                Issuer = configuration["Jwt:Issuer"]!,
                Audience = configuration["Jwt:Audience"]!,
                ExpireMinutes = int.Parse(configuration["Jwt:ExpireMinutes"]!)
            });

            return Ok(new LoginResponse
            {
                Message = "Giriş Yapıldı",
                Token = token,
            });

        }

        [HttpGet]
        [Authorize]

        public IActionResult Get()
        {
        return Ok();
        }
    }
}

