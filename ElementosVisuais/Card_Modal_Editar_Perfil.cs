using PII_VIII.Elementos_Visuais;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolTip;

namespace PII_VIII.ElementosVisuais
{
    internal class Card_Modal_Editar_Perfil:FormArredondado
    {
        Chave chave = new Chave();

        private Label titulo = new Label();
        private Label subtitulo = new Label();
        private Label tituloCard = new Label();
        private Label descCard = new Label();
        private Treino _treino = new Treino();
        private PanelArredonado AtiviEsp = new PanelArredonado();



        //TextBoxs
        private TextBox Nome_TextBox = new TextBox();
        private TextBox Altura_TextBox = new TextBox();
        private TextBox Peso_TextBox = new TextBox();
        private TextBox Email_TextBox = new TextBox();
        private TextBox Aniversario_TextBox = new TextBox();
        private TextBox Senha_TextBox = new TextBox();
        private selecao objetivo = new selecao();


        public Card_Modal_Editar_Perfil()
        {
            Width = 1000;
            Height = 800;
            MaximumSize = this.Size;
            AutoScroll = true;
            this.ShowInTaskbar = false;
            this.FormBorderStyle = FormBorderStyle.None;
            this.StartPosition = FormStartPosition.CenterParent;
            this.BackColor = chave.Branco;
            this.Radius = 40;
            this.Padding = new Padding(40);

            AddBotoes();
            this.Controls.Add(chave.RetornaEspacoTop(40));
            AddElementos();
            this.Controls.Add(chave.RetornaEspacoTop(40));
            AddInfos();
            this.Controls.Add(chave.RetornaEspacoTop(40));
            AddTopo();


            if (Program.user.IdUsuario != 0)
            {
                atualizadados();
            }

            AbreCard();


        }


        private void atualizadados()
        {
            try
            {
                Nome_TextBox.Text = Program.user.Nome;
                Email_TextBox.Text = Program.user.Email;
                Aniversario_TextBox.Text = Program.user.DataNascimento.ToString("dd/MM/yyyy");
                Altura_TextBox.Text = Program.user.Altura.ToString("0.00");
                Peso_TextBox.Text = Program.user.Peso.ToString("0.00");
                Senha_TextBox.Text = Program.user.Senha;
                objetivo.ItemSelecionado = Program.user.IdObjetivo;
            }
            catch { }
        }

        private void AddInfos()
        {

            Panel espTitulo = new Panel
            {
                Dock = DockStyle.Top,
                AutoSize = true
            };

            titulo = new Label
            {
                Dock = DockStyle.Top,
                AutoSize = true,
                Font = chave.H3_Font,
                ForeColor = chave.Azul,
                Text = "Altere as informações abaixo:"
            };

            subtitulo = new Label
            {
                Dock = DockStyle.Top,
                AutoSize = true,
                Font = chave.SubtiruloCard_Font,
                ForeColor = chave.RoxoCinza,
                Text = "Não deixe nenhum dos campos vazios."
            };

            espTitulo.Controls.Add(subtitulo);
            espTitulo.Controls.Add(chave.RetornaEspacoTop(5));
            espTitulo.Controls.Add(titulo);

            this.Controls.Add(espTitulo);
        }

