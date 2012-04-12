using System.Diagnostics;
using System.IO;
using System.Web;

namespace TestUploadApplication
{
    /// <summary>
    /// Summary description for Raw
    /// </summary>
    public class Raw : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            var sw = Stopwatch.StartNew();
            new StreamReader(context.Request.InputStream).ReadToEnd();
            sw.Stop();
            context.Response.Write("Copied in " + sw.Elapsed.TotalSeconds + "s");
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