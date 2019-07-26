<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="ShoppingHeart.Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div style="margin: 200px;">

    <div style=" text-align:center;">
        <asp:ImageButton ID="imgShoppingBag" runat="server" Height="99px" 
            ImageUrl="~/Images/shoppingbag.png" onclick="imgShoppingBag_Click" 
            Width="90px" CausesValidation="false" />
    </div>
        <table align="center" style="border: 1px ridge #999999; width: 450px;">
            <tr>
                <td align="center" colspan="2">
                    <asp:Label ID="Label1" runat="server" Font-Names="Aharoni" ForeColor="#0033CC" Text="Your Shopping Account"
                        Style="font-weight: 700"></asp:Label>
                    <hr />
                </td>
            </tr>
            <tr>
                <td align="center" style="width: 50%;">
                    Email Id :
                </td>
                <td style="width: 50%;">
                    <asp:TextBox ID="txtLoginId" runat="server" Width="200px"></asp:TextBox>
                     <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtLoginId"
                                                        ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td align="center" style="width: 50%;">
                    Password :
                </td>
                <td style="width: 50%;">
                    <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" Width="200px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtPassword"
                                                        ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>

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
                    <asp:LinkButton ID="btnRegister" runat="server" onclick="btnRegister_Click" 
                        style="font-weight: 700" CausesValidation="false">New User Register Here !!</asp:LinkButton>
                    <br />
                    <asp:Label ID="lblAlert" runat="server" Font-Names="Aharoni" ForeColor="Red"></asp:Label>
                    <br />
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtLoginId"
                                                        ErrorMessage="Please Enter Valid EmailId" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
