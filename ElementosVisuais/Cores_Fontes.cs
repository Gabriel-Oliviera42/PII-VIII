using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PII_VIII
{
    internal class Chave
    {
        //Classe que retorna cores e fontes padrão do layout

        //Cores Principais
        public Color RoxoClaro = Color.FromArgb(55, 39, 153);
        public Color RoxoEscuro = Color.FromArgb(9, 4, 70);
        public Color Magenta = Color.FromArgb(161, 23, 48);

        //Cores Complementares
        public Color Verde = Color.FromArgb(11, 118, 2);
        public Color vermelho = Color.FromArgb(219, 92, 92);
        public Color Azul = Color.FromArgb(6, 112, 210);
        public Color RoxoFluorescente = Color.FromArgb(64, 44, 188);

        //Cores SubComplementares
        public Color Sub_Verde = Color.FromArgb(11, 118, 2);
        public Color Sub_vermelho = Color.FromArgb(219, 92, 92);
        public Color Sub_Azul = Color.FromArgb(220, 220, 245);
        public Color SubRoxo = Color.FromArgb(220, 220, 245);



        //Cores de Texto e fundo
        public Color Preto = Color.FromArgb(35, 35, 35);
        public Color CinzaClaro = Color.FromArgb(233, 233, 237);
        public Color Branco = Color.FromArgb(255, 255, 255);
        public Color RoxoCinza = Color.FromArgb(144, 142, 170);


        //Fontes
        public Font H1_Font { get { return new Font("Roboto", 40F, FontStyle.Bold, GraphicsUnit.Point, 0); } }
        public Font Sub_H1_Font { get { return new Font("Roboto", 20F, FontStyle.Bold, GraphicsUnit.Point, 0); } }

        public Font H2_Font { get { return new Font("Roboto", 34F, FontStyle.Bold, GraphicsUnit.Point, 0); } }
        public Font Sub_H2_Font { get { return new Font("Roboto", 20F, FontStyle.Bold, GraphicsUnit.Point, 0); } }

        public Font H3_Font { get { return new Font("Roboto", 24F, FontStyle.Bold, GraphicsUnit.Point, 0); } }
        public Font Sub_H3_Font { get { return new Font("Roboto", 20F, FontStyle.Bold, GraphicsUnit.Point, 0); } }


        public Font tituloCard_Font { get { return new Font("Roboto", 18F, FontStyle.Bold, GraphicsUnit.Point, 0); } }
        public Font SubtiruloCard_Font { get { return new Font("Roboto", 14F, FontStyle.Bold, GraphicsUnit.Point, 0); } }

        public Font TextoPequeno { get { return new Font("Roboto", 12F, FontStyle.Regular, GraphicsUnit.Point, 0); } }
        public Font Textoicone { get { return new Font("Roboto", 9F, FontStyle.Bold, GraphicsUnit.Point, 0); } }

        public Font Botao { get { return new Font("Roboto", 16F, FontStyle.Bold, GraphicsUnit.Point, 0); } }


        public Panel RetornaEspacoTop(int tam)
        {
            Panel esp = new Panel();
            esp.Dock = DockStyle.Top;
            esp.Height = tam;
            return esp;

        }

        public Panel RetornaEspacoRight(int tam)
        {
            Panel esp = new Panel();
            esp.Dock = DockStyle.Right;
            esp.Width = tam;
            return esp;

        }

        public Panel RetornaEspacoLeft(int tam)
        {
            Panel esp = new Panel();
            esp.Dock = DockStyle.Left;
            esp.Width = tam;
            return esp;

        }

        public Panel RetornaEspacoBottom(int tam)
        {
            Panel esp = new Panel();
            esp.Dock = DockStyle.Bottom;
            esp.Height = tam;
            return esp;

        }


    }

}
