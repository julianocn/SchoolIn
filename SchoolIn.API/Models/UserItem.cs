using System;
using System.ComponentModel.DataAnnotations;

namespace SchoolIn.API.Models
{
    public class UserItem
    {
        [Display(Name = "ID")]
        public int ID { get; set; }

        [Display(Name = "Usuário")]
        public string Username { get; set; }

        [Display(Name = "E-mail")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Display(Name = "Senha")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
