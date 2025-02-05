using Library.Domain.Abstractions;
using Library.Domain.Models;

namespace Library.Application.Services
{
    public class BooksService : IBooksService
    {
        private readonly IUnitOfWork _unitOfWork;
        public BooksService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<Book>> GetAllBooks() 
        {
            return await _unitOfWork.BooksRepository.Get();
        }

        public async Task<List<Book>> GetById(Guid id) 
        {
            return await _unitOfWork.BooksRepository.GetById(id);
        }
        public async Task<List<Book>> GetByISBN(string isbn) 
        {
            return await _unitOfWork.BooksRepository.GetByISBN(isbn);
        }
        public async Task<List<Book>> GetByAuthorId(Guid authorId) 
        {
            return await _unitOfWork.BooksRepository.GetByAuthorId(authorId);
        }
        public async Task<Guid> CreateNewBook(Book book) 
        {
            var bookId = await _unitOfWork.BooksRepository.Create(book);
            await _unitOfWork.SaveChangesAsync();
            return bookId;

        }

        public async Task<Guid> UpdateBookInfo(Guid id, string isbn, string name, string genre, string description, Guid authorId, byte[] image, DateTime? bookTook, DateTime? bookRerutn) 
        {
            return await _unitOfWork.BooksRepository.Update(id, isbn, name, genre, description, authorId, image, bookTook, bookRerutn);
        }

        public async Task<Guid> DeleteBook(Guid id) 
        {
            return await _unitOfWork.BooksRepository.Delete(id);
        }

        public async Task<Guid> AddPhoto(Guid id, byte[] photo) 
        {
            return await _unitOfWork.BooksRepository.AddPhoto(id, photo);
        }
    }
}
