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
                    String select = @"Select Id,Nombre,Ap_Paterno,Ap_Materno,Usuario, cast(aes_decrypt(No_Tarjeta,'CLAOMAEL')as char) AS No_Tarjeta,
                    cast(aes_decrypt(Card_Expired,'CLAOMAEL')as char) AS Card_Expired,
                    cast(aes_decrypt(CVV, 'CLAOMAEL')as char)As CVV from usuarios where Id=@ID;";


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
                            Numero_Tarjeta = fila["No_Tarjeta"].ToString(),
                            Card_Expired = fila["Card_Expired"].ToString(),
                            CVV = fila["CVV"].ToString()

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
        public int Actualizar(int Id, string Nombre, string Ap_Paterno, string Ap_Materno,
            string Usuario, string Contrasenia, string No_Tarjeta, string Card_Expired, string CVV)
        {
            if (ConexionBD.Conectar())
            {
                try
                {
                    // Crear la sentencia a ejecutar (UPDATE) con parámetros
                    string updateQuery = @"UPDATE usuarios SET 
                        ID = @ID,
                        Nombre = @Nombre,  
                        Ap_Paterno = @Ap_Paterno,
                        Ap_Materno = @Ap_Materno,
                        Usuario = @Usuario,
                        Contrasenia = Sha2(@Contrasenia,256),
                        No_Tarjeta = aes_encrypt(@No_Tarjeta,'CLAOMAEL'),
                        Card_Expired = aes_encrypt(@Card_Expired,'CLAOMAEL'),
                        CVV = aes_encrypt(@CVV,'CLAOMAEL')
                        WHERE ID = @id;";

                    MySqlCommand command = new MySqlCommand(updateQuery, ConexionBD.conexion);
                    command.Parameters.AddWithValue("@ID", Id);
                    command.Parameters.AddWithValue("@Usuario", Usuario);
                    command.Parameters.AddWithValue("@Contrasenia", Contrasenia);
                    command.Parameters.AddWithValue("@Nombre", Nombre);
                    command.Parameters.AddWithValue("@Ap_Paterno", Ap_Paterno);
                    command.Parameters.AddWithValue("@Ap_Materno", Ap_Materno);
                    command.Parameters.AddWithValue("@No_Tarjeta", No_Tarjeta);
                    command.Parameters.AddWithValue("@CVV", CVV);
                    command.Parameters.AddWithValue("@Card_Expired", Card_Expired);

                    command.Connection = ConexionBD.conexion;

                    // Ejecutar el comando y obtener el número de filas afectadas
                    int rowsAffected = command.ExecuteNonQuery();

                    return rowsAffected;
                }
                finally
                {
                    ConexionBD.Desconectar();
                }
            }
            else
            {
                return 0;
            }
        }

        public int ActNoPass(int Id, string Nombre, string Ap_Paterno, string Ap_Materno,
            string Usuario, string No_Tarjeta, string Card_Expired, string CVV)
        {
            if (ConexionBD.Conectar())
            {
                try
                {
                    // Crear la sentencia a ejecutar (UPDATE) con parámetros
                    string updateQuery = @"UPDATE usuarios SET 
                        ID = @ID,
                        Nombre = @Nombre,  
                        Ap_Paterno = @Ap_Paterno,
                        Ap_Materno = @Ap_Materno,
                        Usuario = @Usuario,
                        No_Tarjeta = aes_encrypt(@No_Tarjeta,'CLAOMAEL'),
                        Card_Expired = aes_encrypt(@Card_Expired,'CLAOMAEL'),
                        CVV = aes_encrypt(@CVV,'CLAOMAEL')
                        WHERE ID = @id;";

                    MySqlCommand command = new MySqlCommand(updateQuery, ConexionBD.conexion);
                    command.Parameters.AddWithValue("@ID", Id);
                    command.Parameters.AddWithValue("@Usuario", Usuario);
                    command.Parameters.AddWithValue("@Nombre", Nombre);
                    command.Parameters.AddWithValue("@Ap_Paterno", Ap_Paterno);
                    command.Parameters.AddWithValue("@Ap_Materno", Ap_Materno);
                    command.Parameters.AddWithValue("@No_Tarjeta", No_Tarjeta);
                    command.Parameters.AddWithValue("@CVV", CVV);
                    command.Parameters.AddWithValue("@Card_Expired", Card_Expired);

                    command.Connection = ConexionBD.conexion;

                    // Ejecutar el comando y obtener el número de filas afectadas
                    int rowsAffected = command.ExecuteNonQuery();

                    return rowsAffected;
                }
                finally
                {
                    ConexionBD.Desconectar();
                }
            }
            else
            {
                return 0;
            }
        }
    }

}