using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PII_VIII
{
    internal class Conexao
    {
        SqlConnection conn = new SqlConnection();
        SqlCommand cmd = new SqlCommand();

        public SqlConnection Conn { get => conn; set => conn = value; }
        public SqlCommand Cmd { get => cmd; set => cmd = value; }

        public void Conectar()
        {
            string aux = "SERVER=.\\SQLEXPRESS;Database=SQL_GestaoSaude;UID=sa;PWD=123";
            Conn.ConnectionString = aux;
            Conn.Open();
        }
        public void Desconectar()
        {
            Conn.Close();
        }
        public void Executar(string sql)
        {
            Conectar();
            Cmd.Connection = Conn;
            Cmd.CommandText = sql;
            Cmd.ExecuteNonQuery();
            Desconectar();
        }
        public DataTable RetornaTabela(string sql)
        {
            DataTable dt = new DataTable();
            Conectar(); 
            SqlCommand cmd = new SqlCommand(sql, Conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);            
            Desconectar();            
            return dt;            
        }

        public DataSet RetornaBanco(string sql)
        {
            DataSet ds = new DataSet();            
            Conectar();  
            SqlCommand cmd = new SqlCommand(sql, Conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);              
            Desconectar();             
            return ds;
        }

        public object RetornaEscalar(string sql)
        {
            object resultado;
            Conectar();
            SqlCommand cmd = new SqlCommand(sql, Conn);
            // Executa a consulta e obtém o valor escalar
            resultado = cmd.ExecuteScalar();
            Desconectar();
            return resultado;
        }


        // novo metodo que estou chamano na parte de login, mas especificamente no metodo Fazer_Login()
        // lembrando que issa é para o banco de dados SQL_GestaoSaude
        public int? ValidarLoginERetornarId(string email, string senha)
        {
            try
            {
                string sql = "SELECT id_usuario FROM usuario WHERE email = @Email AND senha = @Senha";
                Cmd.Connection = Conn;
                Cmd.CommandText = sql;
                Cmd.Parameters.Clear();  // limpa antes de adicionar novos
                Cmd.Parameters.AddWithValue("@Email", email);
                Cmd.Parameters.AddWithValue("@Senha", senha);

                Conectar(); // conecta ao banco de dados
                object result = Cmd.ExecuteScalar(); // executa a consulta e pega o valor
                Desconectar(); // desconecta depois de terminar

                // Verifica se encontrou um usuário com as credenciais informadas
                if (result != null && int.TryParse(result.ToString(), out int userId))
                {
                    return userId; // retorna o ID do usuário caso o login seja válido
                }
                else
                {
                    return null; // retorna null caso o login seja inválido
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao validar login: " + ex.Message);
            }
        }


    }
}
