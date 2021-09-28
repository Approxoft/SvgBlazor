using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.Rendering;
using Microsoft.AspNetCore.Components.Web;

namespace SvgBlazor.Interfaces
{
    public interface ISvgElement
    {
        string Tag();
        void BuildElement(RenderTreeBuilder builder);
        void SetParent(ISvgElement parent);
        ISvgElement Parent();
        void Refresh();

        Task OnClickHandler(MouseEventArgs args);
        Task OnMouseDownHandler(MouseEventArgs args);
        Task OnMouseMoveHandler(MouseEventArgs args);
        Task OnMouseUpHandler(MouseEventArgs args);

        void ElementMouseOver(ISvgElement element, MouseEventArgs args);
        void ElementMouseOut(ISvgElement element, MouseEventArgs args);
    }
}