        private void AddElementos()
        {
            //Espaço para perguntas
            Panel EspForm = new Panel
            {
                Dock = DockStyle.Top,
                Height = 380

            };
            this.Controls.Add(EspForm);


            //Primeira colunas de Perguntas
            Panel Col01 = new Panel
            {
                Dock = DockStyle.Left,
                Width = (EspForm.Width - 20) / 2
            };


            //Col01.Controls.Add(RetornaEspaco(16));
            Col01.Controls.Add(retornaCampo(Senha_TextBox, "Senha"));
            Col01.Controls.Add(chave.RetornaEspacoTop(16));
            Col01.Controls.Add(retornaCampo(Email_TextBox, "E-mail"));
            Col01.Controls.Add(chave.RetornaEspacoTop(16));
            Col01.Controls.Add(retornaCampo(Aniversario_TextBox, "Data de Nascimento:")); //ajustar ainda
            Col01.Controls.Add(chave.RetornaEspacoTop(16));
            Col01.Controls.Add(retornaCampo(Nome_TextBox, "Nome:"));



            //Segunda colunas de Perguntas
            Panel Col02 = new Panel
            {
                Dock = DockStyle.Right,
                Width = Col01.Width
            };



            Col02.Controls.Add(retornaCampo_Select("Objetivo de Treino"));
            Col02.Controls.Add(chave.RetornaEspacoTop(16));
            Col02.Controls.Add(retornaCampo(Altura_TextBox, "Altura(m):"));
            Col02.Controls.Add(chave.RetornaEspacoTop(16));
            Col02.Controls.Add(retornaCampo(Peso_TextBox, "Peso(kg):"));

            Aniversario_TextBox.KeyPress += (s, e) =>
            {
                if (!char.IsControl(e.KeyChar))
                {
                    FormatDateTextBox(Aniversario_TextBox);
                }

            };

            //Espaço entre as colunas
            Panel esp = new Panel
            {
                Dock = DockStyle.Left,
                Width = 20
            };

            //adicionando Colunas nos espaço
            EspForm.Controls.Add(Col02);
            EspForm.Controls.Add(Col01);
        }

        private void AddBotoes()
        {

            PanelArredonado EspBotoes = new PanelArredonado()
            {
                Dock = DockStyle.Top,
                Height = 70
            };

            BotaoArredondado Concluir = new BotaoArredondado
            {
                BackColor = chave.Magenta,
                ForeColor = chave.Branco,
                Radius = 20,
                Text = "Concluir",
                Font = chave.Botao,
                FlatStyle = FlatStyle.Flat,
                TextAlign = System.Drawing.ContentAlignment.MiddleCenter,
                Width = 444,
                Dock = DockStyle.Left
            };

            BotaoArredondado Cancelar = new BotaoArredondado
            {
                BackColor = chave.CinzaClaro,
                ForeColor = chave.Preto,
                Radius = 20,
                Text = "Cancelar",
                Font = chave.Botao,
                FlatStyle = FlatStyle.Flat,
                TextAlign = System.Drawing.ContentAlignment.MiddleCenter,
                Width = 444,
                Dock = DockStyle.Right
            };

            Cancelar.FlatAppearance.BorderSize = 0;
            Concluir.FlatAppearance.BorderSize = 0;

            Cancelar.Click += (s, e) => this.Close();
            Concluir.Click += (s, e) => ConcluirClick();

            EspBotoes.Controls.Add(Cancelar);
            EspBotoes.Controls.Add(Concluir);

            this.Controls.Add(EspBotoes);
        }
        private void AddTopo()
        {
            Panel barra_Topo = new Panel();
            barra_Topo.Dock = DockStyle.Top;
            barra_Topo.Height = 60;

            BotaoArredondado back = new BotaoArredondado
            {
                Radius = 20,
                Width = barra_Topo.Height,
                Dock = DockStyle.Left,
                FlatStyle = FlatStyle.Flat,
                Text = "<",
                TextAlign = ContentAlignment.MiddleCenter,
                Font = chave.Sub_H3_Font,
                ForeColor = chave.RoxoCinza,
                BackColor = chave.CinzaClaro
            };

            back.FlatAppearance.BorderSize = 0;
            back.Click += (senders, e) => this.Close();


            Label titTab = new Label
            {
                Text = "Edição de Perfil",
                Font = chave.tituloCard_Font,
               // TextAlign = ContentAlignment.MiddleCenter,
                ForeColor = chave.RoxoCinza,
                AutoSize = true,
                Padding = new Padding(16),
                Dock = DockStyle.Left

            };

            barra_Topo.Controls.Add(titTab);
            barra_Topo.Controls.Add(back);

            this.Controls.Add(barra_Topo);
        }

