using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

//OBS: tem que criar um metodo que recebe o id de um usuario e retorna todos os treinos deste usuario em um DataTable
//e outro que recebe um id de faixa etaria e retorna todos os treinos daquela faixa etaria também em um DataTable
//também criar uma que recebe um id de Treino e preenche os dados daquele treino na atual classe

namespace PII_VIII
{
    internal class Treino
    {
        public int IdTreino {  get; set; }
        public string NomeTreino {  get; set; }
        public string Descricao { get; set; }
        public int IdObjetivo { get; set; }

        Conexao conexao = new Conexao();

        public DataTable BuscarTodos()
        {
            string sql = "SELECT * FROM treino";
            DataTable dt = conexao.RetornaTabela(sql);
            return dt;
        }
        public int QuantidadeAtividadeTreino(int idTreino)
        {
            string query = $"SELECT COUNT(id_treino) from atividadefisica_treino where id_treino = {idTreino}";
            object quant = conexao.RetornaEscalar(query);
            int quantTreinos = quant != null ? Convert.ToInt32(quant) : 0;
            return quantTreinos;
        }
        public DataTable BuscarDadosTreino(int idTreino)
        {
            string query = $"SELECT * from treino where id_treino = {idTreino}";
            DataTable dt = conexao.RetornaTabela(query);
            return dt;
        }
        //Também na classe Treino criar uma função que recebe um id de Treino e preenche os dados daquele treino na atual classe
        public void PreencherDados(int treinoid) 
        {
            string query = $"SELECT * from treino where id_treino = {treinoid}";
            DataTable dt = conexao.RetornaTabela(query);
            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                IdTreino = treinoid;
                NomeTreino = row["nometreino"].ToString();
                Descricao = row["descricao"].ToString() ;
                IdObjetivo = int.Parse(row["id_objetivo"].ToString());
            }
            else
            {
                throw new Exception("Treino não encontrado.");
            }

        }
        
    }



}
