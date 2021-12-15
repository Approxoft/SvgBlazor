using System;
using System.Globalization;
using System.Text;

namespace SvgBlazor
{
    /// <summary>
    /// The SvgValue class is responsible for storing the values of the different types used in SVG.
    /// </summary>
    public class SvgValue
    {
        private readonly NumberFormatInfo _numberFormatInfo;

        private float _floatValue;

        private string _stringValue;

        private ValueType _valueType = ValueType.Unknown;

        private ValueUnit _unit = ValueUnit.NoUnit;

        public SvgValue()
        {
            _numberFormatInfo = new NumberFormatInfo();
            _numberFormatInfo.NumberDecimalSeparator = ".";
        }

        public SvgValue(int value, ValueUnit unit = ValueUnit.NoUnit)
            : this() => SetValue((int)value, unit);

        public SvgValue(float value, ValueUnit unit = ValueUnit.NoUnit)
            : this() => SetValue(value, unit);

        public SvgValue(string value)
            : this() => SetValue(value);

        public SvgValue(SvgValue value)
            : this()
        {
            _floatValue = value._floatValue;
            _stringValue = value._stringValue;
            _valueType = value._valueType;
            _unit = value._unit;
        }

        private enum ValueType
        {
            Unknown,
            Float,
            String,
        }

        public static string Auto { get; } = "auto";

        public static implicit operator SvgValue(int value) => new SvgValue(value);

        public static implicit operator SvgValue(float value) => new SvgValue(value);

        public static implicit operator SvgValue(string value) => new SvgValue(value);

        public static implicit operator float(SvgValue d) => d.ToFloat();

        public float ToFloat() => _floatValue;

        public override string ToString()
        {
            switch (_valueType)
            {
                case ValueType.Float:
                    {
                        StringBuilder sb = new StringBuilder();
                        sb.Append(_floatValue.ToString(_numberFormatInfo));

                        if (_unit == ValueUnit.Percentage)
                        {
                            sb.Append('%');
                        }
                        else if (_unit != ValueUnit.NoUnit)
                        {
                            sb.Append(_unit.ToString().ToLower());
                        }

                        return sb.ToString();
                    }

                case ValueType.String:
                    return _stringValue;
                default:
                    return string.Empty;
            }
        }

        private void SetValue(float value, ValueUnit unit = ValueUnit.NoUnit)
        {
            _floatValue = value;
            _unit = unit;
            _valueType = ValueType.Float;
        }

        private void SetValue(string value)
        {
            _stringValue = value;
            _unit = ValueUnit.NoUnit;
            _valueType = ValueType.String;
        }
    }
}
