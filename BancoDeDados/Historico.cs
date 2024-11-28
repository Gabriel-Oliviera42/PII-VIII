using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection.Emit;

namespace PII_VIII
{
    internal class Historico
    {
        Conexao conn = new Conexao();
        public int IdHistorico {  get; set; }
        public int IdUsuario { get; set; }
        public DateTime DataInicial { get; set; }
        public DateTime? DataFinal {  get; set; }
        public int IdObjetivo { get; set; }

        public string DescricaoObjetivo { get; set; }

        public void PreencherDados(int id_hist)
        {
            string sql = $@"SELECT * FROM historico WHERE id_historico = {id_hist}";
            DataTable atual = conn.RetornaTabela(sql);
            if (atual.Rows.Count > 0)
            {
                DataRow row = atual.Rows[0];
                IdHistorico = id_hist;
                IdUsuario = int.Parse(row["id_usuario"].ToString());
                IdObjetivo = int.Parse(row["id_objetivo"].ToString());
                DataInicial = (DateTime)row["datainicio"];
                DataFinal = row["datafinal"] == DBNull.Value ? (DateTime?)null : (DateTime)row["datafinal"];
                Objetivo obj = new Objetivo();
                obj.PreencherDados(IdObjetivo);
                DescricaoObjetivo = obj.Descricao;
            }
            else
            {
                throw new Exception("´Registro não encontrado.");
            }
        }


        public DataTable BuscarHistoricoAntigo(int iduser)
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

        public DataTable BuscarHistorico(string pesquisa, int idUsuario, int dia, int mes, int ano)
        {
            string sql = $@"
        SELECT * 
        FROM historico 
        WHERE id_usuario = {idUsuario} AND (
            CONVERT(VARCHAR, datainicio) = '{ano}-{mes}-{dia}' OR
            CONVERT(VARCHAR, datainicio) LIKE '{ano}-{mes}%' OR
            CONVERT(VARCHAR, datainicio) LIKE '%{mes}-{dia}' OR
            CONVERT(VARCHAR, datainicio) LIKE '{ano}%' OR
            CONVERT(VARCHAR, datainicio) LIKE '%{mes}%' OR
            CONVERT(VARCHAR, datainicio) LIKE '%{dia}' OR
            CONVERT(VARCHAR, datafinal) = '{ano}-{mes}-{dia}' OR
            CONVERT(VARCHAR, datafinal) LIKE '{ano}-{mes}%' OR
            CONVERT(VARCHAR, datafinal) LIKE '%{mes}-{dia}' OR
            CONVERT(VARCHAR, datafinal) LIKE '{ano}%' OR
            CONVERT(VARCHAR, datafinal) LIKE '%{mes}%' OR
            CONVERT(VARCHAR, datafinal) LIKE '%{dia}' OR
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

        //public DataTable BuscarHistorico(string pesquisa, int idUsuario)
        //{
        //    string sql = $@"
        //SELECT * 
        //FROM historico 
        //WHERE id_usuario = {idUsuario} AND (
        //    id_historico = {pesquisa} OR 
        //    id_usuario LIKE '%{pesquisa}%' OR 
        //    id_objetivo LIKE '%{pesquisa}%' OR 
        //    CONVERT(VARCHAR, datainicio) LIKE '%{pesquisa}%' OR 
        //    CONVERT(VARCHAR, datafinal) LIKE '%{pesquisa}%')";
        //    try
        //    {
        //        return conn.RetornaTabela(sql);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception("Erro ao buscar histórico: " + ex.Message);
        //    }
        //}
    }
}