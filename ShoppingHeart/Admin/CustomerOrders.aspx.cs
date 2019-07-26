using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ShoppingHeart.BusinessLayer;
using System.Data;

namespace ShoppingHeart.Admin
{
    public partial class CustomerOrders : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetOrdersList();
            }
        }

        /// <summary>
        /// This is to get all the orders placed by the customer 
        /// Here we are calling the GetOrdersList from business layer
        /// </summary>
        private void GetOrdersList()
        {
            ShoppingCart k = new ShoppingCart
            {
                Flag = 0,
                CustomerID=0
            };
            DataTable dt = k.GetOrdersList();

            gvCustomerOrders.DataSource = dt;
            gvCustomerOrders.DataBind();

        }
    }
}