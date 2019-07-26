<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMaster.Master" AutoEventWireup="true"
    CodeBehind="Products.aspx.cs" Inherits="ShoppingHeart.Admin.Products" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div align="center">
        <asp:Label ID="lblTitle" runat="server" Style="font-weight: 700">All Product</asp:Label>
        <hr />
    </div>
    <table align="center" cellspacing="1" style="width: 100%; background-color: #FFFFFF;">
        <tr>
            <td>Select Category :- 
                <asp:DropDownList ID="ddlCategory" runat="server" Width="212px" AutoPostBack="True" OnSelectedIndexChanged="ddlCategory_SelectedIndexChanged">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td align="center">
                <asp:GridView ID="gvAvailableProducts" runat="server" BackColor="White" BorderColor="White"
                    BorderStyle="Ridge" BorderWidth="2px" CellPadding="3" CellSpacing="1" GridLines="None"
                    Width="100%" AutoGenerateColumns="false" OnRowDataBound="gvAvailableProducts_RowDataBound" OnRowDeleting="gvAvailableProducts_RowDeleting">

                    <Columns>
                        <asp:BoundField DataField="ProductID" HeaderText="Product#" ItemStyle-Width="150" />
                        <asp:BoundField DataField="Name" HeaderText="ProductName" ItemStyle-Width="150" />
                        <asp:BoundField DataField="CategoryName" HeaderText="ProductCategory" ItemStyle-Width="50" />
                        <asp:BoundField DataField="AvailableStock" HeaderText="AvailableStock" ItemStyle-Width="150"
                            ItemStyle-Font-Bold="true" ItemStyle-Font-Size="Larger" />
                        <asp:BoundField DataField="Price" HeaderText="Price" ItemStyle-Width="150" />
                        <asp:ImageField DataImageUrlField="ImageUrl" ControlStyle-Width="150" />
                        <asp:CommandField ShowDeleteButton="True" ButtonType="Button" />
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# Eval("ProductID", "~/Admin/EditProduct.aspx?Id={0}") %>'
                                    Text="Edit" />
                            </ItemTemplate>
                        </asp:TemplateField>

                    </Columns>
                    <FooterStyle BackColor="#C6C3C6" ForeColor="Black" />
                    <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#E7E7FF" />
                    <PagerStyle BackColor="#C6C3C6" ForeColor="Black" HorizontalAlign="Center" />
                    <RowStyle BackColor="#DEDFDE" ForeColor="Black" HorizontalAlign="Center" />
                    <SelectedRowStyle BackColor="#9471DE" Font-Bold="True" ForeColor="White" />
                    <SortedAscendingCellStyle BackColor="#F1F1F1" />
                    <SortedAscendingHeaderStyle BackColor="#594B9C" />
                    <SortedDescendingCellStyle BackColor="#CAC9C9" />
                    <SortedDescendingHeaderStyle BackColor="#33276A" />
                </asp:GridView>
            </td>
        </tr>
    </table>
</asp:Content>
