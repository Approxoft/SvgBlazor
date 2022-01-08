using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.Web;

namespace SvgBlazor.Interop
{
    /// <summary>
    /// The class that represents the connection between SvgComponent and SvgElement.
    /// </summary>
    public class SvgElementConnector : Svg
    {
        private readonly SvgComponent _svgComponent;

        /// <summary>
        /// Initializes a new instance of the <see cref="SvgElementConnector"/> class with provided SvgComponent.
        /// </summary>
        /// <param name="component">Initial SvgComponent.</param>
        public SvgElementConnector(SvgComponent component)
        {
            _svgComponent = component;
        }

        /// <inheritdoc/>
        public override void Refresh() => _svgComponent.Refresh();

        /// <inheritdoc/>
        public override async Task OnClickHandler(MouseEventArgs args)
        {
            await base.OnClickHandler(args);
            await _svgComponent.OnClick.InvokeAsync();
        }

        /// <inheritdoc/>
        public override async Task OnMouseDownHandler(MouseEventArgs args)
        {
            await base.OnMouseDownHandler(args);
            await _svgComponent.OnMouseDown.InvokeAsync();
        }

        /// <inheritdoc/>
        public override async Task OnMouseMoveHandler(MouseEventArgs args)
        {
            await base.OnMouseMoveHandler(args);
            await _svgComponent.OnMouseMove.InvokeAsync();
        }

        /// <inheritdoc/>
        public override async Task OnMouseUpHandler(MouseEventArgs args)
        {
            await base.OnMouseUpHandler(args);
            await _svgComponent.OnMouseUp.InvokeAsync();
        }
    }
}
