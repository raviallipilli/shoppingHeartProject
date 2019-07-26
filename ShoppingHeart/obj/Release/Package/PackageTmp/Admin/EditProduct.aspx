<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMaster.Master" AutoEventWireup="true" CodeBehind="EditProduct.aspx.cs" Inherits="ShoppingHeart.Admin.EditProduct" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div align="center">
        <asp:Label ID="lblTitle" runat="server" Style="font-weight: 700">Edit Product Details</asp:Label>
        <asp:HiddenField ID="hfProductID" runat="server" />
        <hr />
    </div>
    <table align="center" cellspacing="1" style="width: 100%; background-color: #FFFFFF;">

          <tr>
            <td style="width: 50%; padding-left: 100px;" align="left">Product Thumbnil :
            </td>
            <td style="width: 50%;" align="left">
                <asp:Image ID="imgPreview" runat="server" Height="160px" Width="215px" />
            </td>
        </tr>
        <tr>
            <td style="width: 50%; padding-left: 100px;" align="left">Product Category :
            </td>
            <td style="width: 50%;" align="left">
                <asp:DropDownList ID="ddlCategory" runat="server" Width="212px" Enabled="False">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td style="width: 50%; padding-left: 100px;" align="left">Product Name :
            </td>
            <td style="width: 50%;" align="left">
                <asp:TextBox ID="txtProductName" runat="server" Width="212px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                    ControlToValidate="txtProductName" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
        </tr>

        <tr>
            <td style="width: 50%; padding-left: 100px;" align="left">Product Description :
            </td>
            <td style="width: 50%;" align="left">
                <asp:TextBox ID="txtProductDescription" runat="server" Width="212px" Height="80px"
                    TextMode="MultiLine"></asp:TextBox>
            </td>
        </tr>
       
        <tr>
            <td style="width: 50%; padding-left: 100px;" align="left">Product Price :
            </td>
            <td style="width: 50%;" align="left">
                <asp:TextBox ID="txtProductPrice" runat="server" Width="212px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                    ControlToValidate="txtProductPrice" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
        </tr>
       
        <tr>
               <td style="width: 50%; padding-left: 100px;" align="left">Product  Quantity :
            </td>
            <td style="width: 50%;" align="left">
                <asp:TextBox ID="txtProductQuantity" runat="server" Width="212px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server"
                    ControlToValidate="txtProductQuantity" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td style="width: 50%; padding-left: 100px;" align="left">Show/Hide Product? :
            </td>
            <td style="width: 50%;" align="left">
                <asp:RadioButtonList ID="rbShowHide" runat="server" RepeatDirection="Horizontal">
                    <asp:ListItem Selected="True" Value="1">Show</asp:ListItem>
                    <asp:ListItem Value="0">Hide</asp:ListItem>
                </asp:RadioButtonList>
            </td>
        </tr>
        <tr>
            <td style="width: 50%;" align="right">&nbsp;
            </td>
            <td style="width: 50%;" align="left">
                <asp:Button ID="btnSubmit" runat="server" Text="Update" Width="217px" Height="30px"
                    OnClick="btnSubmit_Click" />
            </td>
        </tr>
    </table>
</asp:Content>
