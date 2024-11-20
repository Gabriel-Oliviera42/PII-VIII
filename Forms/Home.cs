



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
            //espaco.BackColor = chave.RoxoClaro;


            //Adicionando Banner
            PanelArredonado banner = new PanelArredonado();
            banner.Height = 340;
            banner.BackColor = chave.CinzaClaro;
            banner.Dock = DockStyle.Top;
            banner.Radius = 40;
            banner.BackgroundImage = Properties.Resources.Banner;
            banner.BackgroundImageLayout = ImageLayout.Stretch;


            //Adcicionando card
            Panel SeusTreinos = new Panel();
            SeusTreinos.Dock = DockStyle.Top;
            SeusTreinos.AutoSize = true;

            Label seusTreinos_Label = new Label();
            seusTreinos_Label.Text = "Treinos relacionado para você:";
            seusTreinos_Label.ForeColor = chave.Preto;
            seusTreinos_Label.Font = chave.H3_Font;
            seusTreinos_Label.AutoSize = true;
            seusTreinos_Label.Dock = DockStyle.Top;
            Flow Slide = new Flow();
            Slide.Dock = DockStyle.Top;


            //--Carrega os CARD's com os treinos relacinados ao usuario--//
          

            //Treinos do usuário 
            DataTable treinos = new Usuario().BuscarTreinosUsuario(userId);

            foreach (DataRow row in treinos.Rows)
            {
              
                Treino treino = new Treino();
                treino.NomeTreino = row["nometreino"].ToString();
                treino.Descricao = row["descricao"].ToString();
                treino.IdTreino = int.Parse(row["id_treino"].ToString());
                Card card = new Card();
                card.treino = treino;
                Slide.Controls.Add(card);
                
            }
            //Treino indicados para o usuário
            DataTable indicados = new Usuario().VerificarTreino(userId);
            foreach (DataRow row in indicados.Rows)
            {

                Treino indicado = new Treino();
                indicado.NomeTreino = row["nometreino"].ToString();
                indicado.Descricao = row["descricao"].ToString();
                indicado.IdTreino = int.Parse(row["id_treino"].ToString());
                Card card = new Card();
                card.treino = indicado;
                Slide.Controls.Add(card);

            }


            Slide.Height = ((Slide.Controls.Count / 2) + 1) * new Card().Height;
            SeusTreinos.Controls.Add(Slide);
            SeusTreinos.Controls.Add(chave.RetornaEspacoTop(10));
            SeusTreinos.Controls.Add(seusTreinos_Label);

            espaco.AutoScroll = true;
            espaco.Controls.Add(SeusTreinos);
            espaco.Controls.Add(chave.RetornaEspacoTop(40));
            espaco.Controls.Add(banner);


            this.Controls.Add(espaco);
        }

        private void Home_Load(object sender, EventArgs e)
        {

        }
    }
}
