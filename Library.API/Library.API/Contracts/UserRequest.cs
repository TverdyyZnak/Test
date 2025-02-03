namespace Library.API.Contracts
{
    public record UserRequest(string login, string password, string email, bool root);
    
}
