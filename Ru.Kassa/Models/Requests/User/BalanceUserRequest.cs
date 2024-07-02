using Ru.Kassa.Helpers.Attributes;

namespace Ru.Kassa.Models.Requests.User
{
    public class BalanceUserRequest : IUserRequest
    {
        [FormDataHeader("email")]
        public string Email { get; set; }
        
        [FormDataHeader("password")]
        public string Password { get; set; }
    }
}