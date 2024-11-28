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
        Conexao conexao = new Conexao();

        public DataTable BuscarTodos()
        {
            string query = "MATCH (n:AtividadeFisica) RETURN n.nomeatividade AS Atividade, n.descricao AS Descricao, n.repeticoes AS Repetições, n.dificuldade AS Dificuldade";
            DataTable dt = Task.Run(() => conexaoNeo4J.DTConsulta(query)).Result;
            return dt;
        }

        private DataTable BuscarAtividadeTreino(int idTreino)
        {
            string query = $"SELECT id_atividadefisica from atividadefisica_treino where id_treino = {idTreino}";
            DataTable dt = conexao.RetornaTabela(query);
            return dt;
        }
        public async Task<DataTable> BuscarAtividadesAsync(int idTreino)
        {
            DataTable atividades = BuscarAtividadeTreino(idTreino);
            if (atividades.Rows.Count == 0)
            {
                return new DataTable(); // Retorna um DataTable vazio se não houver IDs
            }

            string consulta = GerarConsultaCypherComIds(atividades);

            DataTable resultado = await conexaoNeo4J.DTConsulta(consulta);
            return resultado;
        }

        public string GerarConsultaCypherComIds(DataTable dt)
        {
             List<int> ids = new List<int>();

            foreach (DataRow row in dt.Rows)
            {
                int id = Convert.ToInt32(row["id_atividadefisica"]);
                ids.Add(id);
            }

            // Se houver ao menos um ID, monta a consulta
            if (ids.Count > 0)
            {
                // Converte a lista de IDs em uma string separada por vírgulas, usando IN
                string idList = string.Join(", ", ids);

                // Retorna a consulta completa com MATCH e WHERE usando IN
                return $"MATCH (n:AtividadeFisica) WHERE n.id_SQL IN [{idList}] " +
                       "RETURN n.id_SQL AS IDSQL, n.nomeatividade AS Nome, n.descricao AS Descricao, n.dificuldade AS Dificuldade";
            }

            // Caso contrário, retorna uma consulta vazia
            return "MATCH (n:AtividadeFisica) WHERE 1 = 0 RETURN n"; // Retorna nada
        }

        public void PreencherDados(int AtividadeFisicaId)
        {
            string query = $"MATCH (n:AtividadeFisica) WHERE n.`id_SQL` = {AtividadeFisicaId} RETURN n.`id_SQL` AS IDSQL, n.dificuldade AS Dificuldade , n.nomeatividade AS Nome , n.descricao AS Descricao";
            DataTable dt = Task.Run(() => conexaoNeo4J.DTConsulta(query)).Result;

            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                IdAtividade = int.Parse(row["IDSQL"].ToString());
                Nome = row["Nome"].ToString();
                Dificuldade = row["Dificuldade"].ToString();
                Descricao = row["Descricao"].ToString();
            }
            else
            {
                throw new Exception("Atividade física não encontrada.");
            }
        }


        public async Task<DataTable> BuscarRegioesAtividadesAsync(int idAtividade)
        {
            string querry = $"MATCH p=(a:AtividadeFisica)-[:ATIVA]->(b:Regiao) where a.`id_SQL` = {idAtividade} RETURN b.nome;";
            DataTable resultado = await conexaoNeo4J.DTConsulta(querry);
            return resultado;
        }
    }
}
