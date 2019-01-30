using MinhasFinancas.Domain.Entidades;
using MinhasFinancas.Domain.Interfaces.Comum;
using System;
using System.Collections.Generic;
using System.Text;

namespace MinhasFinancas.Domain.Interfaces
{
    public interface IContaRepositorio : IRepositorioBase<Conta>
    {
        List<Conta> ListarContasPorUsuario(int usuarioId);
        List<string> ListarNomeContasPorUsuario(int usuarioId);
        int PegarIdContaPorNome(int usuario_Id, string nome);
        string PegarNomeContaPorId(int usuario_Id, int contaId);
    }
}
