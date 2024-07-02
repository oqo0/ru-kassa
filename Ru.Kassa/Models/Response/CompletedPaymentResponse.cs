using Newtonsoft.Json;

namespace Ru.Kassa.Models.Response
{
    public class CompletedPaymentResponse : IResponse
    {
        public int Id { get; set; }
        
        [JsonProperty("order_id")]
        public int OrderId { get; set; }
        
        public decimal Amount { get; set; }
        
        [JsonProperty("in_amount")]
        public decimal InAmount { get; set; }
        
        public string Data { get; set; }
        
        public string CreatedDateTime { get; set; }
        
        public PaymentStatus Status { get; set; }
        
        public string Error { get; set; }
        
        public string Message { get; set; }
    }
}