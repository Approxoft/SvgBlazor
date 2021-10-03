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

        private float DiffX = 0;
        private float DiffY = 0;

        public override async Task OnMouseDownHandler(MouseEventArgs args)
        {
            if (OverElement is not null)
            {
                DiffX = (float)args.OffsetX - OverElement.X;
                DiffY = (float)args.OffsetY - OverElement.Y;
            }
            await base.OnMouseDownHandler(args);
        }

        public override async Task OnMouseMoveHandler(MouseEventArgs args)
        {
            if (MouseDown && OverElement is not null)
            {
                OverElement.X = (float)args.OffsetX - DiffX;
                OverElement.Y = (float)args.OffsetY - DiffY;
            }
            await base.OnMouseMoveHandler(args);
        }
    }
}
