namespace Library.API.Contracts
{
    public record AuthorsResponce(Guid id, string Name, string Surname, DateOnly Birthday, string Country);
    
}
