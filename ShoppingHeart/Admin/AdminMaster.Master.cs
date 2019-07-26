using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using ShoppingHeart.BusinessLayer;

namespace ShoppingHeart.Admin
{
    public partial class AdminMaster : System.Web.UI.MasterPage
    {
        /// <summary>
        /// in Admin Master Page load method we are checking ifthe admin session is active or not 
        /// if its not active then we are redirecting the admin to login page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["ShoppingHeartAdmin"] == null)
            {
                Response.Redirect("~/Admin/Login.aspx");
            }
        }

        /// <summary>
        /// On logout we are clearing the session and redireting the login page 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lbtnLogout_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("~/Admin/Login.aspx");
        }
    }
}
