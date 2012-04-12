using System.IO;
using System.Web;
using Kudu.Core.Infrastructure;

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

            exe.Execute(context.Request.InputStream, context.Response.OutputStream, "");
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