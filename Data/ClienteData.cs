using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using prova_Octo.Models;

namespace prova_Octo.Data
{
    public class ClienteData : Data
    {
        public void Create(Cliente cliente)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = base.connectionDB;
            cmd.CommandText = @"Insert into Cliente Values(@nome, @tipo, @cpf_cnpj)";

            cmd.Parameters.AddWithValue("@nome", cliente.Nome);
            cmd.Parameters.AddWithValue("@tipo", cliente.TipoCliente);
            cmd.Parameters.AddWithValue("@cpf_cnpj", cliente.CPF_CNPJ);

            cmd.ExecuteNonQuery();
        }

        public List<Cliente> Read()
        {
            List<Cliente> lista = new List<Cliente>();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = base.connectionDB;
            cmd.CommandText = @"Select * From Cliente ";

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Cliente cliente = new Cliente();

                cliente.IdCliente = (int)reader["IdCliente"];
                cliente.Nome = (string)reader["Nome"];
                cliente.TipoCliente = (string)reader["TipoCliente"];
                cliente.CPF_CNPJ = (string)reader["CPF_CNPJ"];

                lista.Add(cliente);
            }


            return lista;
        }

        public Cliente Read(int id)
        {
            Cliente cliente = null;

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = base.connectionDB;
            cmd.CommandText = @"Select * From Cliente Where IdCliente = @id";

            cmd.Parameters.AddWithValue("@id", id);

            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                cliente = new Cliente
                {
                    IdCliente = (int)reader["IdCliente"],
                    Nome = (string)reader["Nome"],
                    TipoCliente = (string)reader["TipoCliente"],
                    CPF_CNPJ = (string)reader["CPF_CNPJ"]
                };
            }

            return cliente;
        }

        public void Update(Cliente cliente)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = base.connectionDB;
            cmd.CommandText = @"Update Cliente set Nome = @nome, TipoCliente = @tipo, CPF_CNPJ = @cpf_cnpj
            Where IdCliente = @id";

            cmd.Parameters.AddWithValue("@id", cliente.IdCliente);
            cmd.Parameters.AddWithValue("@nome", cliente.Nome);
            cmd.Parameters.AddWithValue("@tipo", cliente.TipoCliente);
            cmd.Parameters.AddWithValue("@cpf_cnpj", cliente.CPF_CNPJ);

            cmd.ExecuteNonQuery();
        }

        public bool Delete(int id)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = base.connectionDB;
                cmd.CommandText = @"Delete from Cliente Where IdCliente = @id";
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Existem números e endereços atrelados a esse cliente" + ex);

                return false;
            }


        }
    }
}