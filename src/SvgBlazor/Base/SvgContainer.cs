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
            MouseDown = svgcontainer.MouseDown;
            OverElement = svgcontainer.OverElement;
        }

        /// <summary>
        /// Gets a value indicating whether the mouse is down.
        /// </summary>
        public bool MouseDown { get; private set; } = false;

        /// <summary>
        /// Gets the element that the mouse cursor is currently over.
        /// </summary>
        public ISvgElement OverElement { get; private set; }

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

        /// <inheritdoc/>
        public override void ElementMouseOver(ISvgElement element, MouseEventArgs args)
        {
            if (element != this)
            {
                OverElement = element;
            }

            base.ElementMouseOver(this, args);
        }

        /// <inheritdoc/>
        public override void ElementMouseOut(ISvgElement element, MouseEventArgs args)
        {
            if (element != this)
            {
                OverElement = null;
            }

            base.ElementMouseOut(this, args);
        }

        /// <inheritdoc/>
        public override async Task OnClickHandler(MouseEventArgs args)
        {
            if (OverElement is not null)
            {
                await OverElement.OnClickHandler(args);
                await base.OnMouseDownHandler(args);
            }
        }

        /// <inheritdoc/>
        public override async Task OnMouseDownHandler(MouseEventArgs args)
        {
            MouseDown = true;
            if (OverElement is not null)
            {
                await OverElement.OnMouseDownHandler(args);
                await base.OnMouseDownHandler(args);
            }
        }

        /// <inheritdoc/>
        public override async Task OnMouseMoveHandler(MouseEventArgs args)
        {
            if (OverElement is not null)
            {
                await OverElement.OnMouseMoveHandler(args);
                await base.OnMouseMoveHandler(args);
            }
        }

        /// <inheritdoc/>
        public override async Task OnMouseUpHandler(MouseEventArgs args)
        {
            MouseDown = false;
            await (OverElement?.OnMouseUpHandler(args) ?? Task.CompletedTask);
            await base.OnMouseUpHandler(args);
        }

        /// <summary>
        /// Adds elements of this container to the RenderTreeBuilder.
        /// </summary>
        /// <param name="builder">The RenderTreeBuilder to be used.</param>
        protected virtual void AddElements(RenderTreeBuilder builder)
        {
            foreach (var element in _elements)
            {
                element.BuildElement(builder);
            }
        }
    }
}
