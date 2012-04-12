using System.IO;
using System.Web;
using Kudu.Core.Infrastructure;
using System.Diagnostics;

namespace TestUploadApplication
{
    /// <summary>
    /// Summary description for Process
    /// </summary>
    public class Process : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            string path = Path.Combine(HttpRuntime.AppDomainAppPath, "External", "ExternalProcess.exe");
            var exe = new Executable(path, HttpRuntime.AppDomainAppPath);

            var sw = Stopwatch.StartNew();
            exe.Execute(context.Request.InputStream, context.Response.OutputStream, "");
            sw.Stop();

            context.Response.Write("Overall time " + sw.Elapsed.TotalSeconds + "s");
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