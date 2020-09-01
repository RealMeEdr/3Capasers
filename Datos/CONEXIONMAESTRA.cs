using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace Usuarios_3_capas.Datos
{
   internal static class CONEXIONMAESTRA
    {
        public static SqlConnection conexion = new SqlConnection("Data Source=ERYZENi5;Initial Catalog=CAPAS_USUARIOS;Integrated Security=True");

        public static void abrir()
        {
            if (conexion.State == ConnectionState.Closed)
            {
                conexion.Open();
            }
            else
            {
                MessageBox.Show("Error al intentar enlazar la base de datos");
            }
        }

        public static void cerrar()
        {
            if (conexion.State == ConnectionState.Open)
            {
                conexion.Close();
            }
            else
            {
                MessageBox.Show("Error al intentar enlazar la base de datos");
            }
        }
    }
}
