using System.ComponentModel.DataAnnotations;
using System.Web;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Web.Models;


namespace WebExplorer.Models
{
    public class PersonModel
    {

        [Display(Name = "Primeiro e último Nome")]

        public string Nome { get; set; }

        [Display(Name = "Data de Nascimento")]

        [DataType(DataType.DateTime)]
        public string DatadeNascimento { get; set; }

        [Display(Name = "Peso")]

        public int? Peso { get; set; }

        [Display(Name = "Altura")]

        public int? Altura { get; set; }

        [Display(Name = "Cor do Cabelo")]

        public string CordoCabelo { get; set; }

        [Display(Name = "Cor dos Olhos")]

        public string CordeOlhos { get; set; }

        [Display(Name = "Sexo")]

        public string SexoPessoa { get; set; }

        [Display(Name = "ImagemParaCarregar")]

        public HttpPostedFileBase ImagemParaCarregar { get; set; }

        [Display(Name = "ImagemUrl")]
        public string ImagemUrl { get; set; }

    }
}