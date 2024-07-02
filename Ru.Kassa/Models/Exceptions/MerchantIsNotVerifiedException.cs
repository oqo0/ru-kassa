using System;
using Ru.Kassa.Models.Response;

namespace Ru.Kassa.Models.Exceptions
{
    internal class MerchantIsNotVerifiedException : Exception
    {
        internal MerchantIsNotVerifiedException(IResponse response)
            : base($"{response.Error}: Мерчант не прошёл проверку ({response.Message}).") {}
    }
}