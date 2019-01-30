using System;
using System.Collections.Generic;
using System.Text;

namespace MinhasFinancas.Domain.Entidades
{
    public class Transacao
    {
        public int Id { get; set; }

        public DateTime Data { get; set; }

        public char Tipo { get; set; }

        public decimal Valor { get; set; }

        public string Descricao { get; set; }

        public int Conta_Id { get; set; }

        public int Plano_Contas_Id { get; set; }

        public int Usuario_Id { get; set; }
    }
}
