using Clinic.Application.UseCases.AuthService;
using Clinic.Domain.DTOs;
using Clinic.Domain.Entities.Auth;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;

namespace Clinic.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly IAuthService _authService;

        public AuthController(UserManager<User> userManager, IAuthService authService)
        {
            _userManager = userManager;
            _authService = authService;
        }

        [HttpPost]
        [EnableRateLimiting("bucket")]

        public async Task<IActionResult> Register(RegisterDTO register)
        {
            if (!ModelState.IsValid)
            {
                throw new Exception();
            }


            var user = new User()
            {
                Email = register.Email,
                Firsname = register.Firstname,
                Lastname = register.Lastname,
                UserName = register.Username,
                Role = "User"
            };

            var result = await _userManager.CreateAsync(user, register.Password);

            if (!result.Succeeded)
                throw new Exception();

            await _userManager.AddToRoleAsync(user, "User");

            return Ok(new ResponseModel()
            {
                IsSuccess = true,
                Message = "Muvaffaqiyatli yaratildi",
                StatusCode = 201
            });

        }

        [HttpPost]
        [EnableRateLimiting("bucket")]

        public async Task<IActionResult> Login(LoginDTO login)
        {
            //throw new Exception();
            if (!ModelState.IsValid)
            {
                throw new Exception();
            }
            var user = await _userManager.FindByEmailAsync(login.Email);

            if (user == null)
            {
                return BadRequest(new TokenDTO()
                {
                    Message = "Email Not found",
                    isSuccess = false,
                    Token = ""
                });
            }

            var checker = await _userManager.CheckPasswordAsync(user, login.Password);
            if (!checker)
            {
                return BadRequest(new TokenDTO()
                {
                    Message = "Password not match",
                    isSuccess = false,
                    Token = ""
                });
            }

            var token = await _authService.GenerateToken(user);

            return Ok(new TokenDTO()
            {
                Token = token,
                isSuccess = true,
                Message = "Success"
            });

        }
    }
}
