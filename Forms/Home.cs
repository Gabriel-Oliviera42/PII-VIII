



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
            this.Load += new System.EventHandler(this.Home_Load);
            this.ResumeLayout(false);

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

            FlowLayoutPanel slideSeusTreinos = new FlowLayoutPanel();
            slideSeusTreinos.Dock = DockStyle.Top;

            // Treinos do usuário
            DataTable treinos = new Usuario().BuscarTreinosUsuario(userId);
            if(treinos == null || treinos.Rows.Count == 0)
            {
                // Caso não haja treinos indicados
                Label semTreinos_Label = new Label
                {
                    Text = "Você ainda não tem treinos.",
                    ForeColor = chave.Preto,
                    Font = chave.H3_Font,
                    AutoSize = true,
                    Dock = DockStyle.Top
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

                    Card card = new Card { treino = treino };
                    slideSeusTreinos.Controls.Add(card);
                }
            }
            

            // Adicionar cabeçalho "Outros Treinos Para Você"
            Label outrosTreinos_Label = new Label();
            outrosTreinos_Label.Text = "Outros Treinos Para Você:";
            outrosTreinos_Label.ForeColor = chave.Preto;
            outrosTreinos_Label.Font = chave.H3_Font;
            outrosTreinos_Label.AutoSize = true;
            outrosTreinos_Label.Dock = DockStyle.Top;

            FlowLayoutPanel slideOutrosTreinos = new FlowLayoutPanel();
            slideOutrosTreinos.Dock = DockStyle.Top;

            // Treinos indicados para o usuário
            DataTable indicados = new Usuario().TreinosIndicadosUsuario(userId);

            if (indicados == null || indicados.Rows.Count == 0)
            {
                // Caso não haja treinos indicados
                Label semTreinos_Label = new Label
                {
                    Text = "Você ainda não tem treinos indicados.",
                    ForeColor = chave.Preto,
                    Font = chave.H3_Font,
                    AutoSize = true,
                    Dock = DockStyle.Top
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

                    Card card = new Card { treino = indicado };
                    slideOutrosTreinos.Controls.Add(card);
                }
            }

            // Ajustar altura dos slides e adicionar no painel principal
            slideSeusTreinos.Height = (int)Math.Ceiling(slideSeusTreinos.Controls.Count / 2.0) * new Card().Height;
            slideOutrosTreinos.Height = (int)Math.Ceiling(slideOutrosTreinos.Controls.Count / 2.0) * new Card().Height;


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
        }


        private void Home_Load(object sender, EventArgs e)
        {

        }
    }
}
