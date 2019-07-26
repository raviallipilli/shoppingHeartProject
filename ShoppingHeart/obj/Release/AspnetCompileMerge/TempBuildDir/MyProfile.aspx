<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MyProfile.aspx.cs" Inherits="ShoppingHeart.MyProfile" %>

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
            ImageUrl="~/Images/shoppingbag.png" Width="90px" 
            onclick="imgShoppingBag_Click" CausesValidation="false" />
            <br />
    </div>
        <table align="center" style="border: 1px ridge #999999; width: 450px;">
            <tr>
                <td align="center" colspan="2">
                    <asp:Label ID="Label1" runat="server" Font-Names="Aharoni" ForeColor="#0033CC" Text="My Profile"
                        Style="font-weight: 700"></asp:Label>
                    <hr />
                </td>
            </tr>
            <tr>
                <td align="center" style="width: 50%;">
                    Name :
                </td>
                <td style="width: 50%;"> 
                    <asp:TextBox ID="txtName" runat="server" Width="200px" MaxLength="20" Enabled="false"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtName"
                                                        ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
            </tr>
        
            <tr>
                <td align="center" style="width: 50%;">
                    &nbsp;
                    Phone No</td>
                <td style="width: 50%;">
                    <asp:TextBox ID="txtPhoneNo" runat="server"   Width="200px" MaxLength="10"></asp:TextBox>
                     <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtPhoneNo"
                                                        ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td align="center" style="width: 50%;">
                    Address
                </td>
                <td style="width: 50%;">
                    <asp:TextBox ID="txtAddress" runat="server"  Width="200px" MaxLength="200"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtAddress"
                                                        ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
            </tr>
                <tr>
                <td align="center" style="width: 50%;">
                    Email ID :
                </td>
                <td style="width: 50%;">
                    <asp:TextBox ID="txtEmailID" runat="server"  Width="200px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtEmailID"
                                                        ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td align="center" style="width: 50%;">
                    Password</td>
                <td style="width: 50%;">
                    <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"  Width="200px" MaxLength="20"></asp:TextBox>
                     <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtPassword"
                                                        ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td align="center" style="width: 50%;">
                    &nbsp;</td>
                <td style="width: 50%;">
                    &nbsp;</td>
            </tr>
            <tr>
                <td align="center" style="width: 50%;">
                    &nbsp;</td>
                <td style="width: 50%;">
                    <asp:Button ID="btnSave" runat="server" Text="Update Profile Info" 
                        Width="200px" onclick="btnSave_Click" style="font-weight: 700" 
                         />
                </td>
            </tr>
            <tr>
                <td align="center" colspan="2">
                    <hr />
                      <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtEmailID"
                                                        ErrorMessage="Please Enter Valid EmailId" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                    <br />
                    <asp:Label ID="lblAlert" runat="server" Font-Names="Aharoni" ForeColor="Red"></asp:Label>
                </td>
            </tr>
             <tr>
                <td align="center" colspan="2">
                   
                  
                    
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>