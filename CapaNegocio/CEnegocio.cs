
using System.Data;
using CapaDatos;
using CapaEntidad;

namespace CapaNegocio
{
    public class CEnegocio
    {
        CDClientes capaDatos = new CDClientes();
        public bool ValidaCliente(CEClientes cecliente)
        {
            bool validacion = true;
           

            if (cecliente.Nombre == String.Empty)
            {
                validacion = false;
                MessageBox.Show("FALTA EL NOMBRE");
            }

            if (cecliente.Apellido == String.Empty)
            {
                validacion = false;
                MessageBox.Show("FALTA EL apellido");
            }

            if (cecliente.Foto == null)
            {
                validacion = false;
                MessageBox.Show("FALTA LA FOTO");
            }




            return validacion;


        }

        public void pruebaMysql()
        {
            capaDatos.pruebaConexion();
        }


        public void crearCliente(CEClientes cE)
        {
            capaDatos.crear(cE);
        }


        public void EditarCliente(CEClientes cE)
        {
            capaDatos.Editar(cE);
        }


        public DataSet obtenerDatos()
        {
           return capaDatos.Listar();  
        }


        public void EliminarCliente(CEClientes cE)
        {
            capaDatos.Eliminar(cE);
        }



    }
}