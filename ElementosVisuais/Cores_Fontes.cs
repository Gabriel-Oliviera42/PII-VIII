using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        //Cores de Texto e fundo
        public Color Preto = Color.FromArgb(35, 35, 35);
        public Color CinzaClaro = Color.FromArgb(233, 233, 237);
        public Color Branco = Color.FromArgb(255, 255, 255);


        //Fontes
        public Font H1_Font { get { return new Font("Arial", 40F, FontStyle.Bold, GraphicsUnit.Point, 0); } }
        public Font Sub_H1_Font { get { return new Font("Arial", 20F, FontStyle.Bold, GraphicsUnit.Point, 0); } }

        public Font H2_Font { get { return new Font("Arial", 34F, FontStyle.Bold, GraphicsUnit.Point, 0); } }
        public Font Sub_H2_Font { get { return new Font("Arial", 20F, FontStyle.Bold, GraphicsUnit.Point, 0); } }



        public Font TextoPequeno { get { return new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0); } }

        public Font Botao { get { return new Font("Arial", 16F, FontStyle.Bold, GraphicsUnit.Point, 0); } }
    }

}
