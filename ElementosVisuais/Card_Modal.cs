﻿using PII_VIII.Elementos_Visuais;
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
    internal class Card_Modal:FormArredondado
    {
        Chave chave = new Chave();

        private Label titulo = new Label();
        private Label subtitulo = new Label();
        private Label tituloCard = new Label();
        private Label descCard = new Label();
        private Treino _treino = new Treino();

        public Treino treino
        {
            set
            {
                _treino = value;
                atualizaDados();

            }
        }

        private void atualizaDados()
        {
            titulo.Text = _treino.NomeTreino;
            subtitulo.Text = _treino.Descricao;
            AtividadeFisica AF = new AtividadeFisica();

            string desc = "";
            int count = 0;
            foreach (DataRow x in AF.BuscarAtividadeTreino(_treino.idTreino).Rows)
            {
                desc += x[1] + ", ";
                count++;
            }
            tituloCard.Text = count + " Atividades Físicas"; ;
            descCard.Text = desc;


        }

        //Ainda vou ajustar mas assim que chamar a função abaixo ela deve enviar como parâmetro a classe treino que do PoupUP
        //EX: "public CardModal(Treino treinorecbido)" e "CardModal exemplo = new CardModal(treino);"
        //Mas para isso a chamada dela na tela de principal tem que estar concluida senão dá erro toda vez que chamar

        public Card_Modal()
        {
            //this.AutoSize = true;
            this.Width = 1000;
            this.Height = 800;
            this.MaximumSize = this.Size;
            this.AutoScroll = true;


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
            
            AbreCard();

        }

        private void AddAtFisica()
        {
            Flow AtiviEsp = new Flow();
            AtiviEsp.AutoSize = true;
            AtiviEsp.Dock = DockStyle.Top;
            this.Controls.Add(AtiviEsp);

            AtividadeFisica at = new AtividadeFisica();
            at.Nome = "Teste de Nome";
            at.Descricao = "Teste de Descrição";

            AtiviEsp.Controls.Add(RetornaAtvFis(at));
            AtiviEsp.Controls.Add(RetornaAtvFis(at));
            AtiviEsp.Controls.Add(RetornaAtvFis(at));
            AtiviEsp.Controls.Add(RetornaAtvFis(at));
            AtiviEsp.Controls.Add(RetornaAtvFis(at));

           


        }

        PanelArredonado RetornaAtvFis(AtividadeFisica at)
        {
            PanelArredonado fundo = new PanelArredonado();
            fundo.Width = 290;
            fundo.Height = 140;
            fundo.BackColor = chave.CinzaClaro;
            fundo.Radius = 20;
            fundo.Padding = new Padding(20);

            Label tit = new Label();
            tit.AutoSize = true;
            tit.Dock = DockStyle.Top;
            tit.Font = chave.tituloCard_Font;
            tit.ForeColor = chave.Azul;


            //Ajusta Conteúdo
            tit.Text = at.Nome;
            

            fundo.Controls.Add(tit);

            

            return fundo;   
        }

        private void AddInfos()
        {
            //Adicionando icone
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

            //Adicionando título

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

            Thread t = new Thread(() =>
            {
                this.StartPosition = FormStartPosition.CenterScreen;
                this.ShowDialog();
            });

            t.Start();
            FormEscurecerTela();
        }

        //cria um form escuro com opacidade de 50% para ficar sobre o fundo sempre que o poupup aparece
        public void FormEscurecerTela()
        {
            Form es = new Form();
            es.FormBorderStyle = FormBorderStyle.None;
            es.BackColor = Color.Black;
            es.Opacity = 0.5; // Opacidade de 50%
            es.WindowState = FormWindowState.Maximized;
            this.FormClosing += (sender, e) =>
            {
                es.Close();
            };
            es.Click += (s, e) =>
            {
                this.Close();
                es.Close();
            };
            
            es.ShowDialog();
        }
    }
}