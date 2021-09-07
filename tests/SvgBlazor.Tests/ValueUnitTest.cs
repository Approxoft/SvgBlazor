using System;
using Xunit;
using SvgBlazor;

namespace SvgBlazor.Tests
{
    public class ValueUnitTest
    {
        [Theory]
        [InlineData(1.1, "1.1")]
        [InlineData(1, "1")]
        [InlineData(0, "0")]
        public void ConstructorWithDoubleValue(double value, string expected)
        {
            var svgValue = new SvgValue(value);
            Assert.Equal(expected, svgValue.ToString());
        }

        [Theory]
        [InlineData(1.1, ValueUnit.Mm, "1.1mm")]
        [InlineData(1, ValueUnit.Percentage, "1%")]
        [InlineData(0, ValueUnit.NoUnit, "0")]
        public void ConstructorWithDoubleValueAndUnit(double value, ValueUnit unit, string expected)
        {
            var svgValue = new SvgValue(value, unit);
            Assert.Equal(expected, svgValue.ToString());
        }

        [Theory]
        [InlineData("123", "123")]
        [InlineData("test", "test")]
        public void ConstructorWithStringValue(string value, string expected)
        {
            var svgValue = new SvgValue(value);
            Assert.Equal(expected, svgValue.ToString());
        }

        [Fact]
        public void ConstructorWithSvgValue()
        {
            var v1 = new SvgValue(1, ValueUnit.Percentage);
            var v2 = new SvgValue(v1);
            Assert.Equal("1%", v2.ToString());
        }

        [Fact]
        public void AssigningDouble()
        {
            SvgValue value = 1.1;
            Assert.Equal("1.1", value.ToString());
        }

        [Fact]
        public void AssigningString()
        {
            SvgValue value = "test";
            Assert.Equal("test", value.ToString());
        }

        [Fact]
        public void AssigningInt()
        {
            SvgValue value = 1;
            Assert.Equal("1", value.ToString());
        }

        [Fact]
        public void AssigningSvgValueAuto()
        {
            SvgValue value = SvgValue.Auto;
            Assert.Equal("auto", value.ToString());
        }

        [Fact]
        public void AssigningDefaultSvgValue()
        {
            var value = new SvgValue();
            Assert.Empty(value.ToString());
        }
    }
}
