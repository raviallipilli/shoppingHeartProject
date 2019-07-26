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
    public partial class Category : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetCategories();
            }
        }

        private void GetCategories()
        {
            ShoppingCart k = new ShoppingCart();
            DataTable dt = k.GetCategories();
            if (dt.Rows.Count > 0)
            {
                gvAvailableCategories.DataSource = dt;
                gvAvailableCategories.DataBind();
            }
            else
            {
                gvAvailableCategories.DataSource = null;
                gvAvailableCategories.DataBind();
            }

        }

        protected void gvAvailableCategories_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string item = e.Row.Cells[0].Text;
                foreach (Button button in e.Row.Cells[2].Controls.OfType<Button>())
                {
                    if (button.CommandName == "Delete")
                    {
                        button.Attributes["onclick"] = "if(!confirm('Do you want to delete Category# " + item + "? All Products in this Category will also Get Deleted.')){ return false; };";
                    }
                }
            }
        }

        protected void gvAvailableCategories_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int index = Convert.ToInt32(e.RowIndex);
            string CategoryID = gvAvailableCategories.Rows[index].Cells[0].Text;

            ShoppingCart k = new ShoppingCart()
            {
                CategoryID = Convert.ToInt32(CategoryID),
                ProductID = 0
            };
            k.DeleteProductCategories();
            GetCategories();
        }
    }
}