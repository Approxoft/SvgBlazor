using System;
using Xunit;
using SvgBlazor;

namespace SvgBlazor.Tests
{
    public class ValueUnitTest
    {
        [Fact]
        public void ReturnsValidString_GivenConstructorWithDoubleValue()
        {
            {
                var value = new SvgValue(1.1);
                Assert.Equal("1.1", value.ToString());
            }

            {
                var value = new SvgValue(1);
                Assert.Equal("1", value.ToString());
            }

            {
                var value = new SvgValue(0);
                Assert.Equal("0", value.ToString());
            }
        }

        [Fact]
        public void ReturnsValidString_GivenConstructorWithDoubleValueAndUnit()
        {
            {
                var value = new SvgValue(1.1, ValueUnit.Mm);
                Assert.Equal("1.1mm", value.ToString());
            }

            {
                var value = new SvgValue(1, ValueUnit.Percentage);
                Assert.Equal("1%", value.ToString());
            }

            {
                var value = new SvgValue(0, ValueUnit.NoUnit);
                Assert.Equal("0", value.ToString());
            }
        }

        [Fact]
        public void ReturnsValidString_GivenConstructorWithStringValue()
        {
            {
                var value = new SvgValue("123");
                Assert.Equal("123", value.ToString());
            }

            {
                var value = new SvgValue("test");
                Assert.Equal("test", value.ToString());
            }
        }

        [Fact]
        public void ReturnsValidString_GivenConstructorWithSvgValue()
        {
            var v1 = new SvgValue(1, ValueUnit.Percentage);
            var v2 = new SvgValue(v1);
            Assert.Equal("1%", v2.ToString());
        }

        [Fact]
        public void ReturnsValidString_AssignedDouble()
        {
            SvgValue value = 1.1;
            Assert.Equal("1.1", value.ToString());
        }

        [Fact]
        public void ReturnsValidString_AssignedString()
        {
            SvgValue value = "test";
            Assert.Equal("test", value.ToString());
        }

        [Fact]
        public void ReturnsValidString_AssignedInt()
        {
            SvgValue value = 1;
            Assert.Equal("1", value.ToString());
        }

        [Fact]
        public void ReturnsValidString_AssignedSvgValueAuto()
        {
            SvgValue value = SvgValue.Auto;
            Assert.Equal("auto", value.ToString());
        }

        [Fact]
        public void ReturnsEmptyString_AssignedDefaultSvgValue()
        {
            var value = new SvgValue();
            Assert.Empty(value.ToString());
        }
    }
}
