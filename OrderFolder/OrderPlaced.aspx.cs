using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Santiago_HW3.OrderFolder
{
    public partial class OrderPlaced : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            PopulateControls();
        }

        protected void PopulateControls()
        {
            string purchaseorderid = Request.QueryString["PurchaseOrderID"].ToString();

            Label1.Text = purchaseorderid;
        }
       

    }
}