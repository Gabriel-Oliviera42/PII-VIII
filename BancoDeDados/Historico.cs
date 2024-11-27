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
        public int id_historico {  get; set; }  
        public int id_usuario {  get; set; }  
        public int id_objetivo {  get; set; }  
        public DateTime DataInicio { get; set; }  



        Conexao conn = new Conexao();   

        public void PreencherDados(int id_hist)
        {
            string sql = $@"SELECT * FROM historico WHERE id_historico = {id_hist}";
            DataTable atual = conn.RetornaTabela(sql);

            if (atual.Rows.Count > 0)
            {
                DataRow row = atual.Rows[0];

                id_historico = id_hist;
                id_usuario = int.Parse(row["id_usuario"].ToString());
                id_objetivo = int.Parse(row["id_objetivo"].ToString());
                DataInicio = (DateTime)row["datainicio"];
            }
            else
            {
                throw new Exception("´Registro não encontrado.");
            }
        }


        public DataTable RetornarHistoricoDeUsuario(int id_user)
        {
            string sql = $@"SELECT * FROM historico WHERE id_usuario = {id_user}";
            return conn.RetornaTabela(sql);
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