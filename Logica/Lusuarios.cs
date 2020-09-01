using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Usuarios_3_capas.Logica
{
    class Lusuarios
    {
        //se deben declarar privados ya que solo se utilizarán en esta clase
        private int idusuario;
        private string usuarios;
        private string pass;
        private byte[] icono;
        private string estado;

        //Se deben declarar los Métodos. publicos
        public int Idusuario
        {
            get { return idusuario; }
            set { idusuario = value; }
        }

        public string Usuario
        {
            get { return usuarios; }
            set { usuarios = value; }
        }

        public string Pass
        {
            get { return pass; }
            set { pass = value; }
        }

        public byte[] Icono
        {
            get { return icono; }
            set { icono = value; }
        }

        public string Estado
        {
            get { return estado; }
            set { estado = value; }
        }

        public Lusuarios()
        {

        }
        //private int idusuario;
        //private string usuarios;
        //private string pass;
        //private byte[] icono;
        //private string estado;
        public Lusuarios(int idusuario, string usuarios, string pass, byte[] icono, string estado)
        {
            Idusuario = idusuario;
            Usuario = usuarios;
            Pass = pass;
            Icono = icono;
            Estado = estado;
        }
    }
}
