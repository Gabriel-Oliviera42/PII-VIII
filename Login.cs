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
        private Chave chave = new Chave();
        private int PD01 = 40, PD02 = 20;

        // Criando Text Box
        private TextBox Nome_TextBox = new TextBox();
        private TextBox Altura_TextBox = new TextBox();
        private TextBox Peso_TextBox = new TextBox();
        private TextBox Email_TextBox = new TextBox();


        private PanelArredonado FundoRoxo;

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

        private void AdicionaFormulario()
        {
            //Espaço para Formulário
            Panel EspForm = new Panel();
            EspForm.Dock = DockStyle.Left;
            EspForm.Width = 1060;
            EspForm.Padding = new Padding(140);

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
            Col01.Width = 400;
       

            
          //  Col01.Controls.Add(retornaCampo(new TextBox(), "Sexo:"));
            //Col01.Controls.Add(RetornaEspaco(16));
            Col01.Controls.Add(retornaCampo(Email_TextBox, "E-mail"));
            Col01.Controls.Add(RetornaEspaco(16));
            Col01.Controls.Add(retornaCampo(new TextBox(), "Data de Nascimento:")); //ajustar ainda
            Col01.Controls.Add(RetornaEspaco(16));
            Col01.Controls.Add(retornaCampo(Nome_TextBox, "Nome:"));



            //Segunda colunas de Perguntas
            Panel Col02 = new Panel();
            Col02.Dock = DockStyle.Left;
            Col02.Width = 400;



            Col02.Controls.Add(retornaCampo(new TextBox(), "Objetivo de Treino"));
            Col02.Controls.Add(RetornaEspaco(16));
            Col02.Controls.Add(retornaCampo(Altura_TextBox, "Altura:"));
            Col02.Controls.Add(RetornaEspaco(16));
            Col02.Controls.Add(retornaCampo(Peso_TextBox, "Peso:"));

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

            EspForm.Controls.Add(Conclui);
            EspForm.Controls.Add(RetornaEspaco(20));
            EspForm.Controls.Add(perg);
            EspForm.Controls.Add(RetornaEspaco(20));
            EspForm.Controls.Add(Tit);
        }

        private Panel retornaCampo(TextBox tx, string nome)
        {
            Panel Fundo = new Panel();
            Fundo.Dock = DockStyle.Top;
           // Fundo.Height = 120;
            

            PanelArredonado fundoTxt = new  PanelArredonado();
            fundoTxt.Dock = DockStyle.Top;
            fundoTxt.Height = 40;
            fundoTxt.BackColor = chave.CinzaClaro;
            fundoTxt.Radius = 20;
            fundoTxt.Padding = new Padding(10);

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


        private Panel RetornaEspaco(int tam)
        {
            Panel esp = new Panel();
            esp.Dock = DockStyle.Top;
            esp.Height = tam;
            return esp;

        }


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
            Texto01.Text = Texto01.Text.ToUpper() ;
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
        



    }
}
