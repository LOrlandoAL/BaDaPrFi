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
            Bitmap img = new Bitmap(Application.StartupPath + @"\img\Fondo4.jpg");
            this.BackgroundImage = img;
            this.BackgroundImageLayout = ImageLayout.Stretch;
        }

        private void Salir(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            FrmMenu menu = new FrmMenu();
            menu.Show(this);
            this.Hide();
        }

        private void FrmActPerfil_Load(object sender, EventArgs e)
        {

        }

        private void lblContrasena_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void lblNombre_Click(object sender, EventArgs e)
        {

        }

        private void lblUsuario_Click(object sender, EventArgs e)
        {

        }

        private void lblApellidoPaterno_Click(object sender, EventArgs e)
        {

        }
    }
}
