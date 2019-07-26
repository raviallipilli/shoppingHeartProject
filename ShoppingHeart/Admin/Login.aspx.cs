using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Configuration;

namespace ShoppingHeart.Admin
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            txtLoginId.Focus();//setting the focus of cursor in the login textbox
        }

        /// <summary>
        /// getting the adminid and password from web config file
        /// verifying the adminid and password with what is entered in the textbox 
        /// Redirecting the admin to adminarea if id password is correct
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string LoginID = WebConfigurationManager.AppSettings["AdminLoginID"];
            string Password = WebConfigurationManager.AppSettings["AdminPassword"];

            if (txtLoginId.Text == LoginID && txtPassword.Text == Password)
            {
                Session["ShoppingHeartAdmin"] = "ShoppingHeartAdmin";
                Response.Redirect("~/Admin/AddNewProducts.aspx");
            }
            else
            {
                lblAlert.Text = "Incorrect LoginId/Password";
            }
        }
    }
}
