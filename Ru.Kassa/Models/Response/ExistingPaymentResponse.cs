namespace Ru.Kassa.Models.Response
{
    public class ExistingPaymentResponse : IResponse
    {
        public string Error { get; set; }
        public string Message { get; set; }
        public int Id { get; set; }
        public int OrderId { get; set; }
        public decimal Amount { get; set; }
        public PaymentStatus Status { get; set; }
        public string Data { get; set; }
    }
}