<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SupplierDetails.aspx.cs" Inherits="Santiago_HW3.SupplierDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

  <div class="card" style="text-align:center">

        <asp:Image ID="supplierImage" class="card-img-top" width="400px" Height="400px" runat="server" />

    <div class="card-body">
        <h2 class="card-title">
            <asp:Label ID="company" runat="server" Text="Label"></asp:Label>
        </h2>
        <p class="card-text">
            ID:
           <asp:Label ID="suppID" runat="server" Text="Label"></asp:Label>

            <br />
            <h3>Location:</h3>
            <asp:Label ID="city" runat="server" Text="Label1"></asp:Label>
            <asp:Label ID="state" runat="server" Text="Label"></asp:Label>

            <br />
            <h3>Contact:</h3>
            <asp:Label ID="firstName" runat="server" Text="Label"></asp:Label>
            <asp:Label ID="lastName" runat="server" Text="Label"></asp:Label>

        </p>


    </div>

  

</div>




</asp:Content>
