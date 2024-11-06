using PII_VIII.Elementos_Visuais;
using PII_VIII.ElementosVisuais;
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


namespace PII_VIII.Forms
{
    internal class Home:Form
    {
        Menu_Principal menu = new Menu_Principal();

        private void InitializeComponent()
        {

            this.SuspendLayout();
            this.WindowState = FormWindowState.Maximized;
            this.Name = "Home";
            this.ResumeLayout(false);
            this.Padding = new Padding(40);

        }

        public Home()
        {
            InitializeComponent();
            AddMenu();
        }

        private void AddMenu()
        {
            this.Controls.Add(menu);
        }
    }
}
