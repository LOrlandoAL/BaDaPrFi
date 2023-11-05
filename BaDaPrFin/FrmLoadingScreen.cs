using System;
using Datos;
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
    public partial class FrmLoadingScreen : Form
    {
        public FrmLoadingScreen()
        {
            InitializeComponent();
            tmrTemporizador.Start();
        }

        private void Timmer(object sender, EventArgs e)
        {
            if (ConexionBD.Conectar() != false)
            {
                new FrmLogin().Show();
                this.Hide();
                tmrTemporizador.Stop();
            }
            else
            {
                new FrmLogin().Show();
                this.Hide();
                tmrTemporizador.Stop();
            }
        }
    }
}
