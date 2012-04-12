using System;
using System.Diagnostics;
using System.IO;

namespace ExternalProcess
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.OpenStandardInput();
            var ms = new MemoryStream();
            var sw = Stopwatch.StartNew();
            input.CopyTo(ms);
            sw.Stop();
            Console.WriteLine("Copied " + ms.Length + " bytes in " + sw.Elapsed.TotalSeconds);
        }
    }
}
