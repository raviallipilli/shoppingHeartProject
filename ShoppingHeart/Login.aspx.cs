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
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// WE ARE CHEKING IN DATABASE THE LOGINID AND PASSWORD 
        /// ShoppingCart K is an object of Business layer, using that object we are calling Login method of business layer to ]
        /// If the login id and password is there in databse then we are redirecitng the customer to default page with CustomerID and CustomerName Sessions
        /// If id and password is wrong then we are showing message 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            ShoppingCart k = new ShoppingCart()
            {
                CustomerEmailID = txtLoginId.Text,
                CustomerPassword = txtPassword.Text
            };

            DataTable dtResult = k.Login();

            if (dtResult.Rows.Count > 0)
            {
                Session["CustomerID"] = dtResult.Rows[0]["Id"];
                Session["CustomerName"] = dtResult.Rows[0]["CustomerName"]; ;
                Response.Redirect("~/Default.aspx");
            }
            else
            {
                lblAlert.Text = "Incorrect Id / Password !!";
            }
        }

        /// <summary>
        /// Redirecting the user to Register page on the click of this link button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnRegister_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Register.aspx");
        }

        /// <summary>
        /// Redirecting the user to Default page on the click of this image button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void imgShoppingBag_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("~/Default.aspx");
        }
    }
}