using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClothesLine_FN.Models
{
    public class DestinationPlace
    {
        public long Id { get; set; }
        public string Name { get; set; }

        public long MasterCategoryId { get; set; }
        public virtual MasterCategory MasterCategory { get; set; }

        public long CategoryId { get; set; }
        public virtual Category Category { get; set; }
        public virtual List<TourPackege> TourPackeges { get; set; }
    }
}