using Library.Domain.Models;


namespace Library.Domain.Abstractions
{
    public interface IBooksRepository
    {
        Task<List<Book>> Get();
        Task<List<Book>> GetById(Guid id);
        Task<List<Book>> GetByISBN(string isbn);
        Task<List<Book>> GetByAuthorId(Guid authorId);
        Task<Guid> Create(Book book);
        Task<Guid> Update(Guid id, string isbn, string name, string genre, string description, Guid authorId, byte[] image, DateTime? bookTook, DateTime? bookRerutn);
        Task<Guid> Delete(Guid id);
        Task<Guid> AddPhoto(Guid id, byte[] photo);
        
    }
}
