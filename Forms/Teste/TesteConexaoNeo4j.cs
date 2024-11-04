using Neo4j.Driver;
using System;
using System.Data;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PII_VIII
{
    public partial class TesteConexaoNeo4j : Form
    {
        AtividadeFisica af = new AtividadeFisica();
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
            dt = af.BuscarTodos();       
            dataGridViewResultados.DataSource = dt;
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Treino treino = new Treino();
            dgvAtividades.DataSource = treino.BuscarTodos();
        }
    }
}
