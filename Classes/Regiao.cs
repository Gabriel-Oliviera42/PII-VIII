using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PII_VIII.Classes
{
    internal class Regiao
    {
        public int IdRegiao {  get; set; }
        public string NomeRegiao {  get; set; }

        ConexaoNeo4J conexaoNeo4J = new ConexaoNeo4J();

        public async Task<DataTable> BuscarTodasRegioes()
        {
            string query = "MATCH (n:Regiao) RETURN n.nomeregiao AS Nome, n.id AS `Código Região`";
            DataTable dt = await conexaoNeo4J.DTConsulta(query);
            return dt;
        }

        public async Task<DataTable> BuscarRegioesAtvidade(int idAtvidade)
        {
            string query = $"MATCH (a:AtividadeFisica)-[r:TRABALHA_REGIAO]->(b:Regiao) where a.id={idAtvidade} RETURN b.nomeregiao AS Região";
            DataTable dt = await conexaoNeo4J.DTConsulta(query);
            return dt;
        }
    }
}
