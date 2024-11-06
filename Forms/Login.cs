using PII_VIII.Elementos_Visuais;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

using System.Threading.Tasks;
using System.Windows.Forms;


namespace PII_VIII
{
    public partial class Login : Form
    {

        //OBS: Ainda tenho que criar a parte de LOGIN e levar para outra tela após Cadastro ou Login

        //CLASSES E VARIÁVEIS ↓
        private Chave chave = new Chave();
        private int PD01 = 40, PD02 = 20;

        //TextBoxs
        private TextBox Nome_TextBox = new TextBox();
        private TextBox Altura_TextBox = new TextBox();
        private TextBox Peso_TextBox = new TextBox();
        private TextBox Email_TextBox = new TextBox();
        private TextBox Aniversario_TextBox = new TextBox();
        private selecao objetivo = new selecao();

        //Panel da coluna roxa a direita da Tela
        private PanelArredonado FundoRoxo;


        //Configurações iniciais do FORM
        private void InitializeComponent()
        {
            
            this.SuspendLayout();
            this.WindowState = FormWindowState.Maximized;
            this.Name = "Login";
            this.ResumeLayout(false);
            this.Padding = new Padding(PD01);

        }


        public Login()
        {

            InitializeComponent();
            AdicionaBarraRoxa();
            AdicionaFormulario();
        }



        //FUNÇÕES PRINCIPAIS ↓

        //Adicionar Campos
        private void AdicionaFormulario()
        {
            //Espaço para Formulário
            Panel EspForm = new Panel();
            EspForm.Dock = DockStyle.Left;
            EspForm.Width = 1250;
            EspForm.Padding = new Padding(140, 220, 140, 220);

            this.Controls.Add(EspForm);


            //Título
            Label Tit = new Label();
            Tit.Text = "Dados do Usuário:";
            Tit.AutoSize = true;
            Tit.Dock = DockStyle.Top;
            Tit.Font = chave.H2_Font;
            Tit.ForeColor = chave.Preto;


            //Espaço para perguntas
            Panel perg = new Panel();
            perg.Dock = DockStyle.Top;
            perg .Height = 1100;

           

            //Primeira colunas de Perguntas
            Panel Col01 = new Panel();
            Col01.Dock = DockStyle.Left;
            Col01.Width = (EspForm.Width- (140*2)-20)/2;
       

            
          //  Col01.Controls.Add(retornaCampo(new TextBox(), "Sexo:"));
            //Col01.Controls.Add(RetornaEspaco(16));
            Col01.Controls.Add(retornaCampo(Email_TextBox, "E-mail"));
            Col01.Controls.Add(RetornaEspaco(16));
            Col01.Controls.Add(retornaCampo(Aniversario_TextBox, "Data de Nascimento:")); //ajustar ainda
            Col01.Controls.Add(RetornaEspaco(16));
            Col01.Controls.Add(retornaCampo(Nome_TextBox, "Nome:"));



            //Segunda colunas de Perguntas
            Panel Col02 = new Panel();
            Col02.Dock = DockStyle.Left;
            Col02.Width = Col01.Width;



            Col02.Controls.Add(retornaCampo_Select(new TextBox(), "Objetivo de Treino"));
            Col02.Controls.Add(RetornaEspaco(16));
            Col02.Controls.Add(retornaCampo(Altura_TextBox, "Altura(m):"));
            Col02.Controls.Add(RetornaEspaco(16));
            Col02.Controls.Add(retornaCampo(Peso_TextBox, "Peso(kg):"));

            FormataTextBox(Altura_TextBox);
            FormataTextBox(Peso_TextBox);
            FormataTextBox(Aniversario_TextBox);
            Aniversario_TextBox.KeyPress += (s, e) =>
            {
                if (!char.IsControl(e.KeyChar))
                {
                    FormatDateTextBox(Aniversario_TextBox);
                }
                
            };

            //Espaço entre as colunas
            Panel esp = new Panel();
            esp.Dock = DockStyle.Left;
            esp.Width = 20;

            //adicionando Colunas nos espaço
            perg.Controls.Add(Col02);
            perg.Controls.Add(esp);
            perg.Controls.Add(Col01);

            BotaoArredondado Conclui = new BotaoArredondado();
            Conclui.BackColor = chave.Magenta;
            Conclui.ForeColor = chave.Branco;
            Conclui.Radius = PD02;
            Conclui.Text = "Concluir";
            Conclui.Font = chave.Botao;
            Conclui.Height = 70;
            Conclui.Dock = DockStyle.Bottom;
            Conclui.FlatAppearance.BorderSize = 0;
            Conclui.FlatStyle = FlatStyle.Flat;

            Conclui.Click += (s, e) => Cadastra();



            EspForm.Controls.Add(Conclui);
            EspForm.Controls.Add(RetornaEspaco(20));
            EspForm.Controls.Add(perg);
            EspForm.Controls.Add(RetornaEspaco(20));
            EspForm.Controls.Add(Tit);
        }

