using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PII_VIII
{
    using System.Data;

    public class Usuario
    {        
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Sexo { get; set; }
        public float Altura { get; set; }
        public float Peso { get; set; }
        public int IdObjetivo { get; set; }
        public int IdFaixa { get; set; }

        private Conexao con = new Conexao();

        public void Inserir()
        {
            string query = $"INSERT INTO usuario (idobjetivo, idfaixaetariapeso, nome, email, telefone, datanascimento, sexo, altura, peso) " +
                           $"VALUES ('{IdObjetivo}', '{IdFaixa}' , '{Nome}', '{Email}', '{Telefone}', '{DataNascimento.ToString("yyyy-MM-dd")}', '{Sexo}', '{Altura}', '{Peso}')";
            con.Executar(query);            
        }

        public void Atualizar(int id)
        {
            string query = $"UPDATE usuario SET nome = '{Nome}', email = '{Email}', telefone = '{Telefone}', datanascimento = '{DataNascimento.ToString("yyyy-MM-dd")}', sexo = '{Sexo}', altura = {Altura}, peso = {Peso} WHERE id = {id}";
            con.Executar(query);            
        }

        public void Deletar(int id)
        {
            string query = $"DELETE FROM usuario WHERE id = {id}";           
            con.Executar(query);            
        }

        public DataTable BuscarPorId(int id)
        {
            DataTable dt = new DataTable();
            string query = $"SELECT * FROM usuario WHERE idusuario = {id}";
            dt = con.RetornaTabela(query); 
            return dt;
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
                    idFaixaEtariaPeso = Convert.ToInt32(row["idfaixaetariapeso"]); 
                    break; 
                }
            }
            return idFaixaEtariaPeso; 
        }



    }

}
