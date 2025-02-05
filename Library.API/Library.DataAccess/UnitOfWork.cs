using Library.DataAccess.Repositories;
using Library.DataAccess.RepositorIes;
using Library.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DataAccess
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly LibraryDbContext _context;
        public IBooksRepository BooksRepository { get;}
        public IAuthorsRepository AuthorsRepository { get;}
        public IOrderRepositiry OrderRepositiry { get;}
        public UnitOfWork(LibraryDbContext context)
        {
            _context = context;
            BooksRepository = new BooksRepository(context);
            AuthorsRepository = new AuthorsRepository(context);
            OrderRepositiry = new OrderRepository(context);
        }

        public async Task<int> SaveChangesAsync()
        {
            return  await _context.SaveChangesAsync();
        }

        public void Dispose() 
        {
            _context.Dispose();
        }
    }
}
