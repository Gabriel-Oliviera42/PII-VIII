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
    }
}