using MinhasFinancas.Domain.Entidades;
using MinhasFinancas.Domain.Interfaces.Comum;
using System;
using System.Collections.Generic;
using System.Text;

namespace MinhasFinancas.Domain.Interfaces
{
    public interface IUsuarioRepositorio : IRepositorioBase<Usuario>
    {
        int VerificarUsuario(string email, string senha);
        Usuario PegarUsuarioPorEmail(string email);
        void AdicionarUsuario(Usuario usuario);
    }
}
