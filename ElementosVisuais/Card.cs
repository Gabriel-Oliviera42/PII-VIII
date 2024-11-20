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
    internal class Card:PanelArredonado
    {
        Chave chave = new Chave();
        private Label titulo = new Label();
        private Label subtitulo = new Label();
        private Label tituloCard = new Label();
        private Label descCard = new Label();
        private Treino _treino = new Treino();

        private Form formPai = new Form();

        public Treino treino
        {
            set
            {
                _treino = value;
                atualizaDados();
                
            }
        }


        public Form Form_Pai
        {
            set
            {
                formPai = value;
            }
        }

        private void atualizaDados()
        {
            // Atribui o nome e descrição do treino aos respectivos rótulos
            titulo.Text = _treino.NomeTreino;
            subtitulo.Text = _treino.Descricao;

            // Obtém e exibe o número de atividades associadas ao treino
            int quantidadeAtividades = _treino.QuantidadeAtividadeTreino(_treino.IdTreino);
            tituloCard.Text = quantidadeAtividades + " Atividades Físicas";

            // Se desejar, ajuste o descCard para mostrar outros detalhes
            // descCard.Text = "Tipos de Treino";
            //descCard.Text = desc;
        }


        public Card()
        {
            Width = 600;
            Height = 268;
            Radius = 40;
            BackColor = chave.CinzaClaro;
            Padding = new Padding(20);
            

            //Adicionando icone
            Panel espIcone = new Panel
            {
                Dock = DockStyle.Top,
                Height = 50
            };


            PanelArredonado icone = new PanelArredonado
            {
                BackColor = chave.Azul,
                Dock = DockStyle.Left,
                Width = 50,
                Radius = 50,
                BackgroundImage = Properties.Resources.Star,
                BackgroundImageLayout = ImageLayout.Stretch

            };

            espIcone.Controls.Add(icone);

            //Adicionando título

            Panel espTitulo = new Panel
            {
                Dock = DockStyle.Top,
                AutoSize = true
            };

            titulo = new Label
            {
                Dock = DockStyle.Top,
                AutoSize = true,
                Text = "Nome do Treino",
                Font = chave.tituloCard_Font,
                ForeColor = chave.Azul
            };

            subtitulo = new Label
            {
                Dock = DockStyle.Top,
                AutoSize = true,
                Text = "Descrição do Treino",
                Font = chave.SubtiruloCard_Font,
                ForeColor = chave.Preto
            };

            espTitulo.Controls.Add(subtitulo);
            espTitulo.Controls.Add(chave.RetornaEspacoTop(5));
            espTitulo.Controls.Add(titulo);

            //Adiciona card de descrição
            PanelArredonado CardDesc = new PanelArredonado
            {
                Dock = DockStyle.Top,
                Height = 84,
                Padding = new Padding(20),
                Radius = 20,
                BackColor = chave.Sub_Azul
            };

            //Adiciona textos de descrição
            Panel espTextoCard = new Panel
            {
                Dock = DockStyle.Left,
                Width = 460
            };

            tituloCard = new Label
            {
                Dock = DockStyle.Top,
                AutoSize = true,
                Text = "Quantidade de Atividades Físicas",
                Font = chave.Botao,
                ForeColor = chave.Azul
            };

            descCard = new Label
            {
                Dock = DockStyle.Top,
                AutoSize = true,
                Text = "Tipos de Treino",
                Font = chave.TextoPequeno,
                ForeColor = chave.Preto
            };

            espTextoCard.Controls.Add(descCard);
            espTextoCard.Controls.Add(tituloCard);

            //icone no card
            Panel iconeCard = new Panel
            {
                Dock = DockStyle.Right,
                Width = 40,
                BackgroundImage = Properties.Resources.LupaAzul,
                BackgroundImageLayout = ImageLayout.Center
            };

            iconeCard.Click += (s, e) => new Card_Modal(_treino) { treino = _treino} ;

            //adicionando elementos no card 
            CardDesc.Controls.Add(iconeCard);
            CardDesc.Controls.Add(espTextoCard);

            Controls.Add(CardDesc);
            Controls.Add(chave.RetornaEspacoTop(20));
            Controls.Add(espTitulo);
            Controls.Add(chave.RetornaEspacoTop(20));
            Controls.Add(espIcone);


        }



    }
}
