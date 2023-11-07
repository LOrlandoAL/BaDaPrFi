using System;
using MySql.Data.MySqlClient;
using Modelos;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class Usuarios
    {
        public List<Usuarios> GetAll()
        {
            List<Usuarios> lista = new List<Usuarios>();

            if (ConexionBD.Conectar())
            {
                try
                {
                    String select = @"SELECT * FROM Usuarios;";

                    DataTable dt = new DataTable();
                    MySqlCommand sentencia = new MysqlCommand();
                    sentencia.CommandText = select;
                    sentencia.Connectioin = ConexionBD.conexion;
                    MySqlDataAdapter da = new MySqlDataAdapter();
                    da.SalectCommand = sentencia;
                    da.Fill(dt);

                    foreach (DataRow fila in dt.Rows)
                    {
                        Usuarios Usuario = new Usuarios(
                            Convert.ToInt32(fila["ID"]),
                            fila["nombre"].ToString(),
                            fila["ap_paterno"].ToString(),
                            fila["ap_materno"].ToString(),
                            fila["usuario"].ToString(),
                            fila["contraseña"].ToString(),
                            fila["no_tarjeta"].ToString(),
                            fila["card_expired"].ToString(),
                            fila["cvv"].ToString());
                        lista.Add(Usuario);
                    }
                    return lista;
                }
                finally
                {
                    ConexionBD.Desconectar();
                }
            }
            else
            {
                return null;
            }

            return null;
    }
    }
}
