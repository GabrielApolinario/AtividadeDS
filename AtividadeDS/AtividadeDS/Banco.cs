using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace AtividadeDS
{
    class Banco : IDisposable
    {
        private readonly SqlConnection conexao;

        public  Banco()
        {
            conexao = new SqlConnection(ConfigurationManager.ConnectionStrings["conexao"].ConnectionString);
            conexao.Open();
        }

        //Metodo que nao tem retorno
        public void ExecutaComando(string StrQuery)
        {
            SqlCommand vComando = new SqlCommand
            {
                CommandText = StrQuery,
                CommandType = CommandType.Text,
                Connection = conexao
            };
            vComando.ExecuteNonQuery();
        }

        //Metodo com retorno
        public SqlDataReader RetornaComando(string Strquery)
        {
            SqlCommand comando = new SqlCommand(Strquery, conexao);
            return comando.ExecuteReader();
        }

        public void Dispose()
        {
            if (conexao.State == ConnectionState.Open)
                conexao.Close();
        }
    }
}
