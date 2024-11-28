using PII_VIII.Elementos_Visuais;
using System;
using System.Collections.Generic;
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

        
        private Label subtitulo = new Label();
        private Label subtitulo2 = new Label();
        private Label descCard = new Label();
        private Treino _treino = new Treino();
        private PanelArredonado AtiviEsp = new PanelArredonado();

        public Treino treino
        {
            set
            {
                atualizarDados(value);
                _treino = value;
            }
        }

        private Label titulo = new Label();
        private Label tituloCard = new Label();
        PanelArredonado icone;

        private void atualizaCores(Treino treino)
        {
            if (treino.IdObjetivo == 1)
            {

                icone.BackColor = chave.Azul;
                titulo.ForeColor = chave.Azul;
                tituloCard.ForeColor = chave.Azul;



            }
            else if (treino.IdObjetivo == 2)
            {

                icone.BackColor = chave.vermelho;
                titulo.ForeColor = chave.vermelho;
                tituloCard.ForeColor = chave.vermelho;
            }
            else if (treino.IdObjetivo == 3)
            {
  
                icone.BackColor = chave.Verde;
                titulo.ForeColor = chave.Verde;
                tituloCard.ForeColor = chave.Verde;

            }
        }

        private async void atualizarDados(Treino t)
        {
            atualizaCores(t); // Atualiza as cores do layout baseado no treino

            try
            {
                
                // Atualiza os títulos
                titulo.Text = t.NomeTreino;
                subtitulo.Text = t.Descricao;

                // Limpa os controles anteriores
                AtiviEsp.Controls.Clear();

                // Busca atividades relacionadas ao treino
                AtividadeFisica at = new AtividadeFisica();
                DataTable dt = await at.BuscarAtividadesAsync(t.IdTreino);

                // Verifica se o formulário ainda está ativo para evitar exceções
                if (!this.IsDisposed && this.IsHandleCreated)
                {
                    // Cria uma lista temporária de controles para evitar atualizações contínuas da UI
                    List<Control> controles = new List<Control>();

                    foreach (DataRow row in dt.Rows)
                    {
                        // Cria uma nova atividade baseada nos dados retornados
                        AtividadeFisica atv = new AtividadeFisica()
                        {
                            IdAtividade = int.Parse(row["IDSQL"].ToString()),
                            Nome = row["Nome"].ToString(),
                            Dificuldade = row["Dificuldade"].ToString(),
                            Descricao = row["Descricao"].ToString()
                        };

                        // Adiciona o painel e o espaçamento na lista de controles
                        controles.Add(await RetornaAtvFis(atv));
                        controles.Add(chave.RetornaEspacoTop(10));
                    }


                    // Adiciona os controles ao container de uma vez
                    
                    AtiviEsp.Controls.AddRange(controles.ToArray());
                    AtiviEsp.DoubleBufferedPanel();
                }

                // Atualiza o subtítulo para indicar sucesso
                subtitulo2.Text = "Atividades Físicas carregadas com sucesso";
                subtitulo2.ForeColor = titulo.ForeColor;
            }
            catch (Exception ex)
            {
                // Exibe mensagem de erro e registra para depuração
                MessageBox.Show($"Erro ao atualizar os dados: {ex.Message}");
            }
        }




        public Card_Modal(Treino t)
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

        private async Task<PanelArredonado> RetornaAtvFis(AtividadeFisica at)
        {
            PanelArredonado fundo = new PanelArredonado
            {
                AutoSize = true,
                Dock = DockStyle.Top,
                BackColor = chave.CinzaClaro,
                Radius = 20,
                Padding = new Padding(20)
            };

            Label tit = new Label
            {
                AutoSize = true,
                Dock = DockStyle.Top,
                Font = chave.tituloCard_Font,
                ForeColor = chave.Azul
            };

            Label desc = new Label
            {
                AutoSize = false,
                Width = 1000,
                Height = 120,
                
                Dock = DockStyle.Top,
                Font = chave.SubtiruloCard_Font,
                ForeColor = chave.RoxoCinza
            };

            if(_treino.IdObjetivo == 1)
            {
                tit.ForeColor = chave.Azul;
            }
            else if(_treino.IdObjetivo == 2)
            {
                tit.ForeColor = chave.vermelho;
            }
            else if(_treino.IdObjetivo == 3)
            {
                tit.ForeColor = chave.Verde;
            }

            PanelArredonado EspRegioes = new PanelArredonado
            {
                Radius = 20,
                Dock = DockStyle.Top,
                Height = 20
            };


            try
            {
                DataTable regioes = await at.BuscarRegioesAtividadesAsync(at.IdAtividade);

                foreach (DataRow row in regioes.Rows)
                {
                    PanelArredonado regFundo = new PanelArredonado
                    {
                        
                        Radius = 20,
                        Width = 70,
                        BackColor = tit.ForeColor,
                        Dock = DockStyle.Left,
                    };
                    Label regTit = new Label
                    {
                        Text = row[0].ToString(),
                        Font = chave.Textoicone,
                        ForeColor = chave.Branco,
                        Dock = DockStyle.Fill,
                        TextAlign = ContentAlignment.MiddleCenter
                    };
                    regFundo.Controls.Add( regTit );
                    EspRegioes.Controls.Add(chave.RetornaEspacoLeft(10));
                    EspRegioes.Controls.Add( regFundo );

                    EspRegioes.DoubleBufferedPanel();
                    fundo.DoubleBufferedPanel();
                    regFundo.DoubleBufferedPanel();
                    regFundo.Radius = 20;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro: {ex.Message}");
            }





            desc.Text = at.Descricao;
            tit.Text = at.Nome;

            fundo.Controls.Add(desc);
            fundo.Controls.Add(chave.RetornaEspacoTop(10));
            fundo.Controls.Add(EspRegioes);
            fundo.Controls.Add(chave.RetornaEspacoTop(10));
            fundo.Controls.Add(tit);
            

            return fundo;
        }

        private void AddInfos()
        {
            Panel espIcone = new Panel();
            espIcone.Dock = DockStyle.Top;
            espIcone.Height = 60;

            icone = new PanelArredonado();
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

            subtitulo2.Dock = DockStyle.Top;
            subtitulo2.AutoSize = true;
            subtitulo2.Text = "Carregando Atividades Físicas...";
            subtitulo2.Font = chave.SubtiruloCard_Font;
            subtitulo2.ForeColor = chave.RoxoCinza;


            espTitulo.Controls.Add(subtitulo2);
            espTitulo.Controls.Add(chave.RetornaEspacoTop(5));
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
            es.Show();
            Thread.Sleep(50);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Show();
            this.FormClosing += (sender, e) => es.Close();
        }




    }
}
