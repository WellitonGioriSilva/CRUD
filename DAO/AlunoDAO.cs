using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRUD.Mapeamento;
using CRUD.Utilitarios;
using MySql.Data.MySqlClient;

namespace CRUD.DAO
{
    internal class AlunoDAO
    {
        public void Cadastrar(Aluno aluno)
        {
            try
            {
                string dataNasc = aluno._dataNasc.ToString("yyyy-MM-dd");

                string sql = "INSERT INTO Aluno (nome, CPF, DataNasc, sexo, altura, telefone) VALUES (@nome, @CPF, @DataNasc, @sexo, @altura, @telefone)";

                MySqlCommand comando = new MySqlCommand(sql, Conexao.Conectar());
                comando.Parameters.AddWithValue("@nome", aluno._nome);
                comando.Parameters.AddWithValue("@CPF", aluno._cpf);
                comando.Parameters.AddWithValue("@DataNasc", dataNasc);
                comando.Parameters.AddWithValue("@sexo", aluno._sexo);
                comando.Parameters.AddWithValue("@altura", aluno._altura);
                comando.Parameters.AddWithValue("@telefone", aluno._telefone);
                comando.ExecuteNonQuery();
            }
            catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Conexao.FecharConexao();
            }
        }

        public void Atualizar(Aluno aluno)
        {
            try
            {
                if (aluno._id == null || aluno._id == 0) throw new Exception("ID Inválido!");

                    string dataNasc = aluno._dataNasc.ToString("yyyy-MM-dd");

                string sql = "UPDATE Aluno SET nome = @nome, CPF = @CPF, DataNasc = @DataNasc, sexo = @sexo, altura = @altura, telefone = @telefone" +
                    " WHERE id_aluno = @id";

                MySqlCommand comando = new MySqlCommand(sql, Conexao.Conectar());
                comando.Parameters.AddWithValue("@id", aluno._id);
                comando.Parameters.AddWithValue("@nome", aluno._nome);
                comando.Parameters.AddWithValue("@CPF", aluno._cpf);
                comando.Parameters.AddWithValue("@DataNasc", dataNasc);
                comando.Parameters.AddWithValue("@sexo", aluno._sexo);
                comando.Parameters.AddWithValue("@altura", aluno._altura);
                comando.Parameters.AddWithValue("@telefone", aluno._telefone);
                comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Conexao.FecharConexao();
            }
        }

        public List<Aluno> Selecionar(string cpf = "")
        {
            List<Aluno> alunos = new List<Aluno>();

            try
            {
                string filter = "";
                if (cpf != "") filter = "WHERE CPF LIKE @CPF";

                string sql = $"SELECT * FROM Aluno {filter} ORDER BY nome";

                MySqlCommand comando = new MySqlCommand(sql, Conexao.Conectar());
                if (cpf != "") comando.Parameters.AddWithValue("@CPF", $"{cpf}%");

                using (MySqlDataReader dr = comando.ExecuteReader())
                {
                    while (dr.Read()) {
                        Aluno aluno = new Aluno();
                        aluno._id = dr.GetInt32("id_aluno");
                        aluno._nome = dr.GetString("nome");
                        aluno._cpf = dr.GetString("CPF");
                        aluno._sexo = dr.GetChar("sexo");
                        aluno._altura = dr.GetDouble("altura");
                        aluno._telefone = dr.GetString("telefone");
                        aluno._dataNasc = dr.GetDateTime("dataNasc");

                        alunos.Add(aluno);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Conexao.FecharConexao();
            }

            return alunos;
        }
    }
}
