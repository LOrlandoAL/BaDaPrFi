using Google.Protobuf.WellKnownTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Modelos
{
    public class Model_Usuarios
    {
        public int ID { get; set; }
        public String Nombre { get; set; }
        public String Apellido_Paterno { get; set; }
        public String Apellido_Materno { get; set; }
        public String Usuario { get; set; }
        public String Contrasena { get; set; }
        public String Numero_Tarjeta { get; set; }
        public String Card_Expired { get; set; }
        public String CVV { get; set; }

        public Model_Usuarios(int id, string nombre, string app, string apm,
            string user, string psw, string cardNum, string cardExp, string cvv)
        {
            ID = id;
            Nombre = nombre;
            Apellido_Paterno = app;
            Apellido_Materno = apm;
            Usuario = user;
            Contrasena = psw;
            Numero_Tarjeta = cardNum;
            Card_Expired = cardExp;
            CVV = cvv;
        }

        public Model_Usuarios() 
        {
            ID = 0;
            Nombre = "";
            Apellido_Paterno = "";
            Apellido_Materno = "";
            Usuario = "";
            Contrasena = "";
            Numero_Tarjeta = "";
            Card_Expired = "";
            CVV = "";
        }


    }

}