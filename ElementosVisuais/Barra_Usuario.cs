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
        Label DataDeNascimento;
        Label Altura;
        Label Peso;
        Label Objetivo;
        Label IMC;
        Label Classificação;
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
            DataDeNascimento.Text = "Data de Nascimento: " + Program.user.DataNascimento.ToString("dd/MM/yyyy");
            Altura.Text = Program.user.Altura.ToString("0.00 kg");
            Peso.Text = Program.user.Peso.ToString("0.00 m");

            //Adicionar texto de Objetivo, IMC, e Classificação
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

            Panel p01 = new Panel
            {
                Dock = DockStyle.Top,
                AutoSize = true
            };

            Label lbl = new Label
            {
                Text = "SEJA BEM VINDO(A)",
                Dock = DockStyle.Top,
                AutoSize = true,
                Font = chave.SubtiruloCard_Font,
                ForeColor = chave.SubRoxo
            };

            Nome = new Label
            {
                Dock = DockStyle.Top,
                Text = "Usuário",
                ForeColor = chave.Branco,
                Font = chave.H3_Font,
                AutoSize = true

            };

            Email = new Label
            {
                Dock = DockStyle.Top,
                Text = "usuaio@email.com",
                ForeColor = chave.SubRoxo,
                Font = chave.SubtiruloCard_Font,
                AutoSize = true
            };


            PanelArredonado esp01 = new PanelArredonado
            {
                Dock = DockStyle.Top,
                Padding = new Padding(20),
                Radius = 20,
                AutoSize = true,
                BackColor = chave.RoxoFluorescente
            };

            DataDeNascimento = retornaLabel("Data de Nascimento: __/__/____");
            Altura = retornaLabel("Altura: __,__m");
            Peso = retornaLabel("Peso: __,__kg");


            PanelArredonado esp02 = new PanelArredonado
            {
                Dock = DockStyle.Top,
                Padding = new Padding(20),
                Radius = 20,
                AutoSize = true,
                BackColor = chave.RoxoFluorescente
            };

            Objetivo = retornaLabel("Objetivo atual: ____");
            IMC = retornaLabel("IMC: __,__");
            Classificação = retornaLabel("Objetivo Classificação: ____");

            p01.Controls.Add(Email);
            p01.Controls.Add(Nome);
            p01.Controls.Add(lbl);

            esp01.Controls.Add(Peso);
            esp01.Controls.Add(Altura);
            esp01.Controls.Add(DataDeNascimento);

            esp02.Controls.Add(Classificação);
            esp02.Controls.Add(IMC);
            esp02.Controls.Add(Objetivo);

            infos.Controls.Add(esp02);
            infos.Controls.Add(chave.RetornaEspacoTop(20));
            infos.Controls.Add(esp01);
            infos.Controls.Add(chave.RetornaEspacoTop(40));
            infos.Controls.Add(p01);

        }

        private Label retornaLabel(string tx)
        {
            Label x = new Label
            {
                Text = tx,

                Dock = DockStyle.Top,
                AutoSize = true,
                ForeColor = chave.SubRoxo,
                Font = chave.SubtiruloCard_Font
            };
            return x;
        }

        private void AddTopo()
        {
            PanelArredonado topo = new PanelArredonado
            {
                Dock = DockStyle.Top,
                Height = 120,
                BackColor = chave.RoxoEscuro,
                Radius = 38,
                Padding = new Padding(36)
            };
            Panel icone = new Panel
            {
                Dock = DockStyle.Left,
                Width = topo.Height - 36 * 2,
                BackgroundImage = Properties.Resources.Icones_PNG,
                BackgroundImageLayout = ImageLayout.Stretch
            };
            Panel esp = new Panel
            {
                Dock = DockStyle.Left,
                Width = this.Width - icone.Width - 40 * 2
            };
            Label top01 = new Label
            {
                Text = "GESTÃO DE SAÚDE",
                ForeColor = chave.Branco,
                Font = chave.tituloCard_Font,
                Dock = DockStyle.Top,
                AutoSize = true
            };
            Label top02 = new Label
            {
                Text = "Treinos para iniciantes",
                ForeColor = chave.Branco,
                Font = chave.TextoPequeno,
                Dock = DockStyle.Top,
                AutoSize = true
            };

            esp.Controls.Add(top02);
            esp.Controls.Add(top01);

            this.Controls.Add(topo);
            topo.Controls.Add(esp);
            topo.Controls.Add(chave.RetornaEspacoLeft(10));
            topo.Controls.Add(icone);



        }
    }
}
