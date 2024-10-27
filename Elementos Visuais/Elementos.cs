using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PII_VIII.Elementos_Visuais
{
    //Permite Melhor Scrool do FlowLayoutPannel

    public class Flow : FlowLayoutPanel
    {
        public Flow()
        {
            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            this.UpdateStyles();
        }
    }



    //Formata o Panel Permitindo que ele seja arredondado
    public class PanelArredonado : Panel
    {
        private int _radius = 1;
        public PanelArredonado()
        {
           // DoubleBufferedPanel();
        }

        public int Radius
        {
            get
            { return _radius; }
            set
            {
                if (value > this.Height || value > this.Width)
                {
                    if (this.Height / 2 < this.Width / 2)
                    {
                        _radius = this.Height / 2;
                    }
                    else
                    {
                        _radius -= this.Width / 2;
                    }
                }
                else
                {
                    _radius = value;
                }
               // DoubleBufferedPanel();
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {

            base.OnPaint(e);
            GraphicsPath path = new GraphicsPath();
            path.AddArc(0, 0, _radius, _radius, 180, 90);
            path.AddArc(Width - _radius, 0, _radius, _radius, 270, 90);
            path.AddArc(Width - _radius, Height - _radius, _radius, _radius, 0, 90);
            path.AddArc(0, Height - _radius, _radius, _radius, 90, 90);
            path.CloseFigure();
            this.Region = new Region(path);
        }

        public void DoubleBufferedPanel()
        {
            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            this.UpdateStyles();
        }

    }

    //Formata o Botão Permitindo que ele seja arredondado
    public class BotaoArredondado : Button
    {
        public int _radius = 1;

        public int Radius
        {
            get
            { return _radius; }
            set
            {
                if (value > this.Height || value > this.Width)
                {
                    if (this.Height / 2 < this.Width / 2)
                    {
                        _radius = this.Height / 2;
                    }
                    else
                    {
                        _radius -= this.Width / 2;
                    }
                }
                else
                {
                    _radius = value;
                }
                // DoubleBufferedPanel();
            
        }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            GraphicsPath path = new GraphicsPath();
            path.AddArc(0, 0, _radius, _radius, 180, 90);
            path.AddArc(Width - _radius, 0, _radius, _radius, 270, 90);
            path.AddArc(Width - _radius, Height - _radius, _radius, _radius, 0, 90);
            path.AddArc(0, Height - _radius, _radius, _radius, 90, 90);
            path.CloseFigure();
            this.Region = new Region(path);
        }
    }

    //Tlavez eu não use essa classe mas deixei aqui para caso precise
    public partial class FormArredondado : Form
    {
        public FormArredondado()
        {
            this.Paint += new PaintEventHandler(DesenharBordasArredondadas);
        }

        private void DesenharBordasArredondadas(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            Rectangle bounds = this.ClientRectangle;
            int radius = 50;
            using (GraphicsPath path = new GraphicsPath())
            {
                path.AddArc(bounds.X, bounds.Y, radius, radius, 180, 90); // Canto superior esquerdo
                path.AddArc(bounds.X + bounds.Width - radius, bounds.Y, radius, radius, 270, 90); // Canto superior direito
                path.AddArc(bounds.X + bounds.Width - radius, bounds.Y + bounds.Height - radius, radius, radius, 0, 90); // Canto inferior direito
                path.AddArc(bounds.X, bounds.Y + bounds.Height - radius, radius, radius, 90, 90); // Canto inferior esquerdo
                path.CloseFigure();

                // Preenche o formulário com cadastrarBotao cor de fundo
                graphics.FillPath(new SolidBrush(this.BackColor), path);
                this.Region = new Region(path);
            }
        }
    }
}
