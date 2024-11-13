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
        /// <summary>
        /// Ponto de entrada principal para o aplicativo.
        /// </summary>
        /// 
        public static Usuario user = new Usuario();
        
        [STAThread]

       
        static void Main()
        {
            user.IdUsuario = 0;
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
            //Application.Run(new Login());

            Application.Run(new Home());

        }

        static List<string> ListaDepessoas;
        
    }
}
