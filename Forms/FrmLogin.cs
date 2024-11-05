using PII_VIII.Classes;
using PII_VIII.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace PII_VIII
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }
        Usuario usuario = new Usuario();
        private void FrmLogin_Load(object sender, EventArgs e)
        {
            cboUsuarios.ValueMember = "idusuario";
            cboUsuarios.DisplayMember = "nome";
            cboUsuarios.DataSource = usuario.BuscarTodos();
        }

        private void btnCadastro_Click_1(object sender, EventArgs e)
        {
            FrmCadastroUsuario frmCadastro = new FrmCadastroUsuario();
            frmCadastro.ShowDialog();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            Dashboard dashboard = new Dashboard();
            dashboard.ShowDialog();
        }

        private void cboUsuarios_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            TesteConexaoNeo4j teste = new TesteConexaoNeo4j();
            teste.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
           TesteHistorico historico = new TesteHistorico();
            historico.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            TesteObjetivo testeObjetivo = new TesteObjetivo();
            testeObjetivo.ShowDialog();
        }
    }
}
