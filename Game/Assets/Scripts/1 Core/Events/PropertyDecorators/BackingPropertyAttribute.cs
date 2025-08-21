using System;

namespace TDS.Events
{
    [AttributeUsage(AttributeTargets.Field)]
    public class BackingPropertyAttribute : Attribute
    {
        public string PropertyName { get; }

        public BackingPropertyAttribute(string propertyName)
        {
            PropertyName = propertyName;
        }
    }
}