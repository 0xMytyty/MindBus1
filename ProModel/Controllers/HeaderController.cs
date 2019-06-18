using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Umbraco.Web.Mvc;
using System.Web.Mvc;

namespace WebExplorer.Controllers
{
    public class HeaderController : SurfaceController
    {
        public ActionResult RenderHeader()
        {

            return PartialView("~/Views/Partials/WebBase/Header.cshtml");
        }
    }
}