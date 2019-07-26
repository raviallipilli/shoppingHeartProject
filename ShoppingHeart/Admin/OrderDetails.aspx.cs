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
    public partial class OrderDetails : System.Web.UI.Page
    {
        /// <summary>
        /// Order details we are using the UserControl ucCustomerOrder1 to show the details
        /// This control is common and used both on admin area and customer area
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!string.IsNullOrEmpty(Request.QueryString["Id"]))
            {
                string TransactionNo = Request.QueryString["Id"];
               
                ucCustomerOrder1.TransactionNoText = TransactionNo;

            }

            if (!string.IsNullOrEmpty(Convert.ToString(Session["ShoppingHeartAdmin"])))
            {
                ucCustomerOrder1.IsAuthorizedToAddStatus = true;
                
            }
            else
            {
                ucCustomerOrder1.IsAuthorizedToAddStatus = false;
                Response.Redirect("~/Admin/Login.aspx");
            }

        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Admin/OrderDetails.aspx");
        }

       

    }
}