using Library.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Domain.Abstractions
{
    public interface IUsersRepository
    {
        Task<List<User>> GetAll();
        Task<Guid> Create(User user);
        Task<Guid> Update(Guid id, string login, string password, string email, bool root);
        Task<Guid> Delete(Guid id);
    }
}
