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

namespace PII_VIII.ElementosVisuais
{
    internal class Barra_Usuario : PanelArredonado
    {
        Chave chave = new Chave();
        Panel infos = new Panel();
        Label Nome = new Label();
        Label Email = new Label();
        public Barra_Usuario()
        {
            AjustaPanel();
            CriaEspParaInfos();

            AddInfos();
            AddTopo();


            if (Program.user.IdUsuario != 0)
            {
                atualizadados();
            }

        }

        private void atualizadados()
        {
            Nome.Text = Program.user.Nome;
            Email.Text = Program.user.Email;
        }


        private void CriaEspParaInfos()
        {
            infos.Dock = DockStyle.Top;
            infos.AutoSize = true;
            infos.Padding = new Padding(40);
            this.Controls.Add(infos);


        }

        private void AjustaPanel()
        {
            this.Dock = DockStyle.Left;
            this.BackColor = chave.RoxoClaro;
            this.Width = 450;
            this.Radius = 40;
        }

        private void AddInfos()
        {

            Panel p01 = new Panel();
            p01.Dock = DockStyle.Top;
            p01.AutoSize = true;


            Label lbl = new Label();
            lbl.Text = "SEJA BEM VINDO(A)";
            lbl.Dock = DockStyle.Top;
            lbl.AutoSize = true;
            lbl.Font = chave.SubtiruloCard_Font;
            lbl.ForeColor = chave.SubRoxo;


            Nome.Dock = DockStyle.Top;
            Nome.Text = "Usuário";
            Nome.ForeColor = chave.Branco;
            Nome.Font = chave.H3_Font;
            Nome.AutoSize = true;

            Email.Dock = DockStyle.Top;
            Email.Text = "usuaio@email.com";
            Email.ForeColor = chave.SubRoxo;
            Email.Font = chave.SubtiruloCard_Font;
            Email.AutoSize = true;

            p01.Controls.Add(Email);
            p01.Controls.Add(Nome);
            p01.Controls.Add(lbl);

            infos.Controls.Add(p01);

        }

        private void AddTopo()
        {
            PanelArredonado topo = new PanelArredonado();
            topo.Dock = DockStyle.Top;
            topo.Height = 120;
            topo.BackColor = chave.RoxoEscuro;
            topo.Radius = 38;
            topo.Padding = new Padding(36);

            this.Controls.Add(topo);
            Panel icone = new Panel();
            icone.Dock = DockStyle.Left;
            icone.Width = topo.Height - 36 * 2;
            icone.BackgroundImage = Properties.Resources.Icones_PNG;
            icone.BackgroundImageLayout = ImageLayout.Stretch;

            Panel esp = new Panel();

            esp.Dock = DockStyle.Left;
            esp.Width = this.Width - icone.Width - 40 * 2;
            //esp.AutoSize = true;

            Label top01 = new Label();
            top01.Text = "GESTÃO DE SAÚDE";

            top01.ForeColor = chave.Branco;
            top01.Font = chave.tituloCard_Font;
            top01.Dock = DockStyle.Top;
            //top01.Height = 20;
            top01.AutoSize = true;


            Label top02 = new Label();
            top02.Text = "Treinos para iniciantes";

            top02.ForeColor = chave.Branco;
            top02.Font = chave.TextoPequeno;
            top02.Dock = DockStyle.Top;
            //top02.Height = 20;
            top02.AutoSize = true;

            esp.Controls.Add(top02);

            esp.Controls.Add(top01);

            topo.Controls.Add(esp);
            topo.Controls.Add(chave.RetornaEspacoLeft(10));
            topo.Controls.Add(icone);



        }
    }
}
