using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASPFinal.Models.ViewModels
{
    public class CreateAnnouncementsVM
    {
        public Announcements announcements { get; set; }
        public IEnumerable<CarDetails> CarDetails { get; set; }
    }
}