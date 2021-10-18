using System;
using System.Diagnostics;

namespace SvgBlazor.Docs.Generator
{
    class Program
    {
        static int Main()
        {
            try
            {
                var stopWatch = Stopwatch.StartNew();
                
                new ExamplesCode().Generate();

                Console.WriteLine($"SvgBlazor.Docs.Generator completed in {stopWatch.ElapsedMilliseconds} msecs");

                return 0;
            } catch (Exception ex)
            {
                Console.WriteLine($"SvgBlazor.Docs.Generator failed: {ex}");
                return 1;
            }
        }
    }
}
