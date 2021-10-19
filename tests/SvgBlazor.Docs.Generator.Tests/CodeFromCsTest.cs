using System;
using System.IO;
using System.Text;
using Xunit;
using SvgBlazor.Docs.Generator;

namespace SvgBlazor.Docs.Generator.Tests
{
    public class CodeFromCsTest
    {
        [Fact]
        public void ReturnsExampleCodeFromFullCode()
        {
            ExamplesCode ec = new ();

            const string exampleCode =
@"using System;
using SvgBlazor.Docs.Interfaces;

namespace SvgBlazor.Docs.Examples
{
    public class CircleExample: IExampleCode
    {
        public void Example(SvgComponent svg)
        {
            var circle = new SvgCircle()
            {
                CenterX = 100,
                Fill = new SvgFill { Color = ""blue"", Opacity = 0.5f },
            };
            svg.Add(circle);
        }
    }
}";
            using (var stream = GenerateStreamFromString(exampleCode))
            {
                string code = ec.GetCodeFromStream(new StreamReader(stream));
                const string expectedCode =
@"public void Example(SvgComponent svg)
{
    var circle = new SvgCircle()
    {
        CenterX = 100,
        Fill = new SvgFill { Color = ""blue"", Opacity = 0.5f },
    };
    svg.Add(circle);
}";
                Assert.Equal(expectedCode, code);
            }
        }

        [Fact]
        public void ReturnsExampleCodeWhenBracesShareMethodNameLine()
        {
            ExamplesCode ec = new ();

            const string exampleCode =
@"public void Example(SvgComponent svg) {
    var circle = new SvgCircle() {
        Fill = new SvgFill { Color = ""blue"", Opacity = 0.5f },
    };
}";
            using (var stream = GenerateStreamFromString(exampleCode))
            {
                string code = ec.GetCodeFromStream(new StreamReader(stream));
                Assert.Equal(exampleCode, code);
            }
        }

        private static MemoryStream GenerateStreamFromString(string value)
        {
            return new MemoryStream(Encoding.UTF8.GetBytes(value ?? ""));
        }
    }
}
