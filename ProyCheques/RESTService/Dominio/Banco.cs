using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace RESTService.Dominio
{
    [DataContract]
    public class Banco
    {
        [DataMember]
        public string codigo { get; set; }
        [DataMember]
        public string descripcion { get; set; }
        [DataMember]
        public bool estado { get; set; }
    }
}