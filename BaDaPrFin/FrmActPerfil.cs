using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using Datos;
using Modelos;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BaDaPrFin
{
    public partial class FrmActPerfil : Form
    {
        private Model_Usuarios Datos;
        private int id,Afectadas;
        public FrmActPerfil(Model_Usuarios Usu)
        {
            InitializeComponent();
            Bitmap img = new Bitmap(Application.StartupPath + @"\img\Fondo4.jpg");
            this.BackgroundImage = img;
            this.BackgroundImageLayout = ImageLayout.Stretch;
            this.Datos = Usu;

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

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            FrmMenu menu = new FrmMenu(Datos);
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

        private void txtNumTarjeta_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(e.KeyChar >= 48 && e.KeyChar <= 57 || e.KeyChar ==08 ))
            {
                MessageBox.Show("Solo números", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void txtCVV_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(e.KeyChar >= 48 && e.KeyChar <= 57 || e.KeyChar == 08))
            {
                MessageBox.Show("Solo números", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void txtFechaCaducidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(e.KeyChar >= 48 && e.KeyChar <= 57 || e.KeyChar == 08 || e.KeyChar == 47))
            {
                MessageBox.Show("Caracter inválido", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void txtUsuario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 39 || e.KeyChar == 34 || e.KeyChar == 94 ||
               e.KeyChar == 96 || e.KeyChar == 126)
            {
                MessageBox.Show("Caracter invalido", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void txtContrasena_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 39 || e.KeyChar == 34 || e.KeyChar == 94 ||
               e.KeyChar == 96 || e.KeyChar == 126)
            {
                MessageBox.Show("Caracter invalido", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void txtConfirmarContrasena_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 39 || e.KeyChar == 34 || e.KeyChar == 94 ||
               e.KeyChar == 96 || e.KeyChar == 126)
            {
                MessageBox.Show("Caracter invalido", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void txtEdad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(e.KeyChar >= 48 && e.KeyChar <= 57 || e.KeyChar == 08))
            {
                MessageBox.Show("Solo números", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(e.KeyChar >= 97 && e.KeyChar <= 122 || e.KeyChar >= 65 && e.KeyChar <= 90 || e.KeyChar == 08))
            {
                MessageBox.Show("Solo letras", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void txtApellidoPaterno_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(e.KeyChar >= 97 && e.KeyChar <= 122 || e.KeyChar >= 65 && e.KeyChar <= 90 || e.KeyChar == 08))
            {
                MessageBox.Show("Solo letras", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void txtApellidoMaterno_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(e.KeyChar >= 97 && e.KeyChar <= 122 || e.KeyChar >= 65 && e.KeyChar <= 90 || e.KeyChar == 08))
            {
                MessageBox.Show("Solo letras", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void GuardarPerfil(object sender, EventArgs e)
        {
            id = Datos.ID;
            if (txtContrasena.Text == "")
            {
                DialogResult Evento = MessageBox.Show("¿Quieres conservar tu contraseña antigua?", "Seguro", MessageBoxButtons.YesNo);
                if (Evento == DialogResult.Yes)
                {
                    UsuariosDAO Dao = new UsuariosDAO();
                    Afectadas = Dao.ActNoPass(id, txtNombre.Text, txtApellidoPaterno.Text, txtApellidoMaterno.Text, txtUsuario.Text
                        , txtNumTarjeta.Text, txtFechaCaducidad.Text, txtCVV.Text);
                    if (Afectadas != 0)
                    {
                        MessageBox.Show("Se Actualizo Correctamente, Vuelva a iniciar sesion");
                        FrmLoadingScreen Cargar = new FrmLoadingScreen();
                        Cargar.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Algo Salio Mal");
                    }
                }
                else if (Evento == DialogResult.No)
                {
                    if (txtContrasena.Text.Equals(""))
                    {
                        MessageBox.Show("Debes de Rellenar los campos obligatorios", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    else
                    {
                        if (txtContrasena.Text.Equals(txtConfirmarContrasena.Text))
                        {
                            UsuariosDAO Dao = new UsuariosDAO();
                            Afectadas = Dao.Actualizar(id, txtNombre.Text, txtApellidoPaterno.Text, txtApellidoMaterno.Text, txtUsuario.Text
                                , txtContrasena.Text, txtNumTarjeta.Text, txtFechaCaducidad.Text, txtCVV.Text);

                            if (Afectadas != 0)
                            {
                                MessageBox.Show("Se Actualizo Correctamente, Vuelva a iniciar sesion");
                                FrmLoadingScreen Cargar = new FrmLoadingScreen();
                                Cargar.Show();
                                this.Hide();
                            }
                            else
                            {
                                MessageBox.Show("Something going grong");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Las Contraseñas deben de coincidir", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                    }
                }
            }
            else 
            {
                MessageBox.Show("Something going grong");
            }
            

        }
    }
}
