using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ClothesLine_FN.Models
{
    public class Type
    {
        public long Id { get; set; }
        [Required]
        public string Name { get; set; }

        [Required]
        public long CategoryId { get; set; }
        public virtual Category Category { get; set; }
        public virtual List<Product> Products { get; set; }
    }
}