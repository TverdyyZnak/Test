using Library.Domain.Models;

namespace Library.DataAccess.Entites
{
    public class BookEntity
    {
        public Guid Id { get; set; }
        public string ISBN { get; set; } = string.Empty;
        public string BookName { get; set; } = string.Empty;
        public string Genre { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public Guid BookAuthorId { get; set; }
        public DateTime BookTook { get; set; }
        public DateTime BookReturned { get; set; }
        public byte[] Image { get; set; } = [];

    }
}
