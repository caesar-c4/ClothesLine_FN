using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ClothesLine_FN.Models.ViewModel
{
    public class LoginVm
    {
        [Required(ErrorMessage = "Please give your email or phone number")]
        public string EmailOrPhone { get; set; }

        [Required(ErrorMessage = "Please give your password")]
        public string Pass { get; set; }
    }
}