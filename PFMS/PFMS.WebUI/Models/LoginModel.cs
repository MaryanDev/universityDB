using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PFMS.WebUI.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Login field cannot be empty")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Password field cannot be empty")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}