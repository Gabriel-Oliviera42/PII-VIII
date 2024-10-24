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
        public string Nome {  get; set; }
        public string Dificuldade { get; set;}
        public string Descricao {  get; set;}

        ConexaoNeo4J conexaoNeo4J = new ConexaoNeo4J();

        public DataTable BuscarTodos()
        {
            string query = "MATCH (n:AtividadeFisica) RETURN n.nomeatividade AS Atividade, n.descricao AS Descrição, n.repeticoes AS Repetições, n.dificuldade AS Dificuldade";
            DataTable dt = Task.Run(() => conexaoNeo4J.DTConsulta(query)).Result;
            return dt;
        }

        public DataTable BuscarAtividadeTreino(int idTreino)
        {
            string query = $"MATCH (a:AtividadeFisica)-[r:INCLUSA_EM_TREINO]->(t:Treino) where t.id ={idTreino} RETURN a.nomeatividade AS Atividade, a.descricao AS Descrição ,a.dificuldade AS Dificuldade, a.repeticoes AS Repetições";
            DataTable dt = Task.Run(() => conexaoNeo4J.DTConsulta(query)).Result;
            return dt;
        }       

    }
}