        //Adiciona Barra Roxa do lado Direito da Tela
        private void AdicionaBarraRoxa()
        {
            FundoRoxo = new PanelArredonado();
            FundoRoxo.Dock = DockStyle.Right;
            FundoRoxo.BackColor = chave.RoxoClaro;
            FundoRoxo.Radius = PD01;
            FundoRoxo.Width = 400;
            FundoRoxo.Padding = new Padding(PD01);

            Panel icone = new Panel();
            icone.BackgroundImage = Properties.Resources.Icones_PNG;
            icone.BackgroundImageLayout = ImageLayout.Stretch;
            icone.Size = new Size(60, 60);
            FundoRoxo.Controls.Add(icone);
            icone.Location = new Point(PD01, PD01);

            Label Texto01 = new Label();
            Texto01.Text = "Gestão\nde Saúde";
            Texto01.Text = Texto01.Text.ToUpper();
            Texto01.Font = chave.H1_Font;
            Texto01.ForeColor = chave.Branco;
            Texto01.Dock = DockStyle.Top;
            Texto01.TextAlign = ContentAlignment.MiddleLeft;
            Texto01.AutoSize = true;

            Label Texto02 = new Label();
            Texto02.Text = "Treino para Iniciantes.";
            Texto02.Font = chave.Sub_H1_Font;
            Texto02.ForeColor = chave.Branco;
            Texto02.Dock = DockStyle.Bottom;
            Texto02.TextAlign = ContentAlignment.MiddleLeft;
            Texto02.AutoSize = true;
            Texto01.AutoSize = true;

            Panel container = new Panel();
            container.Controls.Add(Texto01);
            container.Controls.Add(Texto02);
            container.Dock = DockStyle.Fill;
            container.Padding = new Padding(0, 230, 0, 230);

            BotaoArredondado Sair = new BotaoArredondado();
            Sair.Text = "SAIR";
            Sair.Dock = DockStyle.Bottom;
            Sair.BackColor = chave.Magenta;
            Sair.ForeColor = chave.Branco;
            Sair.Height = 72;
            Sair.Radius = PD02;
            Sair.FlatStyle = FlatStyle.Flat;
            Sair.FlatAppearance.BorderSize = 0;
            Sair.Font = chave.Botao;

            Sair.Click += (s, e) =>
            {
                this.Close();
            };

            FundoRoxo.Controls.Add(Sair);
            FundoRoxo.Controls.Add(container);
            this.Controls.Add(FundoRoxo);

        }


