using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASPFinal.Models
{
    public class Announcements
    {

        public int Id { get; set; }

        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }

        [Required]
        [StringLength(150)]
        public string City { get; set; }

        public bool Vip { get; set; }

        public int CardDetailsId { get; set; }
        public virtual CarDetails CarDetails { get; set; }
    }
}