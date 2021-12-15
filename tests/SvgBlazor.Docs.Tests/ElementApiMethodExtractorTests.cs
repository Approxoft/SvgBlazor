using SvgBlazor.Docs.Extensions;
using SvgBlazor.Docs.Models;
using System;
using Xunit;

namespace SvgBlazor.Docs.Tests
{
    public class ElementApiMethodExtractorTests
    {
        private ElementApiMethodExtractor _tested;

        public ElementApiMethodExtractorTests()
        {
            _tested = new ElementApiMethodExtractor();
        }

        [Fact]
        public void ExtractsMethodDescriptionFromOverrideWhenVirtualAndOverridenDescriptionsArePresent()
        {
            const string xml = "<?xml version=\"1.0\"?>" +
                        "<doc>" +
                        "<assembly><name>SvgBlazor</name></assembly>" +
                        "<members>" +
                        "   <member name=\"M:SvgBlazor.Docs.Tests.ElementApiMethodExtractorTests.BaseClass1.Method()\">" +
                        "       <summary>Method description from the base class.</summary>" +
                        "   </member>" +
                        "   <member name=\"M:SvgBlazor.Docs.Tests.ElementApiMethodExtractorTests.Class1.Method()\">" +
                        "       <summary>Method description from the class.</summary>" +
                        "   </member>" +
                        "</members>" +
                        "</doc>";

            ReflectionTypesExtensions.LoadXmlDocumentation(xml);

            var result = _tested.Extract(typeof(Class1));

            Assert.Equal("Method description from the class.", result["Method()"].Description);
        }

        [Fact]
        public void ExtractsMethodDescriptionFromVirtualWhenOverridenIsNotPresent()
        {
            const string xml = "<?xml version=\"1.0\"?>" +
                        "<doc>" +
                        "<assembly><name>SvgBlazor</name></assembly>" +
                        "<members>" +
                        "   <member name=\"M:SvgBlazor.Docs.Tests.ElementApiMethodExtractorTests.BaseClass1.Method()\">" +
                        "       <summary>Method description from the base class.</summary>" +
                        "   </member>" +
                        "</members>" +
                        "</doc>";

            ReflectionTypesExtensions.LoadXmlDocumentation(xml);

            var result = _tested.Extract(typeof(Class1));

            Assert.Equal("Method description from the base class.", result["Method()"].Description);
        }

        // rozróżnianie Method oraz method z parametrem
        // sprawdzanie z uzyciem interface'u: gdy jest w interface a nie ma nigdzie wyżej
        // sprawdzanie czy jest w interface i w base class - to ma wziąć z baseclass
        // sprawdzanie czy jest w interface i base class i w derived - to ma wziąć z derived
        // sprawdzenie gdy:
        /*
        public interface IA0{
	
        }

        public interface IA : IA0 {
	
        }

        class Clas1 : IA, IA0 {
	
        }

        class Clas2: Clas1, IA {
        }
         */

        public class BaseClass1
        {
            public virtual void Method()
            {
            }
        }

        public class Class1 : BaseClass1
        {
            public override void Method()
            {   
            }
        }
    }
}

/*
 <member name="P:SvgBlazor.Interfaces.ISvgElement.X">
            <summary>
            Test desc from ISvgEm
            </summary>
        </member>


 <member name="M:SvgBlazor.SvgEventHandler.OnClickHandler(Microsoft.AspNetCore.Components.Web.MouseEventArgs)">
            <summary>
            OnClickHandler virtual test.
            </summary>
            <param name="args"></param>
            <returns></returns>
        </member>
 */