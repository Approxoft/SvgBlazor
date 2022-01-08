using System;
using System.Drawing;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;

namespace SvgBlazor
{
    /// <summary>
    /// The SvgEllipse class is responsible for providing the SVG ellipse element.
    /// </summary>
    public class SvgEllipse : SvgElement
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SvgEllipse"/> class.
        /// </summary>
        public SvgEllipse()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SvgEllipse"/> class with privided SvgEllipse.
        /// </summary>
        /// <param name="svgellipse">Initial SvgEllipse.</param>
        public SvgEllipse(SvgEllipse svgellipse)
            : base(svgellipse)
        {
            CenterX = svgellipse.CenterX;
            CenterY = svgellipse.CenterY;
            RadiusX = svgellipse.RadiusX;
            RadiusY = svgellipse.RadiusY;
        }

        /// <summary>
        /// Gets or sets the x-axis coordinate of the center of the ellipse.
        /// </summary>
        public SvgValue CenterX
        {
            get => X;
            set => X = value;
        }

        /// <summary>
        /// Gets or sets the y-axis coordinate of the center of the ellipse.
        /// </summary>
        public SvgValue CenterY
        {
            get => Y;
            set => Y = value;
        }

        /// <summary>
        /// Gets or sets the radius on the x axis.
        /// </summary>
        public SvgValue RadiusX { get; set; }

        /// <summary>
        /// Gets or sets the radius on the y axis.
        /// </summary>
        public SvgValue RadiusY { get; set; }

        /// <inheritdoc/>
        public override string Tag() => "ellipse";

        /// <inheritdoc/>
        public override void AddAttributes(RenderTreeBuilder builder)
        {
            base.AddAttributes(builder);
            builder.AddAttribute(0, "cx", CenterX);
            builder.AddAttribute(1, "cy", CenterY);
            builder.AddAttribute(2, "rx", RadiusX);
            builder.AddAttribute(3, "ry", RadiusY);
        }
    }
}
