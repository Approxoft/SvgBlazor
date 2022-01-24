// Copyright (c) Approxoft. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;

namespace SvgBlazor
{
    /// <summary>
    /// The SvgPolygon class is responsible for providing the SVG polygon element.
    /// </summary>
    public class SvgPolygon : SvgElement
    {
        private readonly NumberFormatInfo _numberFormatInfo = new () { NumberDecimalSeparator = "." };

        private List<PointF> _points = new ();

        private string _pointsString;

        /// <summary>
        /// Initializes a new instance of the <see cref="SvgPolygon"/> class.
        /// </summary>
        public SvgPolygon()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SvgPolygon"/> class with provided SvgPolygon.
        /// </summary>
        /// <param name="svgpolygon">Initial SvgPolygon.</param>
        public SvgPolygon(SvgPolygon svgpolygon)
            : base(svgpolygon)
        {
            _points = new List<PointF>(svgpolygon._points);
            _pointsString = svgpolygon._pointsString;
        }

        /// <summary>
        /// Gets or sets the points of the polygon.
        /// </summary>
        public IEnumerable<PointF> Points
        {
            get => _points;
            set
            {
                _points = value.ToList();

                PointsToString();
            }
        }

        /// <inheritdoc/>
        public override string Tag() => "polygon";

        /// <inheritdoc/>
        public override void AddAttributes(RenderTreeBuilder builder)
        {
            base.AddAttributes(builder);
            builder.AddAttribute(0, "points", _pointsString);
        }

        /// <summary>
        /// Adds a point to the path.
        /// </summary>
        /// <param name="point">A point to add.</param>
        public virtual void AddPoint(PointF point)
        {
            _points.Add(point);
            PointsToString();
        }

        /// <summary>
        /// Removes all points from the path.
        /// </summary>
        public virtual void ClearPoints()
        {
            _points.Clear();
            PointsToString();
        }

        private void PointsToString()
        {
            const int charactersPerPoint = 10;
            var sb = new StringBuilder(_points.Count * charactersPerPoint);

            for (int i = 0; i < _points.Count; i++)
            {
                if (i > 0)
                {
                    sb.Append(' ');
                }

                var point = _points[i];
                sb.Append(point.X.ToString(_numberFormatInfo));
                sb.Append(' ');
                sb.Append(point.Y.ToString(_numberFormatInfo));
            }

            _pointsString = sb.ToString();
        }
    }
}
