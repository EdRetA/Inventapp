using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Inventapp.Models
{
    public class ProductoDAL
    {
        SqlConnection con = new SqlConnection("Data Source=10.60.0.169;Initial Catalog=dbInventario;User ID=desa;Password=Desa.123");

        public string AgregarProducto(ProductoEnt entrada)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("sp_insProducto", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@nombre", entrada.productoN);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                return ("Producto agregado satisfactoriamente");
            }
            catch (Exception ex)
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                return (ex.Message.ToString());
            }
        }
    }
}
