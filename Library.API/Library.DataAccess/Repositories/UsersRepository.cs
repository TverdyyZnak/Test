using Library.DataAccess.Entites;
using Library.Domain.Abstractions;
using Library.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Library.DataAccess.Repositories
{
    public class UsersRepository : IUsersRepository
    {
        private readonly LibraryDbContext _context;

        public UsersRepository(LibraryDbContext context)
        {
            _context = context;
        }

        public async Task<List<User>> GetAll()
        {
            var userEntity = await _context.Users.AsNoTracking().ToListAsync();

            var users = userEntity.Select(u => User.UserCreate(u.Id, u.Login , u.Password, u.Email, u.AdminRoot).user).ToList();
            return users;
        }

        public async Task<Guid> Create(User user)
        {
            var userEntity = new UserEntity
            {
                Id = user.Id,
                Login = user.Login,
                Password = user.Password,
                Email = user.Email,
                AdminRoot = user.AdminRoot,
            };

            await _context.AddAsync(userEntity);
            await _context.SaveChangesAsync();

            return user.Id;
        }

        public async Task<Guid> Update(Guid id, string login, string password, string email, bool root)
        {
            await _context.Users.Where(u => u.Id == id).ExecuteUpdateAsync(s => s
                .SetProperty(u => u.Id, u=> id)
                .SetProperty(u => u.Login, u => login)
                .SetProperty(u => u.Password, u => password)
                .SetProperty(u => u.Email, u => email)
                .SetProperty(u => u.AdminRoot, u => root)
            );

            return id;
        }

        public async Task<Guid> Delete(Guid id)
        {
            await _context.Users.Where(u => u.Id == id).ExecuteDeleteAsync();

            return id;
        }
    }
}
