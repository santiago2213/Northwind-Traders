<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Checkout.aspx.cs" Inherits="Santiago_HW3.OrderFolder.Checkout" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">


    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1">
        <Columns>
            <asp:BoundField DataField="ProductID" HeaderText="ProductID" SortExpression="ProductID" />
            <asp:BoundField DataField="QuantityToOrder" HeaderText="Quantity" SortExpression="QuantityToOrder" />
            <asp:BoundField DataField="ProductName" HeaderText="Product Name" SortExpression="ProductName" />
            <asp:BoundField DataField="StandardCost" HeaderText="Price" SortExpression="StandardCost" />
            <asp:BoundField DataField="Subtotal" HeaderText="Subtotal" ReadOnly="True" SortExpression="Subtotal" DataFormatString="{0:c}" />
        </Columns>
    </asp:GridView>

    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" SelectCommand="SELECT [ProductID], [QuantityToOrder], [ProductName], [StandardCost], [Subtotal] FROM [ShoppingCart] WHERE ([CartID] = @CartID)">
        <SelectParameters>
            <asp:CookieParameter CookieName="NWTDbFinalProjSpring2022_CartID" Name="CartID" Type="String" />
        </SelectParameters>
    </asp:SqlDataSource>

    <asp:Button ID="PlaceOrderBtn" runat="server" Text="Place Order" OnClick="PlaceOrderBtn_Click"/>

</asp:Content>
