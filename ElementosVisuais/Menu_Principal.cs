using PII_VIII.Elementos_Visuais;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PII_VIII.ElementosVisuais
{
    internal class Menu_Principal:PanelArredonado
    {
        Chave chave = new Chave();

        //Criando Menu
        public Menu_Principal()
        {
            this.Radius = 20;
            this.BackColor = chave.RoxoClaro;
            this.Dock = System.Windows.Forms.DockStyle.Left;
            this.Width = 135;
            this.Padding = new Padding(38);

            Panel home = CriaBotao("Home", chave.RoxoFluorescente, Properties.Resources.Home);
            Panel treinos = CriaBotao("Treinos", chave.RoxoFluorescente, Properties.Resources.Treino);
            Panel historico = CriaBotao("Historico", chave.RoxoFluorescente, Properties.Resources.historico);
            Panel Metas = CriaBotao("Metas", chave.RoxoFluorescente, Properties.Resources.Meta);
            Panel Perfil = CriaBotao("Perfil", chave.RoxoFluorescente, Properties.Resources.Perfil);
            Panel Sair = CriaBotao("Sair", chave.vermelho, Properties.Resources.Sair);

            Sair.Dock = DockStyle.Bottom;
            int pd = 20;

            this.Controls.Add(Perfil);
            this.Controls.Add(chave.RetornaEspacoTop(pd));
            this.Controls.Add(Metas);
            this.Controls.Add(chave.RetornaEspacoTop(pd));
            this.Controls.Add(historico);
            this.Controls.Add(chave.RetornaEspacoTop(pd));
            this.Controls.Add(treinos);
            this.Controls.Add(chave.RetornaEspacoTop(pd));
            this.Controls.Add(home);
            this.Controls.Add(Sair);


            home.Controls["icone"].Click += (s, e) => Home_click();
            treinos.Controls["icone"].Click += (s, e) => Treinos_click();
            historico.Controls["icone"].Click += (s, e) =>  Historico_click();
            Metas.Controls["icone"].Click += (s, e) => Metas_click();
            Perfil.Controls["icone"].Click += (s, e) => Perfil_click();
            Sair.Controls["icone"].Click += (s, e) => Sair_click();
       }

        //retorna campor de Botão
        private Panel CriaBotao(string texto, Color cor, Image icon)
        {
            Panel esp = new Panel();
            BotaoArredondado icone = new BotaoArredondado();
            Label tx = new Label();

            esp.Dock = DockStyle.Top;
            esp.Height = 80;


            icone.Name = "icone";
            icone.Radius = 20;
            icone.Height = 58;
            icone.BackColor = cor;
            icone.Dock = DockStyle.Top;
            icone.FlatAppearance.BorderSize = 0;
            icone.FlatStyle = FlatStyle.Flat;
            icone.BackgroundImage = icon;
            icone.BackgroundImageLayout = ImageLayout.Stretch;
            icone.Padding = new Padding(20);
            tx.Text = texto;



            
            esp.Controls.Add (icone);
            esp.Controls.Add (tx);
            tx.ForeColor = chave.Branco;
            tx.Font = chave.Textoicone;
            tx.Dock = DockStyle.Bottom ;
            tx.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            return esp;
        }



        //Click dos Botões
        private void Home_click()
        {
            MessageBox.Show("Home");
        }
        private void Treinos_click()
        {
            MessageBox.Show("Treinos");
        }
        private void Historico_click()
        {
            MessageBox.Show("Historico");
        }
        private void Metas_click()
        {
            MessageBox.Show("Metas");
        }
        private void Perfil_click()
        {
            MessageBox.Show("Perfil");
        }
        private void Sair_click()
        {
            MessageBox.Show("Sair");
        }
    }
}
