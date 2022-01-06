using SvgBlazor.Docs.Extractors;
using SvgBlazor.Docs.Models;
using System;
using System.Linq;
using Xunit;

namespace SvgBlazor.Docs.Tests
{
    public class ElementApiExtractorTests
    {
        [Fact]
        public void TakesMethodDescriptionFromOverrideWhenVirtualAndOverridenDescriptionsArePresent()
        {
            const string xml = "<?xml version=\"1.0\"?>" +
                        "<doc>" +
                        "<assembly><name>SvgBlazor</name></assembly>" +
                        "<members>" +
                        "   <member name=\"M:SvgBlazor.Docs.Tests.ElementApiExtractorTests.BaseClass1.Method\">" +
                        "       <summary>Method description from the base class.</summary>" +
                        "   </member>" +
                        "   <member name=\"M:SvgBlazor.Docs.Tests.ElementApiExtractorTests.Class1.Method\">" +
                        "       <summary>Method description from the class.</summary>" +
                        "   </member>" +
                        "</members>" +
                        "</doc>";

            var extractor = new ElementApiExtractor(new XmlDoc(xml));

            var result = extractor
                .ExtractApiMethods(typeof(Class1))
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
                        "   <member name=\"M:SvgBlazor.Docs.Tests.ElementApiExtractorTests.BaseClass1.Method\">" +
                        "       <summary>Method description from the base class.</summary>" +
                        "   </member>" +
                        "</members>" +
                        "</doc>";

            var extractor = new ElementApiExtractor(new XmlDoc(xml));

            var result = extractor
                .ExtractApiMethods(typeof(Class1))
                .FirstOrDefault(m => m.Name == "Method");

            Assert.Equal("Method description from the base class.", result.Description);
        }

        [Fact]
        public void TakesAppropriateDescriptionWhenOverloadedMethodIsPresent()
        {
            const string xml = "<?xml version=\"1.0\"?>" +
                        "<doc>" +
                        "<assembly><name>SvgBlazor</name></assembly>" +
                        "<members>" +
                        "   <member name=\"M:SvgBlazor.Docs.Tests.ElementApiExtractorTests.BaseClass1.Method1\">" +
                        "       <summary>Method description from the base class.</summary>" +
                        "   </member>" +
                        "   <member name=\"M:SvgBlazor.Docs.Tests.ElementApiExtractorTests.Class1.Method1(System.Boolean)\">" +
                        "       <summary>Method description from the class.</summary>" +
                        "   </member>" +
                        "</members>" +
                        "</doc>";

            var extractor = new ElementApiExtractor(new XmlDoc(xml));

            var baseClassMethod = extractor
                .ExtractApiMethods(typeof(Class1))
                .FirstOrDefault(m => m.Name == "Method1");

            var classMethod = extractor
                .ExtractApiMethods(typeof(Class1))
                .FirstOrDefault(m => m.Name == "Method1" && m.Parameters.DefaultIfEmpty("").First() == "Boolean flag");

            Assert.Equal("Method description from the base class.", baseClassMethod.Description);
            Assert.Equal("Method description from the class.", classMethod.Description);
        }

        [Fact]
        public void TakesMethodDescriptionFromInterfaceIfNoOtherIsProvided()
        {
            const string xml = "<?xml version=\"1.0\"?>" +
                        "<doc>" +
                        "<assembly><name>SvgBlazor</name></assembly>" +
                        "<members>" +
                        "   <member name=\"M:SvgBlazor.Docs.Tests.ElementApiExtractorTests.IBaseClass.BaseClassInterfaceMethod\">" +
                        "       <summary>Method description for BaseClassInterfaceMethod.</summary>" +
                        "   </member>" +
                        "</members>" +
                        "</doc>";

            var extractor = new ElementApiExtractor(new XmlDoc(xml));

            var method = extractor
                .ExtractApiMethods(typeof(Class1))
                .FirstOrDefault(m => m.Name == "BaseClassInterfaceMethod");

            Assert.Equal("Method description for BaseClassInterfaceMethod.", method.Description);
        }

        [Fact]
        public void TakesMethodDescriptionFromBaseClassWhenDescriptionInInterfaceIsPresent()
        {
            const string xml = "<?xml version=\"1.0\"?>" +
                        "<doc>" +
                        "<assembly><name>SvgBlazor</name></assembly>" +
                        "<members>" +
                        "   <member name=\"M:SvgBlazor.Docs.Tests.ElementApiExtractorTests.IBaseClass.BaseClassInterfaceMethod\">" +
                        "       <summary>Method description for BaseClassInterfaceMethod.</summary>" +
                        "   </member>" +
                        "   <member name=\"M:SvgBlazor.Docs.Tests.ElementApiExtractorTests.BaseClass1.BaseClassInterfaceMethod\">" +
                        "       <summary>Interface method description from the base class.</summary>" +
                        "   </member>" +
                        "</members>" +
                        "</doc>";

            var extractor = new ElementApiExtractor(new XmlDoc(xml));

            var method = extractor
                .ExtractApiMethods(typeof(Class1))
                .FirstOrDefault(m => m.Name == "BaseClassInterfaceMethod");

            Assert.Equal("Interface method description from the base class.", method.Description);
        }

