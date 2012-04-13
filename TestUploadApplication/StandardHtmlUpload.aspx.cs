using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Diagnostics;

namespace TestUploadApplication
{
    public partial class StandardHtmlUpload : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Files.Count > 0)
            {
                var sw = Stopwatch.StartNew();
                Request.Files[0].SaveAs(MapPath("~/testupload.bin"));
                sw.Stop();
                Response.Write("Upload took " + sw.Elapsed.TotalSeconds);
            }
        }
    }
}