using Library.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DataAccess.RepositorIes
{
    public interface IBooksRepository
    {
        Task<List<Book>> Get();
        Task<Guid> Create(Book book);
        Task<Guid> Update(Guid id, Guid isbn, string name, string genre, string description, Guid authorId, DateTime bookTook, DateTime bookRerutn, byte[] image);
        Task<Guid> Delete(Guid id);
        
    }
}
