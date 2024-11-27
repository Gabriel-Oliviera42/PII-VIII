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
    using System.Data.Common;
    using System.Data.SqlClient;
    using System.Globalization;
    using System.Windows.Forms;

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
            try
            {
                // Excluir os registros relacionados na tabela historico
                string queryHistorico = $"DELETE FROM historico WHERE id_usuario = {id}";
                con.Executar(queryHistorico);

                // Excluir os registros relacionados na tabela treino
                string queryTreino = $"DELETE FROM treino_usuario WHERE id_usuario = {id}";
                con.Executar(queryTreino);

                // Agora, excluir o usuário
                string queryUsuario = $"DELETE FROM usuario WHERE id_usuario = {id}";
                con.Executar(queryUsuario);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao excluir a conta: " + ex.Message);
            }
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
                Program.user.Senha = row["senha"].ToString();
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

        public float ImcUser(int idUser)
        {
            // Corrigir a consulta SQL para buscar peso e altura
            string query = $"SELECT peso, altura FROM usuario WHERE id_usuario = {idUser}";

            try
            {
                // Executa a consulta e retorna os dados em um DataTable
                DataTable dt = con.RetornaTabela(query);

                if (dt.Rows.Count > 0)
                {
                    // Obter peso e altura
                    float peso = Convert.ToSingle(dt.Rows[0]["peso"]);
                    float altura = Convert.ToSingle(dt.Rows[0]["altura"]);

                    // Calcular o IMC
                    if (altura > 0)
                    {
                        float imc = peso / (altura * altura);
                        return imc;
                    }
                    else
                    {
                        throw new Exception("Altura não pode ser zero.");
                    }
                }
                else
                {
                    throw new Exception("Usuário não encontrado.");
                }
            }
            catch (Exception ex)
            {
                // Mostra a mensagem de erro
                MessageBox.Show($"Erro ao calcular IMC: {ex.Message}");
                return 0;
            }
        }

        public string ClassificarIMC(float imc)
        {
            if (imc < 18.5)
                return "Abaixo do peso";
            else if (imc >= 18.5 && imc < 24.9)
                return "Peso normal";
            else if (imc >= 25 && imc < 29.9)
                return "Sobrepeso";
            else if (imc >= 30 && imc < 34.9)
                return "Obesidade grau 1";
            else if (imc >= 35 && imc < 39.9)
                return "Obesidade grau 2";
            else
                return "Obesidade grau 3";
        }

        public string BuscarDescricaoObjetivo(int idObjetivo)
        {
            string query = $"SELECT descricao FROM objetivo WHERE id_objetivo = {idObjetivo}";
            try
            {
                // Executa a consulta e obtém o valor único
                object descricao = con.RetornaEscalar(query);
                return descricao != null ? descricao.ToString() : "Objetivo não encontrado";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao buscar objetivo: {ex.Message}");
                return "Erro ao buscar objetivo";
            }
        }

        
    }

}