using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;

namespace SvgBlazor
{
    /// <summary>
    /// SVG polygon element.
    /// </summary>
    public class SvgPolygon : SvgElement
    {
        /// <summary>
        /// The color used to paint the outline of the shape.
        /// </summary>
        public string Stroke { get; set; }

        private List<PointF> _points = new();
        public List<PointF> Points
        {
            set
            {
                _points = value;
                PointsToString();
                UpdateBoundingRect();

            }
            get => _points;
        }

        private string _pointsString;

        private float _boundingRectX1;
        private float _boundingRectY1;
        private float _boundingRectX2;
        private float _boundingRectY2;
        private float _boundingRectWidth;
        private float _boundingRectHeight;

        public SvgPolygon() => ResetBoundingRect();

        public override string Tag() => "polygon";

        public override void AddAttributes(RenderTreeBuilder builder)
        {
            base.AddAttributes(builder);
            builder.AddAttribute(0, "points", _pointsString);
            builder.AddAttribute(1, "stroke", Stroke);
        }

        public override RectangleF BoundingRect() => new(_boundingRectX1,
                                                         _boundingRectY1,
                                                         _boundingRectWidth,
                                                         _boundingRectHeight);

        public virtual void AddPoint(PointF point)
        {
            _points.Add(point);
            UpdateBoundingRect();
            PointsToString();
        }

        public virtual void ClearPoints()
        {
            _points.Clear();
            ResetBoundingRect();
            PointsToString();
        }

        private void UpdateBoundingRect()
        {
            if (_points is null || _points.Count is 0)
                return;

            var lastPoint = _points.Last();

            _boundingRectX1 = Math.Min(lastPoint.X, _boundingRectX1);
            _boundingRectY1 = Math.Min(lastPoint.Y, _boundingRectY1);
            _boundingRectX2 = Math.Max(lastPoint.X, _boundingRectX2);
            _boundingRectY2 = Math.Max(lastPoint.Y, _boundingRectY2);
            _boundingRectWidth = _boundingRectX2 - _boundingRectX1;
            _boundingRectHeight = _boundingRectY2 - _boundingRectY1;
        }

        private void ResetBoundingRect()
        {
            _boundingRectX1 = float.MaxValue;
            _boundingRectY1 = float.MaxValue;
            _boundingRectX2 = float.MinValue;
            _boundingRectY2 = float.MinValue;
            _boundingRectWidth = 0;
            _boundingRectHeight = 0;
        }

        private void PointsToString()
        {
            const int charactersPerPoint = 10;
            var sb = new StringBuilder(_points.Count*charactersPerPoint);
            for (int i=0; i<_points.Count; i++)
            {
                if (i>0) {
                    sb.Append(' ');
                }
                var point = _points[i];
                sb.Append(point.X);
                sb.Append(' ');
                sb.Append(point.Y);
            }
            _pointsString = sb.ToString();
        }
    }
}
