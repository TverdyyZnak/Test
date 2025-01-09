using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Domain.Models
{
    public class User
    {
        public Guid Id { get;}
        public string Login { get;} = string.Empty;
        public string Password { get;} = string.Empty;
        public string Email { get;} = string.Empty;
        public bool AdminRoot { get; } = false;

        private User(Guid id, string login, string password, string email, bool adminRoot)
        {
            Id = id;
            Login = login;
            Password = password;
            Email = email;
            AdminRoot = adminRoot;
        }

        public static (User user, string error) UserCreate(Guid id, string login, string password, string email, bool adminRoot) 
        {
            string error = string.Empty;





            var user = new User(id, login, password, email, adminRoot);

            return (user, error);
        }
    }
}
