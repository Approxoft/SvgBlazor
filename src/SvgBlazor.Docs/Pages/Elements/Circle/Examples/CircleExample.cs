﻿using System;
using SvgBlazor.Docs.Interfaces;

namespace SvgBlazor.Docs.Examples
{
    public class CircleExample: IExampleCode
    {
        public void Example(SvgComponent svg)
        {
            var circle = new SvgCircle()
            {
                CenterX = 100,
                CenterY = 100,
                Radius = 20,
                Fill = new SvgFill { Color="blue", Opacity = 0.5f },
            };
            svg.Add(circle);
        }
    }
}
