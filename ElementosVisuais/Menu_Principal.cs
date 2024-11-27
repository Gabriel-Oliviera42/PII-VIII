using PII_VIII.Elementos_Visuais;
using PII_VIII.Forms;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PII_VIII.ElementosVisuais
{
    internal class Menu_Principal:PanelArredonado
    {
        Chave chave = new Chave();

        public Form FormPai = new Form();
       
        public Menu_Principal()
        {
            this.Radius = 40;
            this.BackColor = chave.RoxoClaro;
            this.Dock = System.Windows.Forms.DockStyle.Left;
            this.Width = 135;
            this.Padding = new Padding(38);
            
            Panel treinos = CriaBotao("Treinos", chave.RoxoFluorescente, Properties.Resources.Treino);
            Panel historico = CriaBotao("Historico", chave.RoxoFluorescente, Properties.Resources.historico);
            Panel Perfil = CriaBotao("Perfil", chave.RoxoFluorescente, Properties.Resources.Perfil);
            Panel Sair = CriaBotao("Sair", chave.vermelho, Properties.Resources.Sair);

            Sair.Dock = DockStyle.Bottom;
            int pd = 20;

            this.Controls.Add(Perfil);
            this.Controls.Add(chave.RetornaEspacoTop(pd));           
            this.Controls.Add(historico);
            this.Controls.Add(chave.RetornaEspacoTop(pd));
            this.Controls.Add(treinos);
            this.Controls.Add(chave.RetornaEspacoTop(pd));            
            this.Controls.Add(Sair);

            treinos.Controls["icone"].Click += (s, e) => Treinos_click();
            historico.Controls["icone"].Click += (s, e) =>  Historico_click();
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
        
        private void Treinos_click()
        {
            Thread init = new Thread(() =>
            {
                Home aux = new Home(Program.user.IdUsuario); 
                aux.ShowDialog();
            });
            init.Start();
            FormPai.Close();
        }
        private void Historico_click()
        {
            Thread init = new Thread(() =>
            {

                Historico_Form aux = new Historico_Form(); 
                aux.ShowDialog();
            });
            init.Start();
            FormPai.Close();
        }        
        private void Perfil_click()
        {
            Thread init = new Thread(() =>
            {
                Perfil aux = new Perfil(); 
                aux.ShowDialog();
            });
            init.Start();
            FormPai.Close();
        }
        private void Sair_click()
        {
            Thread init = new Thread(() =>
            {
                Login aux = new Login(); 
                aux.ShowDialog();
            });
            init.Start();
            FormPai.Close();
        }
    }
}
