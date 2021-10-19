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
    }
}