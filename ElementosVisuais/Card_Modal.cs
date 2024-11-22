using PII_VIII.Elementos_Visuais;
using System;
using System.Data;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PII_VIII.ElementosVisuais
{
    internal class Card_Modal : FormArredondado
    {
        Chave chave = new Chave();

        private Label titulo = new Label();
        private Label subtitulo = new Label();
        private Label tituloCard = new Label();
        private Label descCard = new Label();
        private Treino _treino = new Treino();
        private Panel AtiviEsp = new Panel();

        public Treino treino
        {
            set
            {
                atualizaDados(value);
                _treino = value;
            }
        }

        private async void atualizaDados(Treino t)
        {
            try
            {
                // Atualiza título e subtítulo
                titulo.Text = t.NomeTreino;
                subtitulo.Text = t.Descricao;

                AtividadeFisica at = new AtividadeFisica();

                // Buscando dados de forma assíncrona
                DataTable dt = await at.BuscarAtividadeTreinoAsync(t.IdTreino);

                // Garantir que o formulário está ativo
                if (!this.IsDisposed && this.IsHandleCreated)
                {
                    // Atualizando os controles no thread da interface do usuário
                    this.Invoke((MethodInvoker)(() =>
                    {
                        // Limpar o painel antes de adicionar novos controles
                        AtiviEsp.Controls.Clear();

                        foreach (DataRow row in dt.Rows)
                        {
                            AtividadeFisica atv = new AtividadeFisica()
                            {
                                Nome = row["Atividade"].ToString()
                            };
                            atv.PreencherDados(int.Parse(row["IdAtividade"].ToString()));
                            AtiviEsp.Controls.Add(RetornaAtvFis(atv));
                            AtiviEsp.Controls.Add(chave.RetornaEspacoTop(10));
                        }

                        // Traz o formulário para frente após a atualização
                        this.BringToFront();
                    }));
                }
            }
            catch (Exception ex)
            {
                // Em caso de erro, exibe a mensagem
                MessageBox.Show($"Erro ao atualizar os dados: {ex.Message}");
            }
        }


        public Card_Modal(Treino t)
        {
            Width = 1000;
            Height = 800;
            MaximumSize = this.Size;
            AutoScroll = true;

            // Garante que o formulário ficará sempre no topo
            this.TopMost = true;

            this.ShowInTaskbar = false;
            this.FormBorderStyle = FormBorderStyle.None;
            this.StartPosition = FormStartPosition.CenterParent;
            this.BackColor = chave.Branco;
            this.Radius = 40;
            this.Padding = new Padding(40);

            this.Controls.Add(chave.RetornaEspacoTop(40));
            AddAtFisica();
            this.Controls.Add(chave.RetornaEspacoTop(40));
            AddInfos();
            this.Controls.Add(chave.RetornaEspacoTop(40));
            AddTopo();

            treino = t;
            AbreCard();
        }

        private void AddAtFisica()
        {
            AtiviEsp.AutoSize = true;
            AtiviEsp.Dock = DockStyle.Top;
            this.Controls.Add(AtiviEsp);

            AtividadeFisica at = new AtividadeFisica();
            at.Nome = "Teste de Nome";
            at.Descricao = "Teste de Descrição";
        }

        PanelArredonado RetornaAtvFis(AtividadeFisica at)
        {
            PanelArredonado fundo = new PanelArredonado();
            fundo.AutoSize = true;
            fundo.Dock = DockStyle.Top;

            fundo.BackColor = chave.CinzaClaro;
            fundo.Radius = 20;
            fundo.Padding = new Padding(20);

            Label tit = new Label();
            tit.AutoSize = true;
            tit.Dock = DockStyle.Top;
            tit.Font = chave.tituloCard_Font;
            tit.ForeColor = chave.Azul;

            Label desc = new Label();
            desc.AutoSize = true;
            desc.Dock = DockStyle.Top;
            desc.Font = chave.SubtiruloCard_Font;
            desc.ForeColor = chave.RoxoCinza;

            desc.Text = at.Descricao;
            tit.Text = at.Nome;

            fundo.Controls.Add(desc);
            fundo.Controls.Add(chave.RetornaEspacoTop(10));
            fundo.Controls.Add(tit);

            return fundo;
        }

        private void AddInfos()
        {
            Panel espIcone = new Panel();
            espIcone.Dock = DockStyle.Top;
            espIcone.Height = 60;

            PanelArredonado icone = new PanelArredonado();
            icone.BackColor = chave.Azul;
            icone.Dock = DockStyle.Left;
            icone.Width = espIcone.Height;
            icone.Radius = espIcone.Height;
            icone.BackgroundImage = Properties.Resources.Star;
            icone.BackgroundImageLayout = ImageLayout.Stretch;

            espIcone.Controls.Add(icone);

            Panel espTitulo = new Panel();
            espTitulo.Dock = DockStyle.Top;
            espTitulo.AutoSize = true;

            titulo.Dock = DockStyle.Top;
            titulo.AutoSize = true;
            titulo.Text = "Nome do Treino";
            titulo.Font = chave.H3_Font;
            titulo.ForeColor = chave.Azul;

            subtitulo.Dock = DockStyle.Top;
            subtitulo.AutoSize = true;
            subtitulo.Text = "Descrição do Treino";
            subtitulo.Font = chave.Sub_H3_Font;
            subtitulo.ForeColor = chave.Preto;

            espTitulo.Controls.Add(subtitulo);
            espTitulo.Controls.Add(chave.RetornaEspacoTop(5));
            espTitulo.Controls.Add(titulo);

            this.Controls.Add(espTitulo);
            this.Controls.Add(chave.RetornaEspacoTop(20));
            this.Controls.Add(espIcone);
        }

        private void AddTopo()
        {
            Panel barra_Topo = new Panel();
            barra_Topo.Dock = DockStyle.Top;
            barra_Topo.Height = 60;

            BotaoArredondado back = new BotaoArredondado();
            back.Radius = 20;
            back.Width = barra_Topo.Height;
            back.Dock = DockStyle.Left;
            back.FlatStyle = FlatStyle.Flat;
            back.FlatAppearance.BorderSize = 0;
            back.Click += (senders, e) => this.Close();
            back.Text = "<";
            back.TextAlign = ContentAlignment.MiddleCenter;
            back.Font = chave.Sub_H3_Font;
            back.ForeColor = chave.RoxoCinza;
            back.BackColor = chave.CinzaClaro;

            Label titTab = new Label();
            titTab.Text = "Janela de Treino";
            titTab.Font = chave.tituloCard_Font;
            titTab.TextAlign = ContentAlignment.MiddleCenter;
            titTab.ForeColor = chave.RoxoCinza;
            titTab.AutoSize = true;
            titTab.Padding = new Padding(16);
            titTab.Dock = DockStyle.Left;

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

            // Exibe o formulário escurecido primeiro
            es.Show();

            // Adiciona um atraso pequeno para garantir que o formulário escurecido seja exibido corretamente
            Thread.Sleep(50);  // Atraso de 50 milissegundos

            // Exibe o Card_Modal (popup)
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Show(); // Usando Show() ao invés de ShowDialog()

            // Fecha o formulário escurecido ao fechar o popup
            this.FormClosing += (sender, e) => es.Close();
        }




    }
}
