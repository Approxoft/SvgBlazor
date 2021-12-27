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
