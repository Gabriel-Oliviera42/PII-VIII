using PII_VIII.Elementos_Visuais;
using PII_VIII.ElementosVisuais;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
namespace PII_VIII.ElementosVisuais
{
    internal class Historico_Form : Form
    {
        Menu_Principal menu = new Menu_Principal();
        Chave chave = new Chave();
        private TextBox Pesquisa = new TextBox();
        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // Home
            // 
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Name = "Home";
            this.Padding = new System.Windows.Forms.Padding(40);
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);
            this.Text = "Histórico";
        }
        public Historico_Form()
        {
            InitializeComponent();
            AddBarraUsuario();
            AdicionarElementos();
            AddMenu();
        }
        private void AddMenu()
        {
            menu.FormPai = this;
            this.Controls.Add(chave.RetornaEspacoLeft(20));
            this.Controls.Add(menu);
        }
        private void AddBarraUsuario()
        {
            Barra_Usuario barra_usuario = new Barra_Usuario();
            barra_usuario.Dock = DockStyle.Right;
            this.Controls.Add(chave.RetornaEspacoLeft(20));
            this.Controls.Add(barra_usuario);
        }
        private void AdicionarElementos()
        {
            Panel EspInfos = new Panel
            {
                Dock = DockStyle.Left,
                Width = 1220
            };
            this.Controls.Add(EspInfos);
            Panel EspTopo = new Panel
            {
                Dock = DockStyle.Top,
                AutoSize = true
            };

            Label h1 = new Label
            {
                Dock = DockStyle.Top,
                AutoSize = true,
                ForeColor = chave.RoxoEscuro,
                Font = chave.H1_Font,
                Text = "Histórico"
            };

            Panel EspImput = new Panel
            {
                Height = 55,
                Dock = DockStyle.Top
            };
            BotaoArredondado PesquisaBotao = new BotaoArredondado
            {
                Dock = DockStyle.Right,
                Radius = 10,
                BackColor = chave.RoxoClaro,
                Text = "Pesquisar",
                Font = chave.SubtiruloCard_Font,
                ForeColor = chave.Branco,
                FlatStyle = FlatStyle.Flat,
                Width = 280
            };
            PesquisaBotao.FlatAppearance.BorderSize = 0;
            Panel EspCard = new Panel
            {
                Dock = DockStyle.Top,
                AutoSize = true
            };
            EspCard.Controls.Add(chave.RetornaEspacoTop(5));
            EspCard.Controls.Add(new CardHistorico());
            EspCard.Controls.Add(chave.RetornaEspacoTop(5));
            EspCard.Controls.Add(new CardHistorico());
            EspCard.Controls.Add(chave.RetornaEspacoTop(5));
            EspCard.Controls.Add(new CardHistorico());
            EspInfos.Controls.Add(EspCard);
            EspInfos.Controls.Add(chave.RetornaEspacoTop(40));
            EspInfos.Controls.Add(EspTopo);
            EspImput.Controls.Add(PesquisaBotao);
            EspImput.Controls.Add(chave.RetornaEspacoLeft(20));
            EspImput.Controls.Add(retornaCampo(Pesquisa, "Insira o Registro", 900));
            EspTopo.Controls.Add(EspImput);
            EspTopo.Controls.Add(chave.RetornaEspacoTop(20));
            EspTopo.Controls.Add(h1);
        }
        private Panel retornaCampo(TextBox tx, string nome, int width)
        {

            PanelArredonado fundoTxt = new PanelArredonado
            {
                Dock = DockStyle.Left,
                BackColor = chave.CinzaClaro,
                Radius = 20,
                Padding = new Padding(18),
                Width = width
            };
            tx.Font = chave.TextoPequeno;
            tx.Dock = DockStyle.Fill;
            tx.BorderStyle = BorderStyle.None;
            tx.BackColor = chave.CinzaClaro;
            tx.ForeColor = chave.RoxoEscuro;
            tx.Text = nome;
            fundoTxt.Controls.Add(tx);

            return fundoTxt;
        }
    }
}

