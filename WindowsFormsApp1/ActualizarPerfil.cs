using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Vistas
{
    public partial class ActualizarPerfil : Form
    {
        public ActualizarPerfil()
        {
            InitializeComponent();
        }

        private void Cerrado(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
