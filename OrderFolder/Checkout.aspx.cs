using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Santiago_HW3.OrderFolder
{
    public partial class Checkout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void PlaceOrderBtn_Click(object sender, EventArgs e)
        {
            string connString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            SqlConnection conn = new SqlConnection(connString);

            SqlCommand cmd = conn.CreateCommand();

            cmd.CommandText = "spCreatePurchaseOrder";
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            string cartID;

            HttpContext context = HttpContext.Current;

            if(context.Request.Cookies["NWTDbFinalProjectSpring2022_CartID"] != null)
            {
                cartID = context.Request.Cookies["NWTDbFinalProjectSpring2022_CartID"].Value;
            }
            else
            {
                cartID = Guid.NewGuid().ToString();

                HttpCookie cookie = new HttpCookie("NWTDbFinalProjectSpring2022_CartID", cartID);

                TimeSpan timeSpan = new TimeSpan(10, 0, 0, 0);

                DateTime expirationTime = DateTime.Now.Add(timeSpan);

                cookie.Expires = expirationTime;

                context.Response.Cookies.Add(cookie);
            }



            SqlParameter param = new SqlParameter("@cartID", Request.Cookies["NWTDbFinalProjSpring2022_CartID"].Value);
            param.DbType = System.Data.DbType.String;
            cmd.Parameters.Add(param);//adds the prodID to the set of parameters

            param = new SqlParameter("@empID", User.Identity.GetUserId());
            param.DbType = System.Data.DbType.String;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@PurchaseOrderID", System.Data.DbType.String);
            cmd.Parameters.Add(param);

            //try
            {
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();

            }
           // catch (Exception ex)
           // {

           // }
            //finally
            {
                cmd.Connection.Close();
            }

            Response.Redirect("~/OrderFolder/OrderPlaced.aspx?PurchaseOrderID=" + param.Value);
        }
    }
}