using System;

namespace TDS.Economy
{
    public interface ICappedValueReadOnly<out T>
    {
        T MinValue { get; }
        T MaxValue { get; }
        T Value { get; }
    }
}