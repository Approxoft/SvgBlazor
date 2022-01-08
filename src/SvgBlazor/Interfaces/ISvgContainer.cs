using System;
using Microsoft.AspNetCore.Components.Rendering;
using Microsoft.AspNetCore.Components.Web;

namespace SvgBlazor.Interfaces
{
    /// <summary>
    /// Provides methods to manage container elements.
    /// </summary>
    public interface ISvgContainer : ISvgElement
    {
        /// <summary>
        /// Adds the given element to the container.
        /// </summary>
        /// <param name="element">Element to be added.</param>
        /// <returns>The container to which the element was added.</returns>
        ISvgContainer Add(ISvgElement element);

        /// <summary>
        /// Removes the given element from the container.
        /// </summary>
        /// <param name="element">Element to be removed.</param>
        /// <returns>The container from which the element was removed.</returns>
        ISvgContainer Remove(ISvgElement element);
    }
}
