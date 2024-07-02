namespace Ru.Kassa.Models.Requests
{
    public interface IUserRequest : IRequest
    {
        string Email { get; set; }
        string Password { get; set; }
    }
}