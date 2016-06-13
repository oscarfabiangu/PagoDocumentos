using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using RESTService.Dominio;
using RESTService.Persistencia;

namespace RESTService.Interfaces
{
    public class Bancos : IBancos
    {
        BancoDAO bancoDAO = new BancoDAO();

        public Banco ObtenerBanco(string codigo)
        {
            Banco bancoObtenido = bancoDAO.Obtener(codigo);
            if (bancoObtenido == null)
            {
                throw new WebFaultException<string>("El código " + codigo + " no existe", HttpStatusCode.NotFound);
            }
            return bancoObtenido;
        }
    }
}
