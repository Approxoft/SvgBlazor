using System;
namespace SvgBlazor.Interfaces
{
    public interface ISvgContainer
    {
        ISvgContainer Add(SvgElement element);
        ISvgContainer Remove(SvgElement element);
    }
}
