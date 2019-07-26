using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;


namespace ShoppingHeart.BusinessLayer
{

    /// <summary>
    /// This class is holding all the variables and all the methods which are called from various pages in our website
    /// All the methods are calling the Dataacess create update or delete methods 
    /// All the Methods are having a Stored Procedure name which is exeuted in Sql server
    /// The parameters needed for stored procdure are getting added by AddParamater method 
    /// </summary>
    public class ShoppingCart
    {

        public string CategoryName;
        public int CategoryID;
        public int ProductID;
        public int CustomerID;

        public string ProductName;
        public string ProductImage;
        public string ProductPrice;
        public string ProductDescription;

        public string CustomerName;
        public string CustomerEmailID;
        public string CustomerPhoneNo;
        public string CustomerAddress;
        public string ProductList;
        public string PaymentMethod;

        public string OrderStatus;
        public string OrderNo;

        public int TotalProducts;
        public int TotalPrice;
        public int StockType;
        public int Flag;
        public string CustomerPassword;
        public string SearchText;

        public void AddNewCategory()
        {
            SqlParameter[] parameters = new SqlParameter[1];
            parameters[0] = DataLayer.DataAccess.AddParamater("@CategoryName", CategoryName, System.Data.SqlDbType.VarChar, 200);
            DataTable dt = DataLayer.DataAccess.ExecuteDTByProcedure("SP_AddNewCategory", parameters);
        }

        public void AddNewProduct()
        {
            SqlParameter[] parameters = new SqlParameter[6];
            parameters[0] = DataLayer.DataAccess.AddParamater("@ProductName", ProductName, System.Data.SqlDbType.VarChar, 300);
            parameters[1] = DataLayer.DataAccess.AddParamater("@ProductPrice", ProductPrice, System.Data.SqlDbType.Int, 100);
            parameters[2] = DataLayer.DataAccess.AddParamater("@ProductImage", ProductImage, System.Data.SqlDbType.VarChar, 500);
            parameters[3] = DataLayer.DataAccess.AddParamater("@ProductDescription", ProductDescription, System.Data.SqlDbType.VarChar, 1000);
            parameters[4] = DataLayer.DataAccess.AddParamater("@CategoryID", CategoryID, System.Data.SqlDbType.Int, 100);
            parameters[5] = DataLayer.DataAccess.AddParamater("@ProductQuantity", TotalProducts, System.Data.SqlDbType.Int, 100);

            DataTable dt = DataLayer.DataAccess.ExecuteDTByProcedure("SP_AddNewProduct", parameters);
        }

        public DataTable GetAllProducts()
        {
            SqlParameter[] parameters = new SqlParameter[2];
            parameters[0] = DataLayer.DataAccess.AddParamater("@CategoryID", CategoryID, System.Data.SqlDbType.Int, 20);
            parameters[1] = DataLayer.DataAccess.AddParamater("@SearchText", SearchText, System.Data.SqlDbType.VarChar, 100);
            DataTable dt = DataLayer.DataAccess.ExecuteDTByProcedure("SP_GetAllProducts", parameters);
            return dt;
        }

        public DataTable GetCategories()
        {
            SqlParameter[] parameters = new SqlParameter[0];
            DataTable dt = DataLayer.DataAccess.ExecuteDTByProcedure("SP_GetAllCategories", parameters);
            return dt;
        }


        internal DataTable SaveCustomerOrder()
        {
            SqlParameter[] parameters = new SqlParameter[4];
            parameters[0] = DataLayer.DataAccess.AddParamater("@CustomerID", CustomerID, System.Data.SqlDbType.VarChar, 100);
            parameters[1] = DataLayer.DataAccess.AddParamater("@TotalProducts", TotalProducts, System.Data.SqlDbType.Int, 100);
            parameters[2] = DataLayer.DataAccess.AddParamater("@TotalPrice", TotalPrice, System.Data.SqlDbType.Int, 100);
            parameters[3] = DataLayer.DataAccess.AddParamater("@PaymentMethod", PaymentMethod, System.Data.SqlDbType.VarChar, 100);
            DataTable dt = DataLayer.DataAccess.ExecuteDTByProcedure("SP_SaveCustomerOrder", parameters);

            return dt;
        }

