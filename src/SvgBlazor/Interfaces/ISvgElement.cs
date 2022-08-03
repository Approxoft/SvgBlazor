// Copyright (c) Approxoft. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using Microsoft.AspNetCore.Components.Web;

namespace SvgBlazor.Interfaces
{
    /// <summary>
    /// The interface that represents the SvgElement.
    /// </summary>
    public interface ISvgElement
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
        /// Gets or sets the OnClick event callback.
        /// </summary>
        public EventCallback<MouseEventArgs> OnClick { get; set; }

        /// <summary>
        /// Gets or sets the OnMouseDown event callback.
        /// </summary>
        public EventCallback<MouseEventArgs> OnMouseDown { get; set; }

        /// <summary>
        /// Gets or sets the OnMouseMove event callback.
        /// </summary>
        public EventCallback<MouseEventArgs> OnMouseMove { get; set; }

        /// <summary>
        /// Gets or sets the OnMouseUp event callback.
        /// </summary>
        public EventCallback<MouseEventArgs> OnMouseUp { get; set; }

        /// <summary>
        /// Gets or sets the OnMouseOver event callback.
        /// </summary>
        public EventCallback<MouseEventArgs> OnMouseOver { get; set; }

        /// <summary>
        /// Gets or sets the OnMouseOut event callback.
        /// </summary>
        public EventCallback<MouseEventArgs> OnMouseOut { get; set; }

        /// <summary>
        /// Gets or sets the OnMouseEnter event callback.
        /// </summary>
        public EventCallback<MouseEventArgs> OnMouseEnter { get; set; }
    }
}
