using Library.API.Contracts;
using Library.Application.Services;
using Library.Domain.Models;
using Microsoft.AspNetCore.Authorization;
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

            var response = books.Select(b => new BooksResponce(b.Id, b.ISBN, b.BookName, b.Genre, b.Description, b.BookAuthorId, b.Image, b.BookTook, b.BookReturned));

            return Ok(response);
        }

        [HttpGet("by-id/{id:guid}")]
        public async Task<ActionResult<List<BooksResponce>>> GetBooksById(Guid id) 
        {
            var books = await _booksService.GetById(id);
            var responce = books.Select(b => new BooksResponce(b.Id, b.ISBN, b.BookName, b.Genre, b.Description, b.BookAuthorId, b.Image, b.BookTook, b.BookReturned)).Where(b => b.Id == id);
            return Ok(responce);
        }

        [HttpGet("by-isbn/{isbn}")]
        public async Task<ActionResult<List<BooksResponce>>> GetBooksByISBN(string isbn) 
        {
            var books = await _booksService.GetByISBN(isbn);
            var responce = books.Select(b => new BooksResponce(b.Id, b.ISBN, b.BookName, b.Genre, b.Description, b.BookAuthorId, b.Image, b.BookTook, b.BookReturned)).Where(b => b.ISBN == isbn);
            return Ok(responce);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> CreateBook([FromBody] BooksRequest bRequest) 
        {
            var (book, error) = Book.BookCreate(Guid.NewGuid(), bRequest.ISBN, bRequest.BookName, bRequest.Genre, bRequest.Description, bRequest.BookAuthorId, bRequest.Image, bRequest.BookTook, bRequest.BookReturned);
            if (!string.IsNullOrEmpty(error)) 
            {
                return BadRequest(error);
            }

            await _booksService.CreateNewBook(book);
            
            return Ok();
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<Guid>> DeleteBook(Guid id) 
        {
            return Ok(await _booksService.DeleteBook(id));
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult<Guid>> UpdateBook(Guid id, [FromBody] BooksRequest booksRequest) 
        {
            var updateBook = await _booksService.UpdateBookInfo(id, booksRequest.ISBN, booksRequest.BookName, booksRequest.Genre, booksRequest.Description, booksRequest.BookAuthorId, booksRequest.Image, booksRequest.BookTook, booksRequest.BookReturned);

            return Ok(updateBook);
        }

        [HttpPut("books/add-photo/{id:guid}")]
        public async Task<ActionResult<Guid>> AddPhoto(Guid id, byte[] photo) 
        {
            var addPhoto = await _booksService.AddPhoto(id, photo);
            return Ok(addPhoto);
        }


        [HttpGet("by-author/{authorId:guid}")]
        public async Task<ActionResult<List<Book>>> GetBookByAuthorId(Guid authorId) 
        {
            var books = await _booksService.GetByAuthorId(authorId);
            var responce = books.Select(b => new BooksResponce(b.Id, b.ISBN, b.BookName, b.Genre, b.Description, b.BookAuthorId, b.Image, b.BookTook, b.BookReturned)).Where(a => a.BookAuthorId == authorId);
            return Ok(responce);
        }


    }
}
