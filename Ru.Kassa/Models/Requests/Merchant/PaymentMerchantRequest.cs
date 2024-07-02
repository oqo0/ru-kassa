using Ru.Kassa.Helpers.Attributes;

namespace Ru.Kassa.Models.Requests.Merchant
{
    /// <summary>
    /// Запрос с данными для создания платежа
    /// </summary>
    public class PaymentMerchantRequest : IMerchantRequest
    {
        [FormDataHeader("shop_id")]
        public int ShopId { get; set; }
        
        [FormDataHeader("token")]
        public string Token { get; set; }
        
        [FormDataHeader("order_id")]
        public int OrderId { get; set; }
        
        [FormDataHeader("amount")]
        public decimal Amount { get; set; }
        
        [FormDataHeader("currency")]
        public Currency Currency { get; set; }
        
        [FormDataHeader("method")]
        public string Method { get; set; }
        
        [FormDataHeader("data")]
        public string Data { get; set; }
    }
}