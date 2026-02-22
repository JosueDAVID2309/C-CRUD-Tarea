using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Datos
{
    public class CD_Conexion
    {
        SqlConnection conexion = new SqlConnection("Data Source=localhost\\SQLEXPRESS; Initial Catalog=prueba; Integrated Security=True;  ");

        public SqlConnection AbrirConexion()
        {
            if(conexion.State == ConnectionState.Closed)
                conexion.Open();
            return conexion;
        }

        public SqlConnection  CerrarConexion()
        {
            if (conexion.State == ConnectionState.Open)
                conexion.Close();
            return conexion;
        }

    }
}
