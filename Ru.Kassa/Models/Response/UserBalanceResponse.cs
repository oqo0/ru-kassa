namespace Ru.Kassa.Models.Response
{
    public class UserBalanceResponse : IResponse
    {
        public string Error { get; set; }
        public string Message { get; set; }
        public decimal Balance { get; set; }
    }
}