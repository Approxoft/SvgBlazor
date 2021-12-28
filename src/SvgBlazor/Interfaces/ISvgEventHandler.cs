using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace SvgBlazor.Interfaces
{
    public interface ISvgEventHandler
    {
        /// <summary>
        /// Gets or sets OnClick event callback.
        /// </summary>
        EventCallback<MouseEventArgs> OnClick { get; set; }

        /// <summary>
        /// Gets or sets OnMouseDown event callback.
        /// </summary>
        EventCallback<MouseEventArgs> OnMouseDown { get; set; }

        /// <summary>
        /// Gets or sets OnMouseMove event callback.
        /// </summary>
        EventCallback<MouseEventArgs> OnMouseMove { get; set; }

        /// <summary>
        /// Gets or sets OnMouseUp event callback.
        /// </summary>
        EventCallback<MouseEventArgs> OnMouseUp { get; set; }

        /// <summary>
        /// Gets or sets OnMouseOver event callback.
        /// </summary>
        EventCallback<MouseEventArgs> OnMouseOver { get; set; }

        /// <summary>
        /// Gets or sets OnMouseOut event callback.
        /// </summary>
        EventCallback<MouseEventArgs> OnMouseOut { get; set; }

        /// <summary>
        /// Handles the click event.
        /// </summary>
        /// <param name="args">The MouseEventArgs.</param>
        /// <returns>Result of the asynchronous operation.</returns>
        Task OnClickHandler(MouseEventArgs args);

        /// <summary>
        /// Handles the mouse down event.
        /// </summary>
        /// <param name="args">The MouseEventArgs.</param>
        /// <returns>Result of the asynchronous operation.</returns>
        Task OnMouseDownHandler(MouseEventArgs args);

        /// <summary>
        /// Handles the mouse move event.
        /// </summary>
        /// <param name="args">The MouseEventArgs.</param>
        /// <returns>Result of the asynchronous operation.</returns>
        Task OnMouseMoveHandler(MouseEventArgs args);

        /// <summary>
        /// Handles the mouse up event.
        /// </summary>
        /// <param name="args">The MouseEventArgs.</param>
        /// <returns>Result of the asynchronous operation.</returns>
        Task OnMouseUpHandler(MouseEventArgs args);

        /// <summary>
        /// Handles the mouse over event.
        /// </summary>
        /// <param name="args">The MouseEventArgs.</param>
        /// <returns>Result of the asynchronous operation.</returns>
        Task OnMouseOverHandler(MouseEventArgs args);

        /// <summary>
        /// Handles the mouse out event.
        /// </summary>
        /// <param name="args">The MouseEventArgs.</param>
        /// <returns>Result of the asynchronous operation.</returns>
        Task OnMouseOutHandler(MouseEventArgs args);
    }
}
