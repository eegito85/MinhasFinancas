using MinhasFinancas.Domain.Entidades;
using MinhasFinancas.Domain.Interfaces.Comum;
using System;
using System.Collections.Generic;
using System.Text;

namespace MinhasFinancas.Domain.Interfaces
{
    public interface IPlanoContaRepositorio : IRepositorioBase<Plano_Conta>
    {
        List<Plano_Conta> ListarPlanoContasPorUsuario(int usuarioId);
        List<string> ListarNomePlanoContasPorUsuario(int usuarioId);
        int PegarIdPlanoContaPorNome(int usuario_Id, string descricao);
        string PegarNomePlanoContaPorId(int usuario_Id, int planocontaId);
    }
}
