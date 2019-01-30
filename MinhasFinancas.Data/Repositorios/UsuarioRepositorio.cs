using MinhasFinancas.Data.Context;
using MinhasFinancas.Data.Repositorios.Comum;
using MinhasFinancas.Domain.Entidades;
using MinhasFinancas.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MinhasFinancas.Data.Repositorios
{
    public class UsuarioRepositorio : RepositorioBase<Usuario>, IUsuarioRepositorio
    {

        // 0 para acesso negado e 1 para acesso permitido 
        public int VerificarUsuario(string email, string senha)
        {
            int retorno = 0;
            Usuario usuario = db.Usuarios.Where(u => u.Email == email).FirstOrDefault();
            if (usuario != null)
            {
                if (usuario.Email == email && usuario.Senha == senha)
                {
                    retorno = 1;
                }
            }
            return retorno;
        }

        public Usuario PegarUsuarioPorEmail(string email)
        {
            return db.Usuarios.Where(u => u.Email == email).FirstOrDefault();
        }

        public void AdicionarUsuario(Usuario usuario)
        {
            usuario.Data_Cadastro = DateTime.Now;
            db.Add(usuario);
            db.SaveChanges();
        }

    }
}
