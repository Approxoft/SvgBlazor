using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.Web;

namespace SvgBlazor.Interop
{
    public class SvgElementConnector : Svg
    {
        private readonly SvgComponent _svgComponent;

        public SvgElementConnector(SvgComponent component)
        {
            _svgComponent = component;
        }

        public override void Refresh() => _svgComponent.Refresh();

        public override async Task OnClickHandler(MouseEventArgs args)
        {
            await base.OnClickHandler(args);
            await _svgComponent.OnClick.InvokeAsync();
        }

        public override async Task OnMouseDownHandler(MouseEventArgs args)
        {
            await base.OnMouseDownHandler(args);
            await _svgComponent.OnMouseDown.InvokeAsync();
        }

        public override async Task OnMouseMoveHandler(MouseEventArgs args)
        {
            await base.OnMouseMoveHandler(args);
            await _svgComponent.OnMouseMove.InvokeAsync();
        }

        public override async Task OnMouseUpHandler(MouseEventArgs args)
        {
            await base.OnMouseUpHandler(args);
            await _svgComponent.OnMouseUp.InvokeAsync();
        }
    }
}
