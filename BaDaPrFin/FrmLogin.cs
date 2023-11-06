using Datos;
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
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
            Bitmap img = new Bitmap(Application.StartupPath + @"\img\Aa.jpg");
            this.BackgroundImage = img;
            this.BackgroundImageLayout = ImageLayout.Stretch;
              
        }

        private void Salir(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void Login(object sender, EventArgs e)
        {
            txtUsuario.Text.Trim();
            txtContrasena.Text.Trim();

            if (txtUsuario.Text.Equals("") || txtContrasena.Text.Equals(""))
            {
                MessageBox.Show("Something going wrong.");
            }
            else
            {
                UsuariosDAO Dao = new UsuariosDAO();
                Model_Usuarios Usu = Dao.login(txtUsuario.Text,txtContrasena.Text);
                Model_Usuarios Datos = Dao.ObtenerTodo(Usu.ID);

                if (Usu != null)
                {
                    MessageBox.Show("Bienvenid@" + Usu.Nombre);
                    FrmMenu Menu = new FrmMenu(Datos);
                    Menu.Show();
                    this.Hide();
                }
                else 
                {
                    MessageBox.Show("Algo Salio Mal.");
                }
                
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void lblusu_Click(object sender, EventArgs e)
        {

        }
    }
}
