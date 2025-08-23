using System;

namespace TDS.Economy
{
    public interface ICappedValueReadOnly<out T> where T :struct, IComparable<T>
    {
        T MinValue { get; }
        T MaxValue { get; }
        T Value { get; }
    }
}