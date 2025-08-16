using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using TDS.Handlers;
using UnityEngine;

namespace TDS.Events
{
    public class PropertyEventBus : IPropertyEventBus
    {
        public IEnumerable<object> Source { get; set; }

        public PropertyEventBus() : this(new List<object>())
        {
            
        }

        public PropertyEventBus(IEnumerable<object> source)
        {
            Source = source;
        }

        public void Subscribe<TPropertyType, TOwnerType>(
            string propertyName,
            IHandler<PropertyChangeEvent<TPropertyType, TOwnerType>> handler)
        {
            foreach (TOwnerType owner in Source.OfType<TOwnerType>())
            {
                var ownerType = owner.GetType();

                var backingField = ownerType
                    .GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
                    .FirstOrDefault(f =>
                        f.GetCustomAttribute<BackingPropertyAttribute>()?.PropertyName == propertyName);

                if (backingField == null)
                { 
                    Debug.LogWarning($"No backing field found for property '{propertyName}' in {ownerType}");
                    
                    continue;
                }

                var backingValue = backingField.GetValue(owner);
                
                if (backingValue is ICallPropertyChange<TPropertyType> callPropertyChange)
                {
                    callPropertyChange.Subscribe(handler);
                    
                    continue;
                }
                
                Debug.LogWarning($"Backing field for '{propertyName}' is not an " +
                                 $"ICallPropertyChange<{typeof(TPropertyType).Name},{typeof(TOwnerType).Name}>");
            }
        }

        public void Unsubscribe<TPropertyType, TOwnerType>(
            string propertyName,
            IHandler<PropertyChangeEvent<TPropertyType, TOwnerType>> handler)
        {
            foreach (TOwnerType owner in Source.OfType<TOwnerType>())
            {
                var ownerType = owner.GetType();

                var backingField = ownerType
                    .GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
                    .FirstOrDefault(f =>
                        f.GetCustomAttribute<BackingPropertyAttribute>()?.PropertyName == propertyName);

                if (backingField == null)
                    throw new InvalidOperationException(
                        $"No backing field found for property '{propertyName}' in {ownerType}");

                var backingValue = backingField.GetValue(owner);

                if (backingValue is ICallPropertyChange<TPropertyType> callPropertyChange)
                {
                    callPropertyChange.Unsubscribe(handler);
                }
            }
        }
    }
}