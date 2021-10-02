using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.Web;

namespace SvgBlazor.Interfaces
{
    public interface IEventConnector
    {
        void ElementMouseOver(ISvgElement element, MouseEventArgs args);
        void ElementMouseOut(ISvgElement element, MouseEventArgs args);
        Task OnClickHandler(MouseEventArgs args);
        Task OnMouseDownHandler(MouseEventArgs args);
        Task OnMouseMoveHandler(MouseEventArgs args);
        Task OnMouseUpHandler(MouseEventArgs args);
    }
}
