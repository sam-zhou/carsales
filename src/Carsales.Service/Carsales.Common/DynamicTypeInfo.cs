using System;

namespace Carsales.Common
{
    public class DynamicTypeInfo
    {
        public DynamicTypeInfo(string name, Type parent)
        {
            Name = name;
            Parent = parent;
        }

        public string Name { get; set; }

        public Type Parent { get; set; }
    }
}
