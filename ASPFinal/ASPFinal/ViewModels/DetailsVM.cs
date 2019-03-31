using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ASPFinal.Models;
using ASPFinal.DAL;

namespace ASPFinal.ViewModels
{
    public class DetailsVM
    {
        public Announcements Announcements { get; set; }

        public IEnumerable<News> News { get; set; }

        public List<Announcements> RelatedADS { get; set; }

        public ResentNewsVM ResVM { get; set; }
    }
}