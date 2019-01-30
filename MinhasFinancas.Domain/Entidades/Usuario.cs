using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MinhasFinancas.Domain.Entidades
{
    public class Usuario
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Informe o seu nome completo")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Informe o seu email")]
        [RegularExpression(".+\\@.+\\..+", ErrorMessage = "Informe um email válido...")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Informe sua senha")]
        public string Senha { get; set; }

        [Required(ErrorMessage = "Informe a sua data de nascimento")]
        public DateTime Data_Nascimento { get; set; }

        public DateTime Data_Cadastro { get; set; }
    }
}
