using System;

namespace TDS.Economy
{
    public class CappedValue<T> : ICappedValue<T> where T : struct, IComparable<T>
    {
        private T _minValue;
        private T _maxValue;
        private T _value;

        public T MinValue
        {
            get => _minValue;
            set
            {
                if (value.CompareTo(_maxValue) > 0)
                    throw new ArgumentException("MinValue cannot be greater than MaxValue.");
                _minValue = value;
                if (_value.CompareTo(_minValue) < 0)
                    _value = _minValue;
            }
        }

        public T MaxValue
        {
            get => _maxValue;
            set
            {
                if (value.CompareTo(_minValue) < 0)
                    throw new ArgumentException("MaxValue cannot be less than MinValue.");
                _maxValue = value;
                if (_value.CompareTo(_maxValue) > 0)
                    _value = _maxValue;
            }
        }

        public T Value
        {
            get => _value;
            set
            {
                if (value.CompareTo(_minValue) < 0)
                    _value = _minValue;
                else if (value.CompareTo(_maxValue) > 0)
                    _value = _maxValue;
                else
                    _value = value;
            }
        }

        public CappedValue(T minValue, T maxValue, T value = default)
        {
            if (minValue.CompareTo(maxValue) > 0)
                throw new ArgumentException("minValue must be less than or equal to maxValue.");

            _minValue = minValue;
            _maxValue = maxValue;
            Value = value;
        }
    }
}