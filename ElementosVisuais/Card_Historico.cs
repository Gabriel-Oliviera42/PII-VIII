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
    internal class Card_Historico : PanelArredonado
    {
        Chave chave = new Chave();
        private Label dataInicio = new Label();
        private Label dataFim = new Label();
        private Label descricaoObjetivo = new Label();

        private Historico _historico = new Historico();

        public Label DataInicio { get; set; }
        
        public Label DataFim { get; set; }

        public Label DescricaoObjetivo { get; set; }
                
        private void atualizaDados()
        {
            dataInicio.Text = "De: " + _historico.DataInicial.ToString("dd/MM/yyyy");
            dataFim.Text = "Até : " + _historico.DataFinal?.ToString("dd/MM/yyyy");
            descricaoObjetivo.Text = "Objetivo: " + _historico.DescricaoObjetivo;           

        }
        public Historico historico
        {
            set
            {
                _historico = value;
                atualizaDados();

            }
            get
            {
                return _historico;
            }
        }

        public Card_Historico()
        {

            Height = 180;
            Radius = 40;
            Dock = DockStyle.Top;
            BackColor = chave.CinzaClaro;
            Padding = new Padding(20);
            Panel espIcone = new Panel
            {
                Dock = DockStyle.Left,
                Width = 50,
                Padding = new Padding(0, 14, 0, 14),
            };
            PanelArredonado icone = new PanelArredonado
            {
                BackColor = chave.Azul,

                Dock = DockStyle.Fill,
                Radius = 50,
                BackgroundImage = Properties.Resources.Star,
                BackgroundImageLayout = ImageLayout.Stretch
            };
            espIcone.Controls.Add(icone);
            Panel espTitulo = new Panel
            {
                Dock = DockStyle.Left,
                Width = 354,
                Padding = new Padding(0, 14, 0, 14),
            };
            dataInicio = new Label
            {
                Dock = DockStyle.Top,
                AutoSize = true,
                Text = "//",
                Font = chave.tituloCard_Font,
                ForeColor = chave.Azul
            };
            dataFim = new Label
            {
                Dock = DockStyle.Top,
                AutoSize = true,
                Text = "//",
                Font = chave.tituloCard_Font,
                ForeColor = chave.Azul
            };
            descricaoObjetivo = new Label
            {
                Dock = DockStyle.Top,
                AutoSize = true,
                Text = "Meta: ____",
                Font = chave.SubtiruloCard_Font,
                ForeColor = chave.RoxoCinza
            };
            espTitulo.Controls.Add(dataFim);
            espTitulo.Controls.Add(dataInicio);            
            espTitulo.Controls.Add(descricaoObjetivo);           

            Controls.Add(espTitulo);
            Controls.Add(chave.RetornaEspacoLeft(10));

        }
    }
}





/*
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
    internal class Card_Historico : PanelArredonado
    {
        Chave chave = new Chave();
        private Label titulo = new Label();
        private Label subtitulo = new Label();
        private Label tituloCard = new Label();
        private Label descCard = new Label();
        //private Treino _treino = new Treino();
        private Form formPai = new Form();
        public Form Form_Pai
        {
            set
            {
                formPai = value;
            }
        }
        private void atualizaDados()
        {

        }
        public Historico historico
        {
            set
            {
                historico = value;
                atualizaDados();

            }
            get
            {
                return historico;
            }
        }
        public Card_Historico()
        {

            Height = 120;
            Radius = 40;
            Dock = DockStyle.Top;
            BackColor = chave.CinzaClaro;
            Padding = new Padding(20);
            Panel espIcone = new Panel
            {
                Dock = DockStyle.Left,
                Width = 50,
                Padding = new Padding(0, 14, 0, 14),
            };
            PanelArredonado icone = new PanelArredonado
            {
                BackColor = chave.Azul,

                Dock = DockStyle.Fill,
                Radius = 50,
                BackgroundImage = Properties.Resources.Star,
                BackgroundImageLayout = ImageLayout.Stretch
            };
            espIcone.Controls.Add(icone);
            Panel espTitulo = new Panel
            {
                Dock = DockStyle.Left,
                Width = 354,
                Padding = new Padding(0, 14, 0, 14),
            };
            titulo = new Label
            {
                Dock = DockStyle.Top,
                AutoSize = true,
                Text = "__/__/____",
                Font = chave.tituloCard_Font,
                ForeColor = chave.Azul
            };
            subtitulo = new Label
            {
                Dock = DockStyle.Top,
                AutoSize = true,
                Text = "Meta: ____",
                Font = chave.SubtiruloCard_Font,
                ForeColor = chave.RoxoCinza
            };
            espTitulo.Controls.Add(subtitulo);
            //espTitulo.Controls.Add(chave.RetornaEspacoTop(5));
            espTitulo.Controls.Add(titulo);
            //Adiciona card de descrição
            PanelArredonado CardDesc = new PanelArredonado
            {
                Dock = DockStyle.Right,
                Width = 734,
                Padding = new Padding(18),
                Radius = 20,
                BackColor = chave.Sub_Azul
            };
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
            Treino treino = new Treino();
            //treino.PreencherDados(historico.idTreino)
            //iconeCard.Click += (s, e) => new Card_Modal(_treino);
            //adicionando elementos no card 
            CardDesc.Controls.Add(iconeCard);
            CardDesc.Controls.Add(espTextoCard);
            Controls.Add(CardDesc);
            // Controls.Add(chave.RetornaEspacoLeft(20));
            Controls.Add(espTitulo);
            Controls.Add(chave.RetornaEspacoLeft(10));
            Controls.Add(espIcone);
        }
    }
}
*/