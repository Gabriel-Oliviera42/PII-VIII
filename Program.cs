using PII_VIII.ElementosVisuais;
using PII_VIII.ElementosVisuais.PII_VIII.ElementosVisuais;
using PII_VIII.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PII_VIII
{
    internal static class Program
    {
        public static Usuario user = new Usuario();

        [STAThread]       
        static void Main()
        {
            user.PreencherDados(1);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
           
           //Application.Run(new Login());
            //Application.Run(new Historico_Form());
           Application.Run(new Home(1));
        }
    }
}
