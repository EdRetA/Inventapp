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
       static string conectionString = System.Configuration.ConfigurationManager.ConnectionStrings["InventAPPCS"].ConnectionString;

        SqlConnection con = new SqlConnection(conectionString);
        
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
                
        public List<entradaEnt> BuscarEntrada(entradaEnt entradaD)
        {
            try
            {
                DataTable dt = new DataTable();
                SqlCommand cmd = new SqlCommand("Select id,nombre,lote,cantidad,proveedor, fabricacion, vencimiento, ingreso from vEntradas Where lote=@lote", con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@lote", entradaD.lote);
                con.Open();
                var da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                con.Close();
                List<entradaEnt> ListaEntradas = new List<entradaEnt>();
                foreach (DataRow row in dt.Rows)
                {
                    ListaEntradas.Add(new entradaEnt() { producto = (int)row["id"], productoN = row["nombre"].ToString(), lote = entradaD.lote, cantidad = (int)row["cantidad"], proveedor = row["proveedor"].ToString(), ffabricacion = row["fabricacion"].ToString(), fvencimiento = row["vencimiento"].ToString(), fingreso = row["ingreso"].ToString()  });
                }
                return ListaEntradas;
            }
            catch (Exception ex)
            {
                DataTable dt = new DataTable();
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                List<entradaEnt> ListaEntradas = new List<entradaEnt>();
                return ListaEntradas;
            }
        }

        public List<entradaEnt> BuscarEntradaUn(entradaEnt entradaD)
        {
            try
            {
                DataTable dt = new DataTable();
                SqlCommand cmd = new SqlCommand("Select id,nombre,lote,cantidad,proveedor, fabricacion, vencimiento, ingreso from vEntradas Where lote=@lote and id=@producto", con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@lote", entradaD.lote);
                cmd.Parameters.AddWithValue("@producto", entradaD.producto);
                con.Open();
                var da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                con.Close();
                List<entradaEnt> Entrada = new List<entradaEnt>();
                foreach (DataRow row in dt.Rows)
                {
                    Entrada.Add(new entradaEnt() { producto = (int)row["id"], productoN = row["nombre"].ToString(), cantidad = (int)row["cantidad"], proveedor= row["proveedor"].ToString(), ffabricacion= row["fabricacion"].ToString(), fvencimiento=row["vencimiento"].ToString(), fingreso = row["ingreso"].ToString(), lote = (int)row["lote"] });
                }
                return Entrada;
            }
            catch (Exception ex)
            {
                DataTable dt = new DataTable();
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                List<entradaEnt> ListaEntradas = new List<entradaEnt>();
                return ListaEntradas;
            }
        }

        public string ActualizarEntrada(entradaEnt entradaD)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("sp_updEntrada", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", entradaD.producto);                
                cmd.Parameters.AddWithValue("@ffabricacion", entradaD.ffabricacion);
                cmd.Parameters.AddWithValue("@fvencimiento", entradaD.fvencimiento);
                cmd.Parameters.AddWithValue("@fingreso", entradaD.fingreso);
                cmd.Parameters.AddWithValue("@proveedor", entradaD.proveedor);
                cmd.Parameters.AddWithValue("@cantidad", entradaD.cantidad);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                return ("Producto actualizado satisfactoriamente");
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