using System;
using System.IO;
using System.Web.Profile;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Umbraco.Core;
using Umbraco.Web.Mvc;
using WebExplorer.Models;


namespace WebExplorer.Controllers
{
    public class ProfileSurfaceController : SurfaceController
    {

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ChangeUsername(ChangeUsernameModel changeUsernameModel)
        {
            ViewBag.changeUsernameModel = changeUsernameModel;
            if (User.Identity.IsAuthenticated && ModelState.IsValid)
            {
                var membershipUser = Membership.GetUser();
                var user = Services.MemberService.GetById((int)membershipUser.ProviderUserKey);
                if (changeUsernameModel.NewUsername == changeUsernameModel.ConfirmNewUsername)
                {
                    user.Username = changeUsernameModel.NewUsername;
                    Services.MemberService.Save(user);
                    FormsAuthentication.SetAuthCookie(changeUsernameModel.ConfirmNewUsername, false);


                    return CurrentUmbracoPage();
                }
                else
                {
                    ModelState.AddModelError("changeusernameInvalid", "Os dois campos são diferentes.");
                }
            }

            return CurrentUmbracoPage();
        }

        // Change Password //

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ChangePassword(ChangePasswordModel changePasswordModel)
        {
            if (User.Identity.IsAuthenticated && ModelState.IsValid)
            {
                var user = Membership.GetUser();
                user.ChangePassword(changePasswordModel.Password, changePasswordModel.NewPassword);
                if (changePasswordModel.Password != changePasswordModel.NewPassword)
                {
                    Membership.UpdateUser(user);
                    return CurrentUmbracoPage();
                }
                else
                {
                    ModelState.AddModelError("changepasswordInvalid", "Os dois campos são iguais ou a password antiga está errada.");
                }
            }
            return CurrentUmbracoPage();
        }

        public ActionResult PersonData(PersonModel personModel)
        {
            if (User.Identity.IsAuthenticated && ModelState.IsValid)
            {
                var membershipUser = Membership.GetUser();
                var user = Services.MemberService.GetById((int)membershipUser.ProviderUserKey);
                user.SetValue("nome", personModel.Nome);
                user.SetValue("datadenascimento", personModel.DatadeNascimento);
                user.SetValue("peso", personModel.Peso);
                user.SetValue("altura", personModel.Altura);
                user.SetValue("cordeCabelo", personModel.CordoCabelo);
                user.SetValue("cordeOlhos", personModel.CordeOlhos);
                user.SetValue("sexo", personModel.SexoPessoa);
                if (personModel.ImagemParaCarregar != null)
                {
                    var newFileReference = Services.MediaService.CreateMediaWithIdentity(personModel.Nome, -1, "Image");
                    if (!Valid(personModel.ImagemParaCarregar))
                    {

                        newFileReference.SetValue(Services.ContentTypeBaseServices, "umbracoFile", personModel.ImagemParaCarregar.FileName, personModel.ImagemParaCarregar.InputStream);
                        Services.MediaService.Save(newFileReference);

                        user.SetValue("avatar", newFileReference.Id);
                    }
                }

                Services.MemberService.Save(user);
                
            }

            return RedirectToCurrentUmbracoPage();
        }
       
        private bool Valid(HttpPostedFileBase imagem)
        {
            var fileInfo = new FileInfo(imagem.FileName);
            if ((new string[] { "png", "jpg", "jpeg" }).Contains(fileInfo.Extension)
                && imagem.ContentLength < 15000)
            {
                return true;
            }

            return false;
        }
       

    }

    

}