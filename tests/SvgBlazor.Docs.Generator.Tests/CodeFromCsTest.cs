using System.IO;
using System.Text;
using Xunit;

namespace SvgBlazor.Docs.Generator.Tests
{
    public class CodeFromCsTest
    {
        [Fact]
        public void ReturnsExampleCodeFromFullCode()
        {
            const string exampleCode =
@"using System;
using SvgBlazor.Docs.Interfaces;

namespace SvgBlazor.Docs.Examples
{
    public class CircleExample: IExampleCode
    {
//#example-code-start
        public void Example(SvgComponent svg)
        {
            var circle = new SvgCircle()
            {
                CenterX = 100,
                Fill = new SvgFill { Color = ""blue"", Opacity = 0.5f },
            };
            svg.Add(circle);
        }
//#example-code-end
    }
}";
            ExamplesCode ec = new ();
            using var stream = GenerateStreamFromString(exampleCode);
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

        [Fact]
        public void ReturnsExampleCodeWithTwoExamples()
        {
            const string exampleCode =
@"using System;
using SvgBlazor.Docs.Interfaces;

namespace SvgBlazor.Docs.Examples
{
    public class CircleExample: IExampleCode
    {
//#example-code-start
        public void Example(SvgComponent svg)
//#example-code-end
        {
            var circle = new SvgCircle()
            {
//#example-code-start
                CenterX = 100,
                Fill = new SvgFill { Color = ""blue"", Opacity = 0.5f },
//#example-code-end
            };
            svg.Add(circle);
        }

    }
}";
            ExamplesCode ec = new();
            using var stream = GenerateStreamFromString(exampleCode);
            string code = ec.GetCodeFromStream(new StreamReader(stream));
            string expectedCode =
@"public void Example(SvgComponent svg)

...

CenterX = 100,
Fill = new SvgFill { Color = ""blue"", Opacity = 0.5f },";
            Assert.Equal(expectedCode, code);
        }

        private static MemoryStream GenerateStreamFromString(string value)
        {
            return new MemoryStream(Encoding.UTF8.GetBytes(value ?? string.Empty));
        }
    }
}
