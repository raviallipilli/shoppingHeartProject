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
    public partial class ProductStock : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetCategories();
                GetAvailableStock();
            }
        }

        /// <summary>
        /// Get all the categories and bind to the dropdownlist
        /// Add a default choice of All products to get all products from databse
        /// </summary>
        private void GetCategories()
        {
            ShoppingCart k = new ShoppingCart();
            DataTable dt = k.GetCategories();
            if (dt.Rows.Count > 0)
            {
                ddlCategory.DataValueField = "CategoryID";
                ddlCategory.DataTextField = "CategoryName";
                ddlCategory.DataSource = dt;
                ddlCategory.DataBind();
                ddlCategory.Items.Add(new ListItem("All Products", "0", true));
                ddlCategory.SelectedValue = "0";
            }

        }

        protected void ddlCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetAvailableStock();
        }

        protected void rblProductStock_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetAvailableStock();
        }

        /// <summary>
        /// This method we are executing to get the available stock of the products
        /// The stocks we are fetching based on categoryid
        /// all the data is binded to the gridview gvAvailableStock
        /// </summary>
        private void GetAvailableStock()
        {
            if (Convert.ToInt32(rblProductStock.SelectedValue)==3)
            {
                ShoppingCart k = new ShoppingCart()
                {
                    CategoryID = Convert.ToInt32(ddlCategory.SelectedValue)
                };
                DataTable dt = k.GetHiddenStock();
                if (dt.Rows.Count > 0)
                {

                    gvHiddenStock.DataSource = dt;
                    gvHiddenStock.DataBind();
                    gvHiddenStock.Visible = true;
                    gvAvailableStock.Visible = false;
                   
                    NoRecordsToDisplay.Visible = false;
                }
                else
                {
                    NoRecordsToDisplay.Visible = true;
                    gvHiddenStock.Visible = false;
                }
            }
            else
            {

                ShoppingCart k1 = new ShoppingCart()
                {
                    CategoryID = Convert.ToInt32(ddlCategory.SelectedValue),
                    StockType = Convert.ToInt32(rblProductStock.SelectedValue)
                };
                DataTable dt = k1.GetAvailableStock();
                if (dt.Rows.Count > 0)
                {
                    gvAvailableStock.DataSource = dt;
                    gvAvailableStock.DataBind();
                    gvAvailableStock.Visible = true;
                    gvHiddenStock.Visible = false;
                    NoRecordsToDisplay.Visible = false;
                }
                else
                {
                    NoRecordsToDisplay.Visible = true;
                    gvAvailableStock.Visible = false;
                }
            }
        }


    }
}