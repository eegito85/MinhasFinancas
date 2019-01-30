using MinhasFinancas.Data.Repositorios.Comum;
using MinhasFinancas.Domain.Entidades;
using MinhasFinancas.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MinhasFinancas.Data.Repositorios
{
    public class ContaRepositorio : RepositorioBase<Conta>, IContaRepositorio
    {
        public List<Conta> ListarContasPorUsuario(int usuarioId)
        {
            List<Conta> listaContas = db.Contas.Where(u => u.Usuario_Id == usuarioId).ToList();
            return listaContas;
        }

        public List<string> ListarNomeContasPorUsuario(int usuarioId)
        {
            List<Conta> listaContas = db.Contas.Where(u => u.Usuario_Id == usuarioId).ToList();
            List<string> lista = new List<string>();

            foreach(Conta conta in listaContas)
            {
                lista.Add(conta.Nome);
            }

            return lista;
        }

        public int PegarIdContaPorNome(int usuario_Id, string nome)
        {
            int id = 0;

            id = db.Contas.Where(u => u.Usuario_Id == usuario_Id).Where(u => u.Nome == nome).FirstOrDefault().Id;

            return id;
        }

        public string PegarNomeContaPorId(int usuario_Id, int contaId)
        {
            string nome = "";

            nome = db.Contas.Where(u => u.Usuario_Id == usuario_Id).Where(u => u.Id == contaId).FirstOrDefault().Nome;

            return nome;
        }

    }
}
