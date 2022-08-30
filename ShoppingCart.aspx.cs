using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Santiago_HW3
{
    public partial class ShoppingCart : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
                if(!IsPostBack)
                PopulateControls();

        }

        protected void PopulateControls()
        {
            DataTable dt = ShoppingCartAccess.GetCartItems();

            if (dt.Rows.Count > 0)
            {
                Label1.Text = "These are the items in your cart:";
                GridView1.DataSource = dt;
                GridView1.DataBind();

                decimal ctotal = ShoppingCartAccess.GetCartTotal();
                CartTotal.Text = String.Format("{0:c}", ctotal);

                UpdateCart_btn.Enabled = true;
            }
            else //the user does not have anything in their cart
            {
                Label1.Text = "There are no items in your cart.";
                GridView1.Visible = false;
                CartTotal.Text = "0";
                UpdateCart_btn.Enabled = false;
            }
        }

        protected void UpdateCart_btn_Click(object sender, EventArgs e)
        {
            string productID;
            int newQty;

            int rowCount = GridView1.Rows.Count;

            GridViewRow gridRow;

            TextBox txtBox;

            bool success = true;

            for (int i = 0; i < rowCount; i++)
            {
                //fetch the current row 
                gridRow = GridView1.Rows[i];

                //fetch the productID and qty from the current row
                GridView1.DataKeys[i].Value.ToString();

                productID = GridView1.DataKeys[i].Value.ToString();

                txtBox = (TextBox)gridRow.FindControl("qtyTxtBox");

                //pass the productID and the qty to the method which runs the procedure
                if (Int32.TryParse(txtBox.Text, out newQty))
                {
                    success = success && ShoppingCartAccess.UpdateCart(productID, newQty);

                }

            }



            //update cart status label based on the success outcome
            CartStatusLabel.Text = success ? "Your cart was successfully updated." : "Some items may not have been updated. Please check your cart.";
            // (condition ? courseA : courseB)

            PopulateControls();

        }
            public void CheckoutBtn_Click(object sender, EventArgs e)
            {
                Response.Redirect("~/OrderFolder/Checkout.aspx");
            }
        

    }

}