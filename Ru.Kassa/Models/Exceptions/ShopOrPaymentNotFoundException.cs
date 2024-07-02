using System;
using Ru.Kassa.Models.Response;

namespace Ru.Kassa.Models.Exceptions
{
    internal class ShopOrPaymentNotFoundException : Exception
    {
        internal ShopOrPaymentNotFoundException(IResponse response)
            : base($"{response.Error}: Не найден магазин или платёж ({response.Message}).") {}
    }
}