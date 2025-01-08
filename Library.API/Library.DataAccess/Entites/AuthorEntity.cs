using Library.Domain.Models;

namespace Library.DataAccess.Entites
{
    public class AuthorEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Surname { get; set; } = string.Empty;
        public DateOnly Birthday { get; set; }
        public string Country { get; set; } = string.Empty;
    }
}
