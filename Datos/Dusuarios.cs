using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using Usuarios_3_capas.Logica;
using System.Windows.Forms;
using System.Data;
using System.Xml;

namespace Usuarios_3_capas.Datos
{

    class Dusuarios
    {
        private SqlCommand cmd = new SqlCommand();
        private int idusuario;

        public bool insertar(Lusuarios dt)
        {
            try
            {
                CONEXIONMAESTRA.abrir();
                cmd = new SqlCommand("insertar_usuario", CONEXIONMAESTRA.conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Usuario", dt.Usuario);
                cmd.Parameters.AddWithValue("@Pass", dt.Pass);
                cmd.Parameters.AddWithValue("@Icono",dt.Icono);
                cmd.Parameters.AddWithValue("@Estado", dt.Estado);
                if(cmd.ExecuteNonQuery() != 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Mensaje de error: \n" +ex.Message);
                return false;
            }
            finally
            {
                CONEXIONMAESTRA.cerrar();
            }
        }

        public bool editar(Lusuarios dt)
        {
            try
            {
                CONEXIONMAESTRA.abrir();
                cmd = new SqlCommand("editar_usuarios", CONEXIONMAESTRA.conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id_Usuario",dt.Idusuario);
                cmd.Parameters.AddWithValue("@Usuario", dt.Usuario);
                cmd.Parameters.AddWithValue("@Pass", dt.Pass);
                cmd.Parameters.AddWithValue("@Icono", dt.Icono);
                cmd.Parameters.AddWithValue("@Estado", dt.Estado);
                if (cmd.ExecuteNonQuery() != 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Mensaje de error: \n" + ex.Message);
                return false;
            }
            finally
            {
                CONEXIONMAESTRA.cerrar();
            }
        }
        public DataTable mostrar_usuarios()
        {
            try
            {
                CONEXIONMAESTRA.abrir();
                cmd = new SqlCommand("mostrar_usuarios", CONEXIONMAESTRA.conexion);
                if(cmd.ExecuteNonQuery() != 0)
                {
                    DataTable dt = new DataTable();
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(dt);
                    return dt;
                }
                else
                {
                    return null;   
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Mensaje de Error en: \n" + ex.Message);
                return null;
            }
            finally
            {
                CONEXIONMAESTRA.cerrar();
            }
        }

        public bool eliminar_usuarios(Lusuarios dt)
        {
            try
            {
                CONEXIONMAESTRA.abrir();
                cmd = new SqlCommand("eliminar_usuario", CONEXIONMAESTRA.conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id_Usuario", dt.Idusuario);
                if(cmd.ExecuteNonQuery() != 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en: "+ ex.Message);
                return false;
            }
            finally
            {
                CONEXIONMAESTRA.cerrar();
            }
        }

        public DataTable buscar_usuarios(string parameters)
        {
            try
            {
                CONEXIONMAESTRA.abrir();
                cmd = new SqlCommand("buscar_usuarios", CONEXIONMAESTRA.conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@buscador", parameters);
                if (cmd.ExecuteNonQuery() != 0)
                {
                    DataTable dt = new DataTable();
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(dt);
                    return dt;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Mensaje de Error en: \n" + ex.Message);
                return null;
            }
            finally
            {
                CONEXIONMAESTRA.cerrar();
            }
        }
    }
}