        //Função que cadastra Usuário - (CHAMA APÓS CLICAR NO BOTÃO CONCLUIR)
        private void Cadastra()
        {
            if (Aniversario_TextBox.Text.Length > 9 && Nome_TextBox.Text.Length > 0 && Email_TextBox.Text.Length > 0 && Peso_TextBox.Text.Length > 0 && Altura_TextBox.Text.Length > 0)
            {
                Usuario us = new Usuario
                {
                    Nome = Nome_TextBox.Text,
                    Email = Email_TextBox.Text
                };

                // Validação e conversão para peso e altura
                if (float.TryParse(Peso_TextBox.Text, out float peso) && float.TryParse(Altura_TextBox.Text, out float altura))
                {
                    us.Peso = peso;
                    us.Altura = altura;
                }
                else
                {
                    MessageBox.Show("Peso ou Altura em formato inválido.");
                    return;
                }

                // Extração e verificação da data de nascimento
                try
                {
                    int dia = int.Parse(Aniversario_TextBox.Text.Substring(0, 2));
                    int mes = int.Parse(Aniversario_TextBox.Text.Substring(3, 2));
                    int ano = int.Parse(Aniversario_TextBox.Text.Substring(6, 4));

                    us.DataNascimento = new DateTime(ano, mes, dia);

                    // Cálculo da idade
                    int anoAtual = DateTime.Now.Year;
                    int idade = anoAtual - ano;

                    // População dos demais campos
                    us.IdObjetivo = objetivo.ItemSelecionado;
                    us.IdFaixa = us.VerificaFaixaEtariaPeso(us.Peso, idade);

                    // Inserção no banco de dados
                    us.Inserir();

                    MessageBox.Show("Usuário cadastrado com sucesso!");
                }
                catch (FormatException)
                {
                    MessageBox.Show("Data de nascimento em formato inválido. Use o formato DD/MM/AAAA.");
                }
            }
            else
            {
                MessageBox.Show("Algum dos campos está incompleto. Complete com as informações necessárias!");
            }

        }


        //FUNÇÕES SECUNDARIAS ↓

        // Retorna campor de texto
        private Panel retornaCampo(TextBox tx, string nome)
        {
            Panel Fundo = new Panel();
            Fundo.Dock = DockStyle.Top;
           // Fundo.Height = 120;
            

            PanelArredonado fundoTxt = new  PanelArredonado();
            fundoTxt.Dock = DockStyle.Top;
            fundoTxt.Height = 55;
            fundoTxt.BackColor = chave.CinzaClaro;
            fundoTxt.Radius = 20;
            fundoTxt.Padding = new Padding(18);

            tx.Font = chave.TextoPequeno;
            tx.Dock = DockStyle.Fill;
            tx.BorderStyle = BorderStyle.None;
            tx.BackColor = chave.CinzaClaro;
            tx.ForeColor = chave.RoxoEscuro;
            fundoTxt.Controls.Add(tx);

            Label Texto = new Label();
            Texto.Dock = DockStyle.Top;
            Texto.AutoSize = true;
            Texto.Text = nome;

            Texto.Dock = DockStyle.Top;
            Texto.Font = chave.TextoPequeno;
            Texto.ForeColor = chave.Preto;
            

            Fundo.Controls.Add(fundoTxt);
            Fundo.Controls.Add(RetornaEspaco(8));
            Fundo.Controls.Add(Texto);
            Fundo.AutoSize = true;


            return Fundo;
        }

        //retorna campo de seleção de objetivo
        private Panel retornaCampo_Select(TextBox tx, string nome)
        {
            Panel Fundo = new Panel();
            Fundo.Dock = DockStyle.Top;

            objetivo.Dock = DockStyle.Top;
            objetivo.Height = 55;
            objetivo.BackColor = chave.CinzaClaro;
            objetivo.Radius = 20;

            Objetivo ob = new Objetivo();
            objetivo.DT = ob.BuscarTodosobjetivos();

            Label Texto = new Label();
            Texto.Dock = DockStyle.Top;
            Texto.AutoSize = true;
            Texto.Text = nome;

            Texto.Dock = DockStyle.Top;
            Texto.Font = chave.TextoPequeno;
            Texto.ForeColor = chave.Preto;
            

            Fundo.Controls.Add(objetivo);
            Fundo.Controls.Add(RetornaEspaco(8));
            Fundo.Controls.Add(Texto);
            Fundo.AutoSize = true;


            return Fundo;
        }

        private Panel RetornaEspaco(int tam)
        {
            Panel esp = new Panel();
            esp.Dock = DockStyle.Top;
            esp.Height = tam;
            return esp;

        }
        //Formata Text Box para Receber apenas Números - AJUSTAR
        private void FormataTextBox(TextBox textBox)
        {
            textBox.KeyPress += (s, e) =>
            {
                //if (!char.IsDigit(e.KeyChar))
                //{
                //    e.Handled = true;
                //}
            };

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
        
       



    }
}
