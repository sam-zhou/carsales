using System;

namespace Carsales.Core.Models.Attributes
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class SqlDefaultValueAttribute : Attribute
    {
        public SqlDefaultValueAttribute(string defaultValue)
        {
            DefaultValue = defaultValue;
        }

        public string DefaultValue { get; set; }
    }
}
