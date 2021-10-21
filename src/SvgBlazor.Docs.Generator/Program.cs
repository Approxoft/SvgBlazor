using System;
using System.Diagnostics;
using System.IO;

namespace SvgBlazor.Docs.Generator
{
    public class Program
    {
        public static int Main(string[] args)
        {
            if (args.Length == 1)
            {
                ProjectPaths.SourcePath = Path.Combine(args[0], "src");
            }
            else
            {
                Console.WriteLine($"SvgBlazor.Docs.Generator failed: no solution path provided!");
                return 1;
            }

            try
            {
                var stopWatch = Stopwatch.StartNew();

                new ExamplesCode().Generate();

                Console.WriteLine($"SvgBlazor.Docs.Generator completed in {stopWatch.ElapsedMilliseconds} msecs");

                return 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"SvgBlazor.Docs.Generator failed: {ex}");
                return 1;
            }
        }
    }
}
