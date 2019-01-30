using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace MinhasFinancas.TestesUnitarios.DAO
{
    public class Acesso
    {
        public string conexao = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=Exemplos;Integrated Security=True";

        public int VerificarUsuario(string email, string senha)
        {
            int resultado = 0;
            string sQuery = "";
            string senhaDB = "";

            if (email != null)
            {
                try
                {
                    sQuery = "SELECT Senha as SenhaUsuario FROM Usuarios "
                           + " WHERE Email = @email";

                    SqlConnection sqlConnection1 = new SqlConnection(conexao);
                    SqlCommand cmd = new SqlCommand();
                    SqlDataReader reader;

                    cmd.CommandText = sQuery;
                    cmd.Parameters.AddWithValue("@email", email);

                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = sqlConnection1;

                    sqlConnection1.Open();

                    reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        senhaDB = reader["SenhaUsuario"].ToString();
                    }
                    sqlConnection1.Close();

                    if(senhaDB == senha) { resultado = 1; }

                }
                catch { }
            }
            return resultado;
        }





    }
}
