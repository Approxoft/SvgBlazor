using System;
using System.Drawing;
using System.Threading.Tasks;
using Microsoft.JSInterop;

namespace SvgBlazor.Interfaces
{
    public interface ISvgComponent
    {
        IJSObjectReference Module { get; }

        void Refresh();
    }
}
