
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


namespace PII_VIII.Forms
{
    internal class Home : Form
    {
        Menu_Principal menu = new Menu_Principal();
        Chave chave = new Chave();
        private int userId;


        private FlowLayoutPanel slideSeusTreinos;
        private FlowLayoutPanel slideOutrosTreinos;
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
            this.Text = "Treinos";

        }

        public Home(int idUsuarioLogado)
        {

            this.userId = idUsuarioLogado;
            InitializeComponent();
            AddBarraUsuario();
            AddElementos();
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

            this.Controls.Add(chave.RetornaEspacoLeft(20));
            this.Controls.Add(barra_usuario);
        }


        private void AddElementos()
        {
            Panel espaco = new Panel();
            espaco.Width = 1220 + 10;
            espaco.Dock = DockStyle.Left;

            // Adicionando Banner
            PanelArredonado banner = new PanelArredonado();
            banner.Height = 340;
            banner.BackColor = chave.CinzaClaro;
            banner.Dock = DockStyle.Top;
            banner.Radius = 40;
            banner.BackgroundImage = Properties.Resources.Banner;
            banner.BackgroundImageLayout = ImageLayout.Stretch;            
                        

            // Criar painel principal para os treinos
            Panel TodosTreinos = new Panel();
            TodosTreinos.Dock = DockStyle.Top;
            TodosTreinos.AutoSize = true;

            // Adicionar cabeçalho "Seus Treinos"
            Label seusTreinos_Label = new Label();
            seusTreinos_Label.Text = "Seus Treinos:";
            seusTreinos_Label.ForeColor = chave.Preto;
            seusTreinos_Label.Font = chave.H3_Font;
            seusTreinos_Label.AutoSize = true;
            seusTreinos_Label.Dock = DockStyle.Top;

            slideSeusTreinos = new FlowLayoutPanel();
            slideSeusTreinos.Dock = DockStyle.Top;

            // Adicionar cabeçalho "Outros Treinos Para Você"
            Label outrosTreinos_Label = new Label();
            outrosTreinos_Label.Text = "Outros Treinos Para Você:";
            outrosTreinos_Label.ForeColor = chave.Preto;
            outrosTreinos_Label.Font = chave.H3_Font;
            outrosTreinos_Label.AutoSize = true;
            outrosTreinos_Label.Dock = DockStyle.Top;

            slideOutrosTreinos = new FlowLayoutPanel();
            slideOutrosTreinos.Dock = DockStyle.Top;

            TodosTreinos.Controls.Add(slideOutrosTreinos);
            TodosTreinos.Controls.Add(chave.RetornaEspacoTop(40));
            TodosTreinos.Controls.Add(outrosTreinos_Label);
            TodosTreinos.Controls.Add(chave.RetornaEspacoTop(40));
            TodosTreinos.Controls.Add(slideSeusTreinos);
            TodosTreinos.Controls.Add(chave.RetornaEspacoTop(40));
            TodosTreinos.Controls.Add(seusTreinos_Label);

            // Adicionar ao espaço principal
            espaco.AutoScroll = true;
            espaco.Controls.Add(TodosTreinos);
            espaco.Controls.Add(chave.RetornaEspacoTop(40));
            espaco.Controls.Add(banner);
            this.Controls.Add(espaco);

            AtualizaCards();
        }

