using Library.DataAccess;
using Library.DataAccess.Entites;
using Library.DataAccess.RepositorIes;
using Library.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Xunit;


namespace Library.API.Test
{
    public class BookUseCaseTest
    {
        private readonly LibraryDbContext _context;
        private readonly BooksRepository _booksRepository;

        public BookUseCaseTest()
        {
            var options = new DbContextOptionsBuilder<LibraryDbContext>()
                .UseInMemoryDatabase(databaseName: $"LibraryTestDb_{Guid.NewGuid()}")
                .Options;

            _context = new LibraryDbContext(options);

            _context.Database.EnsureDeleted();
            _context.Database.EnsureCreated();

            _booksRepository = new BooksRepository(_context);

            SeedDatabase();
        }

        private void SeedDatabase()
        {
            _context.Books.AddRange(
                new BookEntity { Id = Guid.NewGuid(), ISBN = "12345", BookName = "Книга 1", Genre = "Хоррор", Description = "Описание 1", BookAuthorId = Guid.NewGuid(), Image = [], BookTook = null, BookReturned = null },
                new BookEntity { Id = Guid.NewGuid(), ISBN = "67890", BookName = "Книга 2", Genre = "Детектив", Description = "Описание 2", BookAuthorId = Guid.NewGuid(), Image = [], BookTook = null, BookReturned = null },
                new BookEntity { Id = Guid.NewGuid(), ISBN = "45676", BookName = "Книга 3", Genre = "Детектив", Description = "Описание 3", BookAuthorId = Guid.NewGuid(), Image = [], BookTook = null, BookReturned = null }
            );
            _context.SaveChanges();
        }


        [Fact]
        public async Task Get_Should_Return_All_Books()
        {
            var books = await _booksRepository.Get();

            

            Assert.NotNull(books);
            Assert.Equal(3, books.Count);
        }

        [Fact]
        public async Task GetById_Should_Return_Correct_Book()
        {
            var expectedBook = await _context.Books.FirstAsync();

            var result = await _booksRepository.GetById(expectedBook.Id);

            Assert.Single(result);
            Assert.Equal(expectedBook.Id, result[0].Id);
        }

        [Fact]
        public async Task Create_Should_Add_Book()
        {

            var (newBook, error) = Book.BookCreate(Guid.NewGuid(), "54321", "Новая книга", "Научная фантастика", "Описание новой книги", Guid.NewGuid(), [], null, null);

            var result = await _booksRepository.Create(newBook);
            await _context.SaveChangesAsync();

            var createdBook = await _context.Books.FindAsync(result);
            Assert.NotNull(createdBook);
            Assert.Equal("Новая книга", createdBook.BookName);
        }

        [Fact]
        public async Task GetByISBN_Should_Return_Book()
        {
            var isbn = "12345";

            var result = await _booksRepository.GetByISBN(isbn);

            Assert.NotNull(result);
            Assert.Single(result);
            Assert.Equal(isbn, result[0].ISBN);
        }

        [Fact]
        public async Task GetByAuthorId_Should_Return_Books()
        {
            var authorId = _context.Books.First().BookAuthorId;

            var result = await _booksRepository.GetByAuthorId(authorId);

            Assert.NotNull(result);
            Assert.NotEmpty(result);
            Assert.All(result, book => Assert.Equal(authorId, book.BookAuthorId));
        }
    }
}