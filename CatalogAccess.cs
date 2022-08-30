using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace Santiago_HW3
{
    public class CatalogAccess
    {
        public static DataTable GetProductsByCategoryID(string catID)
        {
            //create the connection string
            string connString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            //create the connection
            SqlConnection conn = new SqlConnection(connString);

            //create the command object (stored procedure)
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "spGetProductsByCategoryID";
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter param = new SqlParameter("@categoryID", catID);
            param.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(param);

            //open the connection, run the command, close the connection

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
                //catches the exception, may log the errors

            }
            finally
            {
                cmd.Connection.Close();
            }

            return table;
        }


        public static DataTable GetCategoryNames()
        {
            string connString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            SqlConnection conn = new SqlConnection(connString);

            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "spGetAllCategories";
            cmd.CommandType = CommandType.StoredProcedure;

            DataTable table = new DataTable();

            //try
            {
                cmd.Connection.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                table.Load(rdr);
                rdr.Close();
            }
            //catch(Exception ex)
            //{

            //}
            //finally
            {
                cmd.Connection.Close();
            }

            return table;


        }

        

        public static Product GetProductDetails(string productID)
        {
            string connString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            SqlConnection conn = new SqlConnection(connString);

            //create the command object
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "spGetProductDetails";
            cmd.CommandType = CommandType.StoredProcedure;


            //add the parameter
            SqlParameter param = new SqlParameter("@prodID", productID);
            cmd.Parameters.Add(param);

            DataTable table = new DataTable();
            try
            {
                cmd.Connection.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                table.Load(rdr);
                rdr.Close();//releases the resources of the database
            }
            catch (Exception ex)
            {
                Debug.Write("\n\n\n" + ex + "\n\n\n");
            }
            finally
            {
                cmd.Connection.Close();
            }

            Product pd = new Product();

            if (table.Rows.Count > 0)
            {
                DataRow dr = table.Rows[0];
                pd.ProductID = int.Parse(dr["ProductID"].ToString());
                pd.ProductName = dr["ProductName"].ToString();
                pd.Description = dr["Description"].ToString();
                pd.Price = decimal.Parse(dr["ListPrice"].ToString());
                pd.Image = dr["ProdImage"].ToString();
                pd.AvailableQty = dr["AvailableQty"].ToString();
                pd.TargetLevel = dr["TargetLevel"].ToString();
            }
            return pd;

        }


    }
}