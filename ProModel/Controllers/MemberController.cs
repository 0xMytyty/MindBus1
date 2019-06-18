using System.Web.Mvc;
using System.Web.Security;
using Umbraco.Web.Mvc;
using WebExplorer.Models;

namespace WebExplorer.Controllers
{
    public class MemberController : SurfaceController
    {
        public ActionResult RenderLogin()
        {
            return PartialView("_Login", new LoginModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SubmitLogin(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                if (Membership.ValidateUser(model.Username, model.Password))
                {
                    FormsAuthentication.SetAuthCookie(model.Username, false);
                    UrlHelper myHelper = new UrlHelper(HttpContext.Request.RequestContext);
                   
                   return Redirect("/home/");
                }
                else
                {
                    ModelState.AddModelError("", "Datos incorretos.");
                    
                }
                
            }
            return CurrentUmbracoPage();
        }
        
    }
}

        