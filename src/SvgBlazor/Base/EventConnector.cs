using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.Web;
using SvgBlazor.Interfaces;

namespace SvgBlazor
{
    public class EventConnector: IEventConnector
    {
        private bool _mouseDown = false;
        private ISvgElement _overElement;

        public virtual void ElementMouseOver(ISvgElement element, MouseEventArgs args)
        {
            if (_mouseDown)
            {
                return;
            }

            if (element != this)
            {
                _overElement = element;
            }
        }

        public virtual void ElementMouseOut(ISvgElement element, MouseEventArgs args)
        {
            if (_mouseDown)
            {
                return;
            }

            if (element != this)
            {
                _overElement = null;
            }
        }

        public virtual async Task OnClickHandler(MouseEventArgs args)
        {
            await (_overElement?.OnClickHandler(args) ?? Task.CompletedTask);
        }

        public virtual async Task OnMouseDownHandler(MouseEventArgs args)
        {
            _mouseDown = true;
            await (_overElement?.OnMouseDownHandler(args) ?? Task.CompletedTask);
        }

        public virtual async Task OnMouseMoveHandler(MouseEventArgs args)
        {
            await (_overElement?.OnMouseMoveHandler(args) ?? Task.CompletedTask);
        }

        public virtual async Task OnMouseUpHandler(MouseEventArgs args)
        {
            _mouseDown = false;
            await (_overElement?.OnMouseUpHandler(args) ?? Task.CompletedTask);
        }
    }
}
