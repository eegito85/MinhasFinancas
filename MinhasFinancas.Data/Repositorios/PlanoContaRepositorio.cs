using MinhasFinancas.Data.Repositorios.Comum;
using MinhasFinancas.Domain.Entidades;
using MinhasFinancas.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MinhasFinancas.Data.Repositorios
{
    public class PlanoContaRepositorio : RepositorioBase<Plano_Conta>, IPlanoContaRepositorio
    {
        public List<Plano_Conta> ListarPlanoContasPorUsuario(int usuarioId)
        {
            List<Plano_Conta> listaPlanoContas = new List<Plano_Conta>();
            try
            {
                listaPlanoContas = db.Plano_Contas.Where(u => u.Usuario_Id == usuarioId).ToList();
            }
            catch { }
            
            return listaPlanoContas;
        }

        public List<string> ListarNomePlanoContasPorUsuario(int usuarioId)
        {
            List<Plano_Conta> listaContas = db.Plano_Contas.Where(u => u.Usuario_Id == usuarioId).ToList();
            List<string> lista = new List<string>();

            foreach (Plano_Conta plano in listaContas)
            {
                lista.Add(plano.Descricao);
            }
            return lista;
        }

        public int PegarIdPlanoContaPorNome(int usuario_Id, string descricao)
        {
            int id = 0;

            id = db.Plano_Contas.Where(u => u.Usuario_Id == usuario_Id).Where(u => u.Descricao == descricao).FirstOrDefault().Id;

            return id;
        }

        public string PegarNomePlanoContaPorId(int usuario_Id, int planocontaId)
        {
            string nome = "";

            nome = db.Plano_Contas.Where(u => u.Usuario_Id == usuario_Id).Where(u => u.Id == planocontaId).FirstOrDefault().Descricao;

            return nome;
        }

    }
}
