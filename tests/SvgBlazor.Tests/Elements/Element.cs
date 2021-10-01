using System.Drawing;
using Xunit;
using Bunit;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components;

namespace SvgBlazor.Tests
{
    public class ElementTest : TestContext
    {
        [Fact]
        public void RendersSvgElementWithParameters()
        {
            var comp = RenderComponent<SvgComponent>();

            comp.InvokeAsync(() => comp.Instance.Add(new DummyElement()
            {
                Id = "myid",
                Class = "myclass",
                Style = "mystyle",
            }));

            comp.Render();

            var element = comp.Find("dummy");
            Assert.Contains("myid", element.GetAttribute("id"));
            Assert.Contains("myclass", element.GetAttribute("class"));
            Assert.Contains("mystyle", element.GetAttribute("style"));
        }

        [Fact]
        public void SvgElementMouseOverMouseOut()
        {
            var comp = RenderComponent<SvgComponent>();

            bool elementEventHandled = false;
            comp.InvokeAsync(() => comp.Instance.Add(new DummyElement()
            {
                OnClick = EventCallback.Factory.Create<MouseEventArgs>(this, (args) => { elementEventHandled = true; })
            }));

            comp.Render();

            comp.Find("dummy").MouseOver();
            comp.Find("svg").Click();
            Assert.True(elementEventHandled);

            elementEventHandled = false;

            comp.Find("dummy").MouseOut();
            comp.Find("svg").Click();
            Assert.False(elementEventHandled);
        }

        [Fact]
        public void ElementOnClick()
        {
            var comp = RenderComponent<SvgComponent>();

            bool elementEventHandled = false;
            comp.InvokeAsync(() => comp.Instance.Add(new DummyElement()
            {
                OnClick = EventCallback.Factory.Create<MouseEventArgs>(this, (args) => { elementEventHandled = true; })
            }));

            comp.Render();

            comp.Find("dummy").MouseOver();
            comp.Find("svg").Click();
            Assert.True(elementEventHandled);
        }

        [Fact]
        public void ElementOnMouseDown()
        {
            var comp = RenderComponent<SvgComponent>();

            bool elementEventHandled = false;
            comp.InvokeAsync(() => comp.Instance.Add(new DummyElement()
            {
                OnMouseDown = EventCallback.Factory.Create<MouseEventArgs>(this, (args) => { elementEventHandled = true; })
            }));

            comp.Render();

            comp.Find("dummy").MouseOver();
            comp.Find("svg").MouseDown();
            Assert.True(elementEventHandled);
        }

        [Fact]
        public void ElementOnMouseUp()
        {
            var comp = RenderComponent<SvgComponent>();

            bool elementEventHandled = false;
            comp.InvokeAsync(() => comp.Instance.Add(new DummyElement()
            {
                OnMouseUp = EventCallback.Factory.Create<MouseEventArgs>(this, (args) => { elementEventHandled = true; })
            }));

            comp.Render();

            comp.Find("dummy").MouseOver();
            comp.Find("svg").MouseUp();
            Assert.True(elementEventHandled);
        }

        [Fact]
        public void ElementOnMouseMove()
        {
            var comp = RenderComponent<SvgComponent>();

            bool elementEventHandled = false;
            comp.InvokeAsync(() => comp.Instance.Add(new DummyElement()
            {
                OnMouseMove = EventCallback.Factory.Create<MouseEventArgs>(this, (args) => { elementEventHandled = true; })
            }));

            comp.Render();

            comp.Find("dummy").MouseOver();
            comp.Find("svg").MouseMove();
            Assert.True(elementEventHandled);
        }

        [Fact]
        public void SvgElementSetPosition()
        {
            var element = new DummyElement()
            {
                X = 1f,
                Y = 2f,
            };

            Assert.Equal(1f, element.X.ToFloat());
            Assert.Equal(2f, element.Y.ToFloat());
            Assert.Equal(new PointF(1, 2), element.Position());

            element.SetPosition(new PointF(3, 4));
            Assert.Equal(3f, element.X.ToFloat());
            Assert.Equal(4f, element.Y.ToFloat());
            Assert.Equal(new PointF(3, 4), element.Position());
        }

        private class DummyElement : SvgElement
        {
            public override string Tag() => "dummy";
            public override RectangleF BoundingRect() => new RectangleF();
        }
    }
}
