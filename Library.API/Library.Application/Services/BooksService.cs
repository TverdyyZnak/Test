using Library.Domain.Abstractions;
using Library.Domain.Models;

namespace Library.Application.Services
{
    public class BooksService : IBooksService
    {
        private readonly IBooksRepository _bookRepository;
        public BooksService(IBooksRepository booksRepository)
        {
            _bookRepository = booksRepository;
        }

        public async Task<List<Book>> GetAllBooks() 
        {
            return await _bookRepository.Get();
        }

        public async Task<List<Book>> GetById(Guid id) 
        {
            return await _bookRepository.GetById(id);
        }
        public async Task<List<Book>> GetByISBN(string isbn) 
        {
            return await _bookRepository.GetByISBN(isbn);
        }
        public async Task<List<Book>> GetByAuthorId(Guid authorId) 
        {
            return await _bookRepository.GetByAuthorId(authorId);
        }
        public async Task<Guid> CreateNewBook(Book book) 
        {
            return await _bookRepository.Create(book);
        }

        public async Task<Guid> UpdateBookInfo(Guid id, string isbn, string name, string genre, string description, Guid authorId, byte[] image, DateTime? bookTook, DateTime? bookRerutn) 
        {
            return await _bookRepository.Update(id, isbn, name, genre, description, authorId, image, bookTook, bookRerutn);
        }

        public async Task<Guid> DeleteBook(Guid id) 
        {
            return await _bookRepository.Delete(id);
        }

        public async Task<Guid> AddPhoto(Guid id, byte[] photo) 
        {
            return await _bookRepository.AddPhoto(id, photo);
        }
    }
}
