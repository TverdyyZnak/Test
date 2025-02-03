namespace Library.API.Contracts
{
    public record AuthorsRequest(string Name, string Surname, DateOnly Birthday, string Country);
}
