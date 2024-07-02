using Ru.Kassa.Helpers.Attributes;

namespace Ru.Kassa.Models.Requests.User
{
    public class WithdrawalUserRequest : IUserRequest
    {
        [FormDataHeader("email")]
        public string Email { get; set; }
        
        [FormDataHeader("password")]
        public string Password { get; set; }
        
        [FormDataHeader("way")]
        public string Way { get; set; }
        
        [FormDataHeader("wallet")]
        public string Wallet { get; set; }
        
        [FormDataHeader("amount")]
        public decimal Amount { get; set; }
        
        [FormDataHeader("from")]
        public string From { get; set; }
        
        [FormDataHeader("who_fee")]
        public int WhoFee { get; set; }
    }
}