        public void AbreCard()
        {
            // Cria o formulário escurecido
            Form es = new Form
            {
                FormBorderStyle = FormBorderStyle.None,
                BackColor = Color.Black,
                Opacity = 0.5, // Opacidade de 50%
                WindowState = FormWindowState.Maximized,
                StartPosition = FormStartPosition.CenterScreen,
                ShowInTaskbar = false // Não exibe na barra de tarefas
            };
            es.Show();
            Thread.Sleep(50);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Show();
            this.FormClosing += (sender, e) => es.Close();
        }

        private Panel retornaCampo(TextBox tx, string nome)
        {
            Panel Fundo = new Panel
            {
                Dock = DockStyle.Top,
                AutoSize = true
            };
            // Fundo.Height = 120;


            PanelArredonado fundoTxt = new PanelArredonado
            {
                Dock = DockStyle.Top,
                Height = 55,
                BackColor = chave.CinzaClaro,
                Radius = 20,
                Padding = new Padding(18)
            };

            tx.Font = chave.TextoPequeno;
            tx.Dock = DockStyle.Fill;
            tx.BorderStyle = BorderStyle.None;
            tx.BackColor = chave.CinzaClaro;
            tx.ForeColor = chave.RoxoEscuro;
            fundoTxt.Controls.Add(tx);

            Label Texto = new Label
            {
                Dock = DockStyle.Top,
                AutoSize = true,
                Text = nome,
                Font = chave.TextoPequeno,
                ForeColor = chave.Preto
            };


            Fundo.Controls.Add(fundoTxt);
            Fundo.Controls.Add(chave.RetornaEspacoTop(8));
            Fundo.Controls.Add(Texto);

            return Fundo;
        }

        //retorna campo de seleção de objetivo
        private Panel retornaCampo_Select(string nome)
        {
            Panel Fundo = new Panel
            {
                Dock = DockStyle.Top,
                AutoSize = true
            };
            // Fundo.Height = 120;

            objetivo.Dock = DockStyle.Top;
            objetivo.Height = 55;
            objetivo.BackColor = chave.CinzaClaro;
            objetivo.Radius = 20;

            objetivo.DT = new Objetivo().BuscarTodosobjetivos();

            Label Texto = new Label
            {
                Dock = DockStyle.Top,
                AutoSize = true,
                Text = nome,
                Font = chave.TextoPequeno,
                ForeColor = chave.Preto
            };

            Fundo.Controls.Add(objetivo);
            Fundo.Controls.Add(chave.RetornaEspacoTop(8));
            Fundo.Controls.Add(Texto);


            return Fundo;
        }

        //Formata Text Box para receber apenas Data DD/MM/YYYY
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

        private void ConcluirClick()
        {
            try
            {
                Usuario user = new Usuario();
                user.Nome = Nome_TextBox.Text;
                user.Email = Email_TextBox.Text;
                int dia = int.Parse(Aniversario_TextBox.Text.Substring(0, 2));
                int mes = int.Parse(Aniversario_TextBox.Text.Substring(3, 2));
                int ano = int.Parse(Aniversario_TextBox.Text.Substring(6, 4));
                user.DataNascimento = new DateTime(ano, mes, dia);
                user.Altura = float.Parse(Altura_TextBox.Text);
                user.Peso = float.Parse(Peso_TextBox.Text);
                user.Senha = Senha_TextBox.Text;
                user.IdObjetivo = objetivo.ItemSelecionado;
                user.Atualizar(Program.user.IdUsuario);
                Program.user.PreencherDados(Program.user.IdUsuario);

                MessageBox.Show("Dados do Usuario Alterados com sucesso!");
                atualizadados();               

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("erro: não foi possivel alterar os dados do usuario" + ex.Message);
            }

            
        }
    }
}
