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
    public partial class MyProfile : System.Web.UI.Page
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
                    GetInfo();
                }
                else
                {
                    Response.Redirect("~/Login.aspx");
                }
            }
        }

        /// <summary>
        /// Here we are simply calling the GetCustomerInfo method from business layer using the session customerID
        /// </summary>
        private void GetInfo()
        {
            ShoppingCart k = new ShoppingCart()
            {
                CustomerID = Convert.ToInt32(Session["CustomerID"])
            };

            DataTable dtCustomerDetails = k.GetCustomerInfo();

            txtName.Text = Convert.ToString(dtCustomerDetails.Rows[0]["CustomerName"]);
            txtPhoneNo.Text = Convert.ToString(dtCustomerDetails.Rows[0]["CustomerPhoneNo"]);
            txtEmailID.Text = Convert.ToString(dtCustomerDetails.Rows[0]["CustomerEmailID"]);
            txtAddress.Text = Convert.ToString(dtCustomerDetails.Rows[0]["CustomerAddress"]);
            txtPassword.Text = Convert.ToString(dtCustomerDetails.Rows[0]["CustomerPassword"]);

        }

        /// <summary>
        /// If the user wants to update his information then he can click on save button
        /// here we are calling the UpdateProfile Method in the business Layer and passing all the information 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (txtPhoneNo.Text.Length < 10)
            {
                lblAlert.Text = "Enter Valid PhoneNo";
            }
            else
            {
                ShoppingCart k = new ShoppingCart()
                {
                    CustomerID = Convert.ToInt32(Session["CustomerID"]),
                    CustomerEmailID = txtEmailID.Text,
                    CustomerAddress = txtAddress.Text,
                    CustomerPhoneNo = txtPhoneNo.Text,
                    CustomerPassword = txtPassword.Text
                };

                DataTable dtResult = k.UpdateProfile();

                lblAlert.Text = "Record Saved Successfully.";
            }
        }

        protected void imgShoppingBag_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("~/Default.aspx");
        }
    }
}