using System;
using System.Diagnostics;
using System.IO;
using System.Web;

namespace TestUploadApplication
{
    /// <summary>
    /// Summary description for Chunked
    /// </summary>
    public class Chunked : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            string rawChunkSize = context.Request.QueryString["size"];
            int chunkSize = rawChunkSize != null ? Int32.Parse(rawChunkSize) : 4096;
            var sw = Stopwatch.StartNew();
            var ms = new MemoryStream();
            context.Request.InputStream.CopyTo(ms, chunkSize);
            sw.Stop();
            context.Response.Write("Copied " + ms.Length + " bytes in " + sw.Elapsed.TotalSeconds + "s using chunk size " + chunkSize);
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