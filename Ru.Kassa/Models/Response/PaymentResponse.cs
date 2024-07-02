namespace Ru.Kassa.Models.Response
{
    public class PaymentResponse : IResponse
    {
        public int Id { get; set; }
        public string Hash { get; set; }
        public string Url { get; set; }
        public string Error { get; set; }
        public string Message { get; set; }
    }
}