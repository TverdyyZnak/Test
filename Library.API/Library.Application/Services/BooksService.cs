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

        public async Task<Guid> CreateNewBook(Book book) 
        {
            return await _bookRepository.Create(book);
        }

        public async Task<Guid> UpdateBookInfo(Guid id, string isbn, string name, string genre, string description, Guid authorId, DateTime bookTook, DateTime bookRerutn, byte[] image) 
        {
            return await _bookRepository.Update(id, isbn, name, genre, description, authorId, bookTook, bookRerutn, image);
        }

        public async Task<Guid> DeleteBook(Guid id) 
        {
            return await _bookRepository.Delete(id);
        }
    }
}
