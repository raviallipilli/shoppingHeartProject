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
    public partial class Products : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetCategories();
                GetProducts(0);//Get ALL Products 
            }
        }


        /// <summary>
        /// Using this method we are getting all the product categories and binding them to the dropdownlist ddlCateogry
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
            }

        }

        /// <summary>
        /// This method is used to get all the product details and bind to the gridview
        /// </summary>
        /// <param name="CategoryID"></param>
        private void GetProducts(int CategoryID)
        {
            ShoppingCart k = new ShoppingCart()
            {
                CategoryID = CategoryID,
                SearchText=string.Empty
            };

            gvAvailableProducts.DataSource = null;
            gvAvailableProducts.DataSource = k.GetAllProducts(); ;
            gvAvailableProducts.DataBind();
        }

        protected void gvAvailableProducts_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string item = e.Row.Cells[0].Text;
                foreach (Button button in e.Row.Cells[6].Controls.OfType<Button>())
                {
                    if (button.CommandName == "Delete")
                    {
                        button.Attributes["onclick"] = "if(!confirm('Do you want to delete Product# " + item + "?')){ return false; };";
                    }
                }
            }
        }

        protected void gvAvailableProducts_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int index = Convert.ToInt32(e.RowIndex);
            string ProductID = gvAvailableProducts.Rows[index].Cells[0].Text;

            ShoppingCart k = new ShoppingCart()
            {
                CategoryID =0,
                ProductID = Convert.ToInt32(ProductID)
            };
            k.DeleteProductCategories();
            GetProducts(Convert.ToInt32(ddlCategory.SelectedValue));
        }

        protected void ddlCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetProducts(Convert.ToInt32(ddlCategory.SelectedValue));
        }
    }
}