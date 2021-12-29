using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using Microsoft.AspNetCore.Components.Web;
using SvgBlazor.Interfaces;

namespace SvgBlazor
{
    public abstract class SvgElement : SvgEventHandler, ISvgElement
    {
        private ISvgElement _parent;

        public SvgElement()
        {
        }

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

        public SvgValue X { get; set; } = 0;

        public SvgValue Y { get; set; } = 0;

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

        public abstract string Tag();

        public virtual void BuildElement(RenderTreeBuilder builder)
        {
            builder.OpenElement(0, Tag());
            AddAttributes(builder);
            BuildElementAdditionalSteps(builder);
            builder.AddElementReferenceCapture(1, er => ElementReference = er);
            builder.CloseElement();
        }

        public virtual void BuildElementAdditionalSteps(RenderTreeBuilder builder)
        {
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
    }
}
