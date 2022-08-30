using Santiago_HW3;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace NorthwindTraders
{
    public class SupplierCatalog
    {
        public static DataTable AllSuppliers()
        {
            string connString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            SqlConnection conn = new SqlConnection(connString);

            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "AllSuppliers";
            cmd.CommandType = CommandType.StoredProcedure;

            DataTable table = new DataTable();

            //try
            {
                cmd.Connection.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                table.Load(rdr);
                rdr.Close();
            }
            //catch (Exception ex)
            //{
            //    //catches the exception, may log the errors

            //}
            //finally
            {
                cmd.Connection.Close();
            }

            return table;
        }

        public static Supplier GetSupplierByID(string supplierID)
        {
            string connString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            SqlConnection conn = new SqlConnection(connString);

            //create the command object
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "GetSupplierByID";
            cmd.CommandType = CommandType.StoredProcedure;


            //add the parameter
            SqlParameter param = new SqlParameter("@supplierID", supplierID);
            param.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(param);

            DataTable table = new DataTable();
            try
            {
                cmd.Connection.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                table.Load(rdr);
                rdr.Close();//releases the resources of the database
            }
            //catch (Exception ex)
            //{
                
            //}
            finally
            {
                cmd.Connection.Close();
            }

            Supplier pd = new Supplier();

            if (table.Rows.Count > 0)
            {
                DataRow dr = table.Rows[0];
                pd.Company = dr["Company"].ToString();
                pd.SupplierID = (dr["SupplierID"].ToString());
                pd.FirstName = dr["FirstName"].ToString();
                pd.LastName = dr["LastName"].ToString();
                pd.BusinessPhone = dr["BusinessPhone"].ToString();
                pd.City = dr["City"].ToString();
                pd.State = dr["State"].ToString();
                pd.SupplierImage = dr["SupplierImage"].ToString();
            }
            return pd;
        }

    }
}