        internal DataTable Register()
        {
            SqlParameter[] parameters = new SqlParameter[5];
            parameters[0] = DataLayer.DataAccess.AddParamater("@CustomerName", CustomerName, System.Data.SqlDbType.VarChar, 100);
            parameters[1] = DataLayer.DataAccess.AddParamater("@CustomerEmailID", CustomerEmailID, System.Data.SqlDbType.VarChar, 100);
            parameters[2] = DataLayer.DataAccess.AddParamater("@CustomerPhoneNo", CustomerPhoneNo, System.Data.SqlDbType.VarChar, 10);
            parameters[3] = DataLayer.DataAccess.AddParamater("@CustomerAddress", CustomerAddress, System.Data.SqlDbType.VarChar, 500);
            parameters[4] = DataLayer.DataAccess.AddParamater("@CustomerPassword", CustomerPassword, System.Data.SqlDbType.VarChar, 100);

            DataTable dt = DataLayer.DataAccess.ExecuteDTByProcedure("SP_Register", parameters);

            return dt;
        }

        internal DataTable GetOrdersList()
        {
            SqlParameter[] parameters = new SqlParameter[2];
            parameters[0] = DataLayer.DataAccess.AddParamater("@Flag", Flag, System.Data.SqlDbType.Int, 20);
            parameters[1] = DataLayer.DataAccess.AddParamater("@CustomerID", CustomerID, System.Data.SqlDbType.Int, 20);
            DataTable dt = DataLayer.DataAccess.ExecuteDTByProcedure("SP_GetOrdersList", parameters);
            return dt;
        }

        internal DataTable GetTransactionDetails()
        {
            SqlParameter[] parameters = new SqlParameter[1];
            parameters[0] = DataLayer.DataAccess.AddParamater("@TransactionNo", Flag, System.Data.SqlDbType.Int, 20);
            DataTable dt = DataLayer.DataAccess.ExecuteDTByProcedure("SP_GetTransactionDetails", parameters);
            return dt;
        }

        internal DataTable GetSetOrderStatus()
        {
            SqlParameter[] parameters = new SqlParameter[3];
            parameters[0] = DataLayer.DataAccess.AddParamater("@TransactionNo", Convert.ToInt32(OrderNo), System.Data.SqlDbType.Int, 20);
            parameters[1] = DataLayer.DataAccess.AddParamater("@OrderStatus", OrderStatus, System.Data.SqlDbType.VarChar, 300);
            parameters[2] = DataLayer.DataAccess.AddParamater("@Flag", Flag, System.Data.SqlDbType.Int, 10);
            DataTable dt = DataLayer.DataAccess.ExecuteDTByProcedure("SP_OrderStatus", parameters);
            return dt;
        }

        internal void RollBackOrder()
        {
            SqlParameter[] parameters = new SqlParameter[1];
            parameters[0] = DataLayer.DataAccess.AddParamater("@TransactionNo", Convert.ToInt32(OrderNo), System.Data.SqlDbType.Int, 20);
            DataTable dt = DataLayer.DataAccess.ExecuteDTByProcedure("SP_RollBackOrder", parameters);
            
        }

        internal void SaveCustomerProducts()
        {
            SqlParameter[] parameters = new SqlParameter[3];
            parameters[0] = DataLayer.DataAccess.AddParamater("@OrderNo", Convert.ToInt32(OrderNo), System.Data.SqlDbType.Int, 20);
            parameters[1] = DataLayer.DataAccess.AddParamater("@ProductID", ProductID, System.Data.SqlDbType.Int, 20);
            parameters[2] = DataLayer.DataAccess.AddParamater("@TotalProduct", TotalProducts, System.Data.SqlDbType.Int, 10);
            DataTable dt = DataLayer.DataAccess.ExecuteDTByProcedure("SP_SaveCustomerProducts", parameters);

        }

        internal DataTable GetAvailableStock()
        {
            SqlParameter[] parameters = new SqlParameter[2];
            parameters[0] = DataLayer.DataAccess.AddParamater("@StockType", StockType, System.Data.SqlDbType.Int, 10);
            parameters[1] = DataLayer.DataAccess.AddParamater("@CategoryID", CategoryID, System.Data.SqlDbType.Int, 10);
            DataTable dt = DataLayer.DataAccess.ExecuteDTByProcedure("SP_GetAvailableStock", parameters);
            return dt;
        }

        internal DataTable GetIncomeReport()
        {
            SqlParameter[] parameters = new SqlParameter[1];
            parameters[0] = DataLayer.DataAccess.AddParamater("@ReportType", Flag, System.Data.SqlDbType.Int, 10);
            DataTable dt = DataLayer.DataAccess.ExecuteDTByProcedure("SP_GetIncomeReport", parameters);
            return dt;
        }

