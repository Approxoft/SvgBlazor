using SvgBlazor.Docs.Extensions;
using System;
using Xunit;

namespace SvgBlazor.Docs.Tests
{
    public class DummyClass
    {
        public int DummyProperty { get; set; }

        public void DummyMethod()
        {
        }

        public void DummyMethodWithParameters(float width, float height)
        {
        }
    }

    public class ReflectionTypesExtensionsTest
    {
        const string dummyXml = "<?xml version=\"1.0\"?>" +
                        "<doc>" +
                        "<assembly><name>SvgBlazor</name></assembly>" +
                        "<members>" +
                        "   <member name=\"T:SvgBlazor.Docs.Tests.DummyClass\">" +
                        "       <summary>Type summary.</summary>" +
                        "   </member>" +
                        "   <member name=\"P:SvgBlazor.Docs.Tests.DummyClass.DummyProperty\">" +
                        "       <summary>Property summary.</summary>" +
                        "   </member>" +
                        "   <member name=\"M:SvgBlazor.Docs.Tests.DummyClass.DummyMethod()\">" +
                        "       <summary>Method summary.</summary>" +
                        "   </member>" +
                        "   <member name=\"M:SvgBlazor.Docs.Tests.DummyClass.DummyMethodWithParameters(System.Single,System.Single)\">" +
                        "       <summary>Method with parameters summary.</summary>" +
                        "   </member>" +
                        "</members>" +
                        "</doc>";

        public ReflectionTypesExtensionsTest()
        {
            ReflectionTypesExtensions.LoadXmlDocumentation(dummyXml);
        }

        [Fact]
        public void ReturnsTypeSummary()
        {
            Assert.Equal("Type summary.", typeof(DummyClass).GetDocumentation());           
        }

        [Fact]
        public void ReturnsPropertySummary()
        {
            var dummyClassType = typeof(DummyClass);
            Assert.Equal("Property summary.", dummyClassType.GetProperty("DummyProperty").GetDocumentation());
        }

        [Fact]
        public void ReturnsMethodSummary()
        {
            var dummyClassType = typeof(DummyClass);
            Assert.Equal("Method summary.", dummyClassType.GetMethod("DummyMethod").GetDocumentation());
        }

        [Fact]
        public void ReturnsMethodWithParameteresSummary()
        {
            var dummyClassType = typeof(DummyClass);
            Assert.Equal("Method with parameters summary.", dummyClassType.GetMethod("DummyMethodWithParameters").GetDocumentation());
        }
    }
}
