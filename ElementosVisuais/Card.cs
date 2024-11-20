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
            this.Width = 600;
            this.Height = 268;
            this.Radius = 40;
            this.BackColor = chave.CinzaClaro;
            this.Padding = new Padding(20);
            

            //Adicionando icone
            Panel espIcone = new Panel();
            espIcone.Dock = DockStyle.Top;
            espIcone.Height = 50;


            PanelArredonado icone = new PanelArredonado();
            icone.BackColor = chave.Azul;
            icone.Dock= DockStyle.Left;
            icone.Width = 50;
            icone.Radius = 50;
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
            titulo.Font = chave.tituloCard_Font;
            titulo.ForeColor = chave.Azul;

            
            subtitulo.Dock = DockStyle.Top;
            subtitulo.AutoSize = true;
            subtitulo.Text = "Descrição do Treino";
            subtitulo.Font = chave.SubtiruloCard_Font;
            subtitulo.ForeColor = chave.Preto;

            espTitulo.Controls.Add(subtitulo);
            espTitulo.Controls.Add(chave.RetornaEspacoTop(5));
            espTitulo.Controls.Add(titulo);

            //Adiciona card de descrição
            PanelArredonado CardDesc = new PanelArredonado();
            CardDesc.Dock = DockStyle.Top;
            //CardDesc.AutoSize = true;
            CardDesc.Height = 84;
            CardDesc.Padding = new Padding(20);
            CardDesc.Radius = 20;
            CardDesc.BackColor = chave.Sub_Azul;

            //Adiciona textos de descrição
            Panel espTextoCard = new Panel();
            espTextoCard.Dock = DockStyle.Left;
            //espTextoCard.AutoSize = true;
            espTextoCard.Width = 460;

            
            tituloCard.Dock = DockStyle.Top;
            tituloCard.AutoSize = true;
            tituloCard.Text = "Quantidade de Atividades Físicas";
            tituloCard.Font = chave.Botao;
            tituloCard.ForeColor = chave.Azul;

            
            descCard.Dock = DockStyle.Top;
            descCard.AutoSize = true;
            descCard.Text = "Tipos de Treino";
            descCard.Font = chave.TextoPequeno;
            descCard.ForeColor = chave.Preto;


            espTextoCard.Controls.Add(descCard);
            espTextoCard.Controls.Add(tituloCard);

            //icone no card
            Panel iconeCard = new Panel();
            iconeCard.Dock = DockStyle.Right;
            iconeCard.Width = 40;
            iconeCard.BackgroundImage = Properties.Resources.LupaAzul;
            iconeCard.BackgroundImageLayout = ImageLayout.Center;
            iconeCard.Click += (s, e) => new Card_Modal(_treino) { treino = _treino} ;

            //adicionando elementos no card 
            CardDesc.Controls.Add(iconeCard);
            CardDesc.Controls.Add(espTextoCard);

            this.Controls.Add(CardDesc);
            this.Controls.Add(chave.RetornaEspacoTop(20));
            this.Controls.Add(espTitulo);
            this.Controls.Add(chave.RetornaEspacoTop(20));
            this.Controls.Add(espIcone);


        }



    }
}
