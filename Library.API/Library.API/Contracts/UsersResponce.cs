namespace Library.API.Contracts
{
    public record UsersResponce(Guid id, string login, string password, string email, bool root);
}
