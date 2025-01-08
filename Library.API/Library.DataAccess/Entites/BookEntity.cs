using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DataAccess.Entites
{
    public class BookEntity
    {
        public Guid Id { get; set; }
        public Guid ISBN { get; set;  }
        public string BookName { get; set; } = string.Empty;
        public string Genre { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public Guid BookAuthorId { get; set; }
        public DateTime BookTook { get; set; }
        public DateTime BookReturned { get; set; }
        public byte[] Image { get; set; } = [];

    }
}
