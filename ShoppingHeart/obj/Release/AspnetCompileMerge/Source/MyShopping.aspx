<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MyShopping.aspx.cs" Inherits="ShoppingHeart.MyShopping" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div style="margin: 100px;">
    <div style=" text-align:center;">
        <asp:ImageButton ID="imgShoppingBag" runat="server" Height="99px" 
            ImageUrl="~/Images/shoppingbag.png" Width="90px" 
            onclick="imgShoppingBag_Click" CausesValidation="false" />
            <br />
    </div>
        <table align="center" style="border: 1px ridge #999999; width: 952px;">
            <tr>
                <td align="center">
                    <asp:Label ID="Label1" runat="server" Font-Names="Aharoni" ForeColor="#0033CC" Text="My  Shopping Details"
                        Style="font-weight: 700"></asp:Label>
                    <hr />
                </td>
            </tr>
            <tr>
                <td align="center">
                    <asp:GridView ID="gvCustomerOrders" runat="server" BackColor="White" BorderColor="White"
                    BorderStyle="Ridge" BorderWidth="2px" CellPadding="3" CellSpacing="1" GridLines="None"
                    Width="100%" AutoGenerateColumns="false">
                    <Columns>
                        <asp:BoundField DataField="OrderNo" HeaderText="OrderNo" ItemStyle-Width="100" />
                        <asp:BoundField DataField="CustomerName" HeaderText="Name" ItemStyle-Width="150" />
                        <asp:BoundField DataField="CustomerPhoneNo" HeaderText="PhoneNo" ItemStyle-Width="20" />
                        <asp:BoundField DataField="TotalProducts" HeaderText="Products" ItemStyle-Width="150" />
                        <asp:BoundField DataField="TotalPrice" HeaderText="Price" ItemStyle-Width="150" />
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# Eval("OrderNo", "~/TrackYourOrder.aspx?Id={0}") %>'
                                    Text="View Details" Target="_blank" />
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
             <tr>
                <td align="center">
                   
                  
                    
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
