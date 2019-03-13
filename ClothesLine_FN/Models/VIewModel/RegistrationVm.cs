using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ClothesLine_FN.Models.ViewModel
{
    public class RegistrationVm
    {
        [Required(ErrorMessage = "Pleasse give your name")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Please give your phone or email")]
        public string EmailOrPhone { get; set; }

        [Required(ErrorMessage = "Please give a passwored")]
        public string Pass { get; set; }

        [Required(ErrorMessage = "Rewrite your passwored")]
        public string RePass { get; set; }

        [Required]
        public string Gender { get; set; }

        [Required]
        public string Occupation { get; set; }

        public string BirthDay { get; set; }
    }
}