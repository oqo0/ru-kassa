using System;
using Ru.Kassa.Models.Response;

namespace Ru.Kassa.Models.Exceptions
{
    internal class ValueWasNotGivenException : Exception
    {
        internal ValueWasNotGivenException(IResponse response)
            : base($"{response.Error}: Не получено значение ({response.Message}).") {}
    }
}