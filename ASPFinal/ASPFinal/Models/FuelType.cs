using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASPFinal.Models
{
    public class FuelType
    {
        public FuelType()
        {
            CarDetails = new HashSet<CarDetails>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        public virtual ICollection<CarDetails> CarDetails { get; set; }
    }
}