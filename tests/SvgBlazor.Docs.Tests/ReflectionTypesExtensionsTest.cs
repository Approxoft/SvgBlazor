// Copyright (c) Approxoft. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

using SvgBlazor.Docs.Models;
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
                        "   <member name=\"M:SvgBlazor.Docs.Tests.DummyClass.DummyMethod\">" +
                        "       <summary>Method summary.</summary>" +
                        "   </member>" +
                        "   <member name=\"M:SvgBlazor.Docs.Tests.DummyClass.DummyMethodWithParameters(System.Single,System.Single)\">" +
                        "       <summary>Method with parameters summary.</summary>" +
                        "   </member>" +
                        "</members>" +
                        "</doc>";

        [Fact]
        public void ReturnsTypeSummary()
        {
            var xmlDoc = new XmlDoc(dummyXml);
            Assert.Equal("Type summary.",
                xmlDoc.GetDocumentation(typeof(DummyClass)));           
        }

        [Fact]
        public void ReturnsPropertySummary()
        {
            var xmlDoc = new XmlDoc(dummyXml);
            var dummyClassType = typeof(DummyClass);
            Assert.Equal("Property summary.",
                xmlDoc.GetDocumentation(dummyClassType.GetProperty("DummyProperty")));
        }

        [Fact]
        public void ReturnsMethodSummary()
        {
            var xmlDoc = new XmlDoc(dummyXml);
            var dummyClassType = typeof(DummyClass);
            Assert.Equal("Method summary.",
                xmlDoc.GetDocumentation(dummyClassType.GetMethod("DummyMethod")));
        }

        [Fact]
        public void ReturnsMethodWithParameteresSummary()
        {
            var xmlDoc = new XmlDoc(dummyXml);
            var dummyClassType = typeof(DummyClass);
            Assert.Equal("Method with parameters summary.",
                xmlDoc.GetDocumentation(dummyClassType.GetMethod("DummyMethodWithParameters")));
        }
    }
}
