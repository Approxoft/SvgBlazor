using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.Rendering;
using Microsoft.AspNetCore.Components.Web;

namespace SvgBlazor.Interfaces
{
    public interface ISvgElement: ISvgEventHandler
    {
        string Tag();

        void BuildElement(RenderTreeBuilder builder);

        void SetParent(ISvgElement parent);

        ISvgElement Parent();

        void Refresh();

        void ElementMouseOver(ISvgElement element, MouseEventArgs args);

        void ElementMouseOut(ISvgElement element, MouseEventArgs args);
    }
}
