using System;
using System.Globalization;
using System.Text;

namespace SvgBlazor
{
    public class SvgValue
    {
        public enum ValueType
        {
            Unknown,
            Double,
            String,
        }

        public enum SpecialValue
        {
            Auto,
        }

        public enum Unit
        {
            NoUnit,
            Em,
            Ex,
            Px,
            In,
            Cm,
            Mm,
            Pt,
            Pc,
        }

        private readonly double? doubleValue;

        private readonly string stringValue;

        private readonly ValueType valueType = ValueType.Unknown;

        private readonly bool percentage = false;

        private readonly Unit unit = Unit.NoUnit;

        private readonly NumberFormatInfo numberFormatInfo;

        public SvgValue()
        {
            numberFormatInfo = new NumberFormatInfo();
            numberFormatInfo.NumberDecimalSeparator = ".";
        }

        public SvgValue(double v):
            this()
        {
            doubleValue = v;
            valueType = ValueType.Double;
        }

        public SvgValue(string v) :
            this()
        {
            stringValue = v;
            valueType = ValueType.String;
        }

        public SvgValue(SpecialValue special) :
            this()
        {
            switch (special)
            {
                case SpecialValue.Auto:
                    valueType = ValueType.String;
                    stringValue = "auto";
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public static implicit operator SvgValue(int v)
        {
            return new SvgValue(v);
        }

        public static implicit operator SvgValue(double v)
        {
            return new SvgValue(v);
        }

        public static implicit operator SvgValue(SpecialValue special)
        {
            return new SvgValue(special);
        }

        public override string ToString()
        {
            switch (valueType)
            {
                case ValueType.Double:
                    {
                        StringBuilder sb = new StringBuilder();
                        sb.Append(doubleValue.Value.ToString(numberFormatInfo));
                        if (percentage)
                        {
                            sb.Append('%');
                        }
                        else if (unit!= Unit.NoUnit)
                        {
                            sb.Append(' ');
                            sb.Append(unit.ToString().ToLower());
                        }
                        return sb.ToString();
                    }
                case ValueType.String:
                    return stringValue;
                default:
                    return String.Empty;
            }
        }
    }
}
