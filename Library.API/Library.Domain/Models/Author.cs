using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Domain.Models
{
    public class Author
    {
        public Guid Id { get;}
        public string Name { get;} = string.Empty;
        public string Surname { get;} = string.Empty;
        public DateOnly? Birthday { get;}
        public string Country { get;} = string.Empty;
        public List<Book> Books { get;} = [];
    }
}
