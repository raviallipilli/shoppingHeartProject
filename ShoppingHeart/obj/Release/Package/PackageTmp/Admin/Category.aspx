<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMaster.Master" AutoEventWireup="true"
    CodeBehind="Category.aspx.cs" Inherits="ShoppingHeart.Admin.Category" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div align="center">
        <asp:Label ID="lblTitle" runat="server" Style="font-weight: 700">All Categories</asp:Label>
        <hr />
    </div>
    <table align="center" cellspacing="1" style="width: 100%; background-color: #FFFFFF;">
        <tr>
            <td align="center">
              <asp:GridView ID="gvAvailableCategories" runat="server" BackColor="White" 
                    BorderColor="White" BorderStyle="Ridge" BorderWidth="2px" CellPadding="3" 
                    CellSpacing="1" GridLines="None" AutoGenerateColumns="false" 
                    onrowdatabound="gvAvailableCategories_RowDataBound" 
                    onrowdeleting="gvAvailableCategories_RowDeleting">
                     <Columns>
                        <asp:BoundField DataField="CategoryID" HeaderText="CategoryID" ItemStyle-Width="150" />
                        <asp:BoundField DataField="CategoryName" HeaderText="ProductCategory" ItemStyle-Width="50" />
                        <asp:CommandField ShowDeleteButton="True" ButtonType="Button" />
                    </Columns>
                    <FooterStyle BackColor="#C6C3C6" ForeColor="Black" />
                    <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#E7E7FF" />
                    <PagerStyle BackColor="#C6C3C6" ForeColor="Black" HorizontalAlign="Right" />
                    <RowStyle BackColor="#DEDFDE" ForeColor="Black" />
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
