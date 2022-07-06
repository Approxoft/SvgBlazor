// Copyright (c) Approxoft. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using Microsoft.AspNetCore.Components.Web;
using SvgBlazor.Interfaces;

namespace SvgBlazor
{
    /// <summary>
    /// The base class for SVG elements.
    /// </summary>
    public abstract class SvgElement : ISvgElement
    {
        private ISvgElement _parent;

        /// <summary>
        /// Initializes a new instance of the <see cref="SvgElement"/> class.
        /// </summary>
        public SvgElement()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SvgElement"/> class with provided SvgElement.
        /// </summary>
        /// <param name="element">Initial SvgElement.</param>
        public SvgElement(SvgElement element)
        {
            X = element.X;
            Y = element.Y;
            Id = element.Id;
            Class = element.Class;
            Style = element.Style;
            Fill = element.Fill;
        }

        /// <inheritdoc/>
        public SvgValue X { get; set; } = 0;

        /// <inheritdoc/>
        public SvgValue Y { get; set; } = 0;

        /// <inheritdoc/>
        public ElementReference ElementReference { get; set; }

        /// <summary>
        /// Gets or sets the element id.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the element class.
        /// </summary>
        public string Class { get; set; }

        /// <summary>
        /// Gets or sets the element style.
        /// </summary>
        public string Style { get; set; }

        /// <summary>
        /// Gets or sets the element fill.
        /// </summary>
        public SvgFill Fill { get; set; } = new ();

        /// <summary>
        /// Gets or sets the element stroke.
        /// </summary>
        public SvgStroke Stroke { get; set; } = new ();

        /// <inheritdoc/>
        public EventCallback<MouseEventArgs> OnClick { get; set; }

        /// <inheritdoc/>
        public EventCallback<MouseEventArgs> OnMouseDown { get; set; }

        /// <inheritdoc/>
        public EventCallback<MouseEventArgs> OnMouseMove { get; set; }

        /// <inheritdoc/>
        public EventCallback<MouseEventArgs> OnMouseUp { get; set; }

        /// <inheritdoc/>
        public EventCallback<MouseEventArgs> OnMouseOver { get; set; }

        /// <inheritdoc/>
        public EventCallback<MouseEventArgs> OnMouseOut { get; set; }

        /// <inheritdoc/>
        public abstract string Tag();

        /// <inheritdoc/>
        public virtual void BuildElement(RenderTreeBuilder builder)
        {
            builder.OpenElement(0, Tag());
            AddAttributes(builder);
            BuildElementAdditionalSteps(builder);
            builder.AddElementReferenceCapture(1, er => ElementReference = er);
            builder.CloseElement();
        }

        /// <inheritdoc/>
        public virtual void BuildElementAdditionalSteps(RenderTreeBuilder builder)
        {
        }

        /// <summary>
        /// Adds RenderTreeBuilder attributes.
        /// </summary>
        /// <param name="builder">The RenderTreeBuilder used to add attributes.</param>
        public virtual void AddAttributes(RenderTreeBuilder builder)
        {
            builder.AddAttribute(1, "id", Id);
            builder.AddAttribute(2, "class", Class);
            builder.AddAttribute(3, "style", Style);

            if (OnClick.HasDelegate)
            {
                var onClickHandler = EventCallback.Factory.Create<MouseEventArgs>(this, OnClickHandler);
                builder.AddAttribute(4, "onclick", onClickHandler);
            }

            if (OnMouseDown.HasDelegate)
            {
                var onMouseDownHandler = EventCallback.Factory.Create<MouseEventArgs>(this, OnMouseDownHandler);
                builder.AddAttribute(5, "onmousedown", onMouseDownHandler);
            }

            if (OnMouseMove.HasDelegate)
            {
                var onMouseMoveHandler = EventCallback.Factory.Create<MouseEventArgs>(this, OnMouseMoveHandler);
                builder.AddAttribute(6, "onmousemove", onMouseMoveHandler);
            }

            if (OnMouseUp.HasDelegate)
            {
                var onMouseUpHandler = EventCallback.Factory.Create<MouseEventArgs>(this, OnMouseUpHandler);
                builder.AddAttribute(7, "onmouseup", onMouseUpHandler);
            }

            if (OnMouseOver.HasDelegate)
            {
                var onMouseOverHandler = EventCallback.Factory.Create<MouseEventArgs>(this, OnMouseOverHandler);
                builder.AddAttribute(8, "onmouseover", onMouseOverHandler);
            }

            if (OnMouseOut.HasDelegate)
            {
                var onMouseOutHandler = EventCallback.Factory.Create<MouseEventArgs>(this, OnMouseOutHandler);
                builder.AddAttribute(9, "onmouseout", onMouseOutHandler);
            }

            Fill.RenderAttributes(builder);
            Stroke.RenderAttributes(builder);
        }

        /// <inheritdoc/>
        public virtual void SetParent(ISvgElement svgContainer) => _parent = svgContainer;

        /// <inheritdoc/>
        public virtual ISvgElement Parent() => _parent;

        /// <inheritdoc/>
        public virtual void Refresh() => _parent.Refresh();

        private async Task OnMouseOverHandler(MouseEventArgs args) => await OnMouseOver.InvokeAsync(args);

        private async Task OnMouseOutHandler(MouseEventArgs args) => await OnMouseOut.InvokeAsync(args);

        private async Task OnClickHandler(MouseEventArgs args) => await OnClick.InvokeAsync();

        private async Task OnMouseDownHandler(MouseEventArgs args) => await OnMouseDown.InvokeAsync(args);

        private async Task OnMouseMoveHandler(MouseEventArgs args) => await OnMouseMove.InvokeAsync(args);

        private async Task OnMouseUpHandler(MouseEventArgs args) => await OnMouseUp.InvokeAsync(args);
    }
}
