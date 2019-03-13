using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ClothesLine_FN.Models
{
    public class TourPackege
    {
        public long Id { get; set; }
        [Required]
        public long CategoryId { get; set; }
        public virtual Category Category { get; set; }
        [Required]
        public long DestinationPlaceId { get; set; }
        public virtual DestinationPlace DestinationPlace { get; set; }
        [Required]
        public string Name { get; set; }
        public byte[] Image { get; set; }
        public string HotelName { get; set; }
        [Required]
        public decimal Cost { get; set; }
    }
}