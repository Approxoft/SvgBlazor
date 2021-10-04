using System;
using SvgBlazor.Docs.Interfaces;

namespace SvgBlazor.Docs.Examples
{
    public class DraggableExample : IExampleCode
    {
        public void Example(SvgComponent svg)
        {
            var group = new SvgDraggable();
            group.Add(new SvgCircle() { CenterX = 100, CenterY = 100, Radius = 20 });
            group.Add(new SvgCircle() { CenterX = 50, CenterY = 50, Radius = 10 });
            svg.Add(group);
        }
    }
}
