using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using Microsoft.AspNetCore.Components.Web;

namespace SvgBlazor.Interfaces
{
    public interface ISvgElement : ISvgEventHandler
    {
        /// <summary>
        /// Gets or sets the x position of the element.
        /// </summary>
        SvgValue X { get; set; }

        /// <summary>
        /// Gets or sets the y position of the element.
        /// </summary>
        SvgValue Y { get; set; }

        /// <summary>
        /// Gets or sets the reference to a rendered element.
        /// </summary>
        ElementReference ElementReference { get; set; }

        /// <summary>
        /// Provides the tag to be used when rendering this element.
        /// </summary>
        /// <returns>The tag of the element.</returns>
        string Tag();

        /// <summary>
        /// Builds the element based on the given RenderTreeBuilder object.
        /// </summary>
        /// <param name="builder">RenderTreeBuilder object to be used during the build process.</param>
        void BuildElement(RenderTreeBuilder builder);

        /// <summary>
        /// Allows to perform additional steps when building this element. The method is called just after adding attributes and before reference capture.
        /// </summary>
        /// <param name="builder">RenderTreeBuilder object to be used during the build process.</param>
        void BuildElementAdditionalSteps(RenderTreeBuilder builder);

        /// <summary>
        /// Sets the given element as the parent of this element.
        /// </summary>
        /// <param name="parent">The element that will become the parent of this element.</param>
        void SetParent(ISvgElement parent);

        /// <summary>
        /// Returns the parent element of this element.
        /// </summary>
        /// <returns>The parent element.</returns>
        ISvgElement Parent();

        /// <summary>
        /// Refreshes the element.
        /// </summary>
        void Refresh();

        /// <summary>
        /// Called when the mouse cursor moves over the element.
        /// </summary>
        /// <param name="element">Element sending the event.</param>
        /// <param name="args">MouseEventArgs associated with the event.</param>
        void ElementMouseOver(ISvgElement element, MouseEventArgs args);

        /// <summary>
        /// Called when the mouse cursor moves outside the element.
        /// </summary>
        /// <param name="element">Element sending the event.</param>
        /// <param name="args">MouseEventArgs associated with the event.</param>
        void ElementMouseOut(ISvgElement element, MouseEventArgs args);
    }
}
