using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Domain.Abstractions
{
    public interface IUnitOfWork : IDisposable
    {
        IAuthorsRepository AuthorsRepository { get; }
        IBooksRepository BooksRepository { get; }
        IOrderRepositiry OrderRepositiry { get; }

        Task<int> SaveChangesAsync();
    }
}
