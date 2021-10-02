using System;
using SvgBlazor.Docs.Interfaces;
using SvgBlazor.Layouts;

namespace SvgBlazor.Docs.Pages
{
    public class VerticalLayoutExample : IExampleCode
    {
        public void Example(SvgComponent svg)
        {
            var container = new SvgG();
            var rect1 = new SvgRect()
            {
                Width = 100,
                Height = 50,
            };

            var rect2 = new SvgRect()
            {
                Width = 100,
                Height = 50,
            };

            container.Add(rect1);
            container.Add(rect2);
            container.Layout = new VerticalLayout();

            svg.Add(container);
        }
    }
}
