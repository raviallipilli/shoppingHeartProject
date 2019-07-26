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
    public partial class MyShopping : System.Web.UI.Page
    {
        /// <summary>
        /// Checking whether the customer session is active or not
        /// if session is active we get all the customer info
        /// if not then we redirect the customer to login page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["CustomerID"] != null)
                {
                    GetOrdersList();
                }
                else
                {
                    Response.Redirect("~/Login.aspx");
                }
            }
        }

        /// <summary>
        /// Here we are getting all the orders placed by the customer using CustomerID
        /// All the records are bound to the Gridview gvCustomerOrders
        /// </summary>
        private void GetOrdersList()
        {
            ShoppingCart k = new ShoppingCart
            {
                Flag = 0,
                CustomerID = Convert.ToInt32(Session["CustomerID"])
            };
            DataTable dt = k.GetOrdersList();

            gvCustomerOrders.DataSource = dt;
            gvCustomerOrders.DataBind();

        }


        /// <summary>
        /// On click of image button redirecting the user to Default page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void imgShoppingBag_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("~/Default.aspx");
        }
    }
}