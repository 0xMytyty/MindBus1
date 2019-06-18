using WebExplorer.Models;
using System.Net.Mail;
using System.Web.Mvc;
using System.Web.Security;
using Umbraco.Web.Mvc;

namespace WebExplorer.Controllers
{
    public class ForgotPasswordController : SurfaceController
    {
        public ActionResult ForgotPassword(ForgotPasswordModel forgotPasswordModel)
        {
            var member = Services.MemberService.GetByEmail(forgotPasswordModel.Email);

            if (member != null)
            {
                string email = member.Email;
                if (!string.IsNullOrEmpty(email))
                {
                    string passwd = Membership.GeneratePassword(8, 0);
                    Services.MemberService.SavePassword(member, passwd);

                    SmtpClient client = new SmtpClient();
                    var message = new MailMessage("teste1@teste.com", email)
                    {
                        Subject = "New Password",
                        Body = "Your new password is: " + passwd
                    };
                    client.Send(message);
                }
            }

            return PartialView();
        }
    }
}