using Ru.Kassa.Helpers.Attributes;

namespace Ru.Kassa.Models.Requests.Merchant
{
    /// <summary>
    /// Запрос с данными для получения данных о выводе средств
    /// </summary>
    public class WithdrawalMerchantRequest : IMerchantRequest
    {
        [FormDataHeader("shop_id")]
        public int ShopId { get; set; }
        
        [FormDataHeader("token")]
        public string Token { get; set; }
        
        [FormDataHeader("id")]
        public string Id { get; set; }
    }
}