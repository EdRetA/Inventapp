using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Inventapp.Models
{
    public class entradaDAL
    {
        SqlConnection con = new SqlConnection("Data Source=10.60.0.169;Initial Catalog=dbInventario;User ID=desa;Password=Desa.123");
        
        public string AgregarEntrada(entradaEnt entrada)
        {
            try
            {                
                SqlCommand cmd = new SqlCommand("sp_insEntrada", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@producto", entrada.productoN);
                cmd.Parameters.AddWithValue("@lote", entrada.lote);
                cmd.Parameters.AddWithValue("@ffabricacion", entrada.ffabricacion);
                cmd.Parameters.AddWithValue("@fvencimiento", entrada.fvencimiento);
                cmd.Parameters.AddWithValue("@fingreso", entrada.fingreso);
                cmd.Parameters.AddWithValue("@cantidad", entrada.cantidad);
                cmd.Parameters.AddWithValue("@proveedor", entrada.proveedor);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                return ("Entrada de producto agregada satisfactoriamente");
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

        public string AgregarProducto(entradaEnt entrada)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("sp_insProducto", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@producto", entrada.productoN);                
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

        public List<string> BuscarProductos()
        {
            try
            {
                DataTable dt = new DataTable();
                SqlCommand cmd = new SqlCommand("Select nombre from vProducto", con);
                cmd.CommandType = CommandType.Text;                
                con.Open();
                var da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                con.Close();
                List<string> Lista = new List<string>();
                foreach (DataRow row in dt.Rows)
                {
                    Lista.Add(row["nombre"].ToString());
                }
                return Lista;
            }
            catch (Exception ex)
            {
                DataTable dt = new DataTable();
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                return new List<string>(new string[] { "Error"});
            }
        }

        public List<Inventario> CargarFaltante()
        {
            try
            {
                DataTable dt = new DataTable();
                SqlCommand cmd = new SqlCommand("Select Producto,cantidad from vCantProductos", con);
                cmd.CommandType = CommandType.Text;
                con.Open();
                var da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                con.Close();

                List<Inventario> Lista = new List<Inventario>();
                foreach (DataRow row in dt.Rows)
                {
                    Lista.Add(new Inventario() { productoN = row["Producto"].ToString(), cantidad = (int)row["cantidad"] });
                }
                return Lista;
            }
            catch (Exception ex)
            {
                DataTable dt = new DataTable();
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                List<Inventario> Lista = new List<Inventario>();
                return Lista;
                
            }
        }
    }

}