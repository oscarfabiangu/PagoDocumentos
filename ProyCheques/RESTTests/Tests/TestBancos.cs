using System;
using System.IO;
using System.Net;
using System.Text;
using System.Collections.Generic;
using System.Web.Script.Serialization;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RESTTests.Dominio;

namespace RESTTests.Tests
{
    [TestClass]
    public class TestBancos
    {
        [TestMethod]
        public void Test01ObtenerOk()
        {
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create("http://localhost:6252/Interfaces/Bancos.svc/Bancos/BCP");
            req.Method = "GET";
            HttpWebResponse res = (HttpWebResponse)req.GetResponse();
            StreamReader reader = new StreamReader(res.GetResponseStream());
            string bancoJson = reader.ReadToEnd();
            JavaScriptSerializer js = new JavaScriptSerializer();
            Banco bancoObtenido = js.Deserialize<Banco>(bancoJson);
            Assert.AreEqual("BCP", bancoObtenido.codigo);
            Assert.AreEqual("Banco de Crédito del Perú", bancoObtenido.descripcion);
            Assert.AreEqual(true, bancoObtenido.estado);
        }

        [TestMethod]
        public void Test02ObtenerException()
        {
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create("http://localhost:6252/Interfaces/Bancos.svc/Bancos/BBVA");
            req.Method = "GET";
            try
            {
                HttpWebResponse res = (HttpWebResponse)req.GetResponse();
                StreamReader reader = new StreamReader(res.GetResponseStream());
                string bancoJson = reader.ReadToEnd();
                JavaScriptSerializer js = new JavaScriptSerializer();
                Banco bancoObtenido = js.Deserialize<Banco>(bancoJson);
                Assert.AreEqual("BBVA", bancoObtenido.codigo);
                Assert.AreEqual("Banco Continental", bancoObtenido.descripcion);
                Assert.AreEqual(true, bancoObtenido.estado);
            }
            catch (WebException ex)
            {
                HttpStatusCode code = ((HttpWebResponse)ex.Response).StatusCode;
                StreamReader sr = new StreamReader(ex.Response.GetResponseStream());
                string error = sr.ReadToEnd();
                JavaScriptSerializer js = new JavaScriptSerializer();
                string mensajeException = js.Deserialize<string>(error);
                Assert.AreEqual("El código BBVA no existe", mensajeException);
            }
        }
    }
}
