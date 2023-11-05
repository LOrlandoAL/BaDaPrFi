using System;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using Modelos;
using System.Data;

namespace Datos
{
    public class UsuariosDAO
    {
        public List<Model_Usuarios> GetAll()
        {
            List<Model_Usuarios> lista = new List<Model_Usuarios>();

            if (ConexionBD.Conectar())
            {
                try
                {
                    String select = @"SELECT * FROM Usuarios;";

                    DataTable dt = new DataTable();
                    MySqlCommand sentencia = new MySqlCommand();
                    sentencia.CommandText = select;
                    sentencia.Connection = ConexionBD.conexion;
                    MySqlDataAdapter da = new MySqlDataAdapter();
                    da.SelectCommand = sentencia;
                    da.Fill(dt);

                    foreach (DataRow fila in dt.Rows)
                    {
                        Model_Usuarios Usuario = new Model_Usuarios(
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

        }
    }
}