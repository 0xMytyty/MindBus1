using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Web.Models;
using WebExplorer.Models;

namespace Umbraco.Web.PublishedModels
{
    public partial class PersonGalleryModel : ContentModel
    {
        public PersonGalleryModel(IPublishedContent content) : base(content)
        {
        }

        public List<UserModel> UmbUsers { get; set; }

        public PersonModel Person { get; set; }



    }
}