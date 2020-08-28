using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BlackEyesMvc.Models
{
    public class Login
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please Input User_Name")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Please Input Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}