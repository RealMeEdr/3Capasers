using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Windows.Forms;
using Usuarios_3_capas.Datos;
using Usuarios_3_capas.Logica;

namespace Usuarios_3_capas
{
    public partial class Usuarios : Form
    {
        public Usuarios()
        {
            InitializeComponent();
        }
        int idusuarios;
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            PanelUsuario.Visible = true;
            btnGuardar.Visible = true;
            btnGurdarCambios.Visible = false;
            txtUsuario.Clear();
            txtPass.Clear();
        }

        private void Icono_Click(object sender, EventArgs e)
        {
            dlg.InitialDirectory = "";
            dlg.Filter = "Imagenes|*.jpg;*.png";
            dlg.FilterIndex = 2;
            dlg.Title = "Cargador de imagenes";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                Icono.BackgroundImage = null;
                Icono.Image = new Bitmap(dlg.FileName);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if(txtUsuario.Text != "")
            {
                if (txtPass.Text != "")
                {
                    insertar_usuario();
                    mostrar_usuarios();
                }
                else
                {
                    MessageBox.Show("Ingrese una Contraseña", "Sin Contraseña", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Ingrese un Usuario", "Sin usuario",MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void insertar_usuario()
        {
            Lusuarios dt = new Lusuarios();
            Dusuarios funcion = new Dusuarios();
            dt.Usuario = txtUsuario.Text;
            dt.Pass = txtPass.Text;
            //esta serie de comandos es para poder Convertir de formato Image parapoder procesar la imagen en la base de datos
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            Icono.Image.Save(ms, Icono.Image.RawFormat);
            dt.Icono = ms.GetBuffer();
            dt.Estado = "ACTIVO";

            //Después se va a comprobar que los datos hayan sido correctos
            if (funcion.insertar(dt))
            {
                MessageBox.Show("Usuario Registrado con Éxito", "Acción Correcta", MessageBoxButtons.OK);
                PanelUsuario.Visible = false;
                PanelUsuario.Dock = DockStyle.None;
            }
        }

        private void btnAgregar_Click_1(object sender, EventArgs e)
        {
            PanelUsuario.Visible = true;
            PanelUsuario.Dock = DockStyle.Fill;
            btnGuardar.Visible = true;
            btnGurdarCambios.Visible = false;
           
        }

        private void mostrar_usuarios()
        {
            DataTable dt;
            Dusuarios funcion = new Dusuarios();
            dt = funcion.mostrar_usuarios();
            dataListado.DataSource = dt;
        }

        private void Usuarios_Load(object sender, EventArgs e)
        {
            mostrar_usuarios();
        }

        private void dataListado_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            idusuarios = Convert.ToInt32(dataListado.SelectedCells[2].Value.ToString());
            if (e.ColumnIndex == this.dataListado.Columns["Eliminar"].Index)
            {
                DialogResult result;

                result = MessageBox.Show("¿Realmente desea eliminar este usuario? toda su información será borrada y no se podrá recuperar","Eliminando Registros",MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if(result== DialogResult.Yes)
                {
                    Eliminar_usuarios();
                    mostrar_usuarios();
                }
            }
            if (e.ColumnIndex == this.dataListado.Columns["Editar"].Index)
            {
                idusuarios = Convert.ToInt32(dataListado.SelectedCells[2].Value.ToString());
                txtUsuario.Text = dataListado.SelectedCells[3].Value.ToString();
                txtPass.Text = dataListado.SelectedCells[4].Value.ToString();
                Icono.BackgroundImage = null;
                byte[] b = (Byte[])dataListado.SelectedCells[5].Value;
                System.IO.MemoryStream ms = new System.IO.MemoryStream(b);

                Icono.Image = Image.FromStream(ms);

                PanelUsuario.Visible = true;
                PanelUsuario.Dock = DockStyle.Fill;
                btnGuardar.Visible = false;
                btnGurdarCambios.Visible = true;
            }
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            PanelUsuario.Visible = false;
            PanelUsuario.Dock = DockStyle.None;
        }

        private void btnGurdarCambios_Click(object sender, EventArgs e)
        {
            Editar_usuario();
            mostrar_usuarios();
        }
        private void Editar_usuario()
        {
            Lusuarios dt = new Lusuarios();
            Dusuarios funcion = new Dusuarios();
            dt.Idusuario = idusuarios;
            dt.Usuario = txtUsuario.Text;
            dt.Pass = txtPass.Text;
            //esta serie de comandos es para poder Convertir de formato Image parapoder procesar la imagen en la base de datos
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            Icono.Image.Save(ms, Icono.Image.RawFormat);
            dt.Icono = ms.GetBuffer();
            dt.Estado = "ACTIVO";

            //Después se va a comprobar que los datos hayan sido correctos
            if (funcion.editar(dt))
            {
                MessageBox.Show("Información de Usuario Actualizada con Éxito", "Actualización Correcta", MessageBoxButtons.OK);
                PanelUsuario.Visible = false;
                PanelUsuario.Dock = DockStyle.None;
            }
        }

        private void Eliminar_usuarios()
        {
            Lusuarios dt = new Lusuarios();
            Dusuarios funcion = new Dusuarios();
            dt.Idusuario = idusuarios;
            if (funcion.eliminar_usuarios(dt))
            {
                MessageBox.Show("Usuario Eiminado", "Eliminación de Usuarios correcta");
                PanelUsuario.Visible = false;
                PanelUsuario.Dock = DockStyle.None;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            buscar_usuarios();
        }
        private void buscar_usuarios()
        {
            DataTable dt;
            Dusuarios funcion = new Dusuarios();
            dt = funcion.buscar_usuarios(textBox1.Text);
            dataListado.DataSource = dt;
        }

    }
}
