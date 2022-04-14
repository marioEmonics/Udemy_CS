using System;
using MySql.Data.MySqlClient;
using CapaEntidad;
using System.Data;


namespace CapaDatos
{
    public class CDClientes
    {
        string cadenaConexion = "Server=127.0.0.1;User=root;Password=123456;Port=3306;database=curso_cs";
       

        public void pruebaConexion()
        {
            MySqlConnection conn = new MySqlConnection(cadenaConexion);

            try
                {
                    conn.Open();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("ERROR AL CONECTAR" + ex.Message);
                    return;
                }
            
            conn.Close();
            MessageBox.Show("EXITO EN LA CONEXION");



        }


        public void crear(CEClientes cE)
        {
            int i = 0;
            MySqlConnection conn = new MySqlConnection(cadenaConexion);
            conn.Open();
            string query = " INSERT INTO `clientes` (`nombre`, `apellido`, `foto`) VALUES('"+ cE.Nombre + "','"+ cE.Apellido +"','"+ MySql.Data.MySqlClient.MySqlHelper.EscapeString(cE.Foto) +"')";
            MySqlCommand mySqlCommand = conn.CreateCommand();   
            mySqlCommand.CommandText = query;
            i=mySqlCommand.ExecuteNonQuery();             
            conn.Close();
            MessageBox.Show("REGISTROS CREADOS: " + i);



        }


        public void Editar(CEClientes cE)
        {
            MySqlConnection mySqlConnection = new MySqlConnection(cadenaConexion);
            mySqlConnection.Open();
            string Query = "UPDATE `clientes` SET `nombre`='" + cE.Nombre + "', `apellido`='" + cE.Apellido + "', `foto`='" + MySql.Data.MySqlClient.MySqlHelper.EscapeString(cE.Foto) + "' WHERE  `id`=" + cE.Id + ";";
            MySqlCommand mySqlCommand = new MySqlCommand(Query, mySqlConnection);
            mySqlCommand.ExecuteNonQuery();
            mySqlConnection.Close();
            MessageBox.Show("Registro Actualizado!");


        }





        public DataSet Listar()
        {           
            MySqlConnection conn = new MySqlConnection(cadenaConexion);
            DataSet ds = new DataSet();            
            conn.Open();
            string query = "SELECT * FROM clientes";
            MySqlDataAdapter adapter = new MySqlDataAdapter(query, cadenaConexion);
            adapter.Fill(ds,"tabla");
            return ds;



        }


        public void Eliminar(CEClientes cE)
        {
            MySqlConnection mySqlConnection = new MySqlConnection(cadenaConexion);
            mySqlConnection.Open();
            string Query = "DELETE FROM `clientes` WHERE  `id`=" + cE.Id + ";";
            MySqlCommand mySqlCommand = new MySqlCommand(Query, mySqlConnection);
            mySqlCommand.ExecuteNonQuery();
            mySqlConnection.Close();
            MessageBox.Show("Registro Eliminado!");


        }





    }
}