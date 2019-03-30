using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ASPFinal.Models;

namespace ASPFinal.ViewModels
{
    public class HomeIndexVM
    {
        public IEnumerable<News> news { get; set; }
        public IEnumerable<Announcements> announcements { get; set; }
        public Announcements announcement { get; set; }
        public IEnumerable<CarDetails> carDetails { get; set; }
        public CarDetails carDetail { get; set; }
        public IEnumerable<FuelType> fuelTypes { get; set; }
        public IEnumerable<Gearbox> gearboxes { get; set; }
        public IEnumerable<Marka> markas { get; set; }
        public IEnumerable<Model> models { get; set; }
    }
}