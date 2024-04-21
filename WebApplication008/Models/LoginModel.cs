using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication008.Models
{
    public class LoginModel
    {        
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Ingresar Login")]
        [Display(Name = "Nombre de Usuario")]
        [StringLength(20)]        
        public string UserName { get; set; }

        [Required(ErrorMessage = "Ingresar Clave")]
        [DataType(DataType.Password)]
        [Display(Name = "Clave")]
        [StringLength(20)]
        public string Password { get; set; }
        
    }
}