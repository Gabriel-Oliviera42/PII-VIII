using Neo4j.Driver;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PII_VIII

    //Criar uma função que recebe um id da atividade Física e preenche com os dados restantes na atual classe
{
    internal class AtividadeFisica
    {
        public int IdAtividade {  get; set; }
        public string Nome {  get; set; }
        public string Dificuldade { get; set;}
        public string Descricao {  get; set;}

        ConexaoNeo4J conexaoNeo4J = new ConexaoNeo4J();

        public DataTable BuscarTodos()
        {
            string query = "MATCH (n:AtividadeFisica) RETURN n.nomeatividade AS Atividade, n.descricao AS Descricao, n.repeticoes AS Repetições, n.dificuldade AS Dificuldade";
            DataTable dt = Task.Run(() => conexaoNeo4J.DTConsulta(query)).Result;
            return dt;
        }

        public DataTable BuscarAtividadeTreino(int idTreino)
        {
            string query = $"MATCH (a:AtividadeFisica)-[r:INCLUSA_EM_TREINO]->(t:Treino) where t.id ={idTreino} RETURN a.nomeatividade AS Atividade, a.descricao AS Descrição ,a.dificuldade AS Dificuldade, a.repeticoes AS Repetições";
            DataTable dt = Task.Run(() => conexaoNeo4J.DTConsulta(query)).Result;
            return dt;
        }

        //Na classe Atividade Física, criar uma função que recebe um id de Atividade Física e preenche os dados da mesma na atual classe
        public void PreencherDados(int AtividadeFisicaId)
        {
            string query = $"MATCH (n:AtividadeFisica) WHERE n.id = {AtividadeFisicaId} RETURN n.id AS id, n.repeticoes AS repeticoes, n.dificuldade AS dificuldade, n.nomeatividade AS nomeatividade, n.descricao AS descricao";
            DataTable dt = Task.Run(() => conexaoNeo4J.DTConsulta(query)).Result;

            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                IdAtividade = int.Parse(row["id"].ToString());
                Nome = row["nomeatividade"].ToString();
                Dificuldade = row["dificuldade"].ToString();
                Descricao = row["descricao"].ToString();
            }
            else
            {
                throw new Exception("Atividade física não encontrada.");
            }
        }


    }
}
