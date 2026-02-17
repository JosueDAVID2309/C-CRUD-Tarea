using Capa_Datos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace CRUD_Simple
{
    public class CD_Datos
    {
        DataTable tabla = new DataTable();
        SqlDataReader read;
        CD_Conexion conexion = new CD_Conexion();
        SqlCommand cmd = new SqlCommand();
        public DataTable MostrarUsuarios()
        {
            
            cmd.Connection = conexion.AbrirConexion();
            cmd.CommandText = "MostrarUsuarios";
            cmd.CommandType = CommandType.StoredProcedure;
            read = cmd.ExecuteReader();
            tabla.Load(read);

            return tabla;
        }

        public void InsertarUsuario(string nombre, string apellido, int edad, string email)
        {
            cmd.Connection = conexion.AbrirConexion();
            cmd.CommandText = "Crear_Usuario";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@nombre", nombre);
            cmd.Parameters.AddWithValue("@apellido", apellido);
            cmd.Parameters.AddWithValue("@edad", edad);
            cmd.Parameters.AddWithValue ("@email", email);
            cmd.ExecuteNonQuery();
        }

        public void EliminarUsuario(int id)
        {
            cmd.Connection = conexion.AbrirConexion();
            cmd.CommandText = "Eliminar_Usuario";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();
        }

        public void ActualizarUsuario(string nombre, string apellido, int edad, string email, int id)
        {
            cmd.Connection = conexion.AbrirConexion();
            cmd.CommandText = "Actualizar_Usuario";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@nombre", nombre);
            cmd.Parameters.AddWithValue("@apellido", apellido);
            cmd.Parameters.AddWithValue("@edad", edad);
            cmd.Parameters.AddWithValue("@email", email);
            cmd.ExecuteNonQuery();

        }

    }
}
