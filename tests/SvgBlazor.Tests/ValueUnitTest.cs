// Copyright (c) Approxoft. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

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
        public void ConstructorWithFloatValue(float value, string expected)
        {
            var svgValue = new SvgValue(value);
            Assert.Equal(expected, svgValue.ToString());
        }

        [Theory]
        [InlineData(1.1, ValueUnit.Mm, "1.1mm")]
        [InlineData(1, ValueUnit.Percentage, "1%")]
        [InlineData(0, ValueUnit.NoUnit, "0")]
        public void ConstructorWithFloatValueAndUnit(float value, ValueUnit unit, string expected)
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
        public void AssignsFloat()
        {
            SvgValue value = 1.1f;
            Assert.Equal("1.1", value.ToString());
        }

        [Fact]
        public void AssignsString()
        {
            SvgValue value = "test";
            Assert.Equal("test", value.ToString());
        }

        [Fact]
        public void AssignsInt()
        {
            SvgValue value = 1;
            Assert.Equal("1", value.ToString());
        }

        [Fact]
        public void AssignsSvgValueAuto()
        {
            SvgValue value = SvgValue.Auto;
            Assert.Equal("auto", value.ToString());
        }

        [Fact]
        public void AssignsDefaultSvgValue()
        {
            var value = new SvgValue();
            Assert.Empty(value.ToString());
        }
    }
}
