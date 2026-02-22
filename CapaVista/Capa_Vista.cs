using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Capa_Datos;

namespace CRUD_Simple
{

    public partial class Capa_Vista : Form
    {
        public Capa_Vista()
        {
            InitializeComponent();
        }

        CD_Datos dt = new CD_Datos();

        private void LimpiarTextBoxs()
        {
            textBoxNombre.Text = "";
            textBoxApellido.Text = "";
            textBoxEdad.Text = "";
            textBoxEmail.Text = "";

        }

        private void Restablecer()
        {
            labelOperacion.Text = "Insertar Nuevo Registro";
            buttonInsertar.Visible = true;
            buttonInsertar.Enabled = true;
            buttonActualizar.Visible = false;
            buttonActualizar.Enabled = false;
            buttonCancelar.Visible = false;
            buttonCancelar.Enabled = false;
            LimpiarTextBoxs();
        }

        private void Capa_Vista_Load(object sender, EventArgs e)
        {
            dataGridPrincipal.DataSource = dt.MostrarUsuarios();
            buttonActualizar.Visible = false;
            buttonCancelar.Visible = false;
        }

        private void buttonInsertar_Click(object sender, EventArgs e)
        {
            dt.InsertarUsuario(textBoxNombre.Text, textBoxApellido.Text, Convert.ToInt32(textBoxEdad.Text), textBoxEmail.Text);
        }

        private void buttonActualizar_Click(object sender, EventArgs e)
        {
            string id = dataGridPrincipal.CurrentRow.Cells["id"].Value.ToString();

            dt.ActualizarUsuario(textBoxNombre.Text, textBoxApellido.Text, Convert.ToInt32(textBoxEdad.Text), textBoxEmail.Text, Convert.ToInt32(id));
            MessageBox.Show("Usuario actualizado correctamente");
            Restablecer();
        }

        private void buttonEditar_Click(object sender, EventArgs e)
        {

            if (dataGridPrincipal.SelectedRows.Count == 1)
            {
                textBoxNombre.Text = dataGridPrincipal.CurrentRow.Cells["nombre"].Value.ToString();
                textBoxApellido.Text = dataGridPrincipal.CurrentRow.Cells["apellido"].Value.ToString();
                textBoxEdad.Text = dataGridPrincipal.CurrentRow.Cells["edad"].Value.ToString();
                textBoxEmail.Text = dataGridPrincipal.CurrentRow.Cells["email"].Value.ToString();

                labelOperacion.Text = "Editar Registro";
                buttonInsertar.Visible = false;
                buttonInsertar.Enabled = false;
                buttonCancelar.Visible = true;
                buttonCancelar.Enabled = true;
                buttonActualizar.Visible = true;
                buttonActualizar.Enabled = true;
                buttonActualizar.Location = buttonInsertar.Location;
            }
            else if (dataGridPrincipal.SelectedRows.Count > 1)
            {
                MessageBox.Show("Selecciona solo una fila para editar");
            }
            else if (dataGridPrincipal.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecciona una fila para editar");
            }

        }

        private void buttonEliminar_Click(object sender, EventArgs e)
        {
            if(dataGridPrincipal.SelectedRows.Count == 1)
            {
                string id = dataGridPrincipal.CurrentRow.Cells["id"].Value.ToString();
                dt.EliminarUsuario(Convert.ToInt32(id));
                MessageBox.Show("Usuario eliminado correctamente");
            }
            else if(dataGridPrincipal.SelectedRows.Count > 1){ 
                MessageBox.Show("Selecciona solo una fila para eliminar");
            }
            else if(dataGridPrincipal.SelectedRows.Count == 0){ 
                MessageBox.Show("Selecciona una fila para eliminar");
            }
        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            Restablecer();
        }
    }

}
