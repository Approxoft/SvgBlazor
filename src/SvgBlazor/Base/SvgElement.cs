using System;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using System.Collections.Generic;
using Microsoft.AspNetCore.Components.Web;
using SvgBlazor.Interfaces;

namespace SvgBlazor
{
    public abstract class SvgElement: ISvgElement
    {
        public SvgValue Id { get; set; }

        public string Class { get; set; }

        public string Style { get; set; }

        public EventCallback<MouseEventArgs> OnClick { get; set; }

        public abstract string Tag();

        public virtual void BuildElement(RenderTreeBuilder builder)
        {
            builder.OpenElement(0, Tag());
            AddAttributes(builder);
            AddElements(builder);
            builder.CloseElement();
        }

        public virtual void AddElements(RenderTreeBuilder builder)
        {
        }

        public virtual void AddAttributes(RenderTreeBuilder builder)
        {
            builder.AddAttribute(1, "id", Id);
            builder.AddAttribute(2, "class", Class);
            builder.AddAttribute(3, "style", Style);
            var onClickHandler = EventCallback.Factory.Create<MouseEventArgs>(this, OnClickHandler);
            builder.AddAttribute(4, "onclick", onClickHandler);
        }

        public void OnClickHandler(MouseEventArgs args)
        {
            OnClick.InvokeAsync(args);
        }
    }
}
