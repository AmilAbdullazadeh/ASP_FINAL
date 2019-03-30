using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASPFinal.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        [StringLength(70)]
        public string Name { get; set; }

        [Required]
        [StringLength(100)]
        public string Lastname { get; set; }

        [Required]
        [EmailAddress]
        [StringLength(100)]
        [Index("UN_Email", IsUnique = true)]
        public string Email { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [MinLength(3)]
        public string Password { get; set; }
    }
}