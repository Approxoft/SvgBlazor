using System;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using Microsoft.AspNetCore.Components.Web;
using SvgBlazor.Interfaces;

namespace SvgBlazor
{
    public abstract class SvgElement: ISvgElement
    {
        public SvgValue Id { get; set; }

        public string Class { get; set; }

        public string Style { get; set; }

        public Action<MouseEventArgs> OnClick { get; set; }
        public Action<MouseEventArgs> OnMouseDown { get; set; }
        public Action<MouseEventArgs> OnMouseMove { get; set; }
        public Action<MouseEventArgs> OnMouseUp { get; set; }

        private ISvgContainer _parent;

        public abstract string Tag();

        public virtual void BuildElement(RenderTreeBuilder builder)
        {
            builder.OpenElement(0, Tag());
            AddAttributes(builder);
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
        }

        public virtual void OnClickHandler(MouseEventArgs args) => OnClick?.Invoke(args);

        public virtual void OnMouseDownHandler(MouseEventArgs args) => OnMouseDown?.Invoke(args);

        public virtual void OnMouseMoveHandler(MouseEventArgs args) => OnMouseMove?.Invoke(args);

        public virtual void OnMouseUpHandler(MouseEventArgs args) => OnMouseUp?.Invoke(args);

        public virtual void SetParent(ISvgContainer svgContainer) => _parent = svgContainer;

        public virtual ISvgContainer Parent() => _parent;

        public virtual void Refresh() => _parent.Refresh();

        protected virtual void OnMouseOverHandler(MouseEventArgs args) => _parent.ElementMouseOver(this, args);

        protected virtual void OnMouseOutHandler(MouseEventArgs args) => _parent.ElementMouseOut(this, args);
    }
}
