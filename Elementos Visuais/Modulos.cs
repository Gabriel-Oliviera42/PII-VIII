﻿using PII_VIII.Elementos_Visuais;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PII_VIII.Elementos_Visuais
{
    internal class selecao : PanelArredonado
    {
        public selecao()
        {
            inicializa();
        }

        private Chave chave = new Chave();
        Label text = new Label();
        BotaoArredondado next = new BotaoArredondado();
        BotaoArredondado ant = new BotaoArredondado();

        public Font Fonte
        {
            get{ return text.Font; }
            set{ text.Font = value; }
        }


        int op = 0;
        List<string> itens = new List<string>();

        public List<string> Items { get{ return itens; } set { itens = value; atualiza(); } }


        private void atualiza()
        {
            if (itens.Count > 0)
            {
                text.Text = itens[op];
            }
        }

        private void inicializa()
        {
            
            text.Text = "Sem itens";
            this.Padding = new Padding(5);
            text.Font = chave.Botao;
            text.ForeColor = chave.RoxoEscuro;
            text.Dock = DockStyle.Fill;
            text.TextAlign = ContentAlignment.MiddleCenter;

            this.Controls.Add(text);
           

            next.Dock = DockStyle.Right;
            next.Width = 80;
            next.Font = chave.Botao;
            next.Text = ">";
            this.Controls.Add(next);
            next.Radius = 20;
            next.FlatAppearance.BorderSize = 0;
            next.FlatStyle = FlatStyle.Flat;
            next.ForeColor = chave.Branco;
            next.BackColor = chave.RoxoFluorescente;

            ant.Dock = DockStyle.Left;
            ant.Width = 80;
            ant.Font = chave.Botao;
            ant.Text = ">";
            this.Controls.Add(ant);
            ant.Radius = 20;
            ant.FlatAppearance.BorderSize = 0;
            ant.FlatStyle = FlatStyle.Flat;
            ant.ForeColor = chave.Branco;
            ant.BackColor = chave.RoxoFluorescente;


        }
    }
}
