using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MinhasFinancas.Domain.Entidades
{
    public class Conta
    {

        public int Id { get; set; }
        [Required(ErrorMessage ="Informe o nome da conta")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Informe o valor do saldo")]
        public decimal Saldo { get; set; }

        public int Usuario_Id { get; set; }

    }
}
