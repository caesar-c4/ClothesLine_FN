using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClothesLine_FN.Models
{
    public class CartProduct
    {
        public long Id { get; set; }

        public string Name { get; set; }
        public decimal Price { get; set; }
        public double Qty { get; set; }
        public byte[] Image { get; set; }

        public long UserInfoId { get; set; }
        public virtual UserInfo UserInfo { get; set; }
    }
}