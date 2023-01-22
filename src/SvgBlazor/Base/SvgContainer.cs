// Copyright (c) Approxoft. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.Rendering;
using Microsoft.AspNetCore.Components.Web;
using SvgBlazor.Interfaces;

namespace SvgBlazor
{
    /// <summary>
    /// The base class of SVG container elements.
    /// </summary>
    public abstract class SvgContainer : SvgElement, ISvgContainer
    {
        private readonly List<ISvgElement> _elements = new ();

        /// <summary>
        /// Initializes a new instance of the <see cref="SvgContainer"/> class.
        /// </summary>
        public SvgContainer()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SvgContainer"/> class with provided SVG container.
        /// </summary>
        /// <param name="svgcontainer">Initial SVG container.</param>
        public SvgContainer(SvgContainer svgcontainer)
            : base(svgcontainer)
        {
        }

        /// <inheritdoc/>
        public ISvgContainer Add(ISvgElement element)
        {
            element.SetParent(this);
            _elements.Add(element);
            return this;
        }

        /// <inheritdoc/>
        public ISvgContainer Remove(ISvgElement element)
        {
            _elements.Remove(element);
            return this;
        }

        /// <inheritdoc/>
        public override void BuildElementAdditionalSteps(RenderTreeBuilder builder) => AddElements(builder);

        /// <summary>
        /// Adds elements of this container to the RenderTreeBuilder.
        /// </summary>
        /// <param name="builder">The RenderTreeBuilder to be used.</param>
        protected virtual void AddElements(RenderTreeBuilder builder)
        {
            foreach (var element in _elements)
            {
                if (element.IsRenderable)
                {
                    element.BuildElement(builder);
                }
            }
        }
    }
}
