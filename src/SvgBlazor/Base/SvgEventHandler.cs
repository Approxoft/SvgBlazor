using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using SvgBlazor.Interfaces;

namespace SvgBlazor
{
    /// <summary>
    /// The base class for event handling.
    /// </summary>
    public class SvgEventHandler : ISvgEventHandler
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SvgEventHandler"/> class.
        /// </summary>
        public SvgEventHandler()
        {
        }


        /// <summary>
        /// Initializes a new instance of the <see cref="SvgEventHandler"/> class with provided SvgEventHandler.
        /// </summary>
        /// <param name="svgeventhandler">Initial SvgEventHandler.</param>
        public SvgEventHandler(SvgEventHandler svgeventhandler)
        {
            OnClick = svgeventhandler.OnClick;
            OnMouseDown = svgeventhandler.OnMouseDown;
            OnMouseMove = svgeventhandler.OnMouseMove;
            OnMouseUp = svgeventhandler.OnMouseUp;
            OnMouseOver = svgeventhandler.OnMouseOver;
            OnMouseOut = svgeventhandler.OnMouseOut;
        }

        /// <inheritdoc/>
        public EventCallback<MouseEventArgs> OnClick { get; set; }

        /// <inheritdoc/>
        public EventCallback<MouseEventArgs> OnMouseDown { get; set; }

        /// <inheritdoc/>
        public EventCallback<MouseEventArgs> OnMouseMove { get; set; }

        /// <inheritdoc/>
        public EventCallback<MouseEventArgs> OnMouseUp { get; set; }

        /// <inheritdoc/>
        public EventCallback<MouseEventArgs> OnMouseOver { get; set; }

        /// <inheritdoc/>
        public EventCallback<MouseEventArgs> OnMouseOut { get; set; }

        /// <inheritdoc/>
        public virtual async Task OnClickHandler(MouseEventArgs args) => await OnClick.InvokeAsync(args);

        /// <inheritdoc/>
        public virtual async Task OnMouseDownHandler(MouseEventArgs args) => await OnMouseDown.InvokeAsync(args);

        /// <inheritdoc/>
        public virtual async Task OnMouseMoveHandler(MouseEventArgs args) => await OnMouseMove.InvokeAsync(args);

        /// <inheritdoc/>
        public virtual async Task OnMouseUpHandler(MouseEventArgs args) => await OnMouseUp.InvokeAsync(args);

        /// <inheritdoc/>
        public virtual async Task OnMouseOverHandler(MouseEventArgs args) => await OnMouseOver.InvokeAsync(args);

        /// <inheritdoc/>
        public virtual async Task OnMouseOutHandler(MouseEventArgs args) => await OnMouseOut.InvokeAsync(args);
    }
}
