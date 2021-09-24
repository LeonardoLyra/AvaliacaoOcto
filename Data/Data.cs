using System;
using Microsoft.Data.SqlClient;

namespace prova_Octo.Data
{
    public abstract class Data : IDisposable
    {
        //atributo: vai nos permitir conectar com o Banco de Dados
        protected SqlConnection connectionDB;
        //string de conexão como banco de dados

        

        protected Data()
        {
            try
            {
                string strConexao = "Sua String de Conexão Aqui";

                connectionDB = new SqlConnection(strConexao);

                connectionDB.Open();
            }
            catch(SqlException er)
            {
                Console.WriteLine("Erro do banco" + er);
            }
        }

        public void Dispose()
        {
            connectionDB.Close();
        }
    }
}