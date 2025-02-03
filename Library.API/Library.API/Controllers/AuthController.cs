using Library.API.Contracts;
using Library.Application.Services;
using Library.Domain.Abstractions;
using Library.Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;
using System.Text;

namespace Library.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly JwtTokenGenerator _jwtTokenGenerator;
        private readonly IUsersService _usersService;
        public AuthController(JwtTokenGenerator jwtTokenGenerator, IUsersService usersService)
        {
            _jwtTokenGenerator = jwtTokenGenerator;
            _usersService = usersService;
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<ActionResult> Login([FromBody] LoginRequest request) 
        {
            var userList = await _usersService.GetUserByLogin(request.userLogin);

            User? user = userList.FirstOrDefault();

            if(user == null) 
            {
                return Unauthorized("Пользователя с таким логином не существует");
            }

            if (request.userLogin == user.Login && Convert.ToHexString(SHA256.Create().ComputeHash(Encoding.ASCII.GetBytes(request.userPassword))) == user.Password)
            {
                string role = string.Empty;
                if (user.AdminRoot)
                {
                    role = "Admin";
                }
                else 
                {
                    role = "User";
                }

                var token = _jwtTokenGenerator.GenerateToken(user.Id.ToString(), role);
                return Ok(new {Token = token});
            }
            return Unauthorized("Неверный логин или пароль");


        }
    }
}
