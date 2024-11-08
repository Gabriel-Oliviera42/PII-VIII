using PII_VIII.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace PII_VIII.Forms
{
    public partial class TesteObjetivo : Form
    {
        public TesteObjetivo()
        {
            InitializeComponent();
        }
         Objetivo objetivo = new Objetivo();
        private void button1_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = objetivo.BuscarTodosobjetivos();
            dataGridView1.DataSource = dt;
        }
    }
}
