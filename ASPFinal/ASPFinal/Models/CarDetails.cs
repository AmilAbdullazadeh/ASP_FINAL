using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASPFinal.Models
{
    public class CarDetails
    {

        public CarDetails()
        {
            Announcements = new HashSet<Announcements>();
        }

        public int Id { get; set; }

        [StringLength(255)]
        public string Image { get; set; }

        [Required]
        public int Price { get; set; }

        public int ModelId { get; set; }

        [Display(Name = "Product Year")]
        public DateTime ProductionYear { get; set; }

        [Required]
        [DataType("decimal(18,2)")]
        [Display(Name = "Engine Capacity")]
        public double EngineCapacity { get; set; }

        [Required]
        [Display(Name = "March")]
        public int CarMarch { get; set; }

        [Required]
        [StringLength(100)]
        public string Color { get; set; }

        [Required]
        [StringLength(255)]
        [Display(Name = "Content")]
        public string ShortContent { get; set; }

        public int FuelTypeId { get; set; }
        public int GearboxId { get; set; }

        public virtual Gearbox Gearbox { get; set; }
        public virtual FuelType FuelType { get; set; }
        public virtual Model Model { get; set; }
        public virtual ICollection<Announcements> Announcements { get; set; }
    }
}