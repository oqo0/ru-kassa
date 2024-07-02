using System;

namespace Ru.Kassa.Helpers.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    internal class FormDataHeaderAttribute : Attribute
    {
        internal string Header { get; }
        
        internal FormDataHeaderAttribute(string header)
        {
            Header = header;
        }
    }
}