using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using System.Web.Security;
using Umbraco.Web.Mvc;
using WebExplorer.Models;

namespace WebExplorer.Controllers
{
    public class RegisterController : SurfaceController
    {
        [HttpGet]
        public ActionResult RenderRegister(string hello)
        {
            ViewBag.hello = hello;
            return PartialView();
        }

        [HttpPost]

        public ActionResult RenderRegister(RegisterModel model)
        {
            var memberService = Services.MemberService;

            if (ModelState.IsValid)
            {
                var newuser = Membership.CreateUser(model.Username, model.Password, model.Email);
                Services.MemberService.AssignRole(newuser.UserName, "Registrados");
                return PartialView();

            }
            else
            {
                return View("~/home/");
            }

        }
    }
}