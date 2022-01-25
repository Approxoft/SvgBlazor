// Copyright (c) Approxoft. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace SvgBlazor.Docs.Models
{
    public class ElementApiProperty : IElementApiElement
    {
        public string Name { get; set; }

        public string Type { get; set; }

        public string DeclaringType { get; set; }

        public string Description { get; set; }
    }
}
