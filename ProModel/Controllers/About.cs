using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Umbraco.Web.Mvc;
using System.Web.Mvc;

namespace WebExplorer.Controllers
{
    public class AboutController : SurfaceController
    {
        public ActionResult RenderAbout()
        {

            return PartialView();
        }
    }
}