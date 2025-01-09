namespace Library.API.Contracts
{
    public record BooksRequest(string ISBN, string BookName, string Genre, string Description, Guid BookAuthorId, DateTime BookTook, DateTime BookReturned);
    
}
