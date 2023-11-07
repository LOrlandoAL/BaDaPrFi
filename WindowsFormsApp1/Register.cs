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
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
        }

        private void Cerrado(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void btnRegistrarse_Click(object sender, EventArgs e)
        {
            if (txtContrasena != txtConfirmarContrasena) 
            {
                MessageBox.Show("Hi this is a message error, yep an error");
            }
        }
    }
}
