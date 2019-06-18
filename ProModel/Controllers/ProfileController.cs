using System.Web.Mvc;
using System.Web.Security;
using Umbraco.Web.Models;
using Umbraco.Web.Mvc;
using WebExplorer.Models;

namespace WebExplorer.Controllers
{
    [Authorize]
    public class ProfileController : RenderMvcController
    {
        [HttpGet]
        public  ActionResult ProfilePage(ContentModel model)
        {

            var membershipUser = Membership.GetUser();
            var user = Services.MemberService.GetById((int)membershipUser.ProviderUserKey);
            var returnModel = new ProfilePageModel(model.Content)
            {
                Person = new PersonModel()
                {
                    Nome = user.GetValue<string>("nome"),
                    DatadeNascimento = user.GetValue<string>("datadeNascimento"),
                    Peso = user.GetValue<int>("peso"),
                    Altura = user.GetValue<int>("altura"),
                    CordoCabelo = user.GetValue<string>("cordoCabelo"),
                    CordeOlhos = user.GetValue<string>("cordeolhos"),

                }
            };

            var avatarId = user.GetValue<int>("avatar");

            var avatar = UmbracoContext.MediaCache.GetById(avatarId);
            if (avatar != null)
            {
                returnModel.Person.ImagemUrl = avatar.Url;
            }
            else
            {
                return CurrentTemplate(returnModel);
            }

            return CurrentTemplate(returnModel);

        }
    }
}