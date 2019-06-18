using Umbraco.Core.Models.PublishedContent;
using Umbraco.Web.Models;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace WebExplorer.Models
{
    public class ProfilePageModel : ContentModel
    {

        public ProfilePageModel(IPublishedContent content) : base(content)
        { }

        public PersonModel Person { get; set; }
    }
}