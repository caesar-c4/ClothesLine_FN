using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ClothesLine_FN.Models
{
    public class Account
    {
        public int AccountId { get; set; }

        [Required]
        [Display(Name = "Email Or Phone")]
        public string EmailOrPhone { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string Name { get; set; }
        
        public string Gander { get; set; }
        
        public string Profession { get; set; }

        [Required]
        [Display(Name = "Date Of Birth")]
        public string DateOfBirth { get; set; }
        public byte[] Image { get; set; }
        
    }
}