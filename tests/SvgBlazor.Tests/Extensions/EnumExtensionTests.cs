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
        public void RetursString()
        {
            Assert.Equal("dumb", Dummy.Dumb.ToStringValue());
            Assert.Equal("dumber", Dummy.Dumber.ToStringValue());
        }

        private enum Dummy
        {
            [Description("dumb")]
            Dumb,

            [Description("dumber")]
            Dumber,
        }
    }
}
