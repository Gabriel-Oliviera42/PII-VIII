using PII_VIII.Elementos_Visuais;
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

        
        private int op = 0;
        public int ItemSelecionado { get { return op+1; } set { op = value-1; atualiza(); } }
        List<string> itens = new List<string>();

        public List<string> Items { get{ return itens; } set { itens = value; atualiza(); } }
        public DataTable DT
        {
            set
            {
                itens.Clear();
                foreach (DataRow x in value.Rows)
                {
                    itens.Add(x[1].ToString());
                }
                atualiza();
            } 
        }


    


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
            text.Font = chave.TextoPequeno;
            text.ForeColor = chave.RoxoEscuro;
            text.Dock = DockStyle.Fill;
            text.TextAlign = ContentAlignment.MiddleCenter;

            this.Controls.Add(text);
           

            next.Dock = DockStyle.Right;
            next.Width = 60;
            next.Font = chave.Botao;
            next.Text = ">";
            this.Controls.Add(next);
            next.Radius = 20;
            next.FlatAppearance.BorderSize = 0;
            next.FlatStyle = FlatStyle.Flat;
            next.ForeColor = chave.Branco;
            next.BackColor = chave.RoxoFluorescente;

            ant.Dock = DockStyle.Left;
            ant.Width = 60;
            ant.Font = chave.Botao;
            ant.Text = "<";
            this.Controls.Add(ant);
            ant.Radius = 20;
            ant.FlatAppearance.BorderSize = 0;
            ant.FlatStyle = FlatStyle.Flat;
            ant.ForeColor = chave.Branco;
            ant.BackColor = chave.RoxoFluorescente;
            atualizaCor();

            next.Click += (s, e) =>
            {
                if (op < itens.Count - 1)
                {
                    op++;
                    text.Text = itens[op];
                }
                else if (op == itens.Count - 1)
                {
                    op = 0;
                    text.Text = itens[op];
                }
                atualizaCor();
            };
            ant.Click += (s, e) =>
            {
                if (op > 0)
                {
                    op--;
                    text.Text = itens[op];
                }
                else if (op == 0)
                {
                    op = itens.Count-1;
                    text.Text = itens[op];
                }
                atualizaCor();
            };


        }
        private void atualizaCor()
        {
            if (op == 0)
            {
                text.ForeColor = chave.Azul;
            }
            else if (op == 1)
            {
                text.ForeColor = chave.vermelho;
            }
            else if (op == 2)
            {
                text.ForeColor = chave.Verde;
            }

        }
    }
}
