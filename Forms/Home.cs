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
    internal class Home:Form
    {
        Menu_Principal menu = new Menu_Principal();
        Chave chave = new Chave();

        private void InitializeComponent()
        {

            this.SuspendLayout();
            this.WindowState = FormWindowState.Maximized;
            this.Name = "Home";
            this.ResumeLayout(false);
            this.Padding = new Padding(40);

        }

        public Home()
        {
            InitializeComponent();
            AddElementos();
            AddMenu();
        }

        private void AddMenu()
        {
            this.Controls.Add(chave.RetornaEspacoLeft(20));
            this.Controls.Add(menu);
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
            seusTreinos_Label.Text = "Seus Treinos:";
            seusTreinos_Label.ForeColor = chave.Preto;
            seusTreinos_Label.Font = chave.H3_Font;
            seusTreinos_Label.AutoSize = true;
            seusTreinos_Label.Dock = DockStyle.Top;



            Flow Slide = new Flow();
            Slide.Dock = DockStyle.Top;
            Slide.Height = 600;


            Card cardTeste = new Card();
            Slide.Controls.Add(new Card());

            SeusTreinos.Controls.Add(Slide);
            SeusTreinos.Controls.Add(chave.RetornaEspacoTop(10));
            SeusTreinos.Controls.Add(seusTreinos_Label);

            espaco.AutoScroll = true;
            espaco.Controls.Add(SeusTreinos);
            espaco.Controls.Add(chave.RetornaEspacoTop(40));
            espaco.Controls.Add(banner);


            this.Controls.Add(espaco);
        }
    }
}
