using System;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using Microsoft.AspNetCore.Components.Web;
using SvgBlazor.Interfaces;

namespace SvgBlazor
{
    public class SvgComponent: ComponentBase, ISvgContainer
    {
        [Parameter]
        public double Width { get; set; }

        [Parameter]
        public double Height { get; set; }

        /// <summary>
        /// The optional width of the viewbox. If not set, the `Width` value will be used
        /// </summary>
        [Parameter]
        public double? ViewBoxWidth { get; set; }

        /// <summary>
        /// The optional height of the viewbox. If not set, the `Height` value will be used
        /// </summary>
        [Parameter]
        public double? ViewBoxHeight { get; set; }

        [Parameter]
        public EventCallback<MouseEventArgs> OnClick { get; set; }

        [Parameter]
        public RenderFragment ChildContent { get; set; }

        private readonly Svg svg = new();

        protected override void OnParametersSet()
        {
            svg.Width = Width;
            svg.Height = Height;
            svg.ViewBoxHeight = ViewBoxHeight;
            svg.ViewBoxWidth = ViewBoxWidth;
        }

        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            builder.OpenElement(0, "svg");
            svg.AddAttributes(builder);
            svg.AddElements(builder);
            builder.CloseComponent();
        }

        public ISvgContainer Add(SvgElement element)
        {
            svg.Add(element);
            StateHasChanged();
            return this;
        }

        public ISvgContainer Remove(SvgElement element)
        {
            svg.Remove(element);
            StateHasChanged();
            return this;
        }
    }
}
