using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PII_VIII
{
    internal class Treino
    {
        public int idTreino {  get; set; }
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

        public DataTable BuscarTreinosUsuario(int idTreino)
        {
            string query = $"MATCH (a:AtividadeFisica)-[r:INCLUSA_EM_TREINO]->(t:Treino) where t.id ={idTreino} RETURN a.nomeatividade AS Atividade, a.descricao AS Descrição ,a.dificuldade AS Dificuldade, a.repeticoes AS Repetições";
            DataTable dt = conexao.RetornaTabela(query);
            return dt;
        }

    }



}
