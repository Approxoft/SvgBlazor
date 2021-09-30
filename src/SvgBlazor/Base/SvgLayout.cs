using SvgBlazor.Interfaces;
using System.Collections.Generic;

namespace SvgBlazor.Base
{
    public abstract class SvgLayout: ISvgLayout
    {
        private readonly List<ISvgElement> elements = new();

        public void AddElement(ISvgElement element)
        {
            if (!elements.Contains(element)) {
                elements.Add(element);
            }
        }

        public abstract void Update();
    }
}