        [Fact]
        public void TakesPropertyDescriptionFromInterfaceIfNoOtherIsProvided()
        {
            const string xml = "<?xml version=\"1.0\"?>" +
                        "<doc>" +
                        "<assembly><name>SvgBlazor</name></assembly>" +
                        "<members>" +
                        "   <member name=\"P:SvgBlazor.Docs.Tests.ElementApiExtractorTests.IBaseClass.IBaseClassStringProperty\">" +
                        "       <summary>Property description.</summary>" +
                        "   </member>" +
                        "</members>" +
                        "</doc>";

            var extractor = new ElementApiExtractor(new XmlDoc(xml));

            var property = extractor
                .ExtractApiProperties(typeof(Class1))
                .FirstOrDefault(p => p.Name == "IBaseClassStringProperty");

            Assert.Equal("Property description.", property.Description);
        }

        [Fact]
        public void TakesPropertyDescriptionFromBaseClassIfNoOtherIsProvided()
        {
            const string xml = "<?xml version=\"1.0\"?>" +
                        "<doc>" +
                        "<assembly><name>SvgBlazor</name></assembly>" +
                        "<members>" +
                        "   <member name=\"P:SvgBlazor.Docs.Tests.ElementApiExtractorTests.BaseClass1.BaseClassStringProperty\">" +
                        "       <summary>Property description.</summary>" +
                        "   </member>" +
                        "</members>" +
                        "</doc>";

            var extractor = new ElementApiExtractor(new XmlDoc(xml));

            var property = extractor
                .ExtractApiProperties(typeof(Class1))
                .FirstOrDefault(p => p.Name == "BaseClassStringProperty");

            Assert.Equal("Property description.", property.Description);
        }

        [Fact]
        public void TakesPropertyDescriptionFromClass()
        {
            const string xml = "<?xml version=\"1.0\"?>" +
                        "<doc>" +
                        "<assembly><name>SvgBlazor</name></assembly>" +
                        "<members>" +
                        "   <member name=\"P:SvgBlazor.Docs.Tests.ElementApiExtractorTests.Class1.ClassProperty\">" +
                        "       <summary>Property description.</summary>" +
                        "   </member>" +
                        "</members>" +
                        "</doc>";

            var extractor = new ElementApiExtractor(new XmlDoc(xml));

            var property = extractor
                .ExtractApiProperties(typeof(Class1))
                .FirstOrDefault(p => p.Name == "ClassProperty");

            Assert.Equal("Property description.", property.Description);
        }

        [Fact]
        public void TakesPropertyDescriptionFromBaseClassWhenDescriptionInInterfaceIsPresent()
        {
            const string xml = "<?xml version=\"1.0\"?>" +
                        "<doc>" +
                        "<assembly><name>SvgBlazor</name></assembly>" +
                        "<members>" +
                        "   <member name=\"P:SvgBlazor.Docs.Tests.ElementApiExtractorTests.IBaseClass.IBaseClassStringProperty\">" +
                        "       <summary>Property description from interface.</summary>" +
                        "   </member>" +
                        "   <member name=\"P:SvgBlazor.Docs.Tests.ElementApiExtractorTests.BaseClass1.IBaseClassStringProperty\">" +
                        "       <summary>Property description from base class.</summary>" +
                        "   </member>" +
                        "</members>" +
                        "</doc>";

            var extractor = new ElementApiExtractor(new XmlDoc(xml));

            var property = extractor
                .ExtractApiProperties(typeof(Class1))
                .FirstOrDefault(p => p.Name == "IBaseClassStringProperty");

            Assert.Equal("Property description from base class.", property.Description);
        }

        public interface IBaseClass
        {
            public string IBaseClassStringProperty { get; set; }

            public void BaseClassInterfaceMethod();
        }

        public class BaseClass1 : IBaseClass
        {
            public string BaseClassStringProperty { get; set; }

            public string IBaseClassStringProperty { get; set; }

            public void Method1() { }

            public void BaseClassInterfaceMethod() { }

            public virtual void Method() { }
        }

        public class Class1 : BaseClass1
        {
            public string ClassProperty { get; set; }

            public override void Method() { }

            public void Method1(bool flag) { }
        }
    }
}