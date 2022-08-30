using NorthwindTraders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Santiago_HW3
{
    public partial class SupplierDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            PopulateControls();
        }
        protected void PopulateControls()
        {
            string supplierID = Request.QueryString["SupplierID"];

            //use this productID to run the appropriate stored procedure
            Supplier pd = SupplierCatalog.GetSupplierByID(supplierID);

            company.Text = pd.Company;
            suppID.Text = pd.SupplierID;
            city.Text = pd.City;
            state.Text = pd.State;
            firstName.Text = pd.FirstName;
            lastName.Text = pd.LastName;
            supplierImage.ImageUrl = "Images/" + pd.SupplierImage;
        }
    }
}