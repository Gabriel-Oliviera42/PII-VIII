using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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

        }

        private void cboUsuarios_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
