using MinhasFinancas.Data.Repositorios.Comum;
using MinhasFinancas.Domain.Entidades;
using MinhasFinancas.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MinhasFinancas.Data.Repositorios
{
    public class TransacaoRepositorio : RepositorioBase<Transacao>, ITransacaoRepositorio
    {
        public List<Transacao> ListarTransacoesPorUsuario(int usuarioId)
        {
            List<Transacao> listaTransacoes = new List<Transacao>();
            listaTransacoes = db.Transacoes.Where(u => u.Usuario_Id == usuarioId).ToList();
            return listaTransacoes;
        }

        public List<Transacao> FiltrarTransacoes(DateTime data, char tipo, int conta_id, int plano_conta_id)
        {
            List<Transacao> lista = new List<Transacao>();
            try
            {
                lista = db.Transacoes.Where(t => t.Tipo == tipo).Where(t => t.Conta_Id == conta_id).Where(t => t.Plano_Contas_Id == plano_conta_id).ToList();
                DateTime dataPadrao = Convert.ToDateTime("01/01/0001 00:00:00");

                if (data != dataPadrao)
                {
                    lista = lista.Where(t => t.Data == data).ToList();
                }
            }
            catch(Exception ex) {   }

            
            return lista;
        }
    }
}