        private void AtualizaCards()
        {

            slideSeusTreinos.Controls.Clear();
            slideOutrosTreinos.Controls.Clear();
            // Treinos do usuário
            DataTable treinos = new Usuario().BuscarTreinosUsuario(userId);
            if (treinos == null || treinos.Rows.Count == 0)
            {
                // Caso não haja treinos indicados
                Label semTreinos_Label = new Label
                {
                    Text = "Você ainda não tem treinos.",
                    ForeColor = chave.RoxoCinza,
                    Font = chave.Sub_H3_Font,
                    AutoSize = true,
                    Dock = DockStyle.Top,
                    Name = "lblnone"
                };
                slideSeusTreinos.Controls.Add(semTreinos_Label);
            }
            else
            {
                foreach (DataRow row in treinos.Rows)
                {
                    Treino treino = new Treino
                    {
                        NomeTreino = row["nometreino"].ToString(),
                        Descricao = row["descricao"].ToString(),
                        IdTreino = int.Parse(row["id_treino"].ToString())
                    };
                    treino.PreencherDados(treino.IdTreino);

                    Card card = new Card { treino = treino, TreinoUsuario = true };
                    card.Name = treino.IdTreino.ToString();

                    card.AddRemove.Click += (s, e) => RemoverTreinoParaUsuario(Program.user, treino);
                    slideSeusTreinos.Controls.Add(card);
                }
            }

            // Treinos indicados para o usuário
            DataTable indicados = new Usuario().TreinosIndicadosUsuario(userId);

            if (indicados == null || indicados.Rows.Count == 0)
            {
                // Caso não haja treinos indicados
                Label semTreinos_Label = new Label
                {
                    Text = "Você ainda não tem treinos.",
                    ForeColor = chave.RoxoCinza,
                    Font = chave.Sub_H3_Font,
                    AutoSize = true,
                    Dock = DockStyle.Top,
                    Name = "lblnone"
                };
                slideOutrosTreinos.Controls.Add(semTreinos_Label);
            }
            else
            {
                // Adicionar os cards dos treinos indicados
                foreach (DataRow row in indicados.Rows)
                {
                    Treino indicado = new Treino
                    {
                        NomeTreino = row["nometreino"].ToString(),
                        Descricao = row["descricao"].ToString(),
                        IdTreino = int.Parse(row["id_treino"].ToString())
                    };

                    indicado.PreencherDados(indicado.IdTreino);

                    Card card = new Card { treino = indicado, TreinoUsuario = false };
                    card.Name = indicado.IdTreino.ToString();
                    card.AddRemove.Click += (s, e) => AdicionarTreinoParaUsuario(Program.user, indicado);
                    slideOutrosTreinos.Controls.Add(card);
                }
            }

            // Ajustar altura dos slides e adicionar no painel principal
            slideSeusTreinos.Height = (int)Math.Ceiling(slideSeusTreinos.Controls.Count / 2.0) * new Card().Height;
            slideOutrosTreinos.Height = (int)Math.Ceiling(slideOutrosTreinos.Controls.Count / 2.0) * new Card().Height;

        }



        private void AdicionarTreinoParaUsuario(Usuario usuario, Treino treino)
        {
            // Verifica se o treino já existe no controle
            if (slideOutrosTreinos.Controls.ContainsKey(treino.IdTreino.ToString()))
            {
                Card card = (Card)slideOutrosTreinos.Controls[treino.IdTreino.ToString()];
                card.Name = treino.IdTreino.ToString();
                card.TreinoUsuario = true;

                // Atualiza o botão de remoção
                card.AddRemove.Click += (s, e) => RemoverTreinoParaUsuario(usuario, treino);

                // Remove mensagem de "nenhum treino" se presente
                if (slideSeusTreinos.Controls.ContainsKey("lblnone"))
                {
                    slideSeusTreinos.Controls.Remove(slideSeusTreinos.Controls["lblnone"]);
                }

                // Adiciona ao painel de treinos do usuário
                slideSeusTreinos.Controls.Add(card);

                // Adiciona o treino ao banco de dados
                AdicionarTreinoAoBanco(usuario.IdUsuario, treino.IdTreino);
            }
            else
            {
                // Caso o treino não exista nos outros treinos, cria um novo Card
                Card novoCard = new Card
                {
                    Name = treino.IdTreino.ToString(),
                    TreinoUsuario = true,
                };

                // Configura evento para remoção
                novoCard.AddRemove.Click += (s, e) => RemoverTreinoParaUsuario(usuario, treino);

                // Adiciona o novo Card ao painel
                slideSeusTreinos.Controls.Add(novoCard);              
            }
        }

        private void RemoverTreinoParaUsuario(Usuario usuario, Treino treino)
        {
            // Remove do painel
            if (slideSeusTreinos.Controls.ContainsKey(treino.IdTreino.ToString()))
            {
                slideSeusTreinos.Controls.RemoveByKey(treino.IdTreino.ToString());

                
                RemoverTreinoDoBanco(usuario.IdUsuario, treino.IdTreino);
                AtualizaCards();
            }
        }

