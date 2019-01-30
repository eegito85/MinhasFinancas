using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MinhasFinancas.Domain.Entidades
{
    public class Plano_Conta
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Informe a descrição")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "Informe o tipo de conta")]
        public char Tipo { get; set; }

        public int Usuario_Id { get; set; }
    }
}
