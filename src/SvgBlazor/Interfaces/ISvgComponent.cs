using System;
using System.Drawing;
using System.Threading.Tasks;
using Microsoft.JSInterop;

namespace SvgBlazor.Interfaces
{
    public interface ISvgComponent
    {
        void Refresh();

        Task<IJSObjectReference> GetModule();
    }
}
