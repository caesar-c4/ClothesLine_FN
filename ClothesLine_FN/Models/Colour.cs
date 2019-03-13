using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClothesLine_FN.Models
{
    public class Colour
    {
        public long Id { get; set; }
        public string ColourName { get; set; }

        public long MasterCategoryId { get; set; }
        public virtual MasterCategory MasterCategory { get; set; }
        public virtual List<MansProduct> MansProducts { get; set; }
        public virtual List<WomansProduct> WomansProducts { get; set; }
    }
}