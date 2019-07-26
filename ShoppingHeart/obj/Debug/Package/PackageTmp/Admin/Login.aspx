<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="ShoppingHeart.Admin.Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <title></title>
    <style type="text/css">
        /*body {
            /*background-color: rgb(32, 4, 74);*/
            /*background-color:WindowFrame;
            background-image: url("Images/bgshop17.jpg")!important;
            background-size: cover;
            background-attachment: fixed;
            background-position: center;
            border-radius:30px;*/
            
        /*}**/
        /*body {
            background-color: lightgoldenrodyellow;
            background-image: url("Images/bgshop17.jpg")!important;
            background-size: cover;
            background-attachment: fixed;
            background-position: center;
        }*/
        body {
            background-image: url("Images/admin1.jpg") !important;
            /*background-image: url("Images/admin3.jpg");*/
            background-color: rgb(112, 10, 10);
        }
        .auto-style1 {
            color: #FFFFFF;
            background-color: #FFFFFF;
        }
        .auto-style2 {
            color: #FFFFFF;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div style="margin: 200px;">
     <div style=" text-align:center;">
        <asp:ImageButton ID="imgShoppingBag" runat="server" Height="99px" 
            ImageUrl="~/Images/shoppingbag.png" Width="90px" CssClass="auto-style1" />
            <br />
    </div>
        <table align="center" style="border: 1px ridge #999999; width: 450px;">
            <tr>
                <td align="center" colspan="2">
                    <asp:Label ID="Label1" runat="server" Font-Names="Aharoni" ForeColor="#0033CC" Text="ShopingCart- AdminPanel"
                        Style="font-weight: 700" CssClass="auto-style1"></asp:Label>
                    <hr />
                    <asp:Label ID="Label2" runat="server" Font-Names="Aharoni" ForeColor="#0033CC" Text="To use the site use login as (admin) & password as (admin) "
                        Style="font-weight: 700" CssClass="auto-style1"></asp:Label>
                <hr />
                </td>
            </tr>
            <tr>
               
                <td align="center" style="width: 50%; color:white;" class="auto-style2">
                    LoginId :
                </td>
                <td style="width: 50%;">
                    <asp:TextBox ID="txtLoginId" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="center" style="width: 50%; color:white;">
                    <%--<span class="auto-style2">Password</span> :--%>
                    Password :
                </td>
                <td style="width: 50%;">
                    <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="center" style="width: 50%;">
                    &nbsp;
                </td>
                <td style="width: 50%;">
                    <asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click" />
                </td>
            </tr>
            <tr>
                <td align="center" colspan="2">
                    <hr />
                    <asp:Label ID="lblAlert" runat="server" Font-Names="Aharoni" ForeColor="Red"></asp:Label>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
