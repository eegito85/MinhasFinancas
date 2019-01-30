using MinhasFinancas.Data.Repositorios;
using MinhasFinancas.Domain.Entidades;
using MinhasFinancas.TestesUnitarios.DAO;
using System;
using Xunit;

namespace MinhasFinancas.TestesUnitarios
{
    public class UnitTestModels
    {
        [Fact]
        public void TesteLoginUsuario()
        {
            Acesso acesso = new Acesso();

            string email = "e_egito@hotmail.com";
            string senha = "milla2001";
            int resultado = acesso.VerificarUsuario(email, senha);

            Assert.Equal(1, resultado);
        }

    }
}
