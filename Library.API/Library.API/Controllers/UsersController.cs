using Library.API.Contracts;
using Library.Domain.Abstractions;
using Library.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace Library.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUsersService _usersService;

        public UsersController(IUsersService usersService)
        {
            _usersService = usersService;
        }

        [HttpGet]
        public async Task<ActionResult<List<UsersResponce>>> GetAllUsers() 
        {
            var users = await _usersService.GetAll();
            return Ok(users);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> CreateUser([FromBody] UserRequest request) 
        {
            var (user, error) = Library.Domain.Models.User.UserCreate(Guid.NewGuid(), request.login, request.password, request.email, request.root);
            if (!string.IsNullOrEmpty(error)) 
            {
                return BadRequest(error);
            }

            await _usersService.Create(user);
            return Ok();
        }

    }
}
