using Library.Domain.Models;

namespace Library.Application.Services
{
    public interface IBooksService
    {
        Task<List<Book>> GetAllBooks();
        Task<List<Book>> GetById(Guid id);
        Task<List<Book>> GetByISBN(string iSBN);
        Task<List<Book>> GetByAuthorId(Guid authorId);
        Task<Guid> CreateNewBook(Book book);
        Task<Guid> UpdateBookInfo(Guid id, string isbn, string name, string genre, string description, Guid authorId, byte[] image, DateTime? bookTook, DateTime? bookRerutn);
        Task<Guid> DeleteBook(Guid id);
        Task<Guid> AddPhoto(Guid id, byte[] photo);
    }
}