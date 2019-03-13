using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ClothesLine_FN.Models
{
    public class UserInfo
    {
        public long Id { get; set; }
        [Required]
        [Display(Name = "Email Or Phone")]
        public string EmailOrPhone { get; set; }

        [Required]
        public string Name { get; set; }

        public string Gander { get; set; }

        public string Profession { get; set; }

        [Required]
        [Display(Name = "Date Of Birth")]
        public string DateOfBirth { get; set; }

        [Required]
        public string Address { get; set; }

        public virtual List<CartProduct> CartProducts { get; set; }
    }
}