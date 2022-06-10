// Copyright (c) Approxoft. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

using System;
using System.Drawing;
using Bunit;
using Xunit;

namespace SvgBlazor.Tests.Components
{
    public class SvgComponentTests : TestContextWithSvgBlazorJsModule
    {
        [Fact]
        public async void CalculatesBoudingBox()
        {
            var comp = RenderComponent<SvgComponent>();
            var circle = new SvgCircle
            {
                CenterX = 1,
                CenterY = 2,
                Radius = 3,
            };

            await comp.InvokeAsync(() => comp.Instance.Add(circle));

            comp.Render();

            var bbox = await comp.Instance.GetBoundingBox(circle);
            Assert.Equal(new RectangleF(0, 0, 10, 10), bbox);
        }

        [Fact]
        public void RendersMarkupWithoutEvents()
        {
            var comp = RenderComponent<SvgComponent>();
            var actual = comp.Markup;
            var expected = @"<svg viewBox=""0 0 0 0"" width=""0"" height=""0""></svg>";

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void SvgComponentOnClick()
        {
            bool eventHandled = false;

            var comp = RenderComponent<SvgComponent>(parameters => parameters
                .Add(p => p.OnClick, _ => { eventHandled = true; })
            );

            comp.Find("svg").Click();

            var actual = comp.Markup;
            var expected = @"<svg blazor:onclick=""1"" viewBox=""0 0 0 0"" width=""0"" height=""0""></svg>";

            Assert.Equal(expected, actual);
            Assert.True(eventHandled);
        }

        [Fact]
        public void SvgComponentOnMouseDown()
        {
            bool eventHandled = false;

            var comp = RenderComponent<SvgComponent>(parameters => parameters
                .Add(p => p.OnMouseDown, _ => { eventHandled = true; })
            );

            comp.Find("svg").MouseDown();

            var actual = comp.Markup;
            var expected = @"<svg blazor:onmousedown=""1"" viewBox=""0 0 0 0"" width=""0"" height=""0""></svg>";

            Assert.Equal(expected, actual);
            Assert.True(eventHandled);
        }

        [Fact]
        public void SvgComponentOnMouseUp()
        {
            bool eventHandled = false;

            var comp = RenderComponent<SvgComponent>(parameters => parameters
                .Add(p => p.OnMouseUp, _ => { eventHandled = true; })
            );

            comp.Find("svg").MouseUp();

            var actual = comp.Markup;
            var expected = @"<svg blazor:onmouseup=""1"" viewBox=""0 0 0 0"" width=""0"" height=""0""></svg>";

            Assert.Equal(expected, actual);
            Assert.True(eventHandled);
        }

        [Fact]
        public void SvgComponentOnMouseMove()
        {
            bool eventHandled = false;

            var comp = RenderComponent<SvgComponent>(parameters => parameters
                .Add(p => p.OnMouseMove, _ => { eventHandled = true; })
            );

            comp.Find("svg").MouseMove();

            var actual = comp.Markup;
            var expected = @"<svg blazor:onmousemove=""1"" viewBox=""0 0 0 0"" width=""0"" height=""0""></svg>";

            Assert.Equal(expected, actual);
            Assert.True(eventHandled);
        }

        [Fact]
        public void SvgComponentOnMouseOver()
        {
            bool eventHandled = false;

            var comp = RenderComponent<SvgComponent>(parameters => parameters
                .Add(p => p.OnMouseOver, _ => { eventHandled = true; })
            );

            comp.Find("svg").MouseOver();

            var actual = comp.Markup;
            var expected = @"<svg blazor:onmouseover=""1"" viewBox=""0 0 0 0"" width=""0"" height=""0""></svg>";

            Assert.Equal(expected, actual);
            Assert.True(eventHandled);
        }

        [Fact]
        public void SvgComponentOnMouseOut()
        {
            bool eventHandled = false;

            var comp = RenderComponent<SvgComponent>(parameters => parameters
                .Add(p => p.OnMouseOut, _ => { eventHandled = true; })
            );

            comp.Find("svg").MouseOut();

            var actual = comp.Markup;
            var expected = @"<svg blazor:onmouseout=""1"" viewBox=""0 0 0 0"" width=""0"" height=""0""></svg>";

            Assert.Equal(expected, actual);
            Assert.True(eventHandled);
        }

        [Fact]
        public void SvgComponentAllEvents()
        {
            var comp = RenderComponent<SvgComponent>(parameters => parameters
                .Add(p => p.OnClick, _ => { })
                .Add(p => p.OnMouseDown, _ => { })
                .Add(p => p.OnMouseUp, _ => { })
                .Add(p => p.OnMouseMove, _ => { })
                .Add(p => p.OnMouseOver, _ => { })
                .Add(p => p.OnMouseOut, _ => { })
            );

            var actual = comp.Markup;
            var expected = @"<svg blazor:onclick=""1"" blazor:onmousedown=""2"" blazor:onmousemove=""3"" blazor:onmouseup=""4"" blazor:onmouseover=""5"" blazor:onmouseout=""6"" viewBox=""0 0 0 0"" width=""0"" height=""0""></svg>";

            Assert.Equal(expected, actual);
        }

        private class DummyElement : SvgElement
        {
            public override string Tag() => "dummy";
        }
    }
}
