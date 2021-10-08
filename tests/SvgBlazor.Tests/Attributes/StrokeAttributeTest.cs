using System.Drawing;
using Microsoft.AspNetCore.Components.Rendering;
using Xunit;
using Bunit;
using SvgBlazor.Interfaces;

namespace SvgBlazor.Tests
{
    public class StrokeAttributeTest : TestContext
    {
        [Fact]
        public void RendersAttributes()
        {
            var comp = RenderComponent<SvgComponent>();

            comp.InvokeAsync(() => comp.Instance.Add(new DummyStrokeAttributesElement
            {
                Stroke = new SvgStroke
                {
                    Color = "red",
                    DashArray = "1 2 3",
                    DashOffset = 2,
                    Opacity = 0.5f,
                    MiterLimit = 5,
                    Width = 15,
                },
            }));

            comp.Render();

            var element = comp.Find("elementwithstroke");
            Assert.Contains("red", element.GetAttribute("stroke"));
            Assert.Contains("1 2 3", element.GetAttribute("stroke-dasharray"));
            Assert.Contains("2", element.GetAttribute("stroke-dashoffset"));
            Assert.Contains("0.5", element.GetAttribute("stroke-opacity"));
            Assert.Contains("5", element.GetAttribute("stroke-miterlimit"));
            Assert.Contains("15", element.GetAttribute("stroke-width"));
        }

        [Theory]
        [InlineData(StrokeLineCapStyle.Butt, "butt")]
        [InlineData(StrokeLineCapStyle.Round, "round")]
        [InlineData(StrokeLineCapStyle.Square, "square")]
        public void RendersWithLineCapAttribute(StrokeLineCapStyle lineCapStyle, string attributeValue)
        {
            var comp = RenderComponent<SvgComponent>();

            comp.InvokeAsync(() => comp.Instance.Add(new DummyStrokeAttributesElement
            {
                Stroke = new SvgStroke
                {
                    LineCap = lineCapStyle,
                },
            }));

            comp.Render();

            var element = comp.Find("elementwithstroke");
            Assert.Contains(attributeValue, element.GetAttribute("stroke-linecap"));
        }

        [Theory]
        [InlineData(StrokeLineJoinStyle.Arcs, "arcs")]
        [InlineData(StrokeLineJoinStyle.Round, "round")]
        [InlineData(StrokeLineJoinStyle.Bevel, "bevel")]
        [InlineData(StrokeLineJoinStyle.Miter, "miter")]
        public void RendersWithLineJoinAttribute(StrokeLineJoinStyle lineJoinStyle, string attributeValue)
        {
            var comp = RenderComponent<SvgComponent>();

            comp.InvokeAsync(() => comp.Instance.Add(new DummyStrokeAttributesElement
            {
                Stroke = new SvgStroke
                {
                    LineJoin = lineJoinStyle,
                },
            }));

            comp.Render();

            var element = comp.Find("elementwithstroke");
            Assert.Contains(attributeValue, element.GetAttribute("stroke-linejoin"));
        }

        private class DummyStrokeAttributesElement : SvgElement
        {
            public override string Tag() => "elementwithstroke";
            public override RectangleF BoundingRect() => new RectangleF();
        }
    }
}