using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ClothesLine_FN.Models
{
    public class WomansProduct
    {
        public long Id { get; set; }

        [Required]
        public long BrandId { get; set; }
        public virtual Brand Brand { get; set; }

        [Required]
        public long SizeId { get; set; }
        public virtual Size Size { get; set; }

        [Required]
        public long ColourId { get; set; }
        public virtual Colour Colour { get; set; }

        [Required]
        public string Name { get; set; }
        public byte[] Image { get; set; }

        [Required]
        public decimal Price { get; set; }

        [DataType(DataType.MultilineText)]
        [StringLength(maximumLength: 1000, ErrorMessage = "Description can not be more then 1000 characters")]
        public string Description { get; set; }

    }
}