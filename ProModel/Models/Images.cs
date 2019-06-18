using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Web;
using Umbraco.Web.Models;

namespace WebsiteProject.Models
{
    public class Images : ContentModel
    {
        public MvcHtmlString Image1
        {
            get { return Content.Value<MvcHtmlString>("image1"); }
        }

        public Images(IPublishedContent content) : base(content)
        {

        }
    }
}