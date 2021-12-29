using Microsoft.AspNetCore.Components.Rendering;

namespace SvgBlazor.Interfaces
{
    public interface ISvgAttribute
    {
        /// <summary>
        /// Adds attributes to the RenderTreeBuilder.
        /// </summary>
        /// <param name="builder">The RenderTreeBuilder used to build this attibute.</param>
        public void RenderAttributes(RenderTreeBuilder builder);
    }
}
