using System;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using Microsoft.AspNetCore.Components.Web;

namespace SvgBlazor
{
    /// <summary>
    /// SVG circle element.
    /// </summary>
    public class SvgCircle : SvgElement
    {
        /// <summary>
        /// The x-axis coordinate of the center of the circle.
        /// </summary>
        public SvgValue CenterX { get; set; }

        /// <summary>
        /// The y-axis coordinate of the center of the circle.
        /// </summary>
        public SvgValue CenterY { get; set; }

        /// <summary>
        /// The radius of the circle.
        /// </summary>
        public SvgValue Radius { get; set; }

        private bool mouseDown = false;

        private double DiffX = 0;
        private double DiffY = 0;

        public override string Tag() => "circle";

        public override void AddAttributes(RenderTreeBuilder builder)
        {
            base.AddAttributes(builder);
            builder.AddAttribute(0, "cx", CenterX);
            builder.AddAttribute(1, "cy", CenterY);
            builder.AddAttribute(2, "r", Radius);
        }

        public override void OnMouseDownHandler(MouseEventArgs args)
        {
            mouseDown = true;
            DiffX = args.OffsetX - CenterX.ToDouble();
            DiffY = args.OffsetY - CenterY.ToDouble();
        }

        public override void OnMouseMoveHandler(MouseEventArgs args)
        {
            if (mouseDown)
            {
                CenterX = args.OffsetX - DiffX;
                CenterY = args.OffsetY - DiffY;
            }
            OnMouseMove.InvokeAsync(args);
        }

        public override void OnMouseUpHandler(MouseEventArgs args)
        {
            mouseDown = false;
            OnMouseUp.InvokeAsync(args);
        }
    }
}
