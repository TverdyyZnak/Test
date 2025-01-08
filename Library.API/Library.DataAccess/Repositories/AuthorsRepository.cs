
using Library.DataAccess.Entites;
using Library.Domain.Abstractions;
using Library.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Library.DataAccess.RepositorIes
{
    public class AuthorsRepository : IAuthorsRepository
    {
        private readonly LibraryDbContext _context;

        public AuthorsRepository(LibraryDbContext context) 
        {
            _context = context;
        }

        public async Task<List<Author>> GetAll() 
        {
            var authorsEntity = await _context.Authors.AsNoTracking().ToListAsync();

            var authors = authorsEntity.Select(b => Author.AuthorCreate(b.Id, b.Name, b.Surname, b.Birthday, b.Country).Author).ToList();
            return authors;
        }

        public async Task<Guid> Create(Author author) 
        {
            var authorEntity = new AuthorEntity
            {
                Id = author.Id,
                Name = author.Name,
                Surname = author.Surname,
                Birthday = author.Birthday,
                Country = author.Country,
            };

            await _context.AddAsync(authorEntity);
            await _context.SaveChangesAsync();
            
            return author.Id;
        }

        public async Task<Guid> Update(Guid id, string name, string surname, DateOnly birthday) 
        {
            await _context.Authors.Where(a => a.Id == id).ExecuteUpdateAsync(s => s
                .SetProperty(a => a.Id, a => id)
                .SetProperty(a => a.Name, a => name)
                .SetProperty(a => a.Surname, a => surname)
                .SetProperty(a => a.Birthday, a => birthday)
            );

            return id;
        }

        public async Task<Guid> Delete(Guid id) 
        {
            await _context.Authors.Where(a => a.Id == id).ExecuteDeleteAsync();
            
            return id;
        }

    }
}
