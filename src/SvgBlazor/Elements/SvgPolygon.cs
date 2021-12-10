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
    /// The SvgPolygon class is responsible for providing the SVG polygon element.
    /// </summary>
    public class SvgPolygon : SvgElement
    {
        private List<PointF> _points = new ();

        private string _pointsString;

        public IEnumerable<PointF> Points
        {
            get => _points;
            set
            {
                _points = value.ToList();

                PointsToString();
            }
        }

        public override string Tag() => "polygon";

        public override void AddAttributes(RenderTreeBuilder builder)
        {
            base.AddAttributes(builder);
            builder.AddAttribute(0, "points", _pointsString);
        }

        public virtual void AddPoint(PointF point)
        {
            _points.Add(point);
            PointsToString();
        }

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
                sb.Append(point.X);
                sb.Append(' ');
                sb.Append(point.Y);
            }

            _pointsString = sb.ToString();
        }
    }
}
