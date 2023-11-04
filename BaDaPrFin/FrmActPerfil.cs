using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BaDaPrFin
{
    public partial class FrmActPerfil : Form
    {
        public FrmActPerfil()
        {
            InitializeComponent();
        }

        private void Salir(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
