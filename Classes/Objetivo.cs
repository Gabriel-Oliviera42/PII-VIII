using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PII_VIII.Classes
{
    internal class Objetivo
    {
        public int Id {  get; set; }
        public string Descricao { get; set; }

        public Conexao con = new Conexao();

        public DataTable BuscarTodosobjetivos()
        {
            DataTable dt = new DataTable();
            string query = "SELECT * FROM objetivo";
            dt = con.RetornaTabela(query);
            return dt;
        }
    }
}
