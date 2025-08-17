using System;
using System.Linq;
using System.Reflection;
using TDS.Handlers;
using UnityEngine;

namespace TDS.Events
{
    public class PropertyChangeBinder : IPropertyChangeBinder
    {
        public void Subscribe<TPropertyType, TOwnerType>(object obj, string propertyName,
            IHandler<PropertyChangeEvent<TPropertyType, TOwnerType>> handler)
        {
            ICallPropertyChange<TPropertyType> backingValue = GetValueOrThrowException<TPropertyType>(obj,propertyName);

            if (backingValue.IsSubscribed(handler))
            {
                Debug.LogWarning($"{handler} is already subscribed to Property '{propertyName}'");
                
                return;
            }
            
            backingValue.Subscribe(handler);
        }

        private ICallPropertyChange<TPropertyType> GetValueOrThrowException<TPropertyType>(object obj,string propertyName)
        {
            FieldInfo field = GetBackingFieldOrThrowException(obj, propertyName);
            object backingValue = field.GetValue(obj);

            if (backingValue is not ICallPropertyChange<TPropertyType> callPropertyChange)
            {
                throw new ArgumentException($"Backing field for '{field.Name}' is not an " +
                                            $"ICallPropertyChange<{typeof(TPropertyType).Name}>");
            }

            return callPropertyChange;
        }

        private FieldInfo GetBackingFieldOrThrowException(object obj, string propertyName)
        {       
            return GetBackingField(obj, propertyName) ?? throw new ArgumentException($"No backing field found for property '{propertyName}' in {obj.GetType()}");
        }

        private FieldInfo GetBackingField(object obj,string propertyName)
        {
            return obj.GetType()
                .GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
                .FirstOrDefault(f =>
                    CustomAttributeExtensions.GetCustomAttribute<BackingPropertyAttribute>((MemberInfo)f)?.PropertyName == propertyName);
        }
        
        public void Unsubscribe<TPropertyType, TOwnerType>(object obj,
            string propertyName,
            IHandler<PropertyChangeEvent<TPropertyType, TOwnerType>> handler)
        {
            ICallPropertyChange<TPropertyType> backingValue = GetValueOrThrowException<TPropertyType>(obj, propertyName);

            if (!backingValue.IsSubscribed(handler))
            {
                Debug.LogWarning($"{handler} is not subscribed to Property '{propertyName}'");
                
                return;
            }
            
            backingValue.Unsubscribe(handler);
        }
    }
}