<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ProductDetails.aspx.cs" Inherits="Santiago_HW3.ProductDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="card">

        <asp:Image ID="ProdImage" class="card-img-top" width="400px" Height="400px" runat="server" />

    <div class="card-body">
        <h2 class="card-title">
            <asp:Label ID="ProductName" runat="server" Text="Label"></asp:Label>
        </h2>
        <p class="card-text">
            Description:
            <asp:Label ID="Description" runat="server" Text="Label"></asp:Label>

            <br />
            Price:
            <asp:Label ID="ListPrice" runat="server" Text="Label" DataFormatting="{0:c}"></asp:Label>

            <br />
            In Stock:
            <asp:Label ID="ProductAvailabelQty" runat="server" Text="Label"></asp:Label>

            <br />
            Target Quantity:
            <asp:Label ID="ProductTargetLevel" runat="server" Text="Label"></asp:Label>

        </p>
        <asp:Button ID="AddToCart" CssClass="btn btn-primary" runat="server" Text="Add to Cart" OnClick="AddToCart_Click" />

    </div>

  

</div>




</asp:Content>
