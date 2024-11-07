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
            string query = "USE GestaoSaude_II\nSELECT * FROM objetivo";
            dt = con.RetornaTabela(query);
            return dt;
        }
    }
}
