using Library.API.Contracts;
using Library.Application.Services;
using Library.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace Library.API.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class BooksController : ControllerBase
    {
        private readonly IBooksService _booksService;
        public BooksController(IBooksService booksService)
        {
            _booksService = booksService;
        }

        [HttpGet]
        public async Task<ActionResult<List<BooksResponce>>> GetBooks() 
        {
            var books = await _booksService.GetAllBooks();

            var response = books.Select(b => new BooksResponce(b.Id, b.ISBN, b.BookName, b.Genre, b.Description, b.BookAuthorId, b.BookTook, b.BookReturned, b.Image));

            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> CreateBook([FromBody] BooksRequest bRequest) 
        {
            var (book, error) = Book.BookCreate(Guid.NewGuid(), bRequest.ISBN, bRequest.BookName, bRequest.Genre, bRequest.Description, bRequest.BookAuthorId, bRequest.BookTook, bRequest.BookReturned, []);
            if (!string.IsNullOrEmpty(error)) 
            {
                return BadRequest(error);
            }

            await _booksService.CreateNewBook(book);
            
            return Ok();
        }
          



    }
}
