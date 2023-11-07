using System;
using System.Windows.Forms;
using Vistas;

namespace Vistas
{
    public partial class Vis_Menu : Form
    {
        public Vis_Menu()
        {
            InitializeComponent();
        }

        private void btnPerfil_Click(object sender, EventArgs e)
        {
            Perfil Perfil = new Perfil();
            Perfil.Show();
            this.Hide();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            ActualizarPerfil ActPerfil = new ActualizarPerfil();
            ActPerfil.Show();
            this.Hide();
        }

        private void Cerrado(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
