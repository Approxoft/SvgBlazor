using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace SvgBlazor.Interfaces
{
    public interface ISvgEventHandler
    {
        EventCallback<MouseEventArgs> OnClick { get; set; }

        EventCallback<MouseEventArgs> OnMouseDown { get; set; }

        EventCallback<MouseEventArgs> OnMouseMove { get; set; }

        EventCallback<MouseEventArgs> OnMouseUp { get; set; }

        EventCallback<MouseEventArgs> OnMouseOver { get; set; }

        EventCallback<MouseEventArgs> OnMouseOut { get; set; }

        Task OnClickHandler(MouseEventArgs args);

        Task OnMouseDownHandler(MouseEventArgs args);

        Task OnMouseMoveHandler(MouseEventArgs args);

        Task OnMouseUpHandler(MouseEventArgs args);

        Task OnMouseOverHandler(MouseEventArgs args);

        Task OnMouseOutHandler(MouseEventArgs args);
    }
}
