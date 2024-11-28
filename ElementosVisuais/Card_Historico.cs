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
        private PanelArredonado icone;

        private Historico _historico = new Historico();

        public Label DataInicio { get; set; }
        
        public Label DataFim { get; set; }

        public Label DescricaoObjetivo { get; set; }

        private bool IsAtual = false;

        private void atualizaCores()
        {
            if (_historico.IdObjetivo == 1)
            {
                dataInicio.ForeColor = chave.Azul;
                dataFim.ForeColor = chave.Azul;
                icone.BackColor = chave.Azul;

            }
            else if(_historico.IdObjetivo == 2)
            {
                dataInicio.ForeColor = chave.vermelho;
                dataFim.ForeColor = chave.vermelho;
                icone.BackColor = chave.vermelho;
            }
            else if (_historico.IdObjetivo == 3)
            {
                dataInicio.ForeColor = chave.Verde;
                dataFim.ForeColor = chave.Verde;
                icone.BackColor = chave.Verde;
            }
        }


        private void atualizaDados()
        {
            dataInicio.Text = "De: " + _historico.DataInicial.ToString("dd/MM/yyyy");
            if(_historico.DataFinal == null)
            {
                dataFim.Text = "Até : ATUAL";
                IsAtual = true;
            }
            else
            {
                dataFim.Text = "Até : " + _historico.DataFinal?.ToString("dd/MM/yyyy");
                IsAtual= false;
            }
            descricaoObjetivo.Text = "Objetivo: " + _historico.DescricaoObjetivo;
            atualizaCores();

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
                Padding = new Padding(0, 44, 0, 44),
            };
            icone = new PanelArredonado
            {
                BackColor = chave.Azul,

                Dock = DockStyle.Fill,
                Radius = 50,
                BackgroundImage = Properties.Resources.Historico_Card_icone,
                BackgroundImageLayout = ImageLayout.Stretch
            };

            espIcone.Controls.Add(icone);


            Panel espTitulo = new Panel
            {
                Dock = DockStyle.Left,
                Width = 600,
                
                Padding = new Padding(0, 14, 0, 14),
            };
            dataInicio = new Label
            {
                Dock = DockStyle.Top,
                AutoSize = true,
                Text = "//",
                Font = chave.tituloCard_Font,
                ForeColor = chave.Azul,
                Padding = new Padding(0, 5, 0, 5)
            };
            dataFim = new Label
            {
                Dock = DockStyle.Top,
                AutoSize = true,
                Text = "//",
                Font = chave.tituloCard_Font,
                ForeColor = chave.Azul,
                Padding = new Padding(0, 5, 0, 5)
            };
            descricaoObjetivo = new Label
            {
                Dock = DockStyle.Top,
                AutoSize = true,
                Text = "Meta: ____",
                Font = chave.SubtiruloCard_Font,
                ForeColor = chave.RoxoCinza,
                Padding = new Padding(0, 5, 0, 5)
            };

            espTitulo.Controls.Add(descricaoObjetivo);
            espTitulo.Controls.Add(dataFim);
            espTitulo.Controls.Add(dataInicio);            
                      

            Controls.Add(espTitulo);
            Controls.Add(chave.RetornaEspacoLeft(10));
            Controls.Add(espIcone);

        }
    }
}
