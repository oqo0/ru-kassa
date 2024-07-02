namespace Ru.Kassa.Models.Response
{
    public class WithdrawalResponse : IResponse
    {
        public string Error { get; set; }
        public string Message { get; set; }
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public decimal Fee { get; set; }
        public string Way { get; set; }
        public string WhoFee { get; set; }
        public string Status { get; set; }
    }
}