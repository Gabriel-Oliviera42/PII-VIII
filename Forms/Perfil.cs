using PII_VIII.ElementosVisuais;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace PII_VIII.Forms
{
    internal class Perfil:Form
    {
        Menu_Principal menu = new Menu_Principal();
        Chave chave = new Chave();
        private void InitializeComponent()
        {
            this.SuspendLayout();
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Name = "Home";
            this.Padding = new System.Windows.Forms.Padding(40);
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);
            this.Text = "Perfil";

        }

        public Perfil()
        {
            InitializeComponent();
            AddBarraUsuario();

            AddMenu();
        }

        private void AddMenu()
        {
            menu.FormPai = this;
            this.Controls.Add(chave.RetornaEspacoLeft(20));
            this.Controls.Add(menu);
        }
        private void AddBarraUsuario()
        {
            Barra_Usuario barra_usuario = new Barra_Usuario();
            barra_usuario.Dock = DockStyle.Right;
            this.Controls.Add(chave.RetornaEspacoLeft(20));
            this.Controls.Add(barra_usuario);
        }
    }
}
