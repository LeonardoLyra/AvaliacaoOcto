using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using prova_Octo.Models;

namespace prova_Octo.Data
{
    public class EnderecoData : Data
    {
        public void Create(Endereco endereco)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = base.connectionDB;
            cmd.CommandText = @"Insert into Telefone Values(@idC, @logradouro, @tipo)";

            cmd.Parameters.AddWithValue("@idC", endereco.IdCliente);
            cmd.Parameters.AddWithValue("@logradouro", endereco.Logradouro);
            cmd.Parameters.AddWithValue("@tipo", endereco.TipoEndereco);

            cmd.ExecuteNonQuery();
        }
        public Endereco Read(int id)
        {
            Endereco endereco = null;

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = base.connectionDB;
            cmd.CommandText = @"Select * From Endereco Where IdCliente = @id";

            cmd.Parameters.AddWithValue("@id", id);

            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                endereco = new Endereco
                {
                    IdCliente = (int)reader["IdCliente"],
                    Logradouro = (string)reader["Logradouro"],
                    TipoEndereco = (string)reader["TipoEndereco"]
                };
            }

            return endereco;
        }

        public void Update(Endereco endereco)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = base.connectionDB;
            cmd.CommandText = @"Update Endereco set Logradouro = @logradouro, TipoEndereco = @tipo,
            Where IdCliente = @id";

            cmd.Parameters.AddWithValue("@id", endereco.IdCliente);
            cmd.Parameters.AddWithValue("@logradouro", endereco.Logradouro);
            cmd.Parameters.AddWithValue("@tipo", endereco.TipoEndereco);

            cmd.ExecuteNonQuery();
        }

        public bool Delete(int id)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = base.connectionDB;
                cmd.CommandText = @"Delete from Endereco Where IdEndereco = @id";
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