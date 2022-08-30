<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ShoppingCart.aspx.cs" Inherits="Santiago_HW3.ShoppingCart" %>

    <asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <p>
        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
    </p>
    <p>
        <asp:Label ID="CartStatusLabel" runat="server" ></asp:Label>
    <p>

    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNAmes="ProductID" Width="100%">
        <Columns>
            <asp:BoundField DataField="ProductID" HeaderText="Product ID" ReadOnly="True" />
            <asp:BoundField DataField="ProductName" HeaderText="Product Name" ReadOnly="True" />
            <asp:TemplateField HeaderText="Quantity">
                <ItemTemplate>
                    <asp:TextBox ID="qtyTxtBox" runat="server" Text='<%#Eval("QuantityToOrder").ToString()%>'></asp:TextBox>

             </ItemTemplate>     
            </asp:TemplateField>

            <asp:BoundField DataField="StandardCost" HeaderText="Price" ReadOnly="True"  DataFormatString="{0:c}"/>
            <asp:BoundField DataField="subtotal" HeaderText="SubTotal" ReadOnly="True" DataFormatString ="{0:c}"/>
        </Columns>
    </asp:GridView>


    <p>
        <asp:Label ID="CartTotal" runat="server" Text="Cart Total"></asp:Label>
    </p>

    <asp:Button ID="UpdateCart_btn" runat="server" Text="Update Cart" OnClick="UpdateCart_btn_Click"/> 
    
    <asp:Button ID="CheckoutBtn" runat="server" Text="Checkout" OnClick="CheckoutBtn_Click"/> 

</asp:Content>

