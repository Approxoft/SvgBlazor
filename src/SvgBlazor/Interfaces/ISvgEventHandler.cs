using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace SvgBlazor.Interfaces
{
    /// <summary>
    /// Adds event handling.
    /// </summary>
    public interface ISvgEventHandler
    {
        /// <summary>
        /// Gets or sets the OnClick event callback.
        /// </summary>
        EventCallback<MouseEventArgs> OnClick { get; set; }

        /// <summary>
        /// Gets or sets the OnMouseDown event callback.
        /// </summary>
        EventCallback<MouseEventArgs> OnMouseDown { get; set; }

        /// <summary>
        /// Gets or sets the OnMouseMove event callback.
        /// </summary>
        EventCallback<MouseEventArgs> OnMouseMove { get; set; }

        /// <summary>
        /// Gets or sets the OnMouseUp event callback.
        /// </summary>
        EventCallback<MouseEventArgs> OnMouseUp { get; set; }

        /// <summary>
        /// Gets or sets the OnMouseOver event callback.
        /// </summary>
        EventCallback<MouseEventArgs> OnMouseOver { get; set; }

        /// <summary>
        /// Gets or sets the OnMouseOut event callback.
        /// </summary>
        EventCallback<MouseEventArgs> OnMouseOut { get; set; }

        /// <summary>
        /// Handles the OnClick event.
        /// </summary>
        /// <param name="args">The MouseEventArgs.</param>
        /// <returns>Result of the asynchronous operation.</returns>
        Task OnClickHandler(MouseEventArgs args);

        /// <summary>
        /// Handles the OnMouseDown event.
        /// </summary>
        /// <param name="args">The MouseEventArgs.</param>
        /// <returns>Result of the asynchronous operation.</returns>
        Task OnMouseDownHandler(MouseEventArgs args);

        /// <summary>
        /// Handles the OnMouseMove event.
        /// </summary>
        /// <param name="args">The MouseEventArgs.</param>
        /// <returns>Result of the asynchronous operation.</returns>
        Task OnMouseMoveHandler(MouseEventArgs args);

        /// <summary>
        /// Handles the OnMouseUp event.
        /// </summary>
        /// <param name="args">The MouseEventArgs.</param>
        /// <returns>Result of the asynchronous operation.</returns>
        Task OnMouseUpHandler(MouseEventArgs args);

        /// <summary>
        /// Handles the OnMouseOver event.
        /// </summary>
        /// <param name="args">The MouseEventArgs.</param>
        /// <returns>Result of the asynchronous operation.</returns>
        Task OnMouseOverHandler(MouseEventArgs args);

        /// <summary>
        /// Handles the OnMouseOut event.
        /// </summary>
        /// <param name="args">The MouseEventArgs.</param>
        /// <returns>Result of the asynchronous operation.</returns>
        Task OnMouseOutHandler(MouseEventArgs args);
    }
}
