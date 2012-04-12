using System;
using System.Diagnostics;
using System.IO;
using System.Web;

namespace TestUploadApplication
{
    /// <summary>
    /// Summary description for Bufferless
    /// </summary>
    public class Bufferless : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            string rawChunkSize = context.Request["size"];
            int chunkSize = rawChunkSize != null ? Int32.Parse(rawChunkSize) : 4096;
            var sw = Stopwatch.StartNew();
            var ms = new MemoryStream();
            context.Request.GetBufferlessInputStream().CopyTo(ms, chunkSize);
            sw.Stop();
            context.Response.Write("Copied " + ms.Length + " bytes in " + sw.Elapsed.TotalSeconds + "s");
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}