        internal DataTable Login()
        {
            SqlParameter[] parameters = new SqlParameter[2];

            parameters[0] = DataLayer.DataAccess.AddParamater("@CustomerEmailID", CustomerEmailID, System.Data.SqlDbType.VarChar, 100);
            parameters[1] = DataLayer.DataAccess.AddParamater("@CustomerPassword", CustomerPassword, System.Data.SqlDbType.VarChar, 100);

            DataTable dt = DataLayer.DataAccess.ExecuteDTByProcedure("SP_Login", parameters);

            return dt;
        }
        internal DataTable GetCustomerInfo()
        {
            SqlParameter[] parameters = new SqlParameter[1];

            parameters[0] = DataLayer.DataAccess.AddParamater("@CustomerID", CustomerID, System.Data.SqlDbType.Int, 100);

            DataTable dt = DataLayer.DataAccess.ExecuteDTByProcedure("SP_GetCustomerInfo", parameters);

            return dt;
        }

        internal DataTable UpdateProfile()
        {
            SqlParameter[] parameters = new SqlParameter[5];
            parameters[0] = DataLayer.DataAccess.AddParamater("@CustomerID", CustomerID, System.Data.SqlDbType.Int, 10);
            parameters[1] = DataLayer.DataAccess.AddParamater("@CustomerEmailID", CustomerEmailID, System.Data.SqlDbType.VarChar, 100);
            parameters[2] = DataLayer.DataAccess.AddParamater("@CustomerPhoneNo", CustomerPhoneNo, System.Data.SqlDbType.VarChar, 10);
            parameters[3] = DataLayer.DataAccess.AddParamater("@CustomerAddress", CustomerAddress, System.Data.SqlDbType.VarChar, 500);
            parameters[4] = DataLayer.DataAccess.AddParamater("@CustomerPassword", CustomerPassword, System.Data.SqlDbType.VarChar, 100);

            DataTable dt = DataLayer.DataAccess.ExecuteDTByProcedure("SP_UpdateProfile", parameters);

            return dt;
        }

        internal void DeleteProductCategories()
        {
            SqlParameter[] parameters = new SqlParameter[2];
            parameters[0] = DataLayer.DataAccess.AddParamater("@CategoryID", CategoryID, System.Data.SqlDbType.Int, 10);
            parameters[1] = DataLayer.DataAccess.AddParamater("@ProductID", ProductID, System.Data.SqlDbType.Int, 10);
            DataTable dt = DataLayer.DataAccess.ExecuteDTByProcedure("SP_DeleteProductCategory", parameters);

        }

        public DataTable GetProductByID()
        {
            SqlParameter[] parameters = new SqlParameter[1];
            parameters[0] = DataLayer.DataAccess.AddParamater("@ProductID", ProductID, System.Data.SqlDbType.Int, 10);
            DataTable dt = DataLayer.DataAccess.ExecuteDTByProcedure("SP_GetProductByID", parameters);
            return dt;
        }




        internal void EditProduct()
        {
            SqlParameter[] parameters = new SqlParameter[6];
            parameters[0] = DataLayer.DataAccess.AddParamater("@ProductID", ProductID, System.Data.SqlDbType.Int, 100);
            parameters[1] = DataLayer.DataAccess.AddParamater("@ProductName", ProductName, System.Data.SqlDbType.VarChar, 300);
            parameters[2] = DataLayer.DataAccess.AddParamater("@ProductPrice", ProductPrice, System.Data.SqlDbType.Int, 100);
            parameters[3] = DataLayer.DataAccess.AddParamater("@ProductDescription", ProductDescription, System.Data.SqlDbType.VarChar, 1000);
            parameters[4] = DataLayer.DataAccess.AddParamater("@ProductQuantity", TotalProducts, System.Data.SqlDbType.Int, 100);
            parameters[5] = DataLayer.DataAccess.AddParamater("@Flag", Flag, System.Data.SqlDbType.Int, 100);

            DataTable dt = DataLayer.DataAccess.ExecuteDTByProcedure("SP_EditProduct", parameters);
        }

        internal DataTable GetHiddenStock()
        {
            SqlParameter[] parameters = new SqlParameter[1];
            parameters[0] = DataLayer.DataAccess.AddParamater("@CategoryID", CategoryID, System.Data.SqlDbType.Int, 10);
            DataTable dt = DataLayer.DataAccess.ExecuteDTByProcedure("SP_GetHiddenStock", parameters);
            return dt;
        }
    }
}