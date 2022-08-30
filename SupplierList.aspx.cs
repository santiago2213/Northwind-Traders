using NorthwindTraders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Santiago_HW3
{
    public partial class SupplierList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            PopulateControls();
        }
        protected void PopulateControls()
        {
            
            //if(SupplierID != null)
            
                DataList1.DataSource = SupplierCatalog.AllSuppliers();
                DataList1.DataBind();
            
            //else
            
            
            
        }
    }
}