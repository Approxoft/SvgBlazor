namespace SvgBlazor.Interfaces
{
    public interface ISvgLayout
    {
        float? FixedWidth { get; set; }
        void Update();
        void AddElement(ISvgElement element);
    }
}