using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClothesLine_FN.Models
{
    public class MasterCategory
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public virtual List<Category> Categories { get; set; }
        public virtual List<Colour> Colours { get; set; }
        public virtual List<Size> Sizes { get; set; }
        public virtual List<Price> Prices { get; set; }
        public virtual List<DestinationPlace> DestinationPlaces { get; set; }
    }
}