        private void AdicionarTreinoAoBanco(int idUsuario, int idTreino)
        {
            try
            {
                Treino treino = new Treino();
                treino.AdicionarTreinoAoUsuario(idUsuario, idTreino);                
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao adicionar treino no banco: {ex.Message}");
            }
        }

        private void RemoverTreinoDoBanco(int idUsuario, int idTreino)
        {
            try
            {
                Treino treino = new Treino();
                treino.RemoverTreinoDoUsuario(idUsuario, idTreino);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao remover treino no banco: {ex.Message}");
            }
        }
private void AdicionarTreinoParaUsuario(Usuario usuario, Treino treino)
        {
            // Verifica se o treino já existe no controle
            if (slideOutrosTreinos.Controls.ContainsKey(treino.IdTreino.ToString()))
            {
                slideOutrosTreinos.Controls.Remove((Card)slideOutrosTreinos.Controls[treino.IdTreino.ToString()]);
                Card card = new Card
                {
                    treino = treino,    
                };
                //Card card = (Card)slideOutrosTreinos.Controls[treino.IdTreino.ToString()];
                card.Name = treino.IdTreino.ToString();
                card.TreinoUsuario = true;

                // Atualiza o botão de remoção
                card.AddRemove.Click += (s, e) => RemoverTreinoParaUsuario(usuario, treino);

                // Remove mensagem de "nenhum treino" se presente
                if (slideSeusTreinos.Controls.ContainsKey("lblnone"))
                {
                    slideSeusTreinos.Controls.Remove(slideSeusTreinos.Controls["lblnone"]);
                }

                // Adiciona ao painel de treinos do usuário
                slideSeusTreinos.Controls.Add(card);

                // Adiciona o treino ao banco de dados
                AdicionarTreinoAoBanco(usuario.IdUsuario, treino.IdTreino);
            }
            else
            {
                // Caso o treino não exista nos outros treinos, cria um novo Card
                Card novoCard = new Card
                {
                    Name = treino.IdTreino.ToString(),
                    TreinoUsuario = true,
                };

                // Configura evento para remoção
                novoCard.AddRemove.Click += (s, e) => RemoverTreinoParaUsuario(usuario, treino);

                // Adiciona o novo Card ao painel
                slideSeusTreinos.Controls.Add(novoCard);

                // Adiciona o treino ao banco de dados
                AdicionarTreinoAoBanco(usuario.IdUsuario, treino.IdTreino);
            }
        }

        private void RemoverTreinoParaUsuario(Usuario usuario, Treino treino)
        {
            //Treino treino = new Treino();
           
            if (slideSeusTreinos.Controls.ContainsKey(treino.IdTreino.ToString()))
            {
                slideSeusTreinos.Controls.Remove((Card)slideSeusTreinos.Controls[treino.IdTreino.ToString()]);


                Card c = new Card
                {
                    treino=treino
                };
                
                c.Name = treino.IdTreino.ToString();
                c.TreinoUsuario = false;
                c.AddRemove.Click += (s, e) => AdicionarTreinoParaUsuario(usuario, treino);
                if (slideOutrosTreinos.Controls.ContainsKey("lblnone"))
                {
                    slideOutrosTreinos.Controls.Remove(slideOutrosTreinos.Controls["lblnone"]);
                }
                slideOutrosTreinos.Controls.Add(c);
                RemoverTreinoDoBanco(usuario.IdUsuario, treino.IdTreino);
            }
            
        }

        private void AdicionarTreinoAoBanco(int idUsuario, int idTreino)
        {
            try
            {
                using (var repository = new TreinoRepository())
                {
                    repository.AdicionarTreinoAoUsuario(idUsuario, idTreino);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao adicionar treino no banco: {ex.Message}");
            }
        }

        private void RemoverTreinoDoBanco(int idUsuario, int idTreino)
        {
            try
            {
                using (var repository = new TreinoRepository())
                {
                    repository.RemoverTreinoDoUsuario(idUsuario, idTreino);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao remover treino no banco: {ex.Message}");
            }
        }


    }
}
