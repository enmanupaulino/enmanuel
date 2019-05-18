using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Registro_Usuario.BLL;
using Registro_Usuario.Entidades;

namespace Registro_Usuario.UI.Registro
{
    public partial class RegistroUsuario : Form
    {
        public RegistroUsuario()
        {
            InitializeComponent();
        }

        private void Limpiar()
        {
            UsuarioIdnumericUpDown.Value = 0;
            NombreTextBox.Text = string.Empty;
            EmailTextBox.Text = string.Empty;
            NombreUsuarioTextBox.Text = string.Empty;
            ClaveTextBox.Text = string.Empty;
            FechaIngresoDateTimePicker.Value = DateTime.Now;
            FechaRegistroDateTimePicker.Value = DateTime.Now;
        }


        private void NuevoButton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }


        private Usuarios LlenaClase()
        {
            Usuarios Usuario = new Usuarios();
            Usuario.UsuarioId = Convert.ToInt32(UsuarioIdnumericUpDown.Value);
            Usuario.Nombres = NombreTextBox.Text;
            Usuario.NombreUsuario = NombreUsuarioTextBox.Text;
            Usuario.Email = EmailTextBox.Text;
            Usuario.Clave = ClaveTextBox.Text;
            Usuario.FechaIngreso = FechaIngresoDateTimePicker.Value;
            Usuario.FechaRegistro = FechaRegistroDateTimePicker.Value;
            return Usuario;
        }

        private void LlenaCampo(Usuarios usuarios)
        {
            UsuarioIdnumericUpDown.Value = usuarios.UsuarioId;
            NombreUsuarioTextBox.Text = usuarios.NombreUsuario;
            NombreTextBox.Text = usuarios.Nombres;
            EmailTextBox.Text = usuarios.Email;
            ClaveTextBox.Text = usuarios.Clave;
            FechaIngresoDateTimePicker.Value = usuarios.FechaIngreso;
            FechaRegistroDateTimePicker.Value = usuarios.FechaRegistro;

        }
        private bool ExisteEnLaBaseDeDatos()
        {
            Usuarios usuarios = UsuarioBLL.Buscar((int)UsuarioIdnumericUpDown.Value);
            return (usuarios != null);
        }

        private bool Validar()
        {
            bool paso = true;
            if (string.IsNullOrWhiteSpace(NombreTextBox.Text) || string.IsNullOrWhiteSpace(EmailTextBox.Text) || string.IsNullOrWhiteSpace(ClaveTextBox.Text) || string.IsNullOrWhiteSpace(NombreUsuarioTextBox.Text)) ;
            {
                if (string.IsNullOrWhiteSpace(NombreUsuarioTextBox.Text))
                {
                    SuperErrorProvider.SetError(NombreUsuarioTextBox, "no se puede dejar vacio");
                    NombreUsuarioTextBox.Focus();
                    paso = false;
                }
                if (string.IsNullOrWhiteSpace(EmailTextBox.Text))
                {
                    SuperErrorProvider.SetError(EmailTextBox, "no se puede dejar vacio");
                    EmailTextBox.Focus();
                    paso = false;
                }
                if (string.IsNullOrWhiteSpace(ClaveTextBox.Text))
                {
                    SuperErrorProvider.SetError(ClaveTextBox, "no se puede dejar vacio");
                    ClaveTextBox.Focus();
                    paso = false;
                }
                if (string.IsNullOrWhiteSpace(NombreUsuarioTextBox.Text))
                {
                    SuperErrorProvider.SetError(NombreUsuarioTextBox, "no se puede dejar vacio");
                    NombreUsuarioTextBox.Focus();
                    paso = false;
                }
                
                //mYerrorprovier 
                //en la ventana un error y ponerle ese nombre

            }
            return paso;
        }      
        private void GuardarButton_Click_1(object sender, EventArgs e)
        {
            Usuarios usuario = new Usuarios();

            bool paso = false;
            if (!Validar())
                return;
            usuario = LlenaClase();
            
            //Determinar si es guardar o modificar
            if (UsuarioIdnumericUpDown.Value == 0)
                paso = UsuarioBLL.Guardar(usuario);
            else
            {
                if (!ExisteEnLaBaseDeDatos())
                {
                    MessageBox.Show("no se puede modificar", "exixte un fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                paso = UsuarioBLL.Modificar(usuario);
            }

            //infprmar el resultado
            if (paso)
            {
                MessageBox.Show("Guardado", "exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Limpiar();
            }     
            else
                MessageBox.Show("Nose pudo guardar", "fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void EliminarButton_Click_1(object sender, EventArgs e)
        {
            SuperErrorProvider.Clear();
            int id;
            int.TryParse(UsuarioIdnumericUpDown.Text, out id);
            Limpiar();
            if (UsuarioBLL.Eliminar(id))
                MessageBox.Show("eliminado");
            else
                SuperErrorProvider.SetError(UsuarioIdnumericUpDown, "nos e puede eliminar un usuario que no exixte");
        }

        private void BuscarButton_Click_1(object sender, EventArgs e)
        {
            int id;
            Usuarios usuarios = new Usuarios();
            int.TryParse(UsuarioIdnumericUpDown.Text, out id);
            Limpiar();
            usuarios = UsuarioBLL.Buscar(id);
            if (usuarios != null)
            {
                MessageBox.Show("Usuario encontrado");
                LlenaCampo(usuarios);
            }
            else
            {
                MessageBox.Show("usuario no encontrado");
            }
        }


      
    }
}
