using System;
using System.ComponentModel;
using Bunit;
using SvgBlazor.Extensions;
using Xunit;

namespace SvgBlazor.Tests.Extensions
{
    public class EnumExtensionTests
    {
        [Fact]
        public void ReturnsString()
        {
            Assert.Equal("dumb", Dummy.Dumb.ToDescriptionString());
            Assert.Equal("dumber", Dummy.Dumber.ToDescriptionString());
            Assert.Equal("EvenMoreDumber", Dummy.EvenMoreDumber.ToDescriptionString());
        }

        private enum Dummy
        {
            [Description("dumb")]
            Dumb,

            [Description("dumber")]
            Dumber,
            EvenMoreDumber,
        }
    }
}
