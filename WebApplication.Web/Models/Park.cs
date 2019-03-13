using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Web.Models
{
    public class Park
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string State { get; set; }
        public int Acerage { get; set; }
        public int Elevation { get; set; }
        public int Miles { get; set; }
        public int Campsites { get; set; }
        public string Climate { get; set; }
        public int YearFounded { get; set; }
        public int AnnualVisitorCount { get; set; }
        public string Quote { get; set; }
        public string QuoteSource { get; set; }
        public string Description { get; set; }
        public int EntryFee { get; set; }
        public int NumberAnimalSpecies { get; set; }

        public IList<Weather> weathers = new List<Weather>();
    }
}
