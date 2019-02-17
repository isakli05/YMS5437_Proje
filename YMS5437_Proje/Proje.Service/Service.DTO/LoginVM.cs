using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proje.Service.Service.DTO
{
    public class LoginVM
    {
        [EmailAddress(ErrorMessage = "E-Posta Formatında Giriş Yapınız")]
        [Required(ErrorMessage = "E-Posta Giriniz")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Parola Giriniz")]
        public string Password { get; set; }
        public bool IsPersistent { get; set; }
    }
}