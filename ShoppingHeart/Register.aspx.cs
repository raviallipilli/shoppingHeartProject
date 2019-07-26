using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ShoppingHeart.BusinessLayer;
using System.Data;

namespace ShoppingHeart
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// On Register button click we are saving all the customer information into our database
        /// If the customer is registered successfully then we are creating sessions of customerID and CustomerName and redirecting the user to Default page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnRegister_Click(object sender, EventArgs e)
        {

            ShoppingCart k = new ShoppingCart()
            {
                CustomerName = txtName.Text,
                CustomerEmailID = txtEmailID.Text,
                CustomerAddress = txtAddress.Text,
                CustomerPhoneNo = txtPhoneNo.Text,
                CustomerPassword=txtPassword.Text
            };

            DataTable dtResult = k.Register();

            if (Convert.ToInt32(dtResult.Rows[0]["CustomerID"]) > 0)
            {
                Session["CustomerID"] = dtResult.Rows[0]["CustomerID"];
                Session["CustomerName"] = txtName.Text;
                Response.Redirect("~/Default.aspx");
            }
            else
            {

            }
        }

        protected void imgShoppingBag_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("~/Default.aspx");
        }
    }
}