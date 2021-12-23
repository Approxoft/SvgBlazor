using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SvgBlazor.Docs.Models
{
    public class ElementApiMethod : IElementApiElement
    {
        public string Name { get; set; }

        public string ReturnValue { get; set; }

        public IEnumerable<string> Parameters { get; set; }

        public string Description { get; set; }
    }
}
