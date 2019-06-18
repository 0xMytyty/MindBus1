using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebExplorer.Models;
using Umbraco.Core.Composing.CompositionExtensions;
using Umbraco.Web.Mvc;

namespace WebExplorer.Controllers
{
    public class ContactEntrySurfaceController : SurfaceController
    {
        [HttpPost]
        public ActionResult ContactEntry(ContactEntryModel contactEntryModel)
        {
            ViewBag.contactEntryModel = contactEntryModel;
            var contactentries = Services.ContentService.GetById(1252);
            var contactChild = Services.ContentService.Create("contacto", 1252, "contactEntry");
            contactChild.SetValue("nomeCompleto", contactEntryModel.NomeCompleto);
            contactChild.SetValue("email", contactEntryModel.Email);
            contactChild.SetValue("numerodeTelefone", contactEntryModel.NumerodeTelefone);
            contactChild.SetValue("orcamento", contactEntryModel.Orcamento);
            contactChild.SetValue("requisitos", contactEntryModel.Requisitos);

            Services.ContentService.Save(contactChild);

            return RedirectToCurrentUmbracoPage();
        }
    }
}