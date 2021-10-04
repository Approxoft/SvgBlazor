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
    /// Svg container with draggable elements.
    /// </summary>
    public partial class SvgDraggable : SvgG
    {
        private float diffX = 0;
        private float diffY = 0;

        public override void ElementMouseOver(ISvgElement element, MouseEventArgs args)
        {
            if (MouseDown)
            {
                return;
            }
            base.ElementMouseOver(element, args);
        }

        public override void ElementMouseOut(ISvgElement element, MouseEventArgs args)
        {
            if (MouseDown)
            {
                return;
            }
            base.ElementMouseOut(element, args);
        }

        public override async Task OnMouseDownHandler(MouseEventArgs args)
        {
            if (OverElement is not null)
            {
                diffX = (float)args.OffsetX - OverElement.X;
                diffY = (float)args.OffsetY - OverElement.Y;
            }
            await base.OnMouseDownHandler(args);
        }

        public override async Task OnMouseMoveHandler(MouseEventArgs args)
        {
            if (MouseDown && OverElement is not null)
            {
                OverElement.X = (float)args.OffsetX - diffX;
                OverElement.Y = (float)args.OffsetY - diffY;
            }
            await base.OnMouseMoveHandler(args);
        }
    }
}
