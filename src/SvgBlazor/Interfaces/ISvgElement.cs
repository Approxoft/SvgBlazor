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
        void OnClickHandler(MouseEventArgs args);
        void OnMouseDownHandler(MouseEventArgs args);
        void OnMouseMoveHandler(MouseEventArgs args);
        void OnMouseUpHandler(MouseEventArgs args);

        void ElementMouseOver(ISvgElement element, MouseEventArgs args);
        void ElementMouseOut(ISvgElement element, MouseEventArgs args);
    }
}
