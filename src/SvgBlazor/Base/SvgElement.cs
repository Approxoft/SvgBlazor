﻿using System;
using System.Drawing;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.JSInterop;
using SvgBlazor.Extensions;
using SvgBlazor.Interfaces;

namespace SvgBlazor
{
    public abstract class SvgElement : SvgEventHandler, ISvgElement, ISvgElementReferenceable
    {
        private ISvgElement _parent;

        public SvgValue X { get; set; } = 0;

        public SvgValue Y { get; set; } = 0;

        public ElementReference ElementReference { get; set; }

        public IJSRuntime JSRuntime { get; set; }

        private IBoundingBoxable _boundingBoxable; 

        public string Id { get; set; }

        public string Class { get; set; }

        public string Style { get; set; }

        public SvgFill Fill { get; set; } = new ();

        public SvgStroke Stroke { get; set; } = new ();

        public abstract string Tag();

        public virtual void BuildElement(RenderTreeBuilder builder)
        {
            builder.OpenElement(0, Tag());
            AddAttributes(builder);
            builder.AddElementReferenceCapture(1, er => ElementReference = er);
            builder.CloseElement();
        }

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

        public virtual void SetParent(ISvgElement svgContainer) => _parent = svgContainer;

        public virtual void SetBoundingBoxable(IBoundingBoxable boundingBoxable) => _boundingBoxable = boundingBoxable;

        public virtual ISvgElement Parent() => _parent;

        public virtual void Refresh() => _parent.Refresh();

        public virtual void ElementMouseOver(ISvgElement element, MouseEventArgs args)
            => _parent?.ElementMouseOver(element, args);

        public virtual void ElementMouseOut(ISvgElement element, MouseEventArgs args)
            => _parent?.ElementMouseOut(element, args);

        public override async Task OnMouseOverHandler(MouseEventArgs args)
        {
            ElementMouseOver(this, args);
            await base.OnMouseOverHandler(args);
        }

        public override async Task OnMouseOutHandler(MouseEventArgs args)
        {
            ElementMouseOut(this, args);
            await base.OnMouseOutHandler(args);
        }

        public abstract RectangleF BoundingRect();

        public async Task<RectangleF> BoundingRect2() => await _boundingBoxable.GetBoundingBox(this);
    }
}
