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
            string aux = "Server=.\\SQLEXPRESS;Database=GestaoSaude;UID=SA;PWD=123";
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

    }
}
