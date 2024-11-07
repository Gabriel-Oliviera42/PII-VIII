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
    public partial class TesteHistorico : Form
    {
        public TesteHistorico()
        {
            InitializeComponent();
        }
        Historico historico = new Historico();
        private void button3_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            int id = int.Parse(textBox1.Text);
            dt = historico.BuscarPorUsuario(id);
            dgvHistorico.DataSource = dt;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            DateTime datain = dateTimePicker1.Value;
            DateTime dataout = dateTimePicker2.Value;
            dt = historico.BuscarPorIntervaloDatass(datain, dataout);
            dgvHistorico.DataSource=dt;
        }
    }
}
