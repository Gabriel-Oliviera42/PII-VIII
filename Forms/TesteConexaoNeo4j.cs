using Neo4j.Driver;
using PII_VIII.Classes;
using System;
using System.Data;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PII_VIII
{
    public partial class TesteConexaoNeo4j : Form
    {
        AtividadeFisica af = new AtividadeFisica();
        Regiao re = new Regiao();
        public TesteConexaoNeo4j()
        {
            InitializeComponent();
        }
        ConexaoNeo4J conexaoNeo4J = new ConexaoNeo4J();
        private async void button1_Click(object sender, EventArgs e)
        {
            conexaoNeo4J.Conectar();
            bool conexaoBemSucedida = await conexaoNeo4J.TestarConexaoAsync();

            if (conexaoBemSucedida)
            {
                MessageBox.Show("Conexão bem-sucedida com o Neo4j!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Falha ao conectar com o Neo4j.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            
            DataTable dt = new DataTable();
            dt = await af.BuscarTodosAsync();       
            dataGridViewResultados.DataSource = dt;            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Treino treino = new Treino();
            dgvAtividades.DataSource = treino.BuscarTodos();
        }

        private async void TesteConexaoNeo4j_Load(object sender, EventArgs e)
        {            
            comboBoxAtividades.ValueMember = "id";
            comboBoxAtividades.DisplayMember = "Atividade";
            comboBoxAtividades.DataSource = await af.BuscarTodosAsync();
        }

        private async void btnbuscarregioes_Click(object sender, EventArgs e)
        {            
            int atividade = comboBoxAtividades.SelectedIndex; 
            dataGridViewregiao.DataSource = await re.BuscarRegioesAtvidade(atividade);
        }
    }
}
