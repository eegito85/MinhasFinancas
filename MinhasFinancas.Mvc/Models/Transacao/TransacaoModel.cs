using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MinhasFinancas.Mvc.Models.Transacao
{
    public class TransacaoModel
    {
        public int Id { get; set; }

        public DateTime Data { get; set; }

        public char Tipo { get; set; }

        public decimal Valor { get; set; }

        public string Descricao { get; set; }

        public string NomeConta { get; set; }

        public string DescricaoPlanoConta { get; set; }
    }
}
