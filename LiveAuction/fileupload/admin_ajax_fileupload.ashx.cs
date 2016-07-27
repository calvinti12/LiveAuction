using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;

namespace LiveAuction.fileupload
{
    /// <summary>
    /// Summary description for ajax_fileupload
    /// </summary>
    public class admin_ajax_fileupload : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";

            string dirFullPath = HttpContext.Current.Server.MapPath("~/fileupload/upload/");
            var command = context.Request.QueryString["cmd"];
            if (!string.IsNullOrEmpty(command) && command == "delete")
            {
                string deletefilename = context.Request.QueryString["file"];
                deletefilename = dirFullPath + deletefilename;

                if (File.Exists(deletefilename))
                {
                    File.Delete(deletefilename);
                }
                context.Response.Write(true);
            }
            else
            {

                string[] files;
                int numFiles;
                files = System.IO.Directory.GetFiles(dirFullPath);
                numFiles = files.Length;
                numFiles = numFiles + 1;

                string str_image = "";

                foreach (string s in context.Request.Files)
                {
                    HttpPostedFile file = context.Request.Files[s];
                    //  int fileSizeInBytes = file.ContentLength;
                    string fileName = file.FileName;
                    string fileExtension = file.ContentType;

                    if (!string.IsNullOrEmpty(fileName))
                    {
                        fileExtension = Path.GetExtension(fileName);
                        str_image = Guid.NewGuid() + numFiles.ToString() + fileExtension;
                        string pathToSave_100 = HttpContext.Current.Server.MapPath("~/fileupload/upload/") + str_image;
                        file.SaveAs(pathToSave_100);
                    }
                }
                context.Response.Write(str_image);
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }


        private byte[] ConvertHexToBytes(string hex)
        {
            byte[] bytes = new byte[hex.Length / 2];
            for (int i = 0; i < hex.Length; i += 2)
            {
                bytes[i / 2] = Convert.ToByte(hex.Substring(i, 2), 16);
            }
            return bytes;
        }
    }
}