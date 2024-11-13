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
