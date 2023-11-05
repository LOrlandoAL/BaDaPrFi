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
    public partial class FrmPerfil : Form
    {
        public FrmPerfil()
        {
            InitializeComponent();
            Bitmap img = new Bitmap(Application.StartupPath + @"\img\Fondo3.jpg");
            this.BackgroundImage = img;
            this.BackgroundImageLayout = ImageLayout.Stretch;
        }

        private void Salir(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void FrmPerfil_Load(object sender, EventArgs e)
        {

        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            FrmMenu menu = new FrmMenu();
            menu.Show();
            this.Hide();
        }
    }
}
