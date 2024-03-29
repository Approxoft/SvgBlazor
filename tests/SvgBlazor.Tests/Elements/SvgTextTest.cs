﻿// Copyright (c) Approxoft. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

using Xunit;
using Bunit;

namespace SvgBlazor.Tests
{
    public class SvgTextTest : TestContextWithSvgBlazorJsModule
    {
        [Fact]
        public void RendersSvgTextWithParameters()
        {
            var comp = RenderComponent<SvgComponent>();

            comp.InvokeAsync(() => comp.Instance.Add(new SvgText
            {
                X = 1,
                Y = 2,
                ShiftX = 20,
                ShiftY = 30,
                TextLength = 123,
                Text = "Test string",
            }));

            comp.Render();
            var element = comp.Find("text");
            Assert.Contains("1", element.GetAttribute("x"));
            Assert.Contains("2", element.GetAttribute("y"));
            Assert.Contains("20", element.GetAttribute("dx"));
            Assert.Contains("30", element.GetAttribute("dy"));
            Assert.Contains("123", element.GetAttribute("textLength"));
            Assert.Contains("Test string", element.TextContent);
        }

        [Theory]
        [InlineData(TextLengthAdjust.Spacing, "spacing")]
        [InlineData(TextLengthAdjust.SpacingAndGlyphs, "spacingAndGlyphs")]
        public void RendersSvgTextWithLengthAdjustments(TextLengthAdjust textLengthAdjust, string expected)
        {
            var comp = RenderComponent<SvgComponent>();

            comp.InvokeAsync(() => comp.Instance.Add(new SvgText
            {
                LengthAdjust = textLengthAdjust,
                Text = "Test string",
            }));

            comp.Render();
            var element = comp.Find("text");
            Assert.Contains(expected, element.GetAttribute("lengthAdjust"));
            Assert.Contains("Test string", element.TextContent);
        }

        [Theory]
        [InlineData(TextAnchor.Start, "start")]
        [InlineData(TextAnchor.Middle, "middle")]
        [InlineData(TextAnchor.End, "end")]
        public void RendersSvgTextWithTextAnchor(TextAnchor anchor, string expected)
        {
            var comp = RenderComponent<SvgComponent>();

            comp.InvokeAsync(() => comp.Instance.Add(new SvgText
            {
                TextAnchor = anchor,
                Text = "Test string",
            }));

            comp.Render();
            var element = comp.Find("text");
            Assert.Contains(expected, element.GetAttribute("text-anchor"));
            Assert.Contains("Test string", element.TextContent);
        }

        [Theory]
        [InlineData(TextDominantBaseline.Auto, "auto")]
        [InlineData(TextDominantBaseline.TextBottom, "text-bottom")]
        [InlineData(TextDominantBaseline.Alphabetic, "alphabetic")]
        [InlineData(TextDominantBaseline.Ideographic, "ideographic")]
        [InlineData(TextDominantBaseline.Middle, "middle")]
        [InlineData(TextDominantBaseline.Central, "central")]
        [InlineData(TextDominantBaseline.Mathematical, "mathematical")]
        [InlineData(TextDominantBaseline.TextTop, "text-top")]
        public void RendersSvgTextWithDominantBaseline(TextDominantBaseline baseline, string expected)
        {
            var comp = RenderComponent<SvgComponent>();

            comp.InvokeAsync(() => comp.Instance.Add(new SvgText
            {
                DominantBaseline = baseline,
                Text = "Test string",
            }));

            var element = comp.Find("text");
            Assert.Contains(expected, element.GetAttribute("dominant-baseline"));
            Assert.Contains("Test string", element.TextContent);
        }

        [Fact]
        public void CopyConstructor()
        {
            var e1 = new SvgText()
            {
                X = 1f,
                Y = 2f,
                ShiftX = 20f,
                ShiftY = 30f,
                TextLength = 123f,
                Text = "Test string",
            };

            var e2 = new SvgText(e1);

            Assert.Equal(1f, e2.X.ToFloat());
            Assert.Equal(2f, e2.Y.ToFloat());
            Assert.Equal(20f, e2.ShiftX.ToFloat());
            Assert.Equal(30f, e2.ShiftY.ToFloat());
            Assert.Equal(123f, e2.TextLength.ToFloat());
            Assert.Equal("Test string", e2.Text);
        }
    }
}