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
    public abstract class SvgElement : SvgEventHandler, ISvgElement
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
            : base(element)
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

            var onMouseOverHandler = EventCallback.Factory.Create<MouseEventArgs>(this, OnMouseOverHandler);
            builder.AddAttribute(4, "onmouseover", onMouseOverHandler);

            var onMouseOutHandler = EventCallback.Factory.Create<MouseEventArgs>(this, OnMouseOutHandler);
            builder.AddAttribute(5, "onmouseout", onMouseOutHandler);

            Fill.RenderAttributes(builder);
            Stroke.RenderAttributes(builder);
        }

        /// <inheritdoc/>
        public virtual void SetParent(ISvgElement svgContainer) => _parent = svgContainer;

        /// <inheritdoc/>
        public virtual ISvgElement Parent() => _parent;

        /// <inheritdoc/>
        public virtual void Refresh() => _parent.Refresh();

        /// <inheritdoc/>
        public virtual void ElementMouseOver(ISvgElement element, MouseEventArgs args)
            => _parent?.ElementMouseOver(element, args);

        /// <inheritdoc/>
        public virtual void ElementMouseOut(ISvgElement element, MouseEventArgs args)
            => _parent?.ElementMouseOut(element, args);

        /// <inheritdoc/>
        public override async Task OnMouseOverHandler(MouseEventArgs args)
        {
            ElementMouseOver(this, args);
            await base.OnMouseOverHandler(args);
        }

        /// <inheritdoc/>
        public override async Task OnMouseOutHandler(MouseEventArgs args)
        {
            ElementMouseOut(this, args);
            await base.OnMouseOutHandler(args);
        }
    }
}
