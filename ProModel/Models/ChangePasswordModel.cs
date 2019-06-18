
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebExplorer.Models
{
    public class ChangePasswordModel
    {
        [Display(Name = "Password")]
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "NewPassword")]
        [Required]
        [DataType(DataType.Password)]
        public string NewPassword { get; set; }
    }
}