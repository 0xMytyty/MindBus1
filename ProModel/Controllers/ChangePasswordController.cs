using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebExplorer.Controllers
{
    public class ChangePasswordController
    {
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
                user.SetValue("datadeNascimento", personModel.DatadeNascimento);
                user.SetValue("peso", personModel.Peso);
                user.SetValue("altura", personModel.Altura);
                user.SetValue("cordeCabelo", personModel.CordoCabelo);
                user.SetValue("cordeOlhos", personModel.CordeOlhos);
                user.SetValue("sexo", personModel.SexoPessoa);
                if (personModel.ImagemParaCarregar != null)
                {
                    var newFileReference = Services.MediaService.CreateMedia("avatar", -1, "Image");
                    if (!Valid(personModel.ImagemParaCarregar))
                    {
                        newFileReference.SetValue("umbracoFile", personModel.ImagemParaCarregar.InputStream);
                        Services.MediaService.Save(newFileReference);

                        user.SetValue("avatar", newFileReference.Id);
                    }
                }

                Services.MemberService.Save(user);
            }

            return CurrentUmbracoPage();
        }
    }
}