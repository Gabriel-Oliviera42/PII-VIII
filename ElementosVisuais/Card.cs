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
        private Label subtitulo = new Label();
        private Label descCard = new Label();
        private Treino _treino = new Treino();



        private Label titulo = new Label();
        private Label tituloCard = new Label();
        private Label lbAddRemove;
        private BotaoArredondado iconeAddRemove;
        PanelArredonado icone;
        PanelArredonado CardDesc;
        Panel iconeCard;

        private void atualizaCores()
        {
            if(treino.IdObjetivo == 1)
            {
                lbAddRemove.ForeColor = chave.Azul;
                icone.BackColor = chave.Azul;
                titulo.ForeColor = chave.Azul;
                tituloCard.ForeColor = chave.Azul;
                iconeAddRemove.ForeColor = chave.Azul;

                CardDesc.BackColor = chave.Sub_Azul;
                iconeCard.BackgroundImage = Properties.Resources.LupaAzul;
            }
            else if(treino.IdObjetivo == 2)
            {
                lbAddRemove.ForeColor = chave.vermelho;
                icone.BackColor = chave.vermelho;
                titulo.ForeColor = chave.vermelho;
                tituloCard.ForeColor = chave.vermelho;
                iconeAddRemove.ForeColor = chave.vermelho;

                CardDesc.BackColor = chave.Sub_vermelho;
                iconeCard.BackgroundImage = Properties.Resources.Lupa_Vermelha;
            }
            else if (treino.IdObjetivo == 3)
            {
                lbAddRemove.ForeColor = chave.Verde;
                icone.BackColor = chave.Verde;
                titulo.ForeColor = chave.Verde;
                tituloCard.ForeColor = chave.Verde;
                iconeAddRemove.ForeColor = chave.Verde;

                CardDesc.BackColor = chave.Sub_Verde;
                iconeCard.BackgroundImage = Properties.Resources.Lupa_Verde;
            }
        }



        public BotaoArredondado AddRemove
        {
            get { return iconeAddRemove; }
            set { iconeAddRemove = value; }
        }

        private Form formPai = new Form();

        public Treino treino
        {
            set
            {
                _treino = value;
                atualizaDados();
                
            }
            get
            {
                return _treino;
            }
        }

        public Boolean TreinoUsuario
        {
            set
            {
                if (value==true)
                {
                    iconeAddRemove.Text = "-";
                    lbAddRemove.Text = "Remover Treino";
                }
                else
                {
                    iconeAddRemove.Text = "+";
                    lbAddRemove.Text = "Adicionar Treino";
                }
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
            descCard.Text = "Teste de de Treino";
            //descCard.Text = desc;
            Objetivo ob = new Objetivo();
            ob.PreencherDados(_treino.IdObjetivo);
            descCard.Text = "Meta: "+ob.Descricao;
            atualizaCores();
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


            icone = new PanelArredonado
            {
                BackColor = chave.Azul,
                Dock = DockStyle.Left,
                Width = 50,
                Radius = 50,
                BackgroundImage = Properties.Resources.Star,
                BackgroundImageLayout = ImageLayout.Stretch

            };

            Panel espAddRemove = new Panel
            {
                Dock = DockStyle.Right,
                //Width = 212
                AutoSize = true,
            };


            iconeAddRemove = new BotaoArredondado
            {
                Size = new Size(espIcone.Height, espIcone.Height),
                Radius = espIcone.Height,
                BackColor = chave.Sub_Azul,
                //Text = "+",
                ForeColor = chave.Azul,
                Font = chave.H3_Font,
                FlatStyle = FlatStyle.Flat,
                TextAlign = ContentAlignment.MiddleCenter,
                Dock = DockStyle.Left
            };

            lbAddRemove = new Label
            {
                Size = new Size(espIcone.Height, espIcone.Height),
                //Text = "Adicionar Treino",
                ForeColor = chave.Azul,
                Font = chave.SubtiruloCard_Font,
                AutoSize = true,
                FlatStyle = FlatStyle.Flat,
                TextAlign = ContentAlignment.MiddleCenter,
                Dock = DockStyle.Left,
                Padding = new Padding(4, 12, 4, 12)

            };

            TreinoUsuario = false;

            iconeAddRemove.FlatAppearance.BorderSize = 0;
          
            espAddRemove.Controls.Add(lbAddRemove);
            espAddRemove.Controls.Add(iconeAddRemove);

            espIcone.Controls.Add(espAddRemove);
            espIcone.Controls.Add(icone);


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
                ForeColor = chave.RoxoCinza
            };

            espTitulo.Controls.Add(subtitulo);
            espTitulo.Controls.Add(chave.RetornaEspacoTop(5));
            espTitulo.Controls.Add(titulo);

            //Adiciona card de descrição
            CardDesc = new PanelArredonado
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
            iconeCard = new Panel
            {
                Dock = DockStyle.Right,
                Width = 40,
                BackgroundImage = Properties.Resources.LupaAzul,
                BackgroundImageLayout = ImageLayout.Center
            };

            iconeCard.Click += (s, e) => new Card_Modal(_treino) ;

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
