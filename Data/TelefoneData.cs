using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using prova_Octo.Models;

namespace prova_Octo.Data
{
    public class TelefoneData : Data
    {

        public void Create(Telefone telefone)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = base.connectionDB;
            cmd.CommandText = @"Insert into Telefone Values(@idC, @num, @tipo)";

            cmd.Parameters.AddWithValue("@idC", telefone.IdCliente);
            cmd.Parameters.AddWithValue("@num", telefone.NumeroTelefone);
            cmd.Parameters.AddWithValue("@tipo", telefone.TipoTelefone);

            cmd.ExecuteNonQuery();
        }

        public Telefone Read(int id)
        {
            Telefone telefone = null;

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = base.connectionDB;
            cmd.CommandText = @"Select * From Telefone Where IdCliente = @id";

            cmd.Parameters.AddWithValue("@id", id);

            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                telefone = new Telefone
                {
                    IdCliente = (int)reader["IdCliente"],
                    NumeroTelefone = (string)reader["Nome"],
                    TipoTelefone = (string)reader["TipoCliente"]
                };
            }

            return telefone;
        }

        public void Update(Telefone telefone)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = base.connectionDB;
            cmd.CommandText = @"Update Endereco set NumeroTelefone = @num, TipoTelefone = @tipo,
            Where IdCliente = @id";

            cmd.Parameters.AddWithValue("@id", telefone.IdCliente);
            cmd.Parameters.AddWithValue("@num", telefone.NumeroTelefone);
            cmd.Parameters.AddWithValue("@tipo", telefone.TipoTelefone);

            cmd.ExecuteNonQuery();
        }

        public bool Delete(int id)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = base.connectionDB;
                cmd.CommandText = @"Delete from Telefone Where IdTelefone = @id";
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);

                return false;
            }
        }
    }
}