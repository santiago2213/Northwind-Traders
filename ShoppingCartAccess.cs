using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Santiago_HW3
{
    public class ShoppingCartAccess
    {
        internal static void AddProductToCart(string cartID, string prodID)
        {
            string connString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            SqlConnection conn = new SqlConnection(connString);

            SqlCommand cmd = conn.CreateCommand();

            cmd.CommandText = "spShoppingCartAdditem";
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            SqlParameter param = new SqlParameter("@cartID", cartID);
            param.SqlDbType = System.Data.SqlDbType.VarChar;
            cmd.Parameters.Add(param);//adds the prodID to the set of parameters

            param = new SqlParameter("@prodID", prodID);
            param.SqlDbType = System.Data.SqlDbType.Int;
            cmd.Parameters.Add(param);

            try
            {
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {

            }
            finally
            {
                cmd.Connection.Close();
            }
        }

        public static DataTable GetCartItems()
        {

            HttpContext context = HttpContext.Current;

            string cartID;

            if (context.Request.Cookies["NWTDbFinalProjSpring2022_CartID"] != null)
            {
                cartID = context.Request.Cookies["NWTDbFinalProjSpring2022_CartID"].Value;
            }
            else //no cookies on their machine
            {
                cartID = Guid.NewGuid().ToString();

                HttpCookie cookie = new HttpCookie("NWTDbFinalProjSpring2022e_CartID", cartID);

                TimeSpan timespan = new TimeSpan(10, 0, 0, 0);

                DateTime expirationTime = DateTime.Now.Add(timespan);

                cookie.Expires = expirationTime;

                //write thus cookie on their machine
                context.Response.Cookies.Add(cookie);
            }

            string connString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            SqlConnection conn = new SqlConnection(connString);
            SqlCommand cmd = conn.CreateCommand();

            cmd.CommandText = "spShoppingCartGetItems";
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            SqlParameter param = new SqlParameter("@cartid", cartID);
            param.DbType = System.Data.DbType.String;
            cmd.Parameters.Add(param);//adds the prodID to the set of parameters

            DataTable table = new DataTable();

            try
            {
                cmd.Connection.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                table.Load(rdr);
                rdr.Close();


            }
            catch (Exception ex)
            {

            }
            finally
            {
                cmd.Connection.Close();
            }

            return table;

        }


        internal static decimal GetCartTotal()
        {
            string cartID;

            HttpContext context = HttpContext.Current;

            if (context.Request.Cookies["NWTDbFinalProjSpring2022_CartID"] != null)
            {
                cartID = context.Request.Cookies["NWTDbFinalProjSpring2022_CartID"].Value;
            }
            else //no cookies on their machine
            {
                cartID = Guid.NewGuid().ToString();

                HttpCookie cookie = new HttpCookie("NWTDbFinalProjSpring2022_CartID", cartID);

                TimeSpan timespan = new TimeSpan(10, 0, 0, 0);

                DateTime expirationTime = DateTime.Now.Add(timespan);

                cookie.Expires = expirationTime;

                //write thus cookie on their machine
                context.Response.Cookies.Add(cookie);
            }

            string connString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            SqlConnection conn = new SqlConnection(connString);
            SqlCommand cmd = conn.CreateCommand();

            cmd.CommandText = "spShoppingCartGetTotalAmount";
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            SqlParameter param = new SqlParameter("@CartID", cartID);
            param.DbType = System.Data.DbType.String;
            cmd.Parameters.Add(param);//adds the cartID to the set of parameters


            decimal carttotal = 0;

            try
            {
                cmd.Connection.Open();
                decimal.TryParse(cmd.ExecuteScalar().ToString(), out carttotal);


            }
            catch (Exception ex)
            {

            }
            finally
            {
                cmd.Connection.Close();
            }

            return carttotal;
        }

        public static bool UpdateCart(string productID, int newQty)
        {

            string cartID;

            HttpContext context = HttpContext.Current;

            if (context.Request.Cookies["NWTDbFinalProjSpring2022_CartID"] != null)
            {
                cartID = context.Request.Cookies["NWTDbFinalProjSpring2022_CartID"].Value;
            }
            else //no cookies on their machine
            {
                cartID = Guid.NewGuid().ToString();

                HttpCookie cookie = new HttpCookie("NWTDbFinalProjSpring2022_CartID", cartID);

                TimeSpan timespan = new TimeSpan(10, 0, 0, 0);

                DateTime expirationTime = DateTime.Now.Add(timespan);

                cookie.Expires = expirationTime;

                //write thus cookie on their machine
                context.Response.Cookies.Add(cookie);
            }

            string connString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            SqlConnection conn = new SqlConnection(connString);

            SqlCommand cmd = conn.CreateCommand();

            cmd.CommandText = "spShoppingCartUpdateItem";
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            SqlParameter param = new SqlParameter("@cartID", cartID);
            param.DbType = System.Data.DbType.String;
            cmd.Parameters.Add(param);//adds the cartID to the set of parameters

            param = new SqlParameter("@prodID", productID);
            param.DbType = System.Data.DbType.Int32;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@qty", newQty);
            param.DbType = System.Data.DbType.Int32;
            cmd.Parameters.Add(param);


            

            try
            {
                cmd.Connection.Open();
                return (cmd.ExecuteNonQuery() > 0);


            }
            catch (Exception ex)
            {

            }
            finally
            {
                cmd.Connection.Close();
            }

            return false;
        }
    }
}