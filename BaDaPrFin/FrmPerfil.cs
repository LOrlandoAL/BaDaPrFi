using Modelos;
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
        private static Model_Usuarios Datos;
        public FrmPerfil(Model_Usuarios DatosUsuario)
        {
            InitializeComponent();
            Bitmap img = new Bitmap(Application.StartupPath + @"\img\Fondo3.jpg");
            this.BackgroundImage = img;
            this.BackgroundImageLayout = ImageLayout.Stretch;
            Datos = DatosUsuario;

            //Datos Comunes del Usuario.
            txtNombre.Text = Datos.Nombre;
            txtApellidoPaterno.Text = Datos.Apellido_Paterno;
            txtApellidoMaterno.Text = Datos.Apellido_Materno;
            txtUsuario.Text = Datos.Usuario;

            //Datos de la targeta.
            txtNumTarjeta.Text = Datos.Numero_Tarjeta;
            txtCVV.Text = Datos.CVV;
            txtFechaCaducidad.Text = Datos.Card_Expired;
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
            FrmMenu menu = new FrmMenu(Datos);
            menu.Show();
            this.Hide();
        }
    }
}
