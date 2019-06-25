using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Projeto.Services.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Campo Obrigatório.")]
        public string Usuario { get; set; }
        [Required(ErrorMessage = "Campo Obrigatório.")]
        public string Senha { get; set; }

    }
}
