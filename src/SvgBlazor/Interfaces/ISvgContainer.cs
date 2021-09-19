using System;
namespace SvgBlazor.Interfaces
{
    public interface ISvgContainer
    {
        void Add(SvgElement element);
        void Remove(SvgElement element);
    }
}
