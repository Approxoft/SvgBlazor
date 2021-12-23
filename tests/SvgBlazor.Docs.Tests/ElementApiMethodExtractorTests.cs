using SvgBlazor.Docs.Extensions;
using SvgBlazor.Docs.Extractors;
using System;
using System.Linq;
using Xunit;

namespace SvgBlazor.Docs.Tests
{
    public class ElementApiMethodExtractorTests : IDisposable
    {
        private ElementApiMethodExtractor _tested;

        public ElementApiMethodExtractorTests()
        {
            _tested = new ElementApiMethodExtractor();
        }

        [Fact]
        public void TakesMethodDescriptionFromOverrideWhenVirtualAndOverridenDescriptionsArePresent()
        {
            const string xml = "<?xml version=\"1.0\"?>" +
                        "<doc>" +
                        "<assembly><name>SvgBlazor</name></assembly>" +
                        "<members>" +
                        "   <member name=\"M:SvgBlazor.Docs.Tests.ElementApiMethodExtractorTests.BaseClass1.Method\">" +
                        "       <summary>Method description from the base class.</summary>" +
                        "   </member>" +
                        "   <member name=\"M:SvgBlazor.Docs.Tests.ElementApiMethodExtractorTests.Class1.Method\">" +
                        "       <summary>Method description from the class.</summary>" +
                        "   </member>" +
                        "</members>" +
                        "</doc>";

            ReflectionTypesExtensions.LoadXmlDocumentation(xml);

            var result = _tested
                .ExtractMethods(typeof(Class1))
                .FirstOrDefault(m => m.Name == "Method");

            Assert.Equal("Method description from the class.", result.Description);
        }

        [Fact]
        public void TakesMethodDescriptionFromVirtualWhenOverridenIsNotPresent()
        {
            const string xml = "<?xml version=\"1.0\"?>" +
                        "<doc>" +
                        "<assembly><name>SvgBlazor</name></assembly>" +
                        "<members>" +
                        "   <member name=\"M:SvgBlazor.Docs.Tests.ElementApiMethodExtractorTests.BaseClass1.Method\">" +
                        "       <summary>Method description from the base class.</summary>" +
                        "   </member>" +
                        "</members>" +
                        "</doc>";

            ReflectionTypesExtensions.LoadXmlDocumentation(xml);

            var result = _tested
                .ExtractMethods(typeof(Class1))
                .FirstOrDefault(m => m.Name == "Method");

            Assert.Equal("Method description from the base class.", result.Description);
        }

        [Fact]
        public void TakesCorrectDescriptionWhenOverloadedMethodIsPresent()
        {
            const string xml = "<?xml version=\"1.0\"?>" +
                        "<doc>" +
                        "<assembly><name>SvgBlazor</name></assembly>" +
                        "<members>" +
                        "   <member name=\"M:SvgBlazor.Docs.Tests.ElementApiMethodExtractorTests.BaseClass1.Method1\">" +
                        "       <summary>Method description from the base class.</summary>" +
                        "   </member>" +
                        "   <member name=\"M:SvgBlazor.Docs.Tests.ElementApiMethodExtractorTests.Class1.Method1(System.Boolean)\">" +
                        "       <summary>Method description from the class.</summary>" +
                        "   </member>" +
                        "</members>" +
                        "</doc>";

            ReflectionTypesExtensions.LoadXmlDocumentation(xml);

            var baseClassMethod = _tested
                .ExtractMethods(typeof(Class1))
                .FirstOrDefault(m => m.Name == "Method1");

            var classMethod = _tested
                .ExtractMethods(typeof(Class1))
                .FirstOrDefault(m => m.Name == "Method1" && m.Parameters.DefaultIfEmpty("").First() == "System.Boolean flag");

            Assert.Equal("Method description from the base class.", baseClassMethod.Description);
            Assert.Equal("Method description from the class.", classMethod.Description);
        }

        [Fact]
        public void TakesDescriptionFromInterfaceIfNoOtherIsProvided()
        {
            const string xml = "<?xml version=\"1.0\"?>" +
                        "<doc>" +
                        "<assembly><name>SvgBlazor</name></assembly>" +
                        "<members>" +
                        "   <member name=\"M:SvgBlazor.Docs.Tests.ElementApiMethodExtractorTests.IBaseClass.BaseClassInterfaceMethod\">" +
                        "       <summary>Method description for BaseClassInterfaceMethod.</summary>" +
                        "   </member>" +
                        "</members>" +
                        "</doc>";

            ReflectionTypesExtensions.LoadXmlDocumentation(xml);

            var method = _tested
                .ExtractMethods(typeof(Class1))
                .FirstOrDefault(m => m.Name == "BaseClassInterfaceMethod");

            Assert.Equal("Method description for BaseClassInterfaceMethod.", method.Description);
        }

        [Fact]
        public void TakesDescriptionFromBaseClassWhenInterfaceDescriptionIsPresent()
        {
            const string xml = "<?xml version=\"1.0\"?>" +
                        "<doc>" +
                        "<assembly><name>SvgBlazor</name></assembly>" +
                        "<members>" +
                        "   <member name=\"M:SvgBlazor.Docs.Tests.ElementApiMethodExtractorTests.IBaseClass.BaseClassInterfaceMethod\">" +
                        "       <summary>Method description for BaseClassInterfaceMethod.</summary>" +
                        "   </member>" +
                        "   <member name=\"M:SvgBlazor.Docs.Tests.ElementApiMethodExtractorTests.BaseClass1.BaseClassInterfaceMethod\">" +
                        "       <summary>Interface method description from the base class.</summary>" +
                        "   </member>" +
                        "</members>" +
                        "</doc>";

            ReflectionTypesExtensions.LoadXmlDocumentation(xml);

            var method = _tested
                .ExtractMethods(typeof(Class1))
                .FirstOrDefault(m => m.Name == "BaseClassInterfaceMethod");

            Assert.Equal("Interface method description from the base class.", method.Description);
        }

        public void Dispose()
        {
            ReflectionTypesExtensions.ClearLoadedXmlDocumentation();
        }

        public interface IBaseClass
        {
            public void BaseClassInterfaceMethod();
        }

        public class BaseClass1 : IBaseClass
        {
            public void Method1() { }

            public void BaseClassInterfaceMethod() { }

            public virtual void Method() { }
        }

        public class Class1 : BaseClass1
        {
            public override void Method() { }

            public void Method1(bool flag) { }
        }
    }
}