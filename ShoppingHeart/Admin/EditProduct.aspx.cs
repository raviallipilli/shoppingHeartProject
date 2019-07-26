using ShoppingHeart.BusinessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ShoppingHeart.Admin
{
    public partial class EditProduct : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                hfProductID.Value = HttpUtility.UrlDecode(Request.QueryString["Id"]);
                GetProductByID(Convert.ToInt32(hfProductID.Value));
                GetCategories();
            }
        }
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
            ddlCategory.SelectedValue = hfProductID.Value;
        }
        private void GetProductByID(int ProductID)
        {
            ShoppingCart k = new ShoppingCart()
            {
                ProductID = ProductID
            };

           DataTable dt= k.GetProductByID();

           txtProductName.Text = Convert.ToString(dt.Rows[0]["Name"]);
           txtProductDescription.Text = Convert.ToString(dt.Rows[0]["Description"]);
           txtProductPrice.Text = Convert.ToString(dt.Rows[0]["Price"]);
           txtProductQuantity.Text = Convert.ToString(dt.Rows[0]["ProductQuantity"]);
           imgPreview.ImageUrl = Convert.ToString(dt.Rows[0]["ImageUrl"]);
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {

            ShoppingCart k = new ShoppingCart()
            {
                ProductID=Convert.ToInt32(hfProductID.Value),
                ProductName = txtProductName.Text, 
                ProductPrice = txtProductPrice.Text,
                ProductDescription = txtProductDescription.Text,
                TotalProducts = Convert.ToInt32(txtProductQuantity.Text),
                Flag=Convert.ToInt32(rbShowHide.SelectedValue)
               
            };
            k.EditProduct();
            Response.Redirect("~/Admin/Products.aspx?alert=success");
                
        }
    }
}