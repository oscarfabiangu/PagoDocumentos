using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RESTService.Persistencia
{
    public class ConexionUtil
    {
        public static string Cadena
        {
            get
            {
                return @"Data Source=LAPTOP2\SQLEXPRESS;Initial Catalog=BD_CHEQUES;Integrated Security=SSPI;";
            }
        }
    }
}