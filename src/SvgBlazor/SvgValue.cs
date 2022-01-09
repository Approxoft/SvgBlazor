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

        /// <summary>
        /// Initializes a new instance of the <see cref="SvgValue"/> class.
        /// </summary>
        public SvgValue()
        {
            _numberFormatInfo = new NumberFormatInfo();
            _numberFormatInfo.NumberDecimalSeparator = ".";
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SvgValue"/> class with provided value and unit.
        /// </summary>
        /// <param name="value">Initial int value.</param>
        /// <param name="unit">Initial unit.</param>
        public SvgValue(int value, ValueUnit unit = ValueUnit.NoUnit)
            : this() => SetValue((int)value, unit);

        /// <summary>
        /// Initializes a new instance of the <see cref="SvgValue"/> class with provided value and unit.
        /// </summary>
        /// <param name="value">Initial int value.</param>
        /// <param name="unit">Initial unit.</param>
        public SvgValue(float value, ValueUnit unit = ValueUnit.NoUnit)
            : this() => SetValue(value, unit);

        /// <summary>
        /// Initializes a new instance of the <see cref="SvgValue"/> class with provided value.
        /// </summary>
        /// <param name="value">Initial string value.</param>
        public SvgValue(string value)
            : this() => SetValue(value);

        /// <summary>
        /// Initializes a new instance of the <see cref="SvgValue"/> class with provided SvgValue.
        /// </summary>
        /// <param name="value">Initial SvgValue.</param>
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

        /// <summary>
        /// Gets the keyword for 'auto' value.
        /// </summary>
        public static string Auto { get; } = "auto";

        /// <summary>
        /// Conversion operator from int type.
        /// </summary>
        /// <param name="value">An int value.</param>
        public static implicit operator SvgValue(int value) => new SvgValue(value);

        /// <summary>
        /// Conversion operator from float type.
        /// </summary>
        /// <param name="value">A float value.</param>
        public static implicit operator SvgValue(float value) => new SvgValue(value);

        /// <summary>
        /// Conversion operator from string type.
        /// </summary>
        /// <param name="value">A string value.</param>
        public static implicit operator SvgValue(string value) => new SvgValue(value);

        /// <summary>
        /// Conversion operator to float type.
        /// </summary>
        /// <param name="d">A SvgValue.</param>
        public static implicit operator float(SvgValue d) => d.ToFloat();

        /// <summary>
        /// Returns a float that represents the current object.
        /// </summary>
        /// <returns>The float value.</returns>
        public float ToFloat() => _floatValue;

        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <remarks>
        /// If SvgValue stores a float value then the configured unit is added at the end.
        /// </remarks>
        /// <returns>A string value.</returns>
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
