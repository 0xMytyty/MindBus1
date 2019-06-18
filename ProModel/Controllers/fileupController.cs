using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using Umbraco.Core;
using Umbraco.Core.Models;
using Umbraco.Core.Services;
using Umbraco.Web.WebApi;

namespace WebExplorer.Controllers
{
    public class fileupController : UmbracoApiController
    {
        private IMedia CreateMediaItem(int parentId, string fileName, IContentTypeBaseServiceProvider contentTypeBaseServiceProvider)
        {
            IMedia newFile = IMediaService.CreateMedia(fileName, parentId, "Image");
            string filePath = HttpContext.Current.Server.MapPath("~/img/" + fileName);
            using (FileStream stream = System.IO.File.Open(filePath, FileMode.Open))
            {
                newFile.SetValue(contentTypeBaseServiceProvider, "umbracoFile", fileName, stream);
            }
            IMediaService.Save(newFile);
            return newFile;
        }
    }
}