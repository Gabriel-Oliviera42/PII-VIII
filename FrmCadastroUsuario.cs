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
    public partial class FrmCadastroUsuario : Form
    {
        public FrmCadastroUsuario()
        {
            InitializeComponent();
        }

        Conexao conexao = new Conexao();
        Usuario usuario = new Usuario();
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            DateTime dataNascimento = dateTimePickerDN.Value;
            int idade = DateTime.Now.Year - dataNascimento.Year;

            if (dataNascimento > DateTime.Now.AddYears(-idade))
            {
                idade--;
            }
            float peso = float.Parse(textBoxPeso.Text);
            usuario.IdFaixa = usuario.VerificaFaixaEtariaPeso(peso, idade);

            usuario.Nome= textBoxNome.Text;
            usuario.Email= textBoxEmail.Text;
            usuario.Telefone= textBoxTelefone.Text;
            usuario.DataNascimento = dateTimePickerDN.Value;
            usuario.Sexo = comboBoxSexo.Text;
            usuario.Altura = float.Parse(textBoxAltura.Text);
            usuario.Peso= float.Parse(textBoxPeso.Text);
            usuario.Inserir();

            MessageBox.Show("Usuario inserido com sucesso");
            this.Close();
        }

        private void FrmCadastroUsuario_Load(object sender, EventArgs e)
        {            
            comboBoxObjetivo.ValueMember = "idobjetivo";
            comboBoxObjetivo.DisplayMember = "descricao";
            comboBoxObjetivo.DataSource = conexao.RetornaTabela("SELECT * FROM objetivo");
        }

        private void comboBoxObjetivo_SelectedIndexChanged(object sender, EventArgs e)
        {
            usuario.IdObjetivo = comboBoxObjetivo.SelectedIndex;
        }

       
    }
}
