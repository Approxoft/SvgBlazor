using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using SvgBlazor.Interfaces;

namespace SvgBlazor
{
    public class SvgEventHandler : ISvgEventHandler
    {
        public SvgEventHandler()
        {
        }

        public SvgEventHandler(SvgEventHandler svgeventhandler)
        {
            OnClick = svgeventhandler.OnClick;
            OnMouseDown = svgeventhandler.OnMouseDown;
            OnMouseMove = svgeventhandler.OnMouseMove;
            OnMouseUp = svgeventhandler.OnMouseUp;
            OnMouseOver = svgeventhandler.OnMouseOver;
            OnMouseOut = svgeventhandler.OnMouseOut;
        }

        public EventCallback<MouseEventArgs> OnClick { get; set; }

        public EventCallback<MouseEventArgs> OnMouseDown { get; set; }

        public EventCallback<MouseEventArgs> OnMouseMove { get; set; }

        public EventCallback<MouseEventArgs> OnMouseUp { get; set; }

        public EventCallback<MouseEventArgs> OnMouseOver { get; set; }

        public EventCallback<MouseEventArgs> OnMouseOut { get; set; }

        public virtual async Task OnClickHandler(MouseEventArgs args) => await OnClick.InvokeAsync(args);

        public virtual async Task OnMouseDownHandler(MouseEventArgs args) => await OnMouseDown.InvokeAsync(args);

        public virtual async Task OnMouseMoveHandler(MouseEventArgs args) => await OnMouseMove.InvokeAsync(args);

        public virtual async Task OnMouseUpHandler(MouseEventArgs args) => await OnMouseUp.InvokeAsync(args);

        public virtual async Task OnMouseOverHandler(MouseEventArgs args) => await OnMouseOver.InvokeAsync(args);

        public virtual async Task OnMouseOutHandler(MouseEventArgs args) => await OnMouseOut.InvokeAsync(args);
    }
}
