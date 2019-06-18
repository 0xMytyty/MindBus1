using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebExplorer.Models
{
    public class ChangeUsernameModel
    {
        [Display(Name = "NewUsername")]
        [Required]
        public string NewUsername { get; set; }

        [Display(Name = "ConfirmNewUsername")]
        [Required]
        public string ConfirmNewUsername { get; set; }
    }
}