using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using Ru.Kassa.Helpers.Attributes;
using Ru.Kassa.Models.Requests;

namespace Ru.Kassa.Helpers
{
    /// <summary>
    /// Хелпер для создания form-data для HTTP запросов
    /// </summary>
    internal class FormData
    {
        internal string AsString { get; private set; }
        internal ReadOnlyDictionary<string, string> Value { get; private set; }

        internal FormData(IRequest request)
        {
            Update(request);
        }

        internal void Update(IRequest request)
        {
            if (request is null)
                throw new NullReferenceException();

            Value = new ReadOnlyDictionary<string, string>(GetFormRequestAsDictionary(request));
            AsString = GetFormDataAsString(Value);
        }
        
        private static Dictionary<string, string> GetFormRequestAsDictionary(IRequest request)
        {
            var resultDictionary = new Dictionary<string, string>();

            var requestProperties = request
                .GetType()
                .GetProperties();

            foreach (var property in requestProperties)
            {
                var propertyFormDataHeaderAttribute = GetDataHeaderAttribute(property);
                var propertyValue = property.GetValue(request);

                if (propertyFormDataHeaderAttribute is null || propertyValue is null)
                    continue;

                resultDictionary.Add(
                    propertyFormDataHeaderAttribute.Header,
                    propertyValue.ToString());
            }

            return resultDictionary;
        }

        private static FormDataHeaderAttribute GetDataHeaderAttribute(PropertyInfo propertyInfo)
            => propertyInfo.GetCustomAttribute(typeof(FormDataHeaderAttribute)) as FormDataHeaderAttribute;

        private static string GetFormDataAsString(IDictionary<string, string> formDataDictionary)
        {
            var formDataEntries = formDataDictionary
                .Select(entry => $"{entry.Key}={entry.Value}");

            string formDataAsString = string.Join("&", formDataEntries);

            return formDataAsString;
        }
    }
}