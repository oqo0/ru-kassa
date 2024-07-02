using Ru.Kassa.Helpers.Attributes;

namespace Ru.Kassa.Models.Requests.Merchant
{
    /// <summary>
    /// Запрос с данными для получения данных уже существующего платежа
    /// </summary>
    public class ExistingPaymentMerchantRequest : IMerchantRequest
    {
        [FormDataHeader("shop_id")]
        public int ShopId { get; set; }
        
        [FormDataHeader("token")]
        public string Token { get; set; }
        
        [FormDataHeader("id")]
        public int Id { get; set; }
    }
}