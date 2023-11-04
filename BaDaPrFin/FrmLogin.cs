using Datos;
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
                MessageBox.Show("Somthing going wrong.");
            }
            else
            {
                if (ConexionBD.Conectar() != false)
                {
                    MessageBox.Show("Somthing going wrong.");
                }
                else
                {
                    FrmMenu MenuInicio = new FrmMenu();
                    MenuInicio.Show();
                    this.Hide();
                }
            }
        }
    }
}
