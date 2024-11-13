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
            string aux2 = "SERVER=.\\SQLEXPRESS;Integrated Security = True";
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

        // novo metodo que estou chamano na parte de login, mas especificamente no metodo Fazer_Login()
        // lembrando que issa é para o banco de dados SQL_GestaoSaude
        public bool ValidarLogin(string email, string senha)
        {
            try
            {
                string sql = "SELECT COUNT(*) FROM usuario WHERE email = @Email AND senha = @Senha";
                Cmd.Connection = Conn;
                Cmd.CommandText = sql;
                Cmd.Parameters.Clear();  // limpa antes de adicionar novos
                Cmd.Parameters.AddWithValue("@Email", email);
                Cmd.Parameters.AddWithValue("@Senha", senha);

                Conectar(); // conecta ao banco de dados
                int userCount = (int)Cmd.ExecuteScalar(); // executa a consulta e pega o valor
                Desconectar(); // desconectar depois de terminar

                return userCount > 0; // retorna verdadeiro se o login for válido
            }
            catch (Exception ex)
            {
                // se der erro, pode adicionar um tratamento, como uma mensagem de erro
                throw new Exception("Erro ao validar login: " + ex.Message);
            }
        }

    }
}
