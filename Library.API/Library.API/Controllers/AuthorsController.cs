using Library.API.Contracts;
using Library.Domain.Abstractions;
using Library.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;

namespace Library.API.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class AuthorsController : ControllerBase
    {
        private readonly IAuthorsService _authorsService;
        public AuthorsController(IAuthorsService authorsService)
        {
            _authorsService = authorsService;
        }

        [HttpGet]
        public async Task<ActionResult<List<AuthorsResponce>>> GetAllAuthors() 
        {
            var authors = await _authorsService.GetAll();
            var responce = authors.Select(a => new AuthorsResponce(a.Id, a.Name, a.Surname, a.Birthday, a.Country));

            return Ok(responce);
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<List<AuthorsResponce>>> GetAuthorById(Guid id) 
        {
            var author = await _authorsService.GetById(id);
            var responce = author.Select(a => new AuthorsResponce(a.Id, a.Name, a.Surname, a.Birthday, a.Country)).First();

            return Ok(responce);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> CreateAuthor([FromBody] AuthorsRequest authorR) 
        {
            var (author, error) = Author.AuthorCreate(Guid.NewGuid(), authorR.Name, authorR.Surname, authorR.Birthday, authorR.Country);
            if (!string.IsNullOrEmpty(error)) 
            {
                return BadRequest(error);
            }

            await _authorsService.Create(author);

            return Ok();
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<Guid>> DeleteAuthor(Guid id) 
        {
            return Ok(await _authorsService.Delete(id));
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult<Guid>> UpdateAuthor(Guid id,  [FromBody] AuthorsRequest authorR) 
        {
            var author = await _authorsService.Update(id, authorR.Name, authorR.Surname, authorR.Birthday, authorR.Country);
            return Ok(author);
        }

    }
}
