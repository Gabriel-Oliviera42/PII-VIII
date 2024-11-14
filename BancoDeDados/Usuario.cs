using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PII_VIII
{
    public class Usuario
    {
        public int IdUsuario { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }  // Adicionando a propriedade Senha
        public DateTime DataNascimento { get; set; }
        public float Altura { get; set; }
        public float Peso { get; set; }
        public int IdObjetivo { get; set; }
        public int IdFaixa { get; set; }

        private Conexao con = new Conexao();

        public void Inserir()
        {
            string query = "INSERT INTO usuario (nome, email, senha, datanascimento, altura, peso, id_objetivo, id_faixaetariapeso) " +
                           "VALUES (@Nome, @Email, @Senha, @DataNascimento, @Altura, @Peso, @IdObjetivo, @IdFaixa)";

            SqlCommand command = new SqlCommand(query);
            command.Parameters.AddWithValue("@Nome", Nome);
            command.Parameters.AddWithValue("@Email", Email);
            command.Parameters.AddWithValue("@Senha", Senha); // Inclusão da senha no comando SQL
            command.Parameters.AddWithValue("@DataNascimento", DataNascimento.ToString("yyyy-MM-dd"));
            command.Parameters.AddWithValue("@Altura", Altura);
            command.Parameters.AddWithValue("@Peso", Peso);
            command.Parameters.AddWithValue("@IdObjetivo", IdObjetivo);
            command.Parameters.AddWithValue("@IdFaixa", IdFaixa);

            con.Conectar();
            command.Connection = con.Conn;
            command.ExecuteNonQuery();
            con.Desconectar();
        }

        public void Atualizar(int id)
        {
            string query = "UPDATE usuario SET nome = @Nome, email = @Email, senha = @Senha, datanascimento = @DataNascimento, altura = @Altura, peso = @Peso " +
                           "WHERE id_usuario = @IdUsuario";

            SqlCommand command = new SqlCommand(query);
            command.Parameters.AddWithValue("@Nome", Nome);
            command.Parameters.AddWithValue("@Email", Email);
            command.Parameters.AddWithValue("@Senha", Senha); // Inclusão da senha no comando de atualização
            command.Parameters.AddWithValue("@DataNascimento", DataNascimento.ToString("yyyy-MM-dd"));
            command.Parameters.AddWithValue("@Altura", Altura);
            command.Parameters.AddWithValue("@Peso", Peso);
            command.Parameters.AddWithValue("@IdUsuario", id);

            con.Conectar();
            command.Connection = con.Conn;
            command.ExecuteNonQuery();
            con.Desconectar();
        }

        public void Deletar(int id)
        {
            string query = "DELETE FROM usuario WHERE id_usuario = @IdUsuario";
            SqlCommand command = new SqlCommand(query);
            command.Parameters.AddWithValue("@IdUsuario", id);

            try
            {
                con.Conectar();
                command.Connection = con.Conn;
                command.ExecuteNonQuery();
            }
            finally
            {
                con.Desconectar();
            }
        }

        public DataTable BuscarPorId(int id)
        {
            DataTable dt = new DataTable();
            string query = $"SELECT * FROM usuario WHERE idusuario = {id}";
            dt = con.RetornaTabela(query);
            return dt;
        }

        public DataTable BuscarTodos()
        {
            DataTable dt = new DataTable();
            string query = "SELECT * FROM usuario";
            dt = con.RetornaTabela(query);
            return dt;
        }

        public int VerificaFaixaEtariaPeso(float peso, int idade)
        {
            int idFaixaEtariaPeso = 0;
            string sql = "SELECT * FROM faixaetariapeso";
            DataTable tabelaFaixa = con.RetornaTabela(sql);

            foreach (DataRow row in tabelaFaixa.Rows)
            {
                int idadeMin = Convert.ToInt32(row["idademin"]);
                int idadeMax = Convert.ToInt32(row["idademax"]);
                float pesoMin = Convert.ToSingle(row["pesomin"]);
                float pesoMax = Convert.ToSingle(row["pesomax"]);
                if (idade >= idadeMin && idade <= idadeMax && peso >= pesoMin && peso <= pesoMax)
                {
                    idFaixaEtariaPeso = Convert.ToInt32(row["id_faixaetariapeso"]);
                    break;
                }
            }
            return idFaixaEtariaPeso;
        }
    }
}
