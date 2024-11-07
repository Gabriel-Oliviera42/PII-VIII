using Neo4j.Driver;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PII_VIII
{
    internal class AtividadeFisica
    {
        public int IdAtividade { get; set; }
        public string Nome { get; set; }
        public string Dificuldade { get; set; }
        public string Descricao { get; set; }

        ConexaoNeo4J conexaoNeo4J = new ConexaoNeo4J();
        
        public async Task<DataTable> BuscarTodosAsync()
        {
            string query = "MATCH (n:AtividadeFisica) " +
                           "RETURN n.id AS id, n.nomeatividade AS Atividade, " +
                           "n.descricao AS Descrição, n.repeticoes AS Repetições, " +
                           "n.dificuldade AS Dificuldade";

            DataTable dt = await conexaoNeo4J.DTConsulta(query); 
            return dt;
        }
        public async Task<DataTable> BuscarAtividadeTreinoAsync(int idTreino)
        {
            string query = $"MATCH (a:AtividadeFisica)-[r:INCLUSA_EM_TREINO]->(t:Treino) " +
                           $"WHERE t.id = {idTreino} " +
                           "RETURN a.nomeatividade AS Atividade, a.descricao AS Descrição, " +
                           "a.dificuldade AS Dificuldade, a.repeticoes AS Repetições";

            DataTable dt = await conexaoNeo4J.DTConsulta(query); 
            return dt;
        }
    }
}
