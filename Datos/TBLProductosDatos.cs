using CRUDPROJECT.Models;
using System.Data.SqlClient;
using System.Data;


namespace CRUDPROJECT.Datos
{
    public class TBLProductosDatos
    {

        public List<TBLPRODUCTOSModel> Listar()
        {
            var oLista = new List<TBLPRODUCTOSModel>();
            var cn = new Conexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_listar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read()) {
                        oLista.Add(new TBLPRODUCTOSModel()
                        {
                            IdProducto = Convert.ToInt32(dr["IdProducto"]),
                            NombreProd = dr["NombreProd"].ToString(),
                            Precio = Convert.ToInt32(dr["Precio"]),
                            DescripcionProd = dr["DescripcionProd"].ToString()
                        });
                }
            }
        }


            return oLista;
    }

        public TBLPRODUCTOSModel Obtener(int IdProducto)
        {
            {
                var oProductos = new TBLPRODUCTOSModel();
                var cn = new Conexion();
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_Obtener", conexion);
                    cmd.Parameters.AddWithValue("IdProducto", IdProducto);
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            oProductos.IdProducto = Convert.ToInt32(dr["IdProducto"]);
                            oProductos.NombreProd = dr["NombreProd"].ToString();
                            oProductos.Precio = Convert.ToInt32(dr["Precio"]);
                            oProductos.DescripcionProd = dr["DescripcionProd"].ToString();


                        }
                    }
                }


                return oProductos;
            }
        }


           public bool Guardar(TBLPRODUCTOSModel oProducto)
            {
            bool rpta;

            try
            {
                var cn = new Conexion();
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_Guardar", conexion);
                    cmd.Parameters.AddWithValue("NombreProd", oProducto.NombreProd);
                    cmd.Parameters.AddWithValue("Precio", oProducto.Precio);
                    cmd.Parameters.AddWithValue("DescripcionProd", oProducto.DescripcionProd);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                rpta = true;
            }
            catch (Exception e)
            {
                string error = e.Message;
                rpta = false;



            }
            return rpta;

    }

        public bool Editar(TBLPRODUCTOSModel oProducto)
        {
            bool rpta;

            try
            {
                var cn = new Conexion();
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_Editar", conexion);
                    cmd.Parameters.AddWithValue("IdProducto", oProducto.IdProducto);
                    cmd.Parameters.AddWithValue("NombreProd", oProducto.NombreProd);
                    cmd.Parameters.AddWithValue("Precio", oProducto.Precio);
                    cmd.Parameters.AddWithValue("DescripcionProd", oProducto.DescripcionProd);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                rpta = true;
            }
            catch (Exception e)
            {
                string error = e.Message;
                rpta = false;



            }
            return rpta;

        }

        public bool Eliminar(int IdProducto)
        {
            bool rpta;

            try
            {
                var cn = new Conexion();
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_Eliminar", conexion);
                    cmd.Parameters.AddWithValue("IdProducto", IdProducto);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                rpta = true;
            }
            catch (Exception e)
            {
                string error = e.Message;
                rpta = false;
            }
            return rpta;

        }



    }
}
