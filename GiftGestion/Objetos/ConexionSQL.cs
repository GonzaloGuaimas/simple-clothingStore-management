using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace GiftGestion.Objetos
{
    public class ConexionSQL
    {
        MySqlConnection conexion = new MySqlConnection();

        string cadena = "";

        public string AgregarProducto(string nom,string desc)
        {
            string result = "";
            try
            {
                conexion.ConnectionString = cadena;
                conexion.Open();
                string comando = "INSERT INTO Productos (id, nombre, descripcion) VALUES (12,'adsasdasdsa','fdgfkhnjd')";

                MySqlCommand cmd = new MySqlCommand(comando, conexion);

                cmd.ExecuteNonQuery();

                conexion.Close();

                result = "Agregado";


            }catch(Exception es)
            {
                result = es.Message;
            }
            return result;
        }
    }
}
