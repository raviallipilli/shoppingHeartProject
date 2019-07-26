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
    public partial class IncomeReport : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetIncomeReport();
            }
        }

        /// <summary>
        /// On Radio button selection change we are again calling the GetIncomeReport method
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void rblIncomeFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetIncomeReport();
        }

        /// <summary>
        /// This method is used to get the income report
        /// The parameter we are passing the time period based on radio button selection which is weekly montlhy and yearly
        /// We are using Compute Method which is part of datatable to find the total sales and total prodcuts sold
        /// </summary>
        private void GetIncomeReport()
        {
            ShoppingCart k = new ShoppingCart()
            {
                Flag = Convert.ToInt32(rblIncomeFilter.SelectedValue)
            };
            DataTable dt = k.GetIncomeReport();
            if (dt.Rows.Count > 0)
            {
                gvIncomeReport.Visible = true;
                gvIncomeReport.DataSource = dt;
                gvIncomeReport.DataBind();

                object ProductSold;
                ProductSold = dt.Compute("Sum(TotalProducts)", "");

                object TotalIncome;
                TotalIncome = dt.Compute("Sum(TotalPrice)", "");

                lblIncome.Text = "Products Sold :" + ProductSold + "  Total Income :" + TotalIncome;
            }
            else
            {
                gvIncomeReport.Visible = false;
                lblIncome.Text = "No Records Available";
            }
        }
    }
}