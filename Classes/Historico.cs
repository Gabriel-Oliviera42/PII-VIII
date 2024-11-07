using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;
using System.Runtime.InteropServices.ComTypes;
using System.Windows.Forms;

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

        public DataTable BuscarPorIntervaloDatass(DateTime dataInicio, DateTime dataFim)
        {
            string query = "Select * from historico where Datainicial between @Datainicio " +
                "and @Datafim and Datafinal between @Datainicio and @Datafim";



            using (SqlConnection conexao = this.conexao.Conectar())
            {
                {
                    using (SqlCommand comando = new SqlCommand(query, conexao))
                    {
                        comando.Parameters.Add(new SqlParameter("@DataInicio", dataInicio));
                        comando.Parameters.Add(new SqlParameter("@DataFim", dataFim));

                        using (SqlDataAdapter adaptador = new SqlDataAdapter(comando))
                        {
                            DataTable dataTable = new DataTable();
                            adaptador.Fill(dataTable);
                            return dataTable;
                        }
                    }   
                }
            }
        }
    }
}

    
