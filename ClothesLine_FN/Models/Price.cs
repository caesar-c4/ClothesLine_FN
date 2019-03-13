using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClothesLine_FN.Models
{
    public class Price
    {
        public long Id { get; set; }
        public string PriceRangeName { get; set; }
        public decimal PriceAmount { get; set; }
        
        public long MasterCategoryId { get; set; }
        public virtual MasterCategory MasterCategory { get; set; }
    }
}