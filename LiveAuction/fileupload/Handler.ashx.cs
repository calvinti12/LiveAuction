using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;


namespace LiveAuction.fileupload
{
    /// <summary>
    /// Summary description for Handler
    /// </summary>
    public class Handler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string fileName = context.Request.Form["id"];
            string path = HttpContext.Current.Server.MapPath("~/fileupload/upload/") + fileName;
            FileInfo file = new FileInfo(path);
            if (file.Exists)
                file.Delete();
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