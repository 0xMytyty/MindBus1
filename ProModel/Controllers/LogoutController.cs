using System.Web.Mvc;
using System.Web.Security;
using Umbraco.Web.Mvc;
using WebExplorer.Models;

namespace WebExplorer.Controllers
{
    public class LogoutController : SurfaceController
    {


        public ActionResult RenderLogout()
        {
            return PartialView("_Logout", null);
        }

        public ActionResult SubmitLogout()
        {
            TempData.Clear();
            Session.Clear();
            FormsAuthentication.SignOut();
            return RedirectToCurrentUmbracoPage();
        }
    }
}