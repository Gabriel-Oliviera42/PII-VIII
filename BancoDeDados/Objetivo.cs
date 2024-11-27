using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PII_VIII
{
    internal class Objetivo
    {
        public int Id { get; set; }
        public string Descricao { get; set; }

        public Conexao con = new Conexao();

        public DataTable BuscarTodosobjetivos()
        {
            DataTable dt = new DataTable();
            string query = "SELECT * FROM objetivo";
            dt = con.RetornaTabela(query);
            return dt;
        }


        public void PreencherDados(int id_objetivo)
        {
            string query = $"select * from objetivo WHERE id_objetivo = {id_objetivo}";
            DataTable dt = con.RetornaTabela(query);

            if (dt.Rows.Count > 0)
            {
                DataRow dr = dt.Rows[0];

                Id = id_objetivo;
                Descricao = dr["descricao"].ToString();
            }
            else
            {
                throw new Exception("´Registro não encontrado.");
            }

        }
    }
}
