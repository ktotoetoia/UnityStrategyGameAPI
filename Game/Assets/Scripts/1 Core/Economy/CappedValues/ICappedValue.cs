using System;
using System.Collections.Generic;

namespace TDS.Economy
{
    public interface ICappedValue<T> : ICappedValueReadOnly<T> where T : struct, IComparable<T>
    {
        new T MinValue { get; set; }
        new T MaxValue { get; set; }
        new T Value { get; set; }
    }
}