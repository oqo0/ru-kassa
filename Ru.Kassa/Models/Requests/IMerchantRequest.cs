namespace Ru.Kassa.Models.Requests
{
    public interface IMerchantRequest : IRequest
    {
        int ShopId { get; set; }
        string Token { get; set; }
    }
}