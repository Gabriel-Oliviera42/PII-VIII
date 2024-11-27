using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PII_VIII
{
    internal class Historico
    {
        Conexao conn = new Conexao();
        public int IdHistorico {  get; set; }
        public DateTime DataInicial { get; set; }
        public DateTime? DataFinal {  get; set; }
        public int IdObejetivo { get; set; }


        public DataTable BuscarHistorico(string pesquisa, int idUsuario)
        {
            string sql = $@"
            SELECT * 
            FROM historico 
            WHERE id_usuario = {idUsuario} AND (
            id_historico = {pesquisa} OR 
            id_usuario LIKE '%{pesquisa}%' OR 
            id_objetivo LIKE '%{pesquisa}%' OR 
            CONVERT(VARCHAR, datainicio) LIKE '%{pesquisa}%' OR 
            CONVERT(VARCHAR, datafinal) LIKE '%{pesquisa}%')";
            try
            {
                return conn.RetornaTabela(sql);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao buscar histórico: " + ex.Message);
            }
        }   
        
        public DataTable BuscarTodosHistoricos(int iduser)
        {
            string querry = $"select * from historico h inner join objetivo o on h.id_objetivo = o.id_objetivo inner join usuario u on h.id_usuario = u.id_usuario where u.id_usuario = {iduser} and h.datafinal is not null";
            DataTable dt = conn.RetornaTabela(querry);
            return dt;
        }

        public DataTable BuscarHistoricoAtivo(int iduser)
        {
            string querry = $"select * from historico where id_usuario = {iduser} and datafinal is null ";
            DataTable dt = conn.RetornaTabela(querry);
            return dt;
        }
    }
}