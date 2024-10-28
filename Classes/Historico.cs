using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;

namespace PII_VIII.Classes
{
    internal class Historico
    {
        public int IdUsuario { get; set; }
        public int IdObjetivo { get; set; }
        public DateTime DataInicial { get; set; }
        public DateTime DataFinal { get; set; }

        public Conexao conexao = new Conexao();

        // Método para registrar o histórico de um usuário
        public void RegistraHistorico(int usuario, int objetivo)
        {
            DataInicial = DateTime.Now;
            string sql = $"INSERT INTO historico (idusuario, idobjetivo, datainicio, datafinal) " +
                         $"VALUES ({usuario}, {objetivo}, '{DataInicial:yyyy-MM-dd HH:mm:ss}', NULL)";
            conexao.Executar(sql);
        }

        // Método para alterar o objetivo do usuário
        public void AlterarObjetivoUsuario(int usuario, int novoObjetivo)
        {
            DateTime dataFinal = DateTime.Now;
            // Atualiza a data final do objetivo anterior
            string sqlUpdate = $"UPDATE historico SET datafinal = '{dataFinal:yyyy-MM-dd HH:mm:ss}' " +
                               $"WHERE idusuario = {usuario} AND datafinal IS NULL";
            conexao.Executar(sqlUpdate);
            // Registra o novo objetivo com a data de início
            RegistraHistorico(usuario, novoObjetivo);
        }

        public DataTable BuscarPorUsuario(int idUsuario)
        {
            string query = $"SELECT * FROM historico WHERE idusuario = {idUsuario}";
            return conexao.RetornaTabela(query);             
        }

        // Método para buscar o histórico por intervalo de datas retornando um DataSet
        public DataSet BuscarPorIntervaloDatas(DateTime dataInicio, DateTime dataFim)
        {
            string query = "SELECT * FROM historico WHERE DataInicial >= @DataInicio AND DataFinal <= @DataFim";
            var parameters = new SqlParameter[]
            {
            new SqlParameter("@DataInicio", dataInicio),
            new SqlParameter("@DataFim", dataFim)
            };
            return conexao.ExecuteQueryDataSet(query, parameters); // Método que retorna um DataSet
        }
    }
}
