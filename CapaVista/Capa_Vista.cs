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

        private void button1_Click(object sender, EventArgs e)
        {
            
            dataGridPrincipal.DataSource = dt.MostrarUsuarios();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string nombre = textBoxNombre.Text;
            string apellido = textBoxApellido.Text;
            string edad = textBoxEdad.Text;
            string email = textBoxEmail.Text;

            dt.InsertarUsuario(nombre, apellido, Convert.ToInt32(edad), email);
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string id = textBoxId.Text;

            dt.EliminarUsuario(Convert.ToInt32(id));
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string id = textBoxId.Text;
            string nombre = textBoxNombre.Text;
            string apellido = textBoxApellido.Text;
            string edad = textBoxEdad.Text;
            string email = textBoxEmail.Text;

            dt.ActualizarUsuario(nombre, apellido, Convert.ToInt32(edad), email, Convert.ToInt32(id));
        }
    }


}
