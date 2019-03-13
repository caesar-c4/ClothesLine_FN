using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClothesLine_FN.Models
{
    public class Category
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public long MasterCategoryId { get; set; }
        public virtual MasterCategory MasterCategory { get; set; }
        public long? ParentId { get; set; }
        public virtual Category Parent { get; set; }
        public virtual List<Category> Categories { get; set; }
        public virtual List<Brand> Brands { get; set; }
        public virtual List<Type> Types { get; set; }
        public virtual List<DestinationPlace> DestinationPlaces { get; set; }
        public virtual List<TourPackege> TourPackeges { get; set; }
    }
}