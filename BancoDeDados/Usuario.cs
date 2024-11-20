using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PII_VIII
{
    using Neo4j.Driver;
    using System.Data;
    using System.Globalization;

    //Criar uma função que recebe o Id de um usuário e preenche com os dados restantes na atual classe

    public class Usuario
    {
        public int IdUsuario { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public DateTime DataNascimento { get; set; }
        public float Altura { get; set; }
        public float Peso { get; set; }
        public int IdObjetivo { get; set; }
        public int IdFaixa { get; set; }
        public string Senha { get; set; }

        private Conexao con = new Conexao();

        public void Inserir()
        {
           string query = $"INSERT INTO usuario (nome, email, datanascimento, altura, peso, id_objetivo, id_faixaetariapeso, senha)" +
                $"VALUES ('{Nome}','{Email}','{DataNascimento.ToString("yyyy-MM-dd")}', {Altura.ToString("0.00", CultureInfo.InvariantCulture)}, {Peso.ToString("0.00", CultureInfo.InvariantCulture)}, {IdObjetivo}, {IdFaixa}, '{Senha}')";
            con.Executar(query);
        }

        public void Atualizar(int id)
        {
           string query = $"UPDATE usuario SET nome = '{Nome}', email = '{Email}', datanascimento = '{DataNascimento.ToString("yyyy-MM-dd")}', altura ={Altura.ToString("0.00", CultureInfo.InvariantCulture)}, peso =  {Peso.ToString("0.00", CultureInfo.InvariantCulture)} WHERE id = {id}";
           con.Executar(query);            
        }

        public void Deletar(int id)
        {
            string query = $"DELETE FROM usuario WHERE id = {id}";           
            con.Executar(query);            
        }



        public void PreencherDados(int idUsuario)
        {
            DataTable dt = new DataTable();
            string query = $"SELECT * FROM usuario WHERE id_usuario = {idUsuario}";
            dt = con.RetornaTabela(query);

            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];

                Program.user.IdUsuario = idUsuario;
                Program.user.Nome = row["nome"].ToString();
                Program.user.Email = row["email"].ToString();
                Program.user.DataNascimento = Convert.ToDateTime(row["datanascimento"]);
                Program.user.Altura = float.Parse(row["altura"].ToString());
                Program.user.Peso = float.Parse(row["peso"].ToString());
                Program.user.IdObjetivo = int.Parse(row["id_objetivo"].ToString());
                Program.user.IdFaixa = int.Parse(row["id_faixaetariapeso"].ToString());
            }
            else
            {
                throw new Exception("Usuário não encontrado.");
            }
        }

        public DataTable BuscarTodos()
        {
            DataTable dt = new DataTable();
            string query = "SELECT * FROM usuario";
            dt = con.RetornaTabela(query);
            return dt;
        }

        public int VerificaFaixaEtariaPeso(float peso, int idade)
        {
            int idFaixaEtariaPeso = 0;
            string sql = "SELECT * FROM faixaetariapeso";
            DataTable tabelaFaixa = con.RetornaTabela(sql);
                        
            foreach (DataRow row in tabelaFaixa.Rows)
            {
                int idadeMin = Convert.ToInt32(row["idademin"]);
                int idadeMax = Convert.ToInt32(row["idademax"]);
                float pesoMin = Convert.ToSingle(row["pesomin"]);
                float pesoMax = Convert.ToSingle(row["pesomax"]);
                if (idade >= idadeMin && idade <= idadeMax && peso >= pesoMin && peso <= pesoMax)
                {
                    idFaixaEtariaPeso = Convert.ToInt32(row["id_faixaetariapeso"]); 
                    break; 
                }
            }
            return idFaixaEtariaPeso; 
        }

        public DataTable TreinosIndicadosUsuario(int iduser)
        {
            string sql = $"SELECT t.id_treino,t.nometreino, t.descricao,f.id_faixaetariapeso,f.descricao AS descricao_faixa,o.id_objetivo,     o.descricao AS descricao_objetivo " +
                $"FROM treino t INNER JOIN " +
                $"treino_faixaetariapeso tf  ON t.id_treino = tf.id_treino " +
                $"INNER JOIN faixaetariapeso f ON f.id_faixaetariapeso = tf.id_faixaetariapeso " +
                $"INNER JOIN objetivo o ON o.id_objetivo = t.id_objetivo " +
                $"INNER JOIN usuario u ON u.id_faixaetariapeso = tf.id_faixaetariapeso AND u.id_objetivo = t.id_objetivo " +
                $"LEFT JOIN treino_usuario tu ON t.id_treino = tu.id_treino AND tu.id_usuario = u.id_usuario " +
                $"WHERE u.id_usuario = {iduser} AND tu.id_treino IS NULL;";                        
            DataTable dt = con.RetornaTabela(sql);
            return dt;
        }

        public DataTable BuscarTreinosUsuario(int iduser)
        {
            string query = $"select * from treino_usuario tu inner join treino t on tu.id_treino= t.id_treino where tu.id_usuario={iduser} ";
            DataTable dt = con.RetornaTabela(query);
            return dt;
        }

        public DataTable VerificarTreino(int iduser)
        {
            string query = $"";
            DataTable dt = con.RetornaTabela(query);
            return dt;

        }
    }

}