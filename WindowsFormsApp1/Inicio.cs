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
using Vistas;

namespace WindowsFormsApp1
{
    public partial class Inicio : Form
    {
        public Inicio()
        {
            InitializeComponent();
            if (ConexionBD.Conectar() != false)
            {
                MessageBox.Show("Somthing going wrong.");
            }
        }
        private void btnEntrar_Click(object sender, EventArgs e)
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
                    Vis_Menu MenuInicio = new Vis_Menu();
                    MenuInicio.Show();
                    this.Hide();
                }
            }


        }
        private void Inicio_Load(object sender, EventArgs e)
        {

        }


    }
}
