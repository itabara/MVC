using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Hosting;
using System.Web.Http;
using WebAPI_BinaryContent.Models;

namespace WebAPI_BinaryContent.Controllers
{
    public class ByteArrayAPIController : ApiController
    {
        private string rootPath;

        public ByteArrayAPIController()
        {
            // the path of the image store on the server side
            rootPath = HostingEnvironment.MapPath("~/images");
        }

        [Route("Files")]
        public List<FilesInfo> GetFiles()
        {
            List<FilesInfo> files = new List<FilesInfo>();
            foreach (var item in Directory.GetFiles(rootPath))
            {
                FileInfo f = new FileInfo(item);
                files.Add(new FilesInfo() { FileName = f.Name });
            }
            return files;
        }

        /// <summary>
        /// Return the image as Byte Array through the HttpResponseMessage object
        /// </summary>
        /// <param name=""fileName"">
        /// <param name=""ext"">
        /// <returns></returns>
        [Route("Bytes/{fileName}/{ext}")]
        public HttpResponseMessage Get(string fileName, string ext)
        {
            // S1: Construct File Path
            var filePath = Path.Combine(rootPath, fileName + "." + ext);
            if (!File.Exists(filePath))
            {
                //Not found then throw Exception
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            HttpResponseMessage Response = new HttpResponseMessage(HttpStatusCode.OK);

            // S2: Read File as Byte Array
            byte[] fileData = File.ReadAllBytes(filePath);
            if (fileData == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            // S3:Set Response contents and MediaTypeHeaderValue
            Response.Content = new ByteArrayContent(fileData);
            Response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
            return Response;
        }
    }
}
