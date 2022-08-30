using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Santiago_HW3
{
    public partial class ProductDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            PopulateControls();
        }
        protected void PopulateControls()
        {
            string prodID = Request.QueryString["ProductID"];

            //use this productID to run the appropriate stored procedure
            Product pd = CatalogAccess.GetProductDetails(prodID);

            ProductName.Text = pd.ProductName;
            Description.Text = pd.Description;
            ListPrice.Text = String.Format("{0:c}", pd.Price);
            ProdImage.ImageUrl = "~/Images/fruits.jpg";
            ProductAvailabelQty.Text = pd.AvailableQty;
            ProductTargetLevel.Text = pd.TargetLevel;
        }

        protected void AddToCart_Click(object sender, EventArgs e)
        {
            string prodID = Request.QueryString["ProductID"];
            string cartID;

            //if the cart ID already exists
            if (Request.Cookies["NWTDbFinalProjSpring2022_CartID"] != null)
            {
                cartID = Request.Cookies["NWTDbFinalProjSpring2022_CartID"].Value;
            }
            else //no cookies on their machine
            {
                cartID = Guid.NewGuid().ToString();

                HttpCookie cookie = new HttpCookie("NWTDbFinalProjSpring2022_CartID", cartID);

                TimeSpan timespan = new TimeSpan(10, 0, 0, 0);

                DateTime expirationTime = DateTime.Now.Add(timespan);

                cookie.Expires = expirationTime;

                //write thus cookie on their machine
                Response.Cookies.Add(cookie);
            }

            
             ShoppingCartAccess.AddProductToCart(cartID, prodID);
            


        }
    }
}