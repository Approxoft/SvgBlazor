using System;
using System.Linq;
using SvgBlazor.Base;

namespace SvgBlazor.Layouts
{
    public class VerticalLayout : SvgLayout
    {
        public override void Update()
        {
            throw new NotImplementedException();
        }

        private float CalculateHeight() => elements.Sum(e => e.BoundingRect().Height);
    }
}
