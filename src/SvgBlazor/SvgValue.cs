using System;
using System.Globalization;
using System.Text;

namespace SvgBlazor
{
    public class SvgValue
    {
        private enum ValueType
        {
            Unknown,
            Double,
            String,
        }

        public static string Auto { get; } = "auto";

        private double _doubleValue;

        private string _stringValue;

        private ValueType _valueType = ValueType.Unknown;

        private ValueUnit _unit = ValueUnit.NoUnit;

        private readonly NumberFormatInfo _numberFormatInfo;

        public SvgValue()
        {
            _numberFormatInfo = new NumberFormatInfo();
            _numberFormatInfo.NumberDecimalSeparator = ".";
        }

        public SvgValue(double value, ValueUnit unit = ValueUnit.NoUnit):
            this()
        {
            SetValue(value, unit);
        }

        public SvgValue(string value):
            this()
        {
            SetValue(value);
        }

        public SvgValue(SvgValue value):
            this()
        {
            _doubleValue = value._doubleValue;
            _stringValue = value._stringValue;
            _valueType = value._valueType;
            _unit = value._unit;
        }

        public static implicit operator SvgValue(int value)
        {
            return new SvgValue(value);
        }

        public static implicit operator SvgValue(double value)
        {
            return new SvgValue(value);
        }

        public static implicit operator SvgValue(string value)
        {
            return new SvgValue(value);
        }

        public void SetValue(double value, ValueUnit unit = ValueUnit.NoUnit)
        {
            _doubleValue = value;
            _unit = unit;
            _valueType = ValueType.Double;
        }

        public void SetValue(string value)
        {
            _stringValue = value;
            _unit = ValueUnit.NoUnit;
            _valueType = ValueType.String;
        }

        public override string ToString()
        {
            switch (_valueType)
            {
                case ValueType.Double:
                    {
                        StringBuilder sb = new StringBuilder();
                        sb.Append(_doubleValue.ToString(_numberFormatInfo));

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
                    return String.Empty;
            }
        }

        public double ToDouble()
        {
            return _doubleValue;
        }
    }
}
