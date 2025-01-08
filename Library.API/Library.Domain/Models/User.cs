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
        public List<Book> UserBooks { get;} = [];
        public bool AdminRoot { get; }
    }
}
