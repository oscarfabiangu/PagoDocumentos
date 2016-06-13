using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using RESTService.Dominio;

namespace RESTService.Interfaces
{
    [ServiceContract]
    public interface IBancos
    {
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "Bancos/{codigo}", ResponseFormat = WebMessageFormat.Json)]
        Banco ObtenerBanco(string codigo);        
    }
}
