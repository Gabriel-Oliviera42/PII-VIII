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
        Panel TodosHistoricos = new Panel();
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
            this.BackColor = chave.Branco;
            this.Icon = Properties.Resources.iconeazul;
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
        protected void AdicionarElementos()
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
            PesquisaBotao.Click += (sender, e) => PesquisaBotao_Click(sender, e);

            // Criar painel principal para os todos os historicos            
            TodosHistoricos.Dock = DockStyle.Top;
            TodosHistoricos.Height = 760;
            TodosHistoricos.AutoScroll = true;


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
            
            DataTable antigos = new Historico().BuscarHistoricoAntigo(Program.user.IdUsuario);
            
            if (antigos.Rows.Count > 0)
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
        }
        private void PesquisaBotao_Click(object sender, EventArgs e)
        {          

            if(Pesquisa.Text.Length > 9 & !string.IsNullOrEmpty(Pesquisa.Text) & Pesquisa.Text != "Insira o Registro")
            {

                TodosHistoricos.Controls.Clear();
                Historico historico = new Historico();
                int dia = int.Parse(Pesquisa.Text.Substring(0, 2));
                int mes = int.Parse(Pesquisa.Text.Substring(3, 2));
                int ano = int.Parse(Pesquisa.Text.Substring(6, 4));
                if (ano > DateTime.Now.Year || ano < 1924)
                {
                    MessageBox.Show("Ano invalido");
                    return;
                }

                if (mes < 1 || mes > 12)
                {
                    MessageBox.Show("Mês invalido");
                    return;
                }
                if (dia < 1 || dia > 31)
                {
                    MessageBox.Show("Dia invalido");
                    return;
                }

                DataTable resultados = historico.BuscarHistorico(Program.user.IdUsuario, dia, mes, ano);
                if(resultados.Rows.Count > 0)
                {
                    PreencherCards(resultados);
                }
                else
                {
                    Label nada = new Label();
                    nada.Text = "Nenhum registro encontrado para a data informada";
                    nada.ForeColor = chave.Preto;
                    nada.Font = chave.H3_Font;
                    nada.AutoSize = true;
                    nada.Dock = DockStyle.Top;

                    TodosHistoricos.Controls.Add(nada); 


                }
                
            }
            else
            {
                MessageBox.Show("Adicione uma data completa. Por exemplo: 05/06/2024");
            }


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
            tx.ForeColor = chave.RoxoCinza;
            tx.Text = nome;
            tx = AjustaTextBox(tx);

            fundoTxt.Controls.Add(tx);
            return fundoTxt;
        }


        private TextBox AjustaTextBox(TextBox tx)
        {
            string texto = tx.Text;
            bool focus = false;

            //tx.Click += (s, e) =>
            //{
            //    if(tx.Text == texto)
            //    {
            //        tx.Text = "";
            //        focus = true;
            //        tx.ForeColor = chave.RoxoEscuro;
            //    }
            //    else if(tx.Text == "")
            //    {
            //        tx.Text = texto;
            //        focus = false;
            //    }
            //    else
            //    {
            //        tx.ForeColor = chave.RoxoCinza;
            //    }
            //};

            tx.KeyPress += (s, e) =>
            {
                if (tx.Text == texto && tx.ForeColor == chave.RoxoCinza)
                {
                    tx.Text = "";
                    focus = true;
                    tx.ForeColor = chave.RoxoEscuro;
                }
                else if (tx.Text == "" && tx.ForeColor == chave.RoxoEscuro)
                {
                    tx.Text = texto;
                    focus = false;
                    tx.ForeColor = chave.RoxoCinza;
                    this.ActiveControl = null;
                }
                else
                {
                    tx.ForeColor = chave.RoxoEscuro;
                }
                if (!char.IsControl(e.KeyChar))
                {
                    FormatDateTextBox(tx);
                }

            };
            return tx;


        }


        private void PreencherCards(DataTable resultados)
        {
            TodosHistoricos.Controls.Clear();
            foreach (DataRow linha in resultados.Rows)
            {
                Card_Historico card = new Card_Historico();
                Historico h = new Historico();
                h.PreencherDados(int.Parse(linha["id_historico"].ToString()));
                card.historico = h;
                TodosHistoricos.Controls.Add(chave.RetornaEspacoTop(5));
                TodosHistoricos.Controls.Add(card);
            }
        }

        private void FormatDateTextBox(TextBox textBox)
        {
            // Remove todos os caracteres não numéricos para facilitar o controle
            string text = new string(textBox.Text.Where(char.IsDigit).ToArray());

            if (text.Length >= 2)
            {
                text = text.Insert(2, "/");
            }
            if (text.Length >= 5)
            {
                text = text.Insert(5, "/");
            }

            // Limita o texto ao formato DD/MM/YYYY
            if (text.Length > 10)
            {
                text = text.Substring(0, 10);
            }

            // Limita o texto ao comprimento máximo de 9 dígitos (DDMMYYYY)
            if (text.Length > 9)
            {
                text = text.Substring(0, 8);
            }
            // Atualiza o texto do TextBox sem mover o cursor para o final
            int currentSelectionStart = textBox.SelectionStart;
            textBox.Text = text;
            textBox.SelectionStart = currentSelectionStart;
            textBox.SelectionStart = textBox.Text.Length;
            textBox.SelectionLength = 0;
        }


    }


}

