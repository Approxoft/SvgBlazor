// Copyright (c) Approxoft. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

using System.Drawing;
using Xunit;
using Bunit;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components;

namespace SvgBlazor.Tests
{
    public class ElementTest : TestContextWithSvgBlazorJsModule
    {
        [Fact]
        public void ElementWithParameters()
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
        public void ElementOnMouseOut()
        {
            var comp = RenderComponent<SvgComponent>();
            bool elementEventHandled = false;

            comp.InvokeAsync(() => comp.Instance.Add(new DummyElement()
            {
                OnMouseOut = EventCallback.Factory.Create<MouseEventArgs>(this, (args) => { elementEventHandled = true; })
            }));

            comp.Find("dummy").MouseOut();
            Assert.True(elementEventHandled);
        }

        [Fact]
        public void ElementOnMouseOver()
        {
            var comp = RenderComponent<SvgComponent>();
            bool elementEventHandled = false;

            comp.InvokeAsync(() => comp.Instance.Add(new DummyElement()
            {
                OnMouseOver = EventCallback.Factory.Create<MouseEventArgs>(this, (args) => { elementEventHandled = true; })
            }));

            comp.Find("dummy").MouseOver();
            Assert.True(elementEventHandled);
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

            comp.Find("dummy").Click();
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

            comp.Find("dummy").MouseDown();
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

            comp.Find("dummy").MouseUp();
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

            comp.Find("dummy").MouseMove();
            Assert.True(elementEventHandled);
        }

        [Fact]
        public void CopyConstructor()
        {
            var e1 = new DummyElement()
            {
                X = 1f,
                Y = 2f,
                Id = "3",
                Class = "4",
                Style = "5",
                Fill = new SvgFill() { Color = "red" },
            };

            var e2 = new DummyElement(e1);

            Assert.Equal(1f, e2.X.ToFloat());
            Assert.Equal(2f, e2.Y.ToFloat());
            Assert.Equal("3", e2.Id);
            Assert.Equal("4", e2.Class);
            Assert.Equal("5", e2.Style);
            Assert.Equal("red", e2.Fill.Color);
        }

        private class DummyElement : SvgElement
        {
            public DummyElement()
            {
            }

            public DummyElement(DummyElement dummyelement)
                : base(dummyelement)
            {
            }

            public override string Tag() => "dummy";
        }
    }
}