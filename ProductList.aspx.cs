using NorthwindTraders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Santiago_HW3
{
    public partial class ProductList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            PopulateControls();
        }

        protected void PopulateControls()
        {
            string categoryID = Request.QueryString["CategoryID"];

            if (categoryID != null)
            {
                DataList1.DataSource = CatalogAccess.GetProductsByCategoryID(categoryID);
            DataList1.DataBind();
            }
            else
            {
                categoryID = "100";
                DataList1.DataSource = CatalogAccess.GetProductsByCategoryID(categoryID);
                DataList1.DataBind();
            }



        }
    }
}