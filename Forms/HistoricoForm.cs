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

        private Panel slidehistoricoativo;
        private Panel slidehistoricoantigo;
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

            //adiciona o cabecalho
            Panel EspTopo = new Panel
            {
                Dock = DockStyle.Top,
                AutoSize = true
            };
            //titulo historico
            Label h1 = new Label
            {
                Dock = DockStyle.Top,
                AutoSize = true,
                ForeColor = chave.RoxoEscuro,
                Font = chave.H1_Font,
                Text = "Histórico"
            };
            //campo de pesquisa
            Panel EspImput = new Panel
            {
                Height = 55,
                Dock = DockStyle.Top
            };
            //botao de pesquisa
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


       

            // Criar painel principal para os todos os historicos
            Panel TodosHistoricos = new Panel();
            TodosHistoricos.Dock = DockStyle.Top;
            TodosHistoricos.Height = 760;
            //TodosHistoricos.AutoSize = true;


            Label planoatual = new Label();
            planoatual.Text = "Plano ativo:";
            planoatual.ForeColor = chave.Preto;
            planoatual.Font = chave.H3_Font;
            planoatual.AutoSize = true;
            planoatual.Dock = DockStyle.Top;            

            // Adicionar cabeçalho "planos anteriores"
            Label planos_anteriores = new Label();
            planos_anteriores.Text = "Planos anteriores:";
            planos_anteriores.ForeColor = chave.Preto;
            planos_anteriores.Font = chave.H3_Font;
            planos_anteriores.AutoSize = true;
            planos_anteriores.Dock = DockStyle.Top;

            slidehistoricoativo = new Panel();
            slidehistoricoativo.Dock = DockStyle.Top;
            slidehistoricoativo.AutoSize = true;

            slidehistoricoantigo = new Panel();
            slidehistoricoantigo.Dock = DockStyle.Top;
            slidehistoricoantigo.AutoSize = true;

            TodosHistoricos.Controls.Add(slidehistoricoantigo);
            TodosHistoricos.Controls.Add(chave.RetornaEspacoTop(40));
            TodosHistoricos.Controls.Add(planos_anteriores);

            TodosHistoricos.Controls.Add(chave.RetornaEspacoTop(40));

            TodosHistoricos.Controls.Add(slidehistoricoativo);
            TodosHistoricos.Controls.Add(chave.RetornaEspacoTop(40));
            TodosHistoricos.Controls.Add(planoatual);

            EspInfos.Controls.Add(TodosHistoricos);
            EspInfos.Controls.Add(chave.RetornaEspacoTop(40));
            EspInfos.Controls.Add(EspTopo);
            EspImput.Controls.Add(PesquisaBotao);
            EspImput.Controls.Add(chave.RetornaEspacoLeft(20));
            EspImput.Controls.Add(retornaCampo(Pesquisa, "Insira o Registro", 900));
            EspTopo.Controls.Add(EspImput);
            EspTopo.Controls.Add(chave.RetornaEspacoTop(20));
            EspTopo.Controls.Add(h1);


            TodosHistoricos.AutoScroll = true;

            AtualizaCards();
        }

        private void AtualizaCards()
        {
            // Limpar os controles existentes
            slidehistoricoativo.Controls.Clear();
            slidehistoricoantigo.Controls.Clear();

            // Buscar o histórico ativo
            DataTable ativo = new Historico().BuscarHistoricoAtivo(Program.user.IdUsuario);

            // Verifica se há histórico ativo
            if (ativo.Rows.Count > 0) // Corrigido: Verifica se há registros
            {
                foreach (DataRow row in ativo.Rows)
                {                    
                    Historico h = new Historico();
                    h.PreencherDados(int.Parse(row["id_historico"].ToString()));

                    // Cria o cartão e adiciona ao painel
                    Card_Historico card_Historico = new Card_Historico
                    {
                        historico = h,
                    };

                    slidehistoricoativo.Controls.Add(card_Historico);
                }
            }
            //slidehistoricoativo.Refresh();

            // Buscar o histórico ativo
            DataTable antigos = new Historico().BuscarHistoricoAntigo(Program.user.IdUsuario);
            
            if (antigos.Rows.Count > 0) // Corrigido: Verifica se há registros
            {
                foreach (DataRow row in antigos.Rows)
                {
                    Historico h = new Historico();
                    h.PreencherDados(int.Parse(row["id_historico"].ToString()));

                    Card_Historico card_Historico = new Card_Historico
                    {
                        historico = h,
                    };

                    slidehistoricoantigo.Controls.Add(card_Historico);
                    slidehistoricoantigo.Controls.Add(chave.RetornaEspacoTop(5));
                }
            }
            //slidehistoricoativo.Refresh();
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

