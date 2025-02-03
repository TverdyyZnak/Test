using Library.Domain.Abstractions;
using Library.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Services
{
    public class UsersService : IUsersService
    {
        private readonly IUsersRepository _usersRepository;

        public UsersService(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }

        public async Task<List<User>> GetAll() 
        {
            return await _usersRepository.GetAll();
        }

        public async Task<Guid> Create(User user) 
        {
            return await _usersRepository.Create(user);
        }

        public async Task<Guid> Update(Guid id, string login, string password, string email, bool root) 
        {
            return await _usersRepository.Update(id, login, password, email, root);
        }

        public async Task<Guid> Delete(Guid id) 
        {
            return await _usersRepository.Delete(id);
        }

        public async Task<List<User>> GetUserByLogin(string login) 
        {
            return await _usersRepository.GetUserByLogin(login);
        }
    }
}
