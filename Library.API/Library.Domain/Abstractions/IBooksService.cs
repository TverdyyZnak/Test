using Library.Domain.Models;

namespace Library.Application.Services
{
    public interface IBooksService
    {
        Task<List<Book>> GetAllBooks();
        Task<Guid> CreateNewBook(Book book);
        Task<Guid> UpdateBookInfo(Guid id, string isbn, string name, string genre, string description, Guid authorId, DateTime bookTook, DateTime bookRerutn, byte[] image);
        Task<Guid> DeleteBook(Guid id);
    }
}