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
    public partial class AddNewProducts : System.Web.UI.Page
    {

        /// <summary>
        /// Here we are calling the Getcatgories and AddSubmitEvent method
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetCategories();

                AddSubmitEvent();

                if (Request.QueryString["alert"] == "success")
                {
                    Response.Write("<script>alert('Record Saved Sucessfully.');</script>");
                }
            }

           
        }

        /// <summary>
        /// This event is added to make the update panel work and add the triger to it in server side code
        /// </summary>
        private void AddSubmitEvent()
        {
            UpdatePanel updatePanel = Page.Master.FindControl("AdminUpdatePanel") as UpdatePanel;
            UpdatePanelControlTrigger trigger = new PostBackTrigger();
            trigger.ControlID = btnSubmit.UniqueID;

            updatePanel.Triggers.Add(trigger);
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
        /// This event is fired when admin is addding a new product
        /// first the saveproductphoto is executed and then the AddNewProduct method in business layer is called
        /// To display the scucess message we are passing alert=sucess in query string which is captured in page load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (uploadProductPhoto.PostedFile != null)
            {
                SaveProductPhoto();

                ShoppingCart k = new ShoppingCart()
                {
                    ProductName = txtProductName.Text,
                    ProductImage = "~/ProductImages/" + uploadProductPhoto.FileName,
                    ProductPrice = txtProductPrice.Text,
                    ProductDescription = txtProductDescription.Text,
                    CategoryID = Convert.ToInt32(ddlCategory.SelectedValue),
                    TotalProducts = Convert.ToInt32(txtProductQuantity.Text)
                };
                k.AddNewProduct();
                ClearText();
                Response.Redirect("~/Admin/AddNewProducts.aspx?alert=success");
                
            }
            else
            {
                Response.Write("<script>alert('Please Upload Photo');</script>");
                
            }

        }

        /// <summary>
        /// Clear all the values once the new product is added to the database
        /// </summary>
        private void ClearText()
        {
            uploadProductPhoto = null;
            txtProductName.Text = string.Empty;
            txtProductPrice.Text = string.Empty;
            txtProductDescription.Text = string.Empty;
            txtProductQuantity.Text = string.Empty;
        }

        /// <summary>
        /// This method is used to save the photo related to the project in the Product Images folder
        /// We have applied some validations realted to image size,extension,and file name length
        /// </summary>
        private void SaveProductPhoto()
        {
            if (uploadProductPhoto.PostedFile != null)
            {
                string filename = uploadProductPhoto.PostedFile.FileName.ToString();
                string fileExt = System.IO.Path.GetExtension(uploadProductPhoto.FileName);


                //check file name legnth
                if (filename.Length > 96)
                {
                    //Alert.Show("image name should not exceed 96 characters !");
                }
                //check filetype 
                else if (fileExt != ".jpeg" && fileExt != ".jpg" && fileExt != ".png" && fileExt != ".bmp")
                {
                    //Alert.Show("Only jpeg,jpg,bmp & png imags are allowed!");
                }

                //check file size
                else if (uploadProductPhoto.PostedFile.ContentLength > 4000000)
                {
                    //Alert.Show("image size should not be greater than 4MB !");
                }
                //Save images into Images folder
                else
                {
                    uploadProductPhoto.SaveAs(Server.MapPath("~/ProductImages/" + filename));

                }
            }
        }
    }
}
