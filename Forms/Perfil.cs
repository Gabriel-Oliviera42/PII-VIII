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
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace PII_VIII.Forms
{
    internal class Perfil:Form
    {
        Menu_Principal menu = new Menu_Principal();
        Chave chave = new Chave();

        private Label NomeLabel;
        private Label EmailLabel;
        private Label dataNascLabel;
        private Label IMC;
        private Label Classificacao;
        private Label Altura;
        private Label Peso;
        private Label Objetivo;

        private void InitializeComponent()
        {
            this.SuspendLayout();
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Name = "Home";
            this.Padding = new System.Windows.Forms.Padding(40);
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);
            this.Text = "Perfil";

        }

        public Perfil()
        {
            InitializeComponent();
            AddBarraUsuario();
            AdicionaElementos();
            AddMenu();

            if (Program.user.IdUsuario != 0)
            {
                atualizadados();
            }
        }

        private void atualizadados()
        {
            try
            {
                NomeLabel.Text = Program.user.Nome;
                EmailLabel.Text = Program.user.Email;
                dataNascLabel.Text = "Data de Nascimento: " + Program.user.DataNascimento.ToString("dd/MM/yyyy");
                Altura.Text = $"Altura: {Program.user.Altura:0.00} m";
                Peso.Text = $"Peso: {Program.user.Peso:0.00} kg";

                float imc = Program.user.ImcUser(Program.user.IdUsuario);
                IMC.Text = $"IMC: {imc:0.00}";

                string classificacao = Program.user.ClassificarIMC(imc);
                Classificacao.Text = $"Classificacao: {classificacao}";

                Objetivo.Text = $"Objetivo atual: {Program.user.BuscarDescricaoObjetivo(Program.user.IdObjetivo)}"; 
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao atualizar os dados do usuário: {ex.Message}");
            }
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
            this.Controls.Add(barra_usuario);
        }

        private void AdicionaElementos()
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
                Height = 140
            };

            PanelArredonado IconePerfil = new PanelArredonado
            {
                Dock = DockStyle.Left,
                Radius = 40,
                Width = 140,
                BackColor = chave.RoxoClaro,
                BackgroundImage = Properties.Resources.IconePerfil,
                BackgroundImageLayout = ImageLayout.Stretch
            };

            Panel EspTextos = new Panel
            {
                Width = 1050,
                Dock = DockStyle.Left,
                Padding = new Padding(20, 30, 0, 30)
            };

            NomeLabel = new Label
            {
                Text = "Nome do Usuário",
                Dock = DockStyle.Top,
                Font = chave.H3_Font,
                ForeColor = chave.RoxoEscuro,
                AutoSize = true
            };

            EmailLabel = new Label
            {
                Text = "user@email.com",
                Dock = DockStyle.Top,
                Font = chave.Sub_H3_Font,
                ForeColor = chave.RoxoCinza,
                AutoSize = true
            };

            EspTextos.Controls.Add(EmailLabel);
            EspTextos.Controls.Add(NomeLabel);

            EspTopo.Controls.Add(EspTextos);    
            EspTopo.Controls.Add(IconePerfil);


            PanelArredonado EspInfoPessoais = new PanelArredonado
            {
                Dock = DockStyle.Top,
                Radius = 40,
                AutoSize = true,
                BackColor = chave.CinzaClaro,
                Padding = new Padding(40)
            };

            Label tituloInfoPessoaisLabel = new Label
            {
                Text = "Informações Pessoais:",
                Dock = DockStyle.Top,
                Font = chave.tituloCard_Font,
                ForeColor = chave.RoxoClaro,
                AutoSize = true,
                Padding = new Padding(0, 0, 0, 5)
            };


            dataNascLabel = retornaLabel("Data de Nascimento: __/__/____");

            EspInfoPessoais.Controls.Add(dataNascLabel);
            EspInfoPessoais.Controls.Add(tituloInfoPessoaisLabel);


            PanelArredonado EspInfosComposicao = new PanelArredonado()
            {
                Dock = DockStyle.Top,
                Radius = 40,
                AutoSize = true,
                BackColor = chave.CinzaClaro,
                Padding = new Padding(40)
            };

            Label tituloInfosComposicao = new Label
            {
                Text = "Informações de Composição:",
                Dock = DockStyle.Top,
                Font = chave.tituloCard_Font,
                ForeColor = chave.RoxoClaro,
                AutoSize = true,
                Padding = new Padding(0, 0, 0, 5)
            };


            IMC = retornaLabel("IMC: __,__");
            Classificacao = retornaLabel("Classificacao: ____");
            Altura = retornaLabel("Altura: __,__m");
            Peso= retornaLabel("Peso __,__kg");
            Objetivo= retornaLabel("Objetivo atual: ____");



            EspInfosComposicao.Controls.Add(Objetivo);
            EspInfosComposicao.Controls.Add(Peso);
            EspInfosComposicao.Controls.Add(Altura);
            EspInfosComposicao.Controls.Add(Classificacao);
            EspInfosComposicao.Controls.Add(IMC);
            EspInfosComposicao.Controls.Add(tituloInfosComposicao);

            PanelArredonado EspBotoes = new PanelArredonado()
            {
                Dock = DockStyle.Top,
                Height = 70
            };

            BotaoArredondado EditarPerfil = new BotaoArredondado
            {
                BackColor = chave.Magenta,
                ForeColor = chave.Branco,
                Radius = 20,
                Text = "Editar Perfil",
                Font = chave.Botao,
                FlatStyle = FlatStyle.Flat,
                TextAlign = System.Drawing.ContentAlignment.MiddleCenter,
                Width = 600,
                Dock = DockStyle.Left
            };

            BotaoArredondado ApagarPerfil = new BotaoArredondado
            {
                BackColor = chave.CinzaClaro,
                ForeColor = chave.Preto,
                Radius = 20,
                Text = "Excluir Conta",
                Font = chave.Botao,
                FlatStyle = FlatStyle.Flat,
                TextAlign = System.Drawing.ContentAlignment.MiddleCenter,
                Width = 600,
                Dock = DockStyle.Right
            };

            ApagarPerfil.FlatAppearance.BorderSize = 0;
            EditarPerfil.FlatAppearance.BorderSize = 0;

            EspBotoes.Controls.Add(ApagarPerfil);
            EspBotoes.Controls.Add(EditarPerfil);

            ApagarPerfil.Click += (s, e) => ApagarPerfilClick();
            EditarPerfil.Click += (s, e) => EditarPerfilClick();


            EspInfos.Controls.Add(EspBotoes);
            EspInfos.Controls.Add(chave.RetornaEspacoTop(20));
            EspInfos.Controls.Add(EspInfosComposicao);
            EspInfos.Controls.Add(chave.RetornaEspacoTop(20));
            EspInfos.Controls.Add(EspInfoPessoais);
            EspInfos.Controls.Add(chave.RetornaEspacoTop(40));
            EspInfos.Controls.Add(EspTopo); 
        }

        private void EditarPerfilClick()
        {
            Card_Modal_Editar_Perfil aux = new Card_Modal_Editar_Perfil
            {
                OnCloseCallback = AtualizarFormularioPerfil
            };

        }
        private void AtualizarFormularioPerfil()
        {
            // Localiza a barra de usuário existente no formulário
            var barraExistente = this.Controls.OfType<Barra_Usuario>().FirstOrDefault();

            if (barraExistente != null)
            {
                // Remove a barra existente
                this.Controls.Remove(barraExistente);
                barraExistente.Dispose(); // Libera os recursos associados ao componente
            }
            AddBarraUsuario();
            atualizadados();
        }


        private void ApagarPerfilClick()
        {
            // Aparece uma mensagem perguntando se o usuário tem certeza que quer apagar a conta
            DialogResult result = MessageBox.Show("Você tem certeza que deseja apagar sua conta? Essa ação não pode ser desfeita.",
                                                 "Confirmar Exclusão", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            // Se sim, o usuário confirmou a exclusão
            if (result == DialogResult.Yes)
            {
                try
                {
                    Usuario usuario = new Usuario();
                    usuario.Deletar(Program.user.IdUsuario);  // Deleta o usuário no banco de dados

                    // Apaga as informações da sessão atual do usuário
                    Program.user = null;

                    // Inicia o formulário de login em uma thread separada
                    Thread init = new Thread(() =>
                    {
                        Login aux = new Login();
                        aux.ShowDialog();  // Exibe o formulário de login de forma modal
                    });
                    init.Start();

                    // Fecha o formulário de perfil após iniciar a thread para o login
                    this.Close();

                }
                catch (Exception ex)
                {
                    // Caso haja erro ao excluir a conta
                    MessageBox.Show($"Erro ao excluir a conta: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private Label retornaLabel(string tx)
        {
            Label lbl = new Label
            {
                Text = tx,
                Dock = DockStyle.Top,
                Font = chave.SubtiruloCard_Font,
                ForeColor = chave.RoxoCinza,
                Padding = new Padding(0, 0, 0, 5),
                AutoSize = true
            };
            return lbl;
        }
    }
}
