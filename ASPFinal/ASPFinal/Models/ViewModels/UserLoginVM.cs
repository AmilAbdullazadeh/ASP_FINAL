using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ASPFinal.Models.ViewModels
{
    public class UserLoginVM
    {
        [Required]
        [EmailAddress]
        [MinLength(1)]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [MinLength(1)]
        public string Password { get; set; }
    }
}