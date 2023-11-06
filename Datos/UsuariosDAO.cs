using System;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using Modelos;
using System.Data;
using System.Diagnostics.Contracts;

namespace Datos
{
    public class UsuariosDAO
    {
        public Model_Usuarios ObtenerTodo(int ID)
        {
            Model_Usuarios User = null;
            //Conectarme
            if (ConexionBD.Conectar())
            {
                try
                {
                    String select = @"Select Id,Nombre,Ap_Paterno,Ap_Materno,Usuario,Card_Expired from usuarios where Id=@ID";


                    //Definir un datatable para que sea llenado
                    DataTable dt = new DataTable();
                    //Crear el dataadapter
                    MySqlCommand sentencia = new MySqlCommand(select);
                    //Asignar los parámetros
                    sentencia.Parameters.AddWithValue("@ID", ID);
                    sentencia.Connection = ConexionBD.conexion;

                    MySqlDataAdapter da = new MySqlDataAdapter(sentencia);

                    //Llenar el datatable
                    da.Fill(dt);
                    //Revisar si hubo resultados
                    if (dt.Rows.Count > 0)
                    {
                        DataRow fila = dt.Rows[0];
                        User = new Model_Usuarios()
                        {
                            ID = Convert.ToInt32(fila["Id"]),
                            Nombre = fila["Nombre"].ToString(),
                            Apellido_Paterno = fila["Ap_Paterno"].ToString(),
                            Apellido_Materno = fila["Ap_Materno"].ToString(),
                            Usuario = fila["Usuario"].ToString(),
                            Numero_Tarjeta = fila["Numero_Tarjeta"].ToString(),
                            Card_Expired = fila[""].ToString(),

                        };

                    }

                    return User;
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

        public Model_Usuarios login(String Usu, String Contra)
        {
            Model_Usuarios User = null;
            //Conectarme
            if (ConexionBD.Conectar())
            {
                try
                {
                    String select = @"Select Id,Nombre,Usuario from usuarios where contrasenia = sha2(@password,256) and Usuario=@usuario;";


                    //Definir un datatable para que sea llenado
                    DataTable dt = new DataTable();
                    //Crear el dataadapter
                    MySqlCommand sentencia = new MySqlCommand(select);
                    //Asignar los parámetros
                    sentencia.Parameters.AddWithValue("@usuario", Usu);
                    sentencia.Parameters.AddWithValue("@password", Contra);

                    sentencia.Connection = ConexionBD.conexion;

                    MySqlDataAdapter da = new MySqlDataAdapter(sentencia);

                    //Llenar el datatable
                    da.Fill(dt);
                    //Revisar si hubo resultados
                    if (dt.Rows.Count > 0)
                    {
                        DataRow fila = dt.Rows[0];
                        User = new Model_Usuarios()
                        {
                            ID = Convert.ToInt32(fila["Id"]),
                            Nombre = fila["Nombre"].ToString(),
                            Usuario = fila["Usuario"].ToString()
                        };

                    }

                    return User;
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