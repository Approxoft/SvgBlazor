using System;
using System.Drawing;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using Microsoft.AspNetCore.Components.Web;
using SvgBlazor.Interfaces;

namespace SvgBlazor
{
    /// <summary>
    /// Svg G element
    /// </summary>
    public partial class SvgGDraggable : SvgContainer
    {
        public override string Tag() => "g";

        public override RectangleF BoundingRect() => throw new NotImplementedException();

        private bool _mouseDown = false;
        private float DiffX = 0;
        private float DiffY = 0;
        private ISvgElement _overElement;

        public override void ElementMouseOver(ISvgElement element, MouseEventArgs args)
        {
            if (_mouseDown)
            {
                return;
            }

            if (element != this)
            {
                _overElement = element;
            }
            base.ElementMouseOver(element, args);
        }

        public override void ElementMouseOut(ISvgElement element, MouseEventArgs args)
        {
            if (_mouseDown)
            {
                return;
            }

            if (element != this)
            {
                _overElement = null;
            }
            base.ElementMouseOut(element, args);
        }

        public override async Task OnClickHandler(MouseEventArgs args)
        {
            if (_overElement is not null)
            {
                await _overElement.OnClickHandler(args);
                await base.OnMouseDownHandler(args);
            }
        }

        public override async Task OnMouseDownHandler(MouseEventArgs args)
        {
            _mouseDown = true;
            if (_overElement is not null)
            {
                DiffX = (float)args.OffsetX - _overElement.X;
                DiffY = (float)args.OffsetY - _overElement.Y;
                await _overElement.OnMouseDownHandler(args);
                await base.OnMouseDownHandler(args);
            }
        }

        public override async Task OnMouseMoveHandler(MouseEventArgs args)
        {
            if (_overElement is not null)
            {
                if (_mouseDown)
                {
                    _overElement.X = (float)args.OffsetX - DiffX;
                    _overElement.Y = (float)args.OffsetY - DiffY;
                }
                await _overElement.OnMouseMoveHandler(args);
                await base.OnMouseMoveHandler(args);
            }
        }

        public override async Task OnMouseUpHandler(MouseEventArgs args)
        {
            _mouseDown = false;
            await (_overElement?.OnMouseMoveHandler(args)??Task.CompletedTask);
            await base.OnMouseUpHandler(args);
        }
    }
}
