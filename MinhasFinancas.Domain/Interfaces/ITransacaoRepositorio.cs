using MinhasFinancas.Domain.Entidades;
using MinhasFinancas.Domain.Interfaces.Comum;
using System;
using System.Collections.Generic;
using System.Text;

namespace MinhasFinancas.Domain.Interfaces
{
    public interface ITransacaoRepositorio : IRepositorioBase<Transacao>
    {
        List<Transacao> ListarTransacoesPorUsuario(int usuarioId);
        List<Transacao> FiltrarTransacoes(DateTime data, char tipo, int conta_id, int plano_conta_id);
    }
}
