using System;
using Ru.Kassa.Models.Response;

namespace Ru.Kassa.Models.Exceptions
{
    internal class KassaException : Exception
    {
        internal KassaException(IResponse response)
            : base($"{response.Error}: Другая ошибка ({response.Message}).") {}
    }
}