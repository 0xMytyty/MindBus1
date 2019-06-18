using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Umbraco.Core.Models.PublishedContent;

namespace WebExplorer.Models
{
    public class UserModel
    {
        public string Nome { get; set; }

        public IPublishedContent Avatar { get; set; }

        public string ImagemUrl { get; set; }


    }
}