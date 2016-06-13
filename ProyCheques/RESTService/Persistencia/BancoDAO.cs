using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using RESTService.Dominio;

namespace RESTService.Persistencia
{
    public class BancoDAO
    {
        public Banco Obtener(string cod)
        {
            Banco bancoEncontrado = null;
            string sql = "SELECT * FROM tbl_Banco WHERE Cod_Banco = @cod";
            using (SqlConnection con = new SqlConnection(ConexionUtil.Cadena))
            {
                con.Open();
                using (SqlCommand com = new SqlCommand(sql, con))
                {
                    com.Parameters.Add(new SqlParameter("@cod", cod));
                    using (SqlDataReader resultado = com.ExecuteReader())
                    {
                        if (resultado.Read())
                        {
                            bancoEncontrado = new Banco()
                            {
                                codigo = resultado["Cod_Banco"].ToString(),
                                descripcion = resultado["Des_Banco"].ToString(),
                                estado = (bool)resultado["Est_Banco"]
                            };
                        }
                    }
                }
            }
            return bancoEncontrado;
        }

        public Banco Crear(Banco bancoACrear)
        {
            Banco bancoCreado = null;
            string sql = "INSERT INTO tbl_Banco VALUES(@cod,@des,1)";
            using (SqlConnection con = new SqlConnection(ConexionUtil.Cadena))
            {
                con.Open();
                using (SqlCommand com = new SqlCommand(sql, con))
                {
                    com.Parameters.Add(new SqlParameter("@cod", bancoACrear.codigo));
                    com.Parameters.Add(new SqlParameter("@des", bancoACrear.descripcion));
                    com.ExecuteNonQuery();
                }
            }
            bancoCreado = Obtener(bancoACrear.codigo);
            return bancoCreado;
        }

        public Banco Modificar(Banco bancoAModificar)
        {
            Banco bancoModificado = null;
            string sql = "UPDATE tbl_Banco SET Des_Banco = @des, Est_Banco = @est WHERE Cod_Banco = @cod";
            using (SqlConnection con = new SqlConnection(ConexionUtil.Cadena))
            {
                con.Open();
                using (SqlCommand com = new SqlCommand(sql, con))
                {
                    com.Parameters.Add(new SqlParameter("@cod", bancoAModificar.codigo));
                    com.Parameters.Add(new SqlParameter("@des", bancoAModificar.descripcion));
                    com.Parameters.Add(new SqlParameter("@est", bancoAModificar.estado));
                    com.ExecuteNonQuery();
                }
            }
            bancoModificado = Obtener(bancoAModificar.codigo);
            return bancoModificado;
        }

        public void Eliminar(string cod)
        {
            string sql = "DELETE FROM tbl_Banco WHERE Cod_Banco = @cod";
            using (SqlConnection con = new SqlConnection(ConexionUtil.Cadena))
            {
                con.Open();
                using (SqlCommand com = new SqlCommand(sql, con))
                {
                    com.Parameters.Add(new SqlParameter("@cod", cod));
                    com.ExecuteNonQuery();
                }
            }
        }

        public List<Banco> Listar()
        {
            List<Banco> bancosEncontrados = new List<Banco>();
            Banco bancoEncontrado = default(Banco);
            string sql = "SELECT * FROM tbl_Banco";
            using (SqlConnection con = new SqlConnection(ConexionUtil.Cadena))
            {
                con.Open();
                using (SqlCommand com = new SqlCommand(sql, con))
                {
                    using (SqlDataReader resultado = com.ExecuteReader())
                    {
                        while (resultado.Read())
                        {
                            bancoEncontrado = new Banco()
                            {
                                codigo = resultado["Cod_Banco"].ToString(),
                                descripcion = resultado["Des_Banco"].ToString(),
                                estado = (bool)resultado["Est_Banco"]
                            };
                            bancosEncontrados.Add(bancoEncontrado);
                        }
                    }
                }
            }
            return bancosEncontrados;
        }